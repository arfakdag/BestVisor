using BestVisor.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestVisor.Models
{
    public class Algorithm
    {
        int kNN;
        int totalTrainset;
        List<Musteriler> trainset;
        Musteriler customerset;
        public List<Musteriler> nCustomer = new List<Musteriler>();

        Distance[] distances;

        int maxAge = 0;
        int maxCardLimit = 0;
        int maxShopFreq = 0;
        int maxEcommorce = 0;
        int maxVCSF = 0;
        int maxLoan = 0;
        int maxTotalPrice = 0;
        int maxIstallment = 0;
        int response;


        public Algorithm(int k, List<Musteriler> train, Musteriler customer)
        {
            this.kNN = k;//k neighbor

            this.trainset = train;//trainset
            this.customerset = customer;//customer
            this.totalTrainset = train.Count;//total of customer

            distances = new Distance[this.totalTrainset];

            maxAge = train.Max(x => x.Age.Value);
            maxCardLimit = train.Max(x => x.CardLimit.Value);
            maxShopFreq = train.Max(x => x.ShopFrequence.Value);
            maxVCSF = train.Max(x => x.VirtualCardSf.Value);
            maxLoan = train.Max(x => x.LoanDebt.Value);
            maxTotalPrice = train.Max(x => x.TotalPrice.Value);
            maxIstallment = train.Max(x => x.Installments.Value);
        }

        public void setResponse(Musteriler cus)
        {
            for (int i = 0; i < this.totalTrainset; i++)
            {
                distances[i] = new Distance();
                distances[i].distance = 0;
                distances[i].index = i;
                distances[i].sId = trainset[i].CustomerId.ToString();

                distances[i].distance = (float)Math.Sqrt(Math.Pow(cus.Age.Value - trainset[i].Age.Value, 2) + Math.Pow(cus.CardLimit.Value - trainset[i].CardLimit.Value, 2) + Math.Pow(cus.ShopFrequence.Value - trainset[i].ShopFrequence.Value, 2) + Math.Pow(cus.VirtualCardSf.Value - trainset[i].VirtualCardSf.Value, 2) + Math.Pow(cus.LoanDebt.Value - trainset[i].LoanDebt.Value, 2) + Math.Pow(cus.TotalPrice.Value - trainset[i].TotalPrice.Value, 2) + Math.Pow(cus.Installments.Value - trainset[i].Installments.Value, 2));
            }

            List<int> Ids = distances.Where(t=> t.sId != cus.CustomerId.ToString()).OrderBy(x => x.distance).Take(3).Select(x=> x.index).ToList();
            foreach (var item in Ids)
            {
                nCustomer.Add(trainset.ToArray()[item]);
            }
        }

        public float getDistance(float a, float b)
        {
            return (a - b) * (a - b);
        }

        public void runkNN()
        {
            for (int i = 0; i < 1; i++)
            {
                setResponse(this.customerset);
            }
        }
    }
}
