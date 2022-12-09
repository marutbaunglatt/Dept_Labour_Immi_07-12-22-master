using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;
using System.Drawing;

namespace Dept_Labour_Immi.Repositories
{
    public class PenaltyRepo : IPenalty
    {
        private readonly ApplicationDbContext _context;

        public PenaltyRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Penalty>> GetPenaltylist()
        {
            try
            {
                List<Penalty> res = await _context.penalties.Include(b => b.agency).ToListAsync();

                var result = _context.penalties
                        .GroupBy(x => new { x.AgencyID })
                        .Select(x => new
                        {
                            x.Key.AgencyID,
                            Count = x.Count()
                        }).ToList();

                if (result is not null)
                {
                    foreach (var item in result)
                    {
                        foreach (var ite in res)
                        {
                            if (item.AgencyID == ite.AgencyID)
                            {
                                ite.AgencyTotalCount = item.Count;
                            }
                        }
                    }
                }

                List<Penalty> model = res.OrderByDescending(a => a.AgencyTotalCount).ToList();

                return model;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public async Task<Penalty> GetPenaltyById(int? id)
        {
            try
            {
                Penalty penalty = new Penalty();
                penalty = await _context.penalties
                       .Include(b => b.agency)
                       .FirstOrDefaultAsync(m => m.Id == id);
                return penalty;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public async Task<int> createPenalty(Penalty penalty)
        {
            try
            {
                _context.penalties.Add(penalty);
                var res = await _context.SaveChangesAsync();
                return res;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public async Task<int> UpdatePenalty(Penalty penalty)
        {
            try
            {
                _context.penalties.Update(penalty);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public async Task<int> DeletePenalty(Penalty penalty)
        {
            try
            {
                _context.penalties.Remove(penalty);
                var res = await _context.SaveChangesAsync();
                return res;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
