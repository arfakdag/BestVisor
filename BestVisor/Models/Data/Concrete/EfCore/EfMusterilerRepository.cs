using BestVisor.DbModels;
using BestVisor.Models.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestVisor.Models.Data.Concrete.EfCore
{
    public class EfMusterilerRepository : IMusterilerRepository
    {
        private bestvisorContext context;
        public EfMusterilerRepository(bestvisorContext _context)
        {
            context = _context;
        }
        public IQueryable<Musteriler> Listele()
        {
           return context.Musteriler;
        }
        
    }
}