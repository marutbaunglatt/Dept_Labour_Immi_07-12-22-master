using System.Collections.Generic;
using Dept_Labour_Immi.Models;
using Microsoft.Data.SqlClient;
using System;

namespace Dept_Labour_Immi.Interfaces
{
    public interface IBOD
    {
        Task<BOD> getBODById(int? id);
        Task<List<BOD>> getBODList();
        Task<BOD> Create(BOD bOD);
        Task<BOD> Update(BOD bOD);
        Task<int> Delete(int id);
        bool BODExistsInOtherCompany(BOD bOD);



    }
}
