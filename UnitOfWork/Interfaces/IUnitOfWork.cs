using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
