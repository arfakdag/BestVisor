using BestVisor.DbModels;
using BestVisor.Models.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestVisor.Models.Data.Concrete.EfCore
{
    public class EfSektorlerRepository : ISektorlerRepository
    {
        private bestvisorContext context;
        public EfSektorlerRepository(bestvisorContext _context)
        {
            context = _context;
        }
        public IQueryable<Sektorler> Listele()
        {
            return context.Sektorler;
        }
        
    }
}