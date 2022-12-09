using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Repositories
{
    public class ThaiSendingRepo : IThaiSending
    {
        private readonly ApplicationDbContext _context;
        public ThaiSendingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ThaiSending>> GetListThaiSending()
        {
            var model = _context.thaiSendings.Include(a => a.agency).Include(a => a.thaiCompany).AsNoTracking().OrderByDescending(x => x.ThaiSendingId).ToList();
            return model;
        }
        public async Task<ThaiSending> GetThaiSendingByID(string id)
        {
            int _id = Convert.ToInt32(id);
            var model = _context.thaiSendings.Include(a => a.agency).Include(a => a.thaiCompany).AsNoTracking().Where(x => x.ThaiSendingId == _id).FirstOrDefault();
            return model;
        }
        public async Task<int> createThaiSending(ThaiSending model)
        {
            _context.thaiSendings.Add(model);
            var res = await _context.SaveChangesAsync();
            return res;
        }
        public async Task<int> UpdateThaiSending(ThaiSending model)
        {
            _context.thaiSendings.Update(model);
            var res = await _context.SaveChangesAsync();
            return res;
        }
    }
}
