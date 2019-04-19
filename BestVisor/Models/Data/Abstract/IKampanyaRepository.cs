using BestVisor.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestVisor.Models.Data.Abstract
{
    public interface IKampanyaRepository
    {
        IQueryable<Kampanya> Listele();
        void Kayit(Kampanya ent);
    }
    
}
