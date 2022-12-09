using Dept_Labour_Immi.Models;

namespace Dept_Labour_Immi.Interfaces
{
    public interface IPenalty
    {
        Task<List<Penalty>> GetPenaltylist();
        Task<Penalty> GetPenaltyById(int? id);
        Task<int> createPenalty(Penalty penalty);
        Task<int> UpdatePenalty(Penalty penalty);
        Task<int> DeletePenalty(Penalty penalty);
    }
}
