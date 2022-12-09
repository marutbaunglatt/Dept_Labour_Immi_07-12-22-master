using System.Collections.Generic;
using Dept_Labour_Immi.Models;
using Microsoft.Data.SqlClient;
using System;

namespace Dept_Labour_Immi.Interfaces
{
    public interface IThaiCompany
    {
        Task<ThaiCompany> Create(ThaiCompany thaiCompany);
        Task<List<ThaiCompany>> getThaiCompanyList();
        Task<ThaiCompany> getThaiCompanyById(int? id);
        Task<ThaiCompany> Update(ThaiCompany thaiCompany);
        Task<int> Delete(int id);
        bool ThaiCompanyNoExists(ThaiCompany modal);
        Task<List<Blacklist>> GetBlackListByThaiCompanyID(int? id);
    }
}
