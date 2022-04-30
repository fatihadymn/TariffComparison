using AutoMapper;
using TariffComparison.Items.Entities;
using TariffComparison.Items.Models.Response;

namespace TariffComparison.Items.Mappers
{
    public class TariffProfile : Profile
    {
        public TariffProfile()
        {
            CreateMap<Tariff, TariffDto>().AfterMap((src, dest) =>
            {
                dest.TariffName = $"{src.Name} Tariff";
            });
        }
    }
}
