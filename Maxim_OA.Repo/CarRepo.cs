using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maxim_OA.Data;

namespace Maxim_OA.Repo
{
    public class CarRepo
    {
        NewDbContext db = new NewDbContext();

        List<Car> carCollection = new List<Car> {
            new Car() { id=1, make = "Honda", model = "CRV", color = "Green", year = 2016, price = 23845, TCC_Rating = 8, Hwy_MPG = 33 },
            new Car() { id=2, make = "Ford", model = "Escape", color = "Red", year = 2017, price = 23590, TCC_Rating = 7.8, Hwy_MPG = 32 },
            new Car() { id=3, make = "Hyundai", model = "Sante Fe", color = "Grey", year = 2016, price = 24950, TCC_Rating = 8, Hwy_MPG = 27 },
            new Car() { id=4, make = "Mazda", model = "CX-5", color = "Red", year = 2017, price = 21795, TCC_Rating = 8, Hwy_MPG = 35 },
            new Car() { id=5, make = "Subaru", model = "Forester", color = "Blue", year = 2016, price = 22395, TCC_Rating = 8.4, Hwy_MPG = 32 }
        };

        public void buildDatabase() {
            foreach (Car item in carCollection)
            {
                db.Cars.Add(item);
            }
            db.SaveChanges();
        }
        

        public IEnumerable<Car> GetAll()
        {
            return db.Cars.ToList();
        }

        public IEnumerable<Car> GetByCondition(Predicate<Car> del)
        {
            List<Car> carCollection = db.Cars.ToList();
            List<Car> lstCars = new List<Car>();
            foreach (Car item in carCollection)
            {
                if (del(item))
                {
                    lstCars.Add(item);
                }
            }
            return lstCars;
        }
    }
}
