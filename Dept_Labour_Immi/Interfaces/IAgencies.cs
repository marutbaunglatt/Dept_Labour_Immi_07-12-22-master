using Dept_Labour_Immi.Models;

namespace Dept_Labour_Immi.Interfaces
{
    public interface IAgencies
    {
        Task<List<Agency>> GetAgencyList();
        Task<Agency> GetAgencyById(int? id);
        Task<int> createAgency(Agency agency);
        Task<int> UpdateAgency(Agency agency);
        Task<int> DeleteAgency(Agency agency);
        bool AgencyExists(int id);
        Task<List<BOD>> GetBODByAgencyId(string? bodName, int agencyID);
        Task<List<Penalty>> GetPenaltyByAgencyId(int? id);
        Task<List<BOD>> BODList();
    }
}
