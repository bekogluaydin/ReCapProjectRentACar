using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 90, Description = "volkswagen polo", ModelYear = 2016 });
            //carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 120, Description = "ford focus", ModelYear = 2018 });
            //carManager.Add(new Car { BrandId = 2, ColorId = 3, DailyPrice = 50, Description = "toyota yaris", ModelYear = 2017 });
            //carManager.Add(new Car { BrandId = 3, ColorId = 4, DailyPrice = 200, Description = "tesla model x",  ModelYear = 2013 });

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("\n\n----Kiralık Araba Bilgileri----\n");

            //    Console.WriteLine("Araba ID: " + car.Id + "\nAraba Model ID: " + car.BrandId +
            //        "\nAraba Renk ID: " + car.ColorId + "\nAraba Model Yıl:" + car.ModelYear +
            //        "\nAraba Günlük Kira: " + car.DailyPrice + "\nAraba Açıklama: " + car.Description);                
            //}

            foreach (var car in carManager.GetByDailyPrice(30,100))
            {
                Console.WriteLine("\n\n----Kiralık Araba Bilgileri----\n");

                Console.WriteLine("Araba ID: " + car.Id + "\nAraba Model ID: " + car.BrandId +
                    "\nAraba Renk ID: " + car.ColorId + "\nAraba Model Yıl:" + car.ModelYear +
                    "\nAraba Günlük Kira: " + car.DailyPrice + "\nAraba Açıklama: " + car.Description);
            }
        }
    }
}
