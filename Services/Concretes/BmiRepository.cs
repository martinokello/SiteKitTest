using Domain;
using RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryServices.Concretes
{
    public class BmiRepository:AbstractRepository<Bmi>
    {
        public override bool Delete(Bmi toDelete)
        {
            try
            {
                var act = SiteKitDbContext.Bmis.SingleOrDefault(p => p.BmiId == toDelete.BmiId);
                SiteKitDbContext.Bmis.Remove(act);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Bmi GetById(int id)
        {
            return SiteKitDbContext.Bmis.FirstOrDefault(p => p.BmiId == id);
        }

        public override bool Update(Bmi toUpdate)
        {
            try
            {
                var act = SiteKitDbContext.Bmis.SingleOrDefault(p => p.BmiId == toUpdate.BmiId);
                act.Patient = toUpdate.Patient;
                act.PatientId = toUpdate.PatientId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
