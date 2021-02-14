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
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());



            //addingCar(carManager);
            //getAllCar(carManager);
            //gettAllCarDetails(carManager);
            //getCarByDailyPrice(carManager);
            //addingColor(colorManager);
            //getAllColor(colorManager);
            //addingBrand(brandManager);
            //getAllBrand(brandManager);
            //getById(carManager, colorManager, brandManager);
        }

        private static void addingBrand(BrandManager brandManager)
        {
            brandManager.Add(new Brand { Name = "Bugatti" });
            brandManager.Add(new Brand { Name = "m35" });
        }

        private static void addingColor(ColorManager colorManager)
        {
            colorManager.Add(new Color { Name = "Pembe" });
            colorManager.Add(new Color { Name = "Sarı" });
            colorManager.Add(new Color { Name = "Turkuaz" });
        }

        private static void gettAllCarDetails(CarManager carManager)
        {
            Console.WriteLine("\n\n---- Detaylı Kiralık Araba Bilgileri----\n");

            foreach (var carDetails in carManager.GetCarDetails())
            {
                Console.WriteLine("\n\n-----------------------------\n");

                Console.WriteLine("araba ıd: " + carDetails.Id + "\nAraba modeli: " + carDetails.BrandName +
                                   "\nAraba rengi: " + carDetails.ColorName + "\naraba günlük kira: " + carDetails.DailyPrice +
                                   "\naraba açıklama: " + carDetails.Description);
            }
        }

        private static void getAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Brand ID: " + brand.Id + @" \ Brand Name: " + brand.Name);
            }
        }

        private static void getById(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            Console.WriteLine("ID 5 Olan Araba: " + carManager.GetById(5).Description);
            Console.WriteLine("ID 2 olan Brand: " + brandManager.GetById(2).Name);
            Console.WriteLine("ID 4 Olan Renk: " + colorManager.GetById(4).Name);
        }

        private static void getAllCar(CarManager carManager)
        {
            Console.WriteLine("\n\n----kiralık araba bilgileri----\n");

            foreach (var car in carManager.GetAll())
            {
                
                Console.WriteLine("\n\n-----------------------------\n");

                Console.WriteLine("araba ıd: " + car.Id + "\naraba model ıd: " + car.BrandId +
                    "\naraba renk ıd: " + car.ColorId + "\naraba model yıl:" + car.ModelYear +
                    "\naraba günlük kira: " + car.DailyPrice + "\naraba açıklama: " + car.Description);
            }
        }

        private static void addingCar(CarManager carManager)
        {
            carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 90, Description = "volkswagen polo", ModelYear = 2016 });
            carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 120, Description = "ford focus", ModelYear = 2018 });
            carManager.Add(new Car { BrandId = 2, ColorId = 3, DailyPrice = 50, Description = "toyota yaris", ModelYear = 2017 });
            carManager.Add(new Car { BrandId = 3, ColorId = 4, DailyPrice = 200, Description = "tesla model x", ModelYear = 2013 });
        }

        private static void getAllColor(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Renk ID: " + color.Id + @" \ Renk:" + color.Name);
            }
        }

        private static void getCarByDailyPrice(CarManager carManager)
        {
            foreach (var car in carManager.GetByDailyPrice(30, 100))
            {
                Console.WriteLine("\n\n----Kiralık Araba Bilgileri----\n");

                Console.WriteLine("Araba ID: " + car.Id + "\nAraba Model ID: " + car.BrandId +
                    "\nAraba Renk ID: " + car.ColorId + "\nAraba Model Yıl:" + car.ModelYear +
                    "\nAraba Günlük Kira: " + car.DailyPrice + "\nAraba Açıklama: " + car.Description);
            }
        }
    }
}
