using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Entities;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;



        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }




        public List<City> GetCities()
        {
            return _cityDal.Getcities();
        }
    }
}
