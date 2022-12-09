using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Repositories
{
    public class Operation_1Repo : IOperation_1
    {
        private readonly ApplicationDbContext _context;

        public Operation_1Repo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Operation_1>> GetOperation_1List()
        {
            List<Operation_1> res = _context.operation_1s.Include(o => o.agency).Include(o => o.dOE).Include(o => o.thaiCompany).OrderByDescending(a => a.Id).ToList();
            return res;
        }
        public async Task<Operation_1> GetOperation_1ById(int? id)
        {
            Operation_1 oper = new Operation_1();
            oper = await _context.operation_1s
                .Include(o => o.agency)
                .Include(o => o.dOE)
                .Include(o => o.thaiCompany)
                .FirstOrDefaultAsync(m => m.Id == id);

            oper.DOEDateFromDOE = oper.DOEDate.ToString("MM/dd/yyyy");
            return oper;
        }
        public async Task<int> createOperationOne(Operation_1 oper)
        {
            if (oper.DOEID != 0)
            {
                var DoeDate = _context.DOEs.Where(s => s.ID == oper.DOEID).Select(s => s.DOE_Date).FirstOrDefault();
                oper.DOEDate = DoeDate;
            }
            oper.TotalWorkers = oper.MaleWorkers + oper.FemaleWorkers;
            _context.operation_1s.Add(oper);
            var res = await _context.SaveChangesAsync();
            return res;
        }
        public async Task<int> UpdateOperation_1(Operation_1 oper)
        {
            if (oper.DOEID != 0)
            {
                var DoeDate = _context.DOEs.Where(s => s.ID == oper.DOEID).Select(s => s.DOE_Date).FirstOrDefault();
                oper.DOEDate = DoeDate;
            }
            oper.TotalWorkers = oper.MaleWorkers + oper.FemaleWorkers;
            _context.operation_1s.Update(oper);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteOperation_1(Operation_1 oper)
        {
            _context.operation_1s.Remove(oper);
            return await _context.SaveChangesAsync();
        }

        public bool Operation_1Exists(int id)
        {
            return _context.operation_1s.Any(e => e.Id == id);
        }

        public async Task<bool> IsBlackList_Agency(int? id)
        {
            var Agency_data = _context.blacklists.Any(e => e.AgencyID == id && e.IsActive == true);
            return Agency_data;
        }
        public async Task<bool> IsPenalty_Agency(int? id)
        {
            var Agency_data = _context.penalties.Any(e => e.AgencyID == id && e.IsActive == true);
            return Agency_data;
        }
        public async Task<bool> IsBlackList_ThaiCompany(int? id)
        {
            var Thai_data = _context.blacklists.Any(e => e.ThaiCompanyID == id && e.IsActive == true);
            return Thai_data;
        }
        public async Task<bool> IsGreaterThan_DOEDate(Operation_1 oper)
        {
            var doe_data = _context.DOEs.Any(e => e.ID == oper.DOEID && e.DOE_Date > oper.Apply_Date);
            return doe_data;
        }
        public async Task<bool> IsDuplicate_DOEID(Operation_1 oper)
        {
            var DOE_data = false;
            if (oper.Id == 0)
            {
                 DOE_data = _context.operation_1s.Any(e => e.DOEID == oper.DOEID);
            }
            if (oper.Id > 0)
            {
                 DOE_data = _context.operation_1s.Any(e => e.Id != oper.Id && e.DOEID == oper.DOEID);
            }
           
            return DOE_data;
        }

        public async Task<DateTime> GetDOEDateByDOEID(int id)
        {
                var DoeDate = _context.DOEs.Where(s => s.ID == id).Select(s => s.DOE_Date).FirstOrDefault();
                return DoeDate;
        }
       
    }
}
