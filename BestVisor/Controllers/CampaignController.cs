using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestVisor.DbModels;
using BestVisor.Models;
using BestVisor.Models.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BestVisor.Controllers
{
    public class CampaignController : Controller
    {

        int k = 0;

        List<Musteriler> lCustomer = new List<Musteriler>();
        Musteriler uCustomer = new Musteriler();

        private IKampanyaRepository kampanyaRepository;
        private ISektorlerRepository sektorlerRepository;
        private IMusterilerRepository musterilerRepository;
        public CampaignController(IKampanyaRepository _kampanyaRepository, IMusterilerRepository _musterilerRepository, ISektorlerRepository _sektorlerRepository)
        {
            kampanyaRepository = _kampanyaRepository;
            musterilerRepository = _musterilerRepository;
            sektorlerRepository = _sektorlerRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var musteriSayisi = musterilerRepository.Listele().Count();
            ViewBag.MusteriSayisi = musteriSayisi;
            var qry = kampanyaRepository.Listele();
            ViewBag.Kampanyalar = qry;
            ViewBag.Data = sektorlerRepository.Listele().ToList();
            return View(qry);
        }
        [HttpPost]
        public List<int> Index(string sId)
        {
            List<Musteriler> obj = new List<Musteriler>();
            lCustomer = musterilerRepository.Listele().ToList();
            uCustomer = lCustomer.Where(x => x.CustomerId.ToString() == sId).First();

            obj = Cotrol();

            return obj.Select(x => x.Campaign.Value).ToList();
        }

        private List<Musteriler> Cotrol()
        {
            List<Customer> temp = new List<Customer>();
            k = 3;

            Algorithm alg = new Algorithm(k, lCustomer, uCustomer);
            alg.runkNN();

            return alg.nCustomer;
        }

        [HttpPost]
        public List<DataForChart> GetData(int skip)
        {
            DateTime t = DateTime.Now;
            List<DataForChart> data = new List<DataForChart>();
            var obj = musterilerRepository.Listele().Skip(skip).Distinct().Take(12);
            int k = -1;
            Random rnd = new Random();
            foreach (var item in obj)
            {
                DataForChart yeni = new DataForChart();
                yeni.year = t.AddMonths(k).Month;
                yeni.income = item.TotalPrice.Value;
                int index = yeni.income / rnd.Next(1, 10);
                yeni.expenses = rnd.Next(index, index + rnd.Next(0, 250));
                data.Add(yeni);
                --k;
            }

            return data;
        }

        public List<Pie> GetDataForPie()
        {
            List<Pie> temp = new List<Pie>();

            var sek = sektorlerRepository.Listele();
            var obj = musterilerRepository.Listele();

            foreach (var item in sek)
            {
                Pie pie = new Pie();
                pie.id = obj.Where(x => x.MerchantId == item.Id).Count();
                pie.text = item.SectorName;
                temp.Add(pie);
            }

            return temp;
        }

        [HttpPost]
        public bool Kayit(string title, string desc, string sanal, string et, int yas, string[] sektorID)
        {
            var ent = new Kampanya();
            ent.CampaignName = title;
            ent.CampaignDesc = desc;
            ent.CampaignSms = desc;
            var str = string.Join(',', sektorID);
            ent.SektorList = str;
            ent.Id = kampanyaRepository.Listele().Max(x => x.Id) + 1;
            if (ModelState.IsValid)
            {
                bestvisorContext t = new bestvisorContext();
                t.Add(ent);
                t.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public int CheckCustomers(string title, string desc, string sanal, string et, int yas, string[] sektorID)
        {
            int count = 0;
            if (yas > 45)
            {
                count = musterilerRepository.Listele().Where(x => x.Age > 45 && x.Ecommerce == (et == "on" ? true : false) && x.VirtualCard == (sanal == "on" ? true : false)).Count();
            }
            else if (yas > 25)
            {
                count = musterilerRepository.Listele().Where(x => x.Age > 25 && x.Age < 45 && x.Ecommerce == (et == "on" ? true : false) && x.VirtualCard == (sanal == "on" ? true : false)).Count();
            }
            else
            {
                count = musterilerRepository.Listele().Where(x => x.Age > 18 && x.Age < 25 && x.Ecommerce == (et == "on" ? true : false) && x.VirtualCard == (sanal == "on" ? true : false)).Count();
            }
            return count;
        }
    }
}