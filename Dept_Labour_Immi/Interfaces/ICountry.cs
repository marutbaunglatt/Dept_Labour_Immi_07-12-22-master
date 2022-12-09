using System.Collections.Generic;
using Dept_Labour_Immi.Models;
using Microsoft.Data.SqlClient;
using System;

namespace Dept_Labour_Immi.Interfaces
{
    public interface ICountry
    {
        Task<Country> Create(Country country);
        Task<List<Country>> getCountryList();
        Task<Country> getCountryById(int? id);
        Task<Country> Update(Country country);
        bool CountryExists(Country modal);
    }
}
