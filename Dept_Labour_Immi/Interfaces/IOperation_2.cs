using System.Collections.Generic;
using Dept_Labour_Immi.Models;
using Microsoft.Data.SqlClient;
using System;

namespace Dept_Labour_Immi.Interfaces
{
    public interface IOperation_2
    {
        List<DOE> getDOEList();
        Operation_1 GetOperation1ByDoeId(int doeId);
        Operation_2 CheckDOEAndRemainWorker(int doeId);
        Task<Operation_2> Create(Operation_2 opt2);
        Task<List<Operation_2>> getOperation2List();
        Task<Operation_2> getOperation2ById(int? id);
        Task<int> Update(Operation_2 opt2);
        Task<int> Delete(int id);
        //bool Operation2NoExists(Operation_2 opt2);
        Task<bool> CheckEC(Operation_2 ec);

    }
}
