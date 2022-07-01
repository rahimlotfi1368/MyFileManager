﻿using MaadiranChainStorePrices.Models.Common;

namespace MaadiranChainStorePrices.Models.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PersonelCode { get; set; }
    }
}
