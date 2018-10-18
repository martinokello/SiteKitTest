using DataAccess;
using Domain;
using RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Interfaces;

namespace UnitOfWork.Concretes
{
    public class SiteKitUnitOfWork : IUnitOfWork
    {
        public AbstractRepository<BmiCategory> _bmiCategoryRepository { get; set; }
        public AbstractRepository<Bmi> _bmiRepository { get; set; }
        public AbstractRepository<Patient> _patientRepository { get; set; }
        public SiteKitUnitOfWork(AbstractRepository<BmiCategory> bmiCategoryRepository, AbstractRepository<Bmi> bmiRepository, AbstractRepository<Patient> patientRepository)
        {
            SiteKitDbContext = new SiteKitDbContext();
            _bmiCategoryRepository = bmiCategoryRepository;
            _bmiCategoryRepository.SiteKitDbContext = SiteKitDbContext;

            _bmiRepository = bmiRepository;
            _bmiRepository.SiteKitDbContext = SiteKitDbContext;

            _patientRepository = patientRepository;
            _patientRepository.SiteKitDbContext = SiteKitDbContext;

        }
        public SiteKitDbContext SiteKitDbContext { get; set; }
        public void SaveChanges()
        {
            SiteKitDbContext.SaveChanges();
        }
    }
}
