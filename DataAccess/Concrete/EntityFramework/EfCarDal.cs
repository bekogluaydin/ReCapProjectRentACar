using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cars in context.Cars
                             join color in context.Colors on cars.ColorId equals color.Id
                             join brand in context.Brands on cars.BrandId equals brand.Id
                             select new CarDetailDto
                             {
                                 Id = cars.Id, BrandName =brand.Name, ColorName =color.Name, 
                                 Description= cars.Description, DailyPrice = cars.DailyPrice
                             };
                return result.ToList();
            }          
        }
    }
}
