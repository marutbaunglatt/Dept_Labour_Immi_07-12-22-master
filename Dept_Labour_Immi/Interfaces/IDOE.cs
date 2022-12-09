using System.Collections.Generic;
using Dept_Labour_Immi.Models;
using Microsoft.Data.SqlClient;
using System;

namespace Dept_Labour_Immi.Interfaces
{
    public interface IDOE
    {
        Task<DOE> Create(DOE dOE);
        Task<List<DOE>> getDOEList();
        Task<DOE> getDOEById(int? id);
        Task<DOE> Update(DOE doe);
        Task<int> Delete(int id);
        bool DOENoExists(DOE doe);
    }
}
