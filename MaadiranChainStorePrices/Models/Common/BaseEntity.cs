using System;

namespace MaadiranChainStorePrices.Models.Common
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.UtcNow;
        }
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? Creator { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
