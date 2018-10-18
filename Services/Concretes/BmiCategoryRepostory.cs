using Domain;
using RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryServices.Concretes
{
    public class BmiCategoryRepostory : AbstractRepository<BmiCategory>
    {
        public override bool Delete(BmiCategory toDelete)
        {
            try
            {
                var act = SiteKitDbContext.BmiCategories.SingleOrDefault(p => p.BmiCategoryId == toDelete.BmiCategoryId);
                SiteKitDbContext.BmiCategories.Remove(act);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override BmiCategory GetById(int id)
        {
            return SiteKitDbContext.BmiCategories.FirstOrDefault(p => p.BmiCategoryId == id);
        }

        public override bool Update(BmiCategory toUpdate)
        {
            try
            {
                var act = SiteKitDbContext.BmiCategories.SingleOrDefault(p => p.BmiCategoryId == toUpdate.BmiCategoryId);
                act.Category = toUpdate.Category;
                act.BmiRange = toUpdate.BmiRange;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
