using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task ChangeCarFeatureAvailableToFalseAsync(int id)
        {
            var value = await _context.CarFeatures.Where(x => x.CarID == id).FirstOrDefaultAsync();
            value.Available = false;
            _context.Update(value);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeCarFeatureAvailableToTrueAsync(int id)
        {
            var value = await _context.CarFeatures.Where(x => x.CarID == id).FirstOrDefaultAsync();
            value.Available = true;
            _context.Update(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CarFeature>> GetCarFeaturesByCarIdAsync(int id)
        {
            return await _context.CarFeatures.Include(x => x.Feature).Where(x => x.CarID == id).ToListAsync();
        }
    }
}
