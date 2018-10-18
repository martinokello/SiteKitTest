using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteKitBMISystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SiteKitBMISystem.Tests
{
    [TestClass]
    public class PatientsBmiTest
    {
        private IList<Patient> _patients;
        private IList<Bmi> _bmis;
        private IList<BmiCategory> _bmiCategories;

        [TestInitialize]
        public void Setup()
        {
            _bmiCategories = new List<BmiCategory>();

            var bmiRange1 = new BmiCategory { Category = "UnderWeight", BmiRange = "Below 18.5" };
            var bmiRange2 = new BmiCategory { Category = "Normal Weight", BmiRange = "18.5 - 24.9" };
            var bmiRange3 = new BmiCategory { Category = "Pre-Obesity", BmiRange = "25.0 - 29.9" };
            var bmiRange4 = new BmiCategory { Category = "Obesity Class 1", BmiRange = "30.0 - 34.9" };

            _bmiCategories.Add(bmiRange1);
            _bmiCategories.Add(bmiRange2);
            _bmiCategories.Add(bmiRange2);
            _bmiCategories.Add(bmiRange4);
            _patients = new List<Patient>();

            var patient = new Patient {PatientId =1, PatientName = "Joanne Okello", BmiCategoryId = 3, BmiCategory = bmiRange3 };
            var patient2 = new Patient { PatientId = 2, PatientName = "Leon Okello", BmiCategoryId = 2, BmiCategory = bmiRange2 };
            var patient3 = new Patient { PatientId = 3, PatientName = "Savannah Okello", BmiCategoryId = 2, BmiCategory = bmiRange2 };
            var patient4 = new Patient { PatientId = 4, PatientName = "Martin Okello", BmiCategoryId = 3, BmiCategory = bmiRange3 };

            _patients.Add(patient);
            _patients.Add(patient2);
            _patients.Add(patient3);
            _patients.Add(patient4);


            _bmis = new List<Bmi>();
            var bmi1 = new Bmi { PatientId = 1, PatientBmi = 26 };
            var bmi2 = new Bmi { PatientId = 2, PatientBmi = 19 };
            var bmi3 = new Bmi { PatientId = 3, PatientBmi = 19 };
            var bmi4 = new Bmi { PatientId = 4, PatientBmi = 26 };

            _bmis.Add(bmi1);
            _bmis.Add(bmi2);
            _bmis.Add(bmi3);
            _bmis.Add(bmi4);
        }
        
        [TestMethod]
        public void Test_GetBmiCategoryPatientCount_Has_Correct_NumberOf_Rows_2()
        {
            var controller = new HomeController();
            var result = controller.GetBmiCategoryPatientCount(_patients.AsQueryable());
            Assert.AreEqual(result.Count(), 2);
        }
        [TestMethod]
        public void Test_GetBmiCategoryPatientCount_Has_Values_2_NormalWeight_2_PreObesity()
        {
            var controller = new HomeController();
            var result = controller.GetBmiCategoryPatientCount(_patients.AsQueryable());

            var normalWeight = result.Where(p => p.BmiCategory.Equals("Normal Weight")).FirstOrDefault();
            var preObesity = result.Where(p => p.BmiCategory.Equals("Pre-Obesity")).FirstOrDefault();
            Assert.AreEqual(2, normalWeight.PatientCount);
            Assert.AreEqual(2, preObesity.PatientCount);
        }
        [TestMethod]
        public void Test_GetBmiCategoryPatientCount_Has_Correct_NumberOf_Rows_3()
        {
            var bmiRange5 = new BmiCategory { Category = "Obesity Class 1", BmiRange = "30.0 - 34.9" };
            var patient5 = new Patient { PatientId = 5, PatientName = "Pamella Okello", BmiCategoryId = 4, BmiCategory = bmiRange5 };
            _patients.Add(patient5);
            var controller = new HomeController();
            var result = controller.GetBmiCategoryPatientCount(_patients.AsQueryable());
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        public void Test_GetBmiCategoryPatientCount_Has_Values_2_NormalWeight_2_PreObesity_1_ObesityClass1()
        {
            var bmiRange5 = new BmiCategory { Category = "Obesity Class 1", BmiRange = "30.0 - 34.9" };
            var patient5 = new Patient { PatientId = 5, PatientName = "Pamella Okello", BmiCategoryId = 4, BmiCategory = bmiRange5 };
            _patients.Add(patient5);
            var controller = new HomeController();
            var result = controller.GetBmiCategoryPatientCount(_patients.AsQueryable());
            var normalWeight = result.Where(p => p.BmiCategory.Equals("Normal Weight")).FirstOrDefault();
            var preObesity = result.Where(p => p.BmiCategory.Equals("Pre-Obesity")).FirstOrDefault();
            var obesity = result.Where(p => p.BmiCategory.Equals("Obesity Class 1")).FirstOrDefault();
            Assert.AreEqual(2, normalWeight.PatientCount);
            Assert.AreEqual(2, preObesity.PatientCount);
            Assert.AreEqual(1, obesity.PatientCount);
        }
    }
}
