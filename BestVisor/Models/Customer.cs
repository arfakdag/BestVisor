using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestVisor.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public bool Sex { get; set; }
        public int Age { get; set; }
        public int CardLimit { get; set; }
        public int ShopFreq { get; set; }
        public bool VirtualCard { get; set; }
        public int Ecommerce { get; set; }
        public int VirtualCardShopFrequence { get; set; }
        public int Loan { get; set; }
        public int TotalPrice { get; set; }
        public int Installments { get; set; }
        public int MerchantId { get; set; }
        public int CampaignId { get; set; }
        public int response { get; set; }

        public void setResponse(int res)
        {
            this.response = res;
        }

        public int getResponse()
        {
            return this.response;
        }
    }
}
