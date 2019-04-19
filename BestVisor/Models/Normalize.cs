using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestVisor.Models
{
    public class Normalize
    {
        public float Age = 0;
        public float CardLimit = 0;
        public float ShopFreq = 0;
        public float Ecommorce = 0;
        public float VCSF = 0;
        public float Loan = 0;
        public float TotalPrice = 0;
        public float Istallment = 0;

        public Normalize(Customer cus, int maxAge, int maxCardLimit, int maxShopFreq, int maxEcommorce, int maxVCSF, int maxLoan, int maxTotalPrice, int maxIstallment)
        {
            Age = (float)cus.Age / (float)maxAge;
            CardLimit = (float)cus.CardLimit / (float)maxCardLimit;
            ShopFreq = (float)cus.ShopFreq / (float)maxShopFreq;
            Ecommorce = (float)cus.Ecommerce / (float)maxEcommorce;
            VCSF = (float)cus.VirtualCardShopFrequence / (float)maxVCSF;
            Loan = (float)cus.Loan / (float)maxLoan;
            TotalPrice = (float)cus.TotalPrice / (float)maxTotalPrice;
            Istallment = (float)cus.Installments / (float)maxIstallment;
        }
    }
}
