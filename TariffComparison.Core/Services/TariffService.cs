using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffComparison.Data;
using TariffComparison.Items.Entities;
using TariffComparison.Items.Exceptions;
using TariffComparison.Items.Models.Enum;
using TariffComparison.Items.Models.Response;
using TariffComparison.Items.Queries;

namespace TariffComparison.Core.Services
{
    public class TariffService : ServiceBase, ITariffService
    {
        private readonly ApplicationContext _dbContext;

        private readonly ILogger<TariffService> _logger;

        private readonly IMapper _mapper;

        public TariffService(ApplicationContext dbContext, ILogger<TariffService> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<TariffDto>> GetTariffs(GetTariffsRequest query)
        {
            var result = new List<TariffDto>();

            var existTariffs = await _dbContext.Tariffs.Where(x => x.IsActive).ToListAsync();

            foreach (var item in existTariffs)
            {
                var tariff = _mapper.Map<TariffDto>(item);

                switch (item.Name)
                {
                    case TariffName.Basic:
                        tariff.AnnualCosts = BasicAnnualCost(item, query.Consumption);
                        break;

                    case TariffName.Packaged:
                        tariff.AnnualCosts = PackagedAnnualCost(item, query.Consumption);
                        break;

                    default:
                        throw new BusinessException($"Tariff type is not supported. Tariff Type : {item.Name.ToString()}");
                }

                result.Add(tariff);
            }

            _logger.LogInformation("Tariffs calculated");

            return result.OrderBy(x => x.AnnualCosts).ToList();
        }

        private decimal BasicAnnualCost(Tariff tariff, decimal consumption) =>
            (tariff.BaseCost * 12m) + (tariff.ExtraCost * consumption);

        private decimal PackagedAnnualCost(Tariff tariff, decimal consumption)
        {
            var annualCost = tariff.BaseCost;

            if (consumption > tariff.BaseLimit)
            {
                annualCost += (consumption - tariff.BaseLimit.Value) * tariff.ExtraCost;
            }

            return annualCost;
        }
    }
}
