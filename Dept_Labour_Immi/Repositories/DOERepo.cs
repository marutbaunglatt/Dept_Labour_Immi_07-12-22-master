using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Repositories
{
    public class DOERepo : IDOE
    {
        private readonly ApplicationDbContext _context;
        public DOERepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DOE> Create(DOE dOE)
        {         
            _context.Add(dOE);
            await _context.SaveChangesAsync();
            return dOE;
        }

        public async Task<List<DOE>> getDOEList()
        {
            var dOEList = await _context.DOEs.OrderByDescending(a => a.ID).ToListAsync();

            return dOEList;
        }

        public async Task<DOE> getDOEById(int? id)
        {
            var dOE = await _context.DOEs.FirstOrDefaultAsync(s => s.ID == id);
            return dOE;
        }

        public async Task<DOE> Update(DOE doe)
        {

            _context.Update(doe);
            await _context.SaveChangesAsync();
            return doe;
        }

        public async Task<int> Delete(int id)
        {
            var dOE = await _context.DOEs.FirstOrDefaultAsync(s => s.ID == id);
            if (dOE != null)
            {
                _context.DOEs.Remove(dOE);
            }
            return await _context.SaveChangesAsync();
        }

        public bool DOENoExists(DOE doe)
        {
            bool isExist = false;
            if (doe.ID == 0)
            {
                isExist = _context.DOEs.Any(a => a.DOE_NO == doe.DOE_NO);
            }
            else if (doe.ID > 0)
            {
                isExist = _context.DOEs.Any(a => a.ID != doe.ID && a.DOE_NO == doe.DOE_NO);
            }
            return isExist;
        }
    }
}
