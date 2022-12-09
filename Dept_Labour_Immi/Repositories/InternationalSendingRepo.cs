using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Repositories
{
    public class InternationalSendingRepo : IInternationalSending
    {
        private readonly ApplicationDbContext _context;
        public InternationalSendingRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<InternationalSending> Create(InternationalSending model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<InternationalSending>> getIntlSendingList()
        {
            var sendingList = await _context.internationalSendings.Include(s => s.Country).Include(x => x.Agency).Include(s => s.ServiceThaiWorker).ToListAsync();

            return sendingList;
        }

        public async Task<InternationalSending> getIntlSendingById(int? id)
        {
            var intl = await _context.internationalSendings.Include(a => a.Country).Include(t => t.Agency).Include(s => s.ServiceThaiWorker).Where(x => x.ID == id).FirstOrDefaultAsync();
            return intl;
        }

        public async Task<InternationalSending> Update(InternationalSending model)
        {

            _context.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<int> Delete(int id)
        {
            var intl = await _context.internationalSendings.FirstOrDefaultAsync(s => s.ID == id);
            if (intl != null)
            {
                _context.internationalSendings.Remove(intl);
            }
            return await _context.SaveChangesAsync();
        }

        public bool IsExists(InternationalSending model)
        {
            bool isExist = false;
            if (model.ID == 0)
            {
                isExist = _context.internationalSendings.Any(a => a.CountryID == model.CountryID && a.AgencyID == model.AgencyID && a.Date == model.Date);
            }
            else if (model.ID > 0)
            {
                isExist = _context.internationalSendings.Any(a => a.ID != model.ID && a.CountryID == model.CountryID && a.AgencyID == model.AgencyID && a.Date == model.Date);
            }
            return isExist;
        }
    }
}
