using System.Collections.Generic;
using Dept_Labour_Immi.Models;
using Microsoft.Data.SqlClient;
using System;

namespace Dept_Labour_Immi.Interfaces
{
    public interface IInternationalSending
    {
        Task<InternationalSending> Create(InternationalSending model);
        Task<List<InternationalSending>> getIntlSendingList();
        Task<InternationalSending> getIntlSendingById(int? id);
        Task<InternationalSending> Update(InternationalSending intl);
        Task<int> Delete(int id);
        bool IsExists(InternationalSending model);
    }
}
