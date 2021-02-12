using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("\n\n----Kiralık Araba Bilgileri----\n");

            //    Console.WriteLine("Araba ID: " + car.Id + "\nAraba Model ID: " + car.BrandId +
            //        "\nAraba Renk ID: " + car.ColorId + "\nAraba Model Yıl:" + car.ModelYear +
            //        "\nAraba Günlük Kira: " + car.DailyPrice + "\nAraba Açıklama: " + car.Description);                
            //}

            foreach (var car in carManager.GetByDailyPrice(1,30))
            {
                Console.WriteLine("\n\n----Kiralık Araba Bilgileri----\n");

                Console.WriteLine("Araba ID: " + car.Id + "\nAraba Model ID: " + car.BrandId +
                    "\nAraba Renk ID: " + car.ColorId + "\nAraba Model Yıl:" + car.ModelYear +
                    "\nAraba Günlük Kira: " + car.DailyPrice + "\nAraba Açıklama: " + car.Description);
            }
        }
    }
}
