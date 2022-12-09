using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Repositories
{
    public class BlacklistRepo : IBlacklist
    {
        private readonly ApplicationDbContext _context;

        public BlacklistRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Blacklist>> GetBlacklist()
        {
            try
            {
                List<Blacklist> res = await _context.blacklists.Include(b => b.agency).Include(b => b.thaiCompany).OrderByDescending(a => a.Id).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public async Task<Blacklist> GetBlacklistById(int? id)
        {
            try
            {
                Blacklist black = new Blacklist();
                black = await _context.blacklists
                       .Include(b => b.agency)
                       .Include(b => b.thaiCompany)
                       .FirstOrDefaultAsync(m => m.Id == id);
                return black;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public async Task<int> createBlacklist(Blacklist black)
        {
            try
            {
                _context.blacklists.Add(black);
                var res = await _context.SaveChangesAsync();
                return res;
            }
            catch(Exception ex) { 
            
            }
            return 0;
        }
        public async Task<int> UpdateBlacklist(Blacklist black)
        {
            try
            {
                _context.blacklists.Update(black);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public async Task<int> DeleteBlackList(Blacklist black)
        {
            try
            {
                _context.blacklists.Remove(black);
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
