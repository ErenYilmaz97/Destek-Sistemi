﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;

namespace Business.Abstract
{
    public interface ICityService
    {
        List<City> GetCities();
    }
}
