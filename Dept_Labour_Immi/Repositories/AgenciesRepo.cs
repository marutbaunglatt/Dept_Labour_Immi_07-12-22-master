using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Repositories
{
    public class AgenciesRepo : IAgencies
    {
        private readonly ApplicationDbContext _context;

        public AgenciesRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Agency>> GetAgencyList()
        {
            List<Agency> model = new List<Agency>();
            List<Agency> res = await _context.agencies.OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in res)
            {
                int id = Convert.ToInt32(item.BOD_Name);
                var str = _context.bODs.Where(x => x.ID == id).Select(x => x.Name).FirstOrDefault();
                item.BODName = str;
                model.Add(item);

            }

            return model;
        }
        public async Task<Agency> GetAgencyById(int? id)
        {
            Agency agen = new Agency();

            agen = await _context.agencies.FirstOrDefaultAsync(m => m.Id == id);
            int bodID = Convert.ToInt32(agen.BOD_Name);
            var str = _context.bODs.Where(x => x.ID == bodID).Select(x => x.Name).FirstOrDefault();
            agen.BODName = str;

            return agen;
        }

        public async Task<List<BOD>> GetBODByAgencyId(string? bodName,int agencyID)
        {
            int id = Convert.ToInt32(bodName);
            List<BOD> bod = new List<BOD>();
            bod = _context.bODs.Where(m => m.ID == id || m.AgencyID == agencyID).ToList();
            return bod;
        }

        public async Task<List<Penalty>> GetPenaltyByAgencyId(int? id)
        {
            List<Penalty> penalty = new List<Penalty>();
            penalty = _context.penalties.Where(m => m.AgencyID == id).ToList();
            return penalty;
        }
        public async Task<int> createAgency(Agency agency)
        {
            _context.agencies.Add(agency);
            var res = await _context.SaveChangesAsync();
            return res;
        }
        public async Task<int> UpdateAgency(Agency agency)
        {
            _context.agencies.Update(agency);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAgency(Agency agency)
        {
            _context.agencies.Remove(agency);
            var res = await _context.SaveChangesAsync();
            return res;
        }
        public bool AgencyExists(int id)
        {
            return _context.agencies.Any(e => e.Id == id);
        }

        public async Task<List<BOD>> BODList()
        {
            try
            {
                var lst = _context.bODs.Where(x => x.Position == "Managing Director").ToList();
                return lst;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
