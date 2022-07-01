using MaadiranChainStorePrices.Models.Common;

namespace MaadiranChainStorePrices.Models.Entities
{
    public class Brand:BaseEntity
    {
        public string BrandName { get; set; }
        public string LogoName { get; set; }
        public string KatalogName { get; set; }
    }
}
