using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Repositories
{
    public class ThaiCompanyRepo : IThaiCompany
    {
        private readonly ApplicationDbContext _context;
        public ThaiCompanyRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ThaiCompany> Create(ThaiCompany model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<List<ThaiCompany>> getThaiCompanyList()
        {
            var thaiCompanyList = await _context.thaiCompanies.Include(t => t.agency).OrderByDescending(a => a.ID).ToListAsync();

            return thaiCompanyList;
        }
        public async Task<ThaiCompany> getThaiCompanyById(int? id)
        {
            var thaiCompany = await _context.thaiCompanies
               .Include(t => t.agency)
               .FirstOrDefaultAsync(m => m.ID == id);
            return thaiCompany;
        }
        public async Task<ThaiCompany> Update(ThaiCompany model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<int> Delete(int id)
        {
            var tc = await _context.thaiCompanies.FirstOrDefaultAsync(s => s.ID == id);
            if (tc != null)
            {
                _context.thaiCompanies.Remove(tc);
            }
            return await _context.SaveChangesAsync();
        }
        public bool ThaiCompanyNoExists(ThaiCompany model)
        {
            bool isExist = false;
            if (model.ID == 0)
            {
                isExist = _context.thaiCompanies.Any(a => a.CompanyName == model.CompanyName && a.AgencyID == model.AgencyID);
            }
            else if (model.ID > 0)
            {
                isExist = _context.thaiCompanies.Any(a => a.ID != model.ID && a.CompanyName == model.CompanyName && a.AgencyID == model.AgencyID);
            }
            return isExist;
        }

        public async Task<List<Blacklist>> GetBlackListByThaiCompanyID(int? id)
        {
            List<Blacklist> blacklists = new List<Blacklist>();
            blacklists = _context.blacklists.Include(a => a.agency).Include(b => b.thaiCompany).Where(m => m.ThaiCompanyID == id).ToList();
            return blacklists;
        }
    }
}
