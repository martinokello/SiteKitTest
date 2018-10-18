using DataAccess;
using RepositoryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryServices.Abstracts
{
    public abstract class AbstractRepository<T>:IRepository<T> where T : class
    {
        public SiteKitDbContext SiteKitDbContext { get; set; }
        public abstract bool Delete(T toDelete);

        public IQueryable<T> GetAll()
        {
            return SiteKitDbContext.Set<T>().AsQueryable<T>();
        }

        public abstract T GetById(int id);

        public bool Insert(T toInsert)
        {
            try
            {
                SiteKitDbContext.Set<T>().Add(toInsert);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public abstract bool Update(T toUpdate);
    }
}
