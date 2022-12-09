using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Repositories
{
    public class BODRepo : IBOD
    {
        private readonly ApplicationDbContext _context;
        string errmsg;
        public BODRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BOD> Create(BOD bOD)
        {         
            _context.Add(bOD);
            await _context.SaveChangesAsync();
            return bOD;
        }

        public async Task<int> Delete(int id)
        {
            var bOD = await _context.bODs.FirstOrDefaultAsync(s => s.ID == id);
            if (bOD != null)
            {
                _context.bODs.Remove(bOD);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<BOD> getBODById(int? id)
        {
            var bod = await _context.bODs
                .Include(b => b.agency)
                .FirstOrDefaultAsync(m => m.ID == id);
            return bod;
        }

        public async Task<List<BOD>> getBODList()
        {
            var bodList = await _context.bODs.Include(t => t.agency).OrderByDescending(a => a.ID).ToListAsync();
            return bodList;
        }

        public async Task<BOD> Update(BOD bOD)
        {
            _context.Update(bOD);
            await _context.SaveChangesAsync();
            return bOD;
        }

        public bool BODExistsInOtherCompany(BOD model)
        {
            bool isExist = false;
            if (model.ID == 0)
            {
                isExist = _context.bODs.Any(a => a.NRC == model.NRC);
            }
            else if (model.ID > 0)
            {
                isExist = _context.bODs.Any(a => a.ID != model.ID && a.NRC == model.NRC);
            }
            return isExist;
        }
    }
}
