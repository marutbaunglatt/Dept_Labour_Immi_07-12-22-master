using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Models;
using Dept_Labour_Immi.Interfaces;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Authorization;
using Dept_Labour_Immi.Enum;

namespace Dept_Labour_Immi.Controllers
{
    [Authorize(Roles = ConstantValues.User_Admin_Officer)]
    public class Operation_1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOperation_1 _Oper;
        string errmsg;
        public Operation_1Controller(ApplicationDbContext context, IOperation_1 oper)
        {
            _context = context;
            _Oper = oper;
        }

        // GET: Operation_1
        public async Task<IActionResult> Index()
        {
            List<Operation_1> operList = new List<Operation_1>();
            operList = await _Oper.GetOperation_1List();
            return View(operList);
        }

        // GET: Operation_1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.operation_1s == null)
            {
                return NotFound();
            }

            var operation_1 = await _Oper.GetOperation_1ById(id);

            if (operation_1 == null)
            {
                return NotFound();
            }

            return View(operation_1);
        }

        // GET: Operation_1/Create
        public IActionResult Create()
        {
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName");
            ViewData["DOEID"] = new SelectList(_context.DOEs, "ID", "DOE_NO");
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Apply_Date,Document_Complete_Date,AgencyID,ThaiCompanyID,DOEID,WorkType,MaleWorkers,FemaleWorkers,TotalWorkers,Remark,DOEDateFromDOE")] Operation_1 operation_1)
        {
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", operation_1.AgencyID);
            ViewData["DOEID"] = new SelectList(_context.DOEs, "ID", "DOE_NO", operation_1.DOEID);
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName", operation_1.ThaiCompanyID);

            var isCheckDate = await _Oper.IsGreaterThan_DOEDate(operation_1);
            var IsBlackList_Agency = await _Oper.IsBlackList_Agency(operation_1.AgencyID);
            var IsBlackList_ThaiCompany = await _Oper.IsBlackList_ThaiCompany(operation_1.ThaiCompanyID);
            var IsDuplicate_DOEID = await _Oper.IsDuplicate_DOEID(operation_1);
            var IsPenalty_Agency = await _Oper.IsPenalty_Agency(operation_1.AgencyID);

            int isCheckError = 0;
            if (operation_1.Document_Complete_Date < operation_1.Apply_Date)
            {
                errmsg = "စာရွက်စာတမ်းပြည့်စုံသည့်ရက်စွဲသည် တင်ပြသည့်ရက်စွဲ ထက်မငယ်ရပါ။ ပြန်လည်စစ်ဆေးပေးပါ။";
                ModelState.AddModelError("Error", errmsg);
                isCheckError += 1;
               // return View(operation_1);
            }
            if (isCheckDate)
            {
                errmsg = "တင်ပြသည့် ရက်စွဲသည် D.O.E ရက်စွဲထက် မငယ်ရပါ။ ပြန်လည်စစ်ဆေးပေးပါ။";
                ModelState.AddModelError("Error", errmsg);
                // return View(operation_1);
                isCheckError += 1;
            }
            if (IsBlackList_Agency)
            {
                errmsg = "Agencyသည် Blacklist ထဲတွင်ရှိနေပါသည်။ အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
                ModelState.AddModelError("Error", errmsg);
                // return View(operation_1);
                isCheckError += 1;
            }
            if (IsPenalty_Agency)
            {
                errmsg = "Agencyသည် Penalty ထဲတွင်ရှိနေပါသည်။ အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
                ModelState.AddModelError("Error", errmsg);
                //   return View(operation_1);
                isCheckError += 1;
            }
            if (IsBlackList_ThaiCompany)
            {
                errmsg = "ထိုင်းCompany တွင်ပြစ်ဒဏ်ရှိပါသည် အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
                ModelState.AddModelError("Error", errmsg);
                // return View(operation_1);
                isCheckError += 1;
            }
            if (IsDuplicate_DOEID)
            {
                errmsg = "စာအမှတ်သည် ရွေးချယ်ပြီးသားဖြစ်နေပါသည်။ အချက်အလက်များကို ပြန်လည်စစ်ဆေးပေးပါ။";
                ModelState.AddModelError("Error", errmsg);
                //return View(operation_1);
                isCheckError += 1;
            }
           
            if (isCheckError > 0)
            {
                return View(operation_1);
            }
            else
            {
                var res = await _Oper.createOperationOne(operation_1);
                return RedirectToAction(nameof(Index));
            }

            return View(operation_1);
        }

        // GET: Operation_1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.operation_1s == null)
            {
                return NotFound();
            }

            var operation_1 = await _Oper.GetOperation_1ById(id);
            if (operation_1 == null)
            {
                return NotFound();
            }
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", operation_1.AgencyID);
            ViewData["DOEID"] = new SelectList(_context.DOEs, "ID", "DOE_NO", operation_1.DOEID);
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName", operation_1.ThaiCompanyID);
            return View(operation_1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Apply_Date,Document_Complete_Date,AgencyID,ThaiCompanyID,DOEID,DOEDateFromDOE,WorkType,MaleWorkers,FemaleWorkers,TotalWorkers,Remark")] Operation_1 operation_1)
        {
            if (id != operation_1.Id)
            {
                return NotFound();
            }
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", operation_1.AgencyID);
            ViewData["DOEID"] = new SelectList(_context.DOEs, "ID", "DOE_NO", operation_1.DOEID);
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName", operation_1.ThaiCompanyID);

            var isCheckDate = await _Oper.IsGreaterThan_DOEDate(operation_1);
            var IsBlackList_Agency = await _Oper.IsBlackList_Agency(operation_1.AgencyID);
            var IsBlackList_ThaiCompany = await _Oper.IsBlackList_ThaiCompany(operation_1.ThaiCompanyID);
            var IsPenalty_Agency = await _Oper.IsPenalty_Agency(operation_1.AgencyID);
            var IsDuplicate_DOEID = await _Oper.IsDuplicate_DOEID(operation_1);
            int isCheckError = 0;
            if (operation_1.Document_Complete_Date < operation_1.Apply_Date)
            {
                errmsg = "စာရွက်စာတမ်းပြည့်စုံသည့်ရက်စွဲသည် တင်ပြသည့်ရက်စွဲ ထက်မငယ်ရပါ။ ပြန်လည်စစ်ဆေးပေးပါ။";
                ModelState.AddModelError("Error", errmsg);
                // return View(operation_1);
                isCheckError += 1;
            }
            if (isCheckDate)
            {
                errmsg = "တင်ပြသည့် ရက်စွဲသည် D.O.E ရက်စွဲထက် မငယ်ရပါ။ ပြန်လည်စစ်ဆေးပေးပါ။";
                ModelState.AddModelError("Error", errmsg);
                // return View(operation_1);
                isCheckError += 1;
            }
            if (IsBlackList_Agency)
            {
                errmsg = "Agencyသည် Blacklist ထဲတွင်ရှိနေပါသည်။ အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
                ModelState.AddModelError("Error", errmsg);
                // return View(operation_1);
                isCheckError += 1;
            }
            if (IsPenalty_Agency)
            {
                errmsg = "Agencyသည် Penalty ထဲတွင်ရှိနေပါသည်။ အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
                ModelState.AddModelError("Error", errmsg);
                //  return View(operation_1);
                isCheckError += 1;
            }
            if (IsBlackList_ThaiCompany)
            {
                errmsg = "ထိုင်းCompany တွင်ပြစ်ဒဏ်ရှိပါသည်။ အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
                ModelState.AddModelError("Error", errmsg);
                //  return View(operation_1);
                isCheckError += 1;
            }
            if (IsDuplicate_DOEID)
            {
                errmsg = "စာအမှတ်သည် ရွေးချယ်ပြီးသားဖြစ်နေပါသည်။ အချက်အလက်များကို ပြန်လည်စစ်ဆေးပေးပါ။";
                ModelState.AddModelError("Error", errmsg);
                //return View(operation_1);
                isCheckError += 1;
            }
            if (isCheckError > 0)
            {
                return View(operation_1);
            }
            else
            {
                try
                {
                    await _Oper.UpdateOperation_1(operation_1);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!Operation_1Exists(operation_1.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(operation_1);
        }

        // GET: Operation_1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.operation_1s == null)
            {
                return NotFound();
            }

            var operation_1 = await _Oper.GetOperation_1ById(id);
            if (operation_1 == null)
            {
                return NotFound();
            }

            return View(operation_1);
        }

        // POST: Operation_1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.operation_1s == null)
            {
                return Problem("Entity set 'ApplicationDbContext.operation_1s'  is null.");
            }
            var operation_1 = await _Oper.GetOperation_1ById(id);
            if (operation_1 != null)
            {
                await _Oper.DeleteOperation_1(operation_1);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<JsonResult> GetDOEDateByDOEID(int id)
        {
            string str = "";
            if (id != 0)
            {
                var doeDatetime = await _Oper.GetDOEDateByDOEID(id);
                var DateOnlyFromDOE = doeDatetime.ToString("MM/dd/yyyy");
                return Json(DateOnlyFromDOE);
            }
            return Json(str);
        }
    }
}
