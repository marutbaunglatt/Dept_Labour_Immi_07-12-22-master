using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Repositories
{
    public class Operation_2Repo : IOperation_2
    {
        private readonly ApplicationDbContext _context;
        public Operation_2Repo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<DOE> getDOEList()
        {
            List<DOE> result = new List<DOE>();
            result = (from op in _context.operation_1s
                      join doe in _context.DOEs on op.DOEID equals doe.ID
                      select doe).ToList();
            return result;
        }
        public Operation_1 GetOperation1ByDoeId(int doeId)
        {
            var ope = _context.operation_1s.Include(a => a.agency).Include(t => t.thaiCompany).Where(x => x.DOEID == doeId).FirstOrDefault();

            return ope;
        }
        public Operation_2 CheckDOEAndRemainWorker(int doeId)
        {
            Operation_2 op2 = _context.operation_2s.OrderByDescending(o => o.ID).FirstOrDefault(s => s.DOEID == doeId);

            return op2;
        }

        public async Task<Operation_2> Create(Operation_2 model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<Operation_2>> getOperation2List()
        {
            List<Operation_2> operationList = await _context.operation_2s.Include(o => o.agency).Include(o => o.dOE).Include(o => o.thaiCompany).ToListAsync();
            return operationList;
        }

        public async Task<Operation_2> getOperation2ById(int? id)
        {
            var opt2 = await _context.operation_2s
                        .Include(a => a.agency)
                        .Include(d => d.dOE)
                        .Include(t => t.thaiCompany)
                        .FirstOrDefaultAsync(s => s.ID == id);
            return opt2;
        }
        public async Task<bool> CheckEC(Operation_2 ec)
        {
            bool result = false;
            var data = await _context.operation_2s.OrderByDescending(x => x.ID).FirstOrDefaultAsync(s => s.DOEID == ec.DOEID);
            if(data.ID == ec.ID)
            {
                result= true;
            }
            return result;
        }

        public async Task<int> Update(Operation_2 opt2)
        {
            _context.Update(opt2);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var opt2 = await _context.operation_2s.FirstOrDefaultAsync(s => s.ID == id);
            if (opt2 != null)
            {
                _context.operation_2s.Remove(opt2);
            }
            return await _context.SaveChangesAsync();
        }

        //public bool Operation2NoExists(Operation_2 model)
        //{
        //    bool isExist = false;
        //    if (model.ID == 0)
        //    {
        //        isExist = _context.operation_2s.Any(a => a.DOE_NO == doe.DOE_NO);
        //    }
        //    else if (doe.ID > 0)
        //    {
        //        isExist = _context.DOEs.Any(a => a.ID != doe.ID && a.DOE_NO == doe.DOE_NO);
        //    }
        //    return isExist;
        //}
    }
}
