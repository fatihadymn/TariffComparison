using TariffComparison.Items.Models.Enum;

namespace TariffComparison.Items.Entities
{
    public class Tariff : BaseEntity
    {
        public TariffName Name { get; set; }

        public decimal BaseCost { get; set; }

        public decimal ExtraCost { get; set; }

        public decimal? BaseLimit { get; set; }
    }
}
