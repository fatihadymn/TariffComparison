using System.Collections.Generic;
using System.Threading.Tasks;
using TariffComparison.Items.Models.Response;
using TariffComparison.Items.Queries;

namespace TariffComparison.Core.Services
{
    public interface ITariffService : IServiceBase
    {
        Task<List<TariffDto>> GetTariffs(GetTariffsRequest query);
    }
}
