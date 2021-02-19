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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //addingCar(carManager);
            //getAllCar(carManager);
            //getAllCarDetails(carManager);
            //getCarByDailyPrice(carManager);

            //addingColor(colorManager);
            //getAllColor(colorManager);

            //addingBrand(brandManager);
            //getAllBrand(brandManager);

            //getById(carManager, colorManager, brandManager);

            //addingUser(userManager);
            //getAllUser(userManager);

            //addingCustomer(customerManager);
            //getAllCustomerDetails(customerManager);

            //addingRental(rentalManager);
            //getAllRental(rentalManager);
            //getAllRentalDetails(rentalManager);

        }

        private static void getAllRentalDetails(RentalManager rentalManager)
        {
            var result = rentalManager.GetAllRentalDetails();

            if (result.Success)
            {
                Console.WriteLine("\n\n---- Detaylı Customer Bilgileri----\n");
                foreach (var rentalDetail in result.Data)
                {
                    Console.WriteLine("\n\n-----------------------------\n");

                    Console.WriteLine("ıd: " + rentalDetail.Id + "\nUser Id: " + rentalDetail.UserId +
                                       "\nCustomer First Name: " + rentalDetail.CustomerFirstName + "\nCustomer Last Name: " + rentalDetail.CustomerLastName +
                                       "\nCompany Name: " + rentalDetail.CompanyName + "\nCustomer Email : " + rentalDetail.Email +
                                       "\nCar Description: " + rentalDetail.CarDescription + "\nBrand Name: " + rentalDetail.BrandName
                                       + "\nModel Year: " + rentalDetail.ModelYear + "\nDaily Price: " + rentalDetail.DailyPrice
                                       + "\nRentDate: " + rentalDetail.RentDate + "\nReturn date: " + rentalDetail.ReturnDate);
                }
                Console.WriteLine("\n\n\n" + result.Message);
            }
            else { Console.WriteLine(result.Message); }
        }

        private static void getAllCustomerDetails(CustomerManager customerManager)
        {
            var result = customerManager.GetCustomerDetails();

            if (result.Success)
            {
                Console.WriteLine("\n\n---- Detaylı Customer Bilgileri----\n");
                foreach (var customerDetails in result.Data)
                {
                    Console.WriteLine("\n\n-----------------------------\n");

                    Console.WriteLine("ıd: " + customerDetails.Id + "\nUser Id: " + customerDetails.UserId +
                                       "\nUser First Name: " + customerDetails.FirstName + "\nUser Last Name: " + customerDetails.LastName +
                                       "\nCompany Name: " + customerDetails.CompanyName + "\nUser Email : " + customerDetails.Email +
                                       "\nUser Password: " + customerDetails.Password);
                }
                Console.WriteLine("\n\n\n" + result.Message);
            }
            else { Console.WriteLine(result.Message); }
        }

        private static void getAllRental(RentalManager rentalManager)
        {
            var result = rentalManager.GetAll();

            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("\n\n-----------------------------\n");

                    Console.WriteLine("rental ıd: " + rental.Id + "\nCar Id: " + rental.CarId +
                                       "\nCustomer Id: " + rental.CustomerId + "\nRent Date: " + rental.RentDate +
                                       "\nReturn Date: " + rental.ReturnDate);
                }
                Console.WriteLine("\n\n\n" + result.Message);
            }
            else { Console.WriteLine(result.Message); }
        }

        private static void addingRental(RentalManager rentalManager)
        {
            var result = rentalManager.Add(new Rental { CarId =1006, CustomerId = 5, RentDate = new DateTime(2020, 02, 19), ReturnDate = new DateTime(2020, 02, 20) });
            Console.WriteLine(result.Message);           
        }

        private static void addingCustomer(CustomerManager customerManager)
        {
            var result1 = customerManager.Add(new Customer { UserId = 3, CompanyName = "Albayrak Rent" });

            if (result1.Success)
            {
                Console.WriteLine(result1.Message);
            }
            else { Console.WriteLine(result1.Message); }
        }

        private static void addingUser(UserManager userManager)
        {
           var result1 = userManager.Add(new User { FirstName = "Metecan", LastName = "Öğün" });
            if (result1.Success)
            {
                Console.WriteLine(result1.Message);
            }
            else { Console.WriteLine(result1.Message); }
        }

        private static void getAllUser(UserManager userManager)
        {
            var result = userManager.GetAll();
            if (result.Success)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine("\n\n-----------------------------\n");

                    Console.WriteLine("user ıd: " + user.Id + "\nUser First Name: " + user.FirstName +
                                       "\nUser Last Name: " + user.LastName + "\nUser Email: " + user.Email +
                                       "\nUser Password: " + user.Password);
                }
                Console.WriteLine("\n\n\n" + result.Message);
            }
            else { Console.WriteLine(result.Message); }
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

        private static void getAllCarDetails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                Console.WriteLine("\n\n---- Detaylı Kiralık Araba Bilgileri----\n");
                foreach (var carDetails in result.Data)
                {
                    Console.WriteLine("\n\n-----------------------------\n");

                    Console.WriteLine("araba ıd: " + carDetails.Id + "\nAraba modeli: " + carDetails.BrandName +
                                       "\nAraba rengi: " + carDetails.ColorName + "\naraba günlük kira: " + carDetails.DailyPrice +
                                       "\naraba açıklama: " + carDetails.Description);
                }
                Console.WriteLine("\n\n\n" + result.Message);
            }
            else { Console.WriteLine(result.Message); }           
        }

        private static void getAllBrand(BrandManager brandManager)
        {
            var result = brandManager.GetAll();

            if (result.Success)
            {
                foreach (var brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine("Brand ID: " + brand.Id + @" \ Brand Name: " + brand.Name);
                    Console.WriteLine(result.Message);
                }
            }
            else { Console.WriteLine(result.Message); }
            
        }

        private static void getById(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            Console.WriteLine("ID 5 Olan Araba: " + carManager.GetById(5).Data.Description);
            Console.WriteLine("ID 2 olan Brand: " + brandManager.GetById(2).Data.Name);
            Console.WriteLine("ID 4 Olan Renk: " + colorManager.GetById(4).Data.Name);
        }

        private static void getAllCar(CarManager carManager)
        {
            Console.WriteLine("\n\n----kiralık araba bilgileri----\n");

            foreach (var car in carManager.GetAll().Data)
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
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("Renk ID: " + color.Id + @" \ Renk:" + color.Name);
            }
        }

        private static void getCarByDailyPrice(CarManager carManager)
        {
            foreach (var car in carManager.GetByDailyPrice(30, 100).Data)
            {
                Console.WriteLine("\n\n----Kiralık Araba Bilgileri----\n");

                Console.WriteLine("Araba ID: " + car.Id + "\nAraba Model ID: " + car.BrandId +
                    "\nAraba Renk ID: " + car.ColorId + "\nAraba Model Yıl:" + car.ModelYear +
                    "\nAraba Günlük Kira: " + car.DailyPrice + "\nAraba Açıklama: " + car.Description);
            }
        }
    }
}
