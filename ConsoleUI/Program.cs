using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("\n\n----Kiralık Araba Bilgileri----\n");

                Console.WriteLine("Araba ID: " + car.Id + "\nAraba Model ID: " + car.BrandId +
                    "\nAraba Renk ID: " + car.ColorId + "\nAraba Model Yıl:" + car.ModelYear +
                    "\nAraba Günlük Kira: " + car.DailyPrice + "\nAraba Açıklama: " + car.Description);                
            }
        }
    }
}
