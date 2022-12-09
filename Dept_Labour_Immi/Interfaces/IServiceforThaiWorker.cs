using System.Collections.Generic;
using Dept_Labour_Immi.Models;
using Microsoft.Data.SqlClient;
using System;

namespace Dept_Labour_Immi.Interfaces
{
    public interface IServiceforThaiWorker
    {
        Task<ServiceforThaiWorker> getServiceforThaiWorkeryId(int? id);
        Task<List<ServiceforThaiWorker>> getServiceforThaiWorkerList();
        Task<ServiceforThaiWorker> Create(ServiceforThaiWorker bOD);
        Task<ServiceforThaiWorker> Update(ServiceforThaiWorker bOD);
        Task<int> Delete(int id);
    }
}
