using Dept_Labour_Immi.Models;

namespace Dept_Labour_Immi.Interfaces
{
    public interface IOperation_1
    {
        Task<List<Operation_1>> GetOperation_1List();
        Task<Operation_1> GetOperation_1ById(int? id);
        Task<int> createOperationOne(Operation_1 oper);
        Task<int> UpdateOperation_1(Operation_1 oper);
        Task<int> DeleteOperation_1(Operation_1 oper);
        bool Operation_1Exists(int id);
        Task<bool> IsBlackList_Agency(int? id);
        Task<bool> IsBlackList_ThaiCompany(int? id);
        Task<bool> IsGreaterThan_DOEDate(Operation_1 oper);
        Task<bool> IsDuplicate_DOEID(Operation_1 oper);
        Task<DateTime> GetDOEDateByDOEID(int id);
        Task<bool> IsPenalty_Agency(int? id);
    }
}
