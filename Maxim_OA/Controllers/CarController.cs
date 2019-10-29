using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Maxim_OA.Repo;
using Maxim_OA.Data;

namespace Maxim_OA.Controllers
{
    public class CarController : ApiController
    {
        CarRepo carRepository;
        public CarController()
        {
            carRepository = new CarRepo();
        }

        [Route("BuildDB")]
        public IHttpActionResult GetBuildDB() {
            carRepository.buildDatabase();
            return Ok();
        }

        [Route("NewestCars")]
        public IEnumerable<Car> GetNewestCars()
        {
            int _year = carRepository.GetAll().Max(x => x.year);
            return carRepository.GetByCondition(z => z.year == _year);
        }

        [Route("CarsByAlphabetized")]
        public IEnumerable<Car> GetCarsByAlphabetized()
        {
            return carRepository.GetAll().OrderBy(z => z.make);
        }

        [Route("CarsByPrice")]
        public IEnumerable<Car> GetCarsByPrice()
        {
            return carRepository.GetAll().OrderBy(x => x.price);
        }

        [Route("BestValue")]
        public IEnumerable<Car> GetByBestValue()
        {
            double rating = carRepository.GetAll().Max(x => x.TCC_Rating);
            return carRepository.GetByCondition(x => x.TCC_Rating == rating);
        }

        [Route("FuelConsumption")]
        public double GetFuelConsumption(int id, double miles)
        {
            double mpg = carRepository.GetByCondition(x => x.id == id).FirstOrDefault().Hwy_MPG;
            return miles / mpg;
        }

        [Route("Random")]
        public Car GetRandom()
        {
            Random rmd = new Random();
            int id = rmd.Next(carRepository.GetAll().Count());
            return carRepository.GetByCondition(x => x.id == id).FirstOrDefault();
        }

        [Route("AvgMpgByYear")]
        public double GetAvgMpgByYear(int year)
        {
            return carRepository.GetByCondition(x => x.year == year).Select(x => x.Hwy_MPG).Average();
        }
    }
}
