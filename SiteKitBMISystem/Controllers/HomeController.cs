using Domain;
using RepositoryServices.Concretes;
using SiteKitBMISystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.Concretes;
using UnitOfWork.Interfaces;

namespace SiteKitBMISystem.Controllers
{
    public class HomeController : Controller
    {
        private SiteKitUnitOfWork _unitOfWork;
        public HomeController()
        {
            //Dependencies can be injected via Dependency Ioc Containers which I normally use Unity
            //However I have covered so much and no time to couple dependency containers.
            var siteKitUnitOfWork = new SiteKitUnitOfWork(new BmiCategoryRepostory(), new BmiRepository(), new PatientRepository());
            _unitOfWork = siteKitUnitOfWork as SiteKitUnitOfWork;
        }
        public ActionResult Index()
        {
            if(_unitOfWork != null)
            {
                var result = GetBmiCategoryPatientCount(_unitOfWork._patientRepository.GetAll());
                ViewBag.BmiCategoryPatientCount = result;
            }
            return View();
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public BmiCategoryPatientCountViewModel[] GetBmiCategoryPatientCount(IQueryable<Patient> patients)
        {
            var result = from p in patients
                         group p by p.BmiCategory into grp
                         select new BmiCategoryPatientCountViewModel { BmiCategory = grp.Key.Category, PatientCount=grp.Count() };
            
            return result.ToArray();
        }
    }
}