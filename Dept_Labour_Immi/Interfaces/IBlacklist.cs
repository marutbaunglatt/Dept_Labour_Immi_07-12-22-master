using Dept_Labour_Immi.Models;

namespace Dept_Labour_Immi.Interfaces
{
    public interface IBlacklist
    {
        Task<List<Blacklist>> GetBlacklist();
        Task<Blacklist> GetBlacklistById(int? id);
        Task<int> createBlacklist(Blacklist black);
        Task<int> UpdateBlacklist(Blacklist black);
        Task<int> DeleteBlackList(Blacklist black);
    }
}
