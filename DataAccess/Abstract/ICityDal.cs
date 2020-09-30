using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface ICityDal
    {
        List<City> Getcities();
    }
}
