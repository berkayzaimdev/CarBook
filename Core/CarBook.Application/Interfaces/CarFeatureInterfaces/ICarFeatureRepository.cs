﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> GetCarFeaturesByCarIdAsync(int id);
        Task ChangeCarFeatureAvailableToFalseAsync(int id);
        Task ChangeCarFeatureAvailableToTrueAsync(int id);
        Task CreateCarFeatureByCar(CarFeature carFeature);
    }
}
