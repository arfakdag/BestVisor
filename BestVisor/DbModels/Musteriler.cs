using System;
using System.Collections.Generic;

namespace BestVisor.DbModels
{
    public partial class Musteriler
    {
        public int CustomerId { get; set; }
        public bool? GenderFemale { get; set; }
        public int? Age { get; set; }
        public int? CardLimit { get; set; }
        public int? ShopFrequence { get; set; }
        public bool? VirtualCard { get; set; }
        public bool? Ecommerce { get; set; }
        public int? VirtualCardSf { get; set; }
        public int? LoanDebt { get; set; }
        public int? TotalPrice { get; set; }
        public int? Installments { get; set; }
        public int? MerchantId { get; set; }
        public int? Campaign { get; set; }
        public int Id { get; set; }
    }
}
