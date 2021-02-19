using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {

            var rentalsReturnDate = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            var hasCustomersRentedCar = _rentalDal.GetAll(c => c.CustomerId == rental.CustomerId);
            bool carVarMi = false;
            bool customerVarMi = false;

            if (rentalsReturnDate.Count > 0 || hasCustomersRentedCar.Count > 0)
            {
                foreach (var rentalreturnDate in rentalsReturnDate)
                {
                    if (rentalreturnDate.ReturnDate == default)
                    {
                        carVarMi = true;
                    }
                }

                foreach (var hasCustomerRentedCar in hasCustomersRentedCar)
                {
                    if (hasCustomerRentedCar.ReturnDate == default)
                    {
                       customerVarMi = true;
                    }
                }

                if (carVarMi && customerVarMi == false)
                {
                    return new ErrorResult(Messages.rentalCancelled + " for car");
                }

                else if(customerVarMi && carVarMi == false)
                {
                    return new ErrorResult(Messages.rentalCancelled + " for customer");
                }

                else if(customerVarMi && carVarMi)
                {
                    return new ErrorResult(Messages.rentalCancelled + " for customer and car");
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.rentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.rentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.rentalListed);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetByRentDate(DateTime first, DateTime second)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental reental)
        {
            throw new NotImplementedException();
        }
    }
}
