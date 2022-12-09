using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Repositories
{
    public class ServiceforThaiWorkerRepo : IServiceforThaiWorker
    {
        private readonly ApplicationDbContext _context;
        string errmsg;
        public ServiceforThaiWorkerRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceforThaiWorker> Create(ServiceforThaiWorker thaiWorker)
        {         
            _context.serviceforThaiWorkers.Add(thaiWorker);
            await _context.SaveChangesAsync();
            return thaiWorker;
        }

        public async Task<int> Delete(int id)
        {
            var thaiWorker = await _context.serviceforThaiWorkers.FirstOrDefaultAsync(s => s.ID == id);
            if (thaiWorker != null)
            {
                _context.serviceforThaiWorkers.Remove(thaiWorker);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<ServiceforThaiWorker> getServiceforThaiWorkeryId(int? id)
        {
            var thaiWorker = await _context.serviceforThaiWorkers
                .FirstOrDefaultAsync(m => m.ID == id);
            return thaiWorker;
        }

        public async Task<List<ServiceforThaiWorker>> getServiceforThaiWorkerList()
        {
            var thaiWorkerList = await _context.serviceforThaiWorkers.OrderByDescending(a => a.ID).ToListAsync();
            return thaiWorkerList;
        }

        public async Task<ServiceforThaiWorker> Update(ServiceforThaiWorker thaiWorkerList)
        {
            _context.Update(thaiWorkerList);
            await _context.SaveChangesAsync();
            return thaiWorkerList;
        }
    }
}
