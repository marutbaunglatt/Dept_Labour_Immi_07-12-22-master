using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Dept_Labour_Immi.Repositories
{
    public class CountryRepo : ICountry
    {
        private readonly ApplicationDbContext _context;
        public CountryRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Country> Create(Country country)
        {         
            _context.Add(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<List<Country>> getCountryList()
        {
            var countryList = await _context.countries.OrderByDescending(a => a.ID).ToListAsync();
            return countryList;
        }

        public async Task<Country> getCountryById(int? id)
        {
            var country = await _context.countries.FirstOrDefaultAsync(s => s.ID == id);
            return country;
        }

        public async Task<Country> Update(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public bool CountryExists(Country country)
        {
            bool isExist = false;
            if (country.ID == 0)
            {
                isExist = _context.countries.Any(a => a.Name == country.Name);
            }
            else if (country.ID > 0)
            {
                isExist = _context.countries.Any(a => a.ID != country.ID && a.Name == country.Name);
            }
            return isExist;
        }
    }
}
