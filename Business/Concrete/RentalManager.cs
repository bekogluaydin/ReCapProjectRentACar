using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            if (rental.CarId != 0 && rental.CustomerId !=0 && rental.RentDate != default)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.rentalAdded);
            }
            return new ErrorResult(Messages.rentalRentDateInvalid);
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
