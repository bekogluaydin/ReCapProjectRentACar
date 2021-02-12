using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2002, DailyPrice=300, Description="Dizel Beyaz Astra"},
                new Car{Id=2, BrandId=2, ColorId=1, ModelYear=2020, DailyPrice=1500, Description="Honda Civic Beyaz Renkli"},
                new Car{Id=3, BrandId=3, ColorId=2, ModelYear=2015, DailyPrice=800, Description="Kırmızı Renkli Benzinli Pego 307"},
                new Car{Id=3, BrandId=2,ColorId=2, ModelYear=2010, DailyPrice=600, Description="Honda Civic Kırmızı Renkli"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetByID(int Id)
        {
            return _cars.SingleOrDefault(p => p.Id == Id);
        }

        public List<Car> GettAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
