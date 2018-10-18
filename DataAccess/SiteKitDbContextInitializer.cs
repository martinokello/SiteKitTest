using Domain;
using System.Data.Entity;

namespace DataAccess
{
    public class SiteKitDbContextInitializer : CreateDatabaseIfNotExists<SiteKitDbContext>
    {
        protected override void Seed(SiteKitDbContext context)
        {
            base.Seed(context);
            var bmiRange1 = new BmiCategory { Category="UnderWeight", BmiRange="Below 18.5"};
            var bmiRange2 = new BmiCategory { Category = "Normal Weight", BmiRange = "18.5 - 24.9" };
            var bmiRange3 = new BmiCategory { Category = "Pre-Obesity", BmiRange = "25.0 - 29.9" };
            var bmiRange4 = new BmiCategory { Category = "Obesity Class 1", BmiRange = "30.0 - 34.9" };

            context.BmiCategories.Add(bmiRange1);
            context.BmiCategories.Add(bmiRange2);
            context.BmiCategories.Add(bmiRange3);
            context.BmiCategories.Add(bmiRange4);

            context.SaveChanges();
            var patient = new Patient { PatientName = "Joanne Okello", BmiCategoryId = 3,  BmiCategory=bmiRange3};
            var patient2 = new Patient { PatientName = "Leon Okello", BmiCategoryId = 2,  BmiCategory = bmiRange2 };
            var patient3 = new Patient { PatientName = "Savannah Okello", BmiCategoryId = 2,  BmiCategory = bmiRange2 };
            var patient4 = new Patient { PatientName = "Martin Okello", BmiCategoryId = 3, BmiCategory = bmiRange3 };

            context.Patients.Add(patient);
            context.Patients.Add(patient2);
            context.Patients.Add(patient3);
            context.Patients.Add(patient4);

            context.SaveChanges();

            var bmi1 = new Bmi { PatientId = 1, PatientBmi = 26 };
            var bmi2 = new Bmi { PatientId = 2, PatientBmi = 19 };
            var bmi3 = new Bmi { PatientId = 3, PatientBmi = 19 };
            var bmi4 = new Bmi { PatientId = 4, PatientBmi = 26 };

            context.Bmis.Add(bmi1);
            context.Bmis.Add(bmi2);
            context.Bmis.Add(bmi3);
            context.Bmis.Add(bmi4);

            context.SaveChanges();
        }
    }
}