using BestVisor.DbModels;
using BestVisor.Models.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestVisor.Models.Data.Concrete.EfCore
{
    public class EfKampanyaRepository : IKampanyaRepository
    {
        private bestvisorContext context;
        public EfKampanyaRepository(bestvisorContext _context)
        {
            context = _context;
        }
        public IQueryable<Kampanya> Listele()
        {
           return context.Kampanya;
        }

        public void Kayit(Kampanya ent)
        {
            context.Kampanya.Add(ent);
            context.SaveChanges();
        }
    }
}