using Domain;
using RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryServices.Concretes
{
    public class PatientRepository:AbstractRepository<Patient>
    {
        public override bool Delete(Patient toDelete)
        {
            try
            {
                var act= SiteKitDbContext.Patients.SingleOrDefault(p => p.PatientId == toDelete.PatientId);
                SiteKitDbContext.Patients.Remove(act);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Patient GetById(int id)
        {
            return SiteKitDbContext.Patients.FirstOrDefault(p => p.PatientId == id);
        }

        public override bool Update(Patient toUpdate)
        {
            try
            {
                var act = SiteKitDbContext.Patients.SingleOrDefault(p => p.PatientId == toUpdate.PatientId);
                act.PatientName = toUpdate.PatientName;
                act.BmiCategory = toUpdate.BmiCategory;
                act.BmiCategoryId = toUpdate.BmiCategoryId;
                act.Weight = toUpdate.Weight;
                act.Height = toUpdate.Height;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
