using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Dbcontext;
using Entities.Entities;

namespace DataAccess.Concrete.EfSqlServer
{

    public class EfCityDal : ICityDal
    {
        private readonly AppDbContext _context;


        //DI
        public EfCityDal(AppDbContext context)
        {
            _context = context;
        }



        public List<City> Getcities()
        {
            return _context.Cities.ToList();
        }
    }
}
