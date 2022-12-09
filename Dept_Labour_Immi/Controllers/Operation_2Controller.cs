using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Authorization;
using Dept_Labour_Immi.Interfaces;
using Microsoft.Build.Evaluation;
using System.Diagnostics.Metrics;
using Dept_Labour_Immi.Enum;

namespace Dept_Labour_Immi.Controllers
{
    //[Authorize]
    [Authorize(Roles = ConstantValues.User_Admin_Officer)]
    public class Operation_2Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOperation_2 _iOperation2;
        private readonly IOperation_1 _iOperation1;
        string errmsg;
        public Operation_2Controller(ApplicationDbContext context, IOperation_2 iOperation2,
            IOperation_1 iOperation1)
        {
            _context = context;
            _iOperation2 = iOperation2;
            _iOperation1 = iOperation1;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Operation_2> optList = new List<Operation_2>();
            optList = await _iOperation2.getOperation2List();
            return View(optList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.operation_2s == null)
            {
                return NotFound();
            }

            var operation = await _iOperation2.getOperation2ById(id);

            if (operation == null)
            {
                return NotFound();
            }

            return View(operation);
        }

        public IActionResult Create()
        {
            var doeList = _iOperation2.getDOEList();
            ViewData["DOEID"] = new SelectList(doeList, "ID", "DOE_NO");
            return View();
        }

        [HttpGet]
        public IActionResult GetDemandData(int doeId)
        {
            var result = _iOperation2.CheckDOEAndRemainWorker(doeId);
            var doeList = _iOperation2.GetOperation1ByDoeId(doeId);

            //return Json(new {result = result,  });
            //return Json(doeList);
            return Json(new { data = doeList, EC = result });
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Operation_2 model)//[Bind("ID,DOE_NO,DOE_Date")] DOE dOE)
        //{
        //    ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", model.AgencyID);
        //    ViewData["DOEID"] = new SelectList(_context.DOEs, "ID", "DOE_NO", model.DOEID);
        //    ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName", model.ThaiCompanyID);


        // //   var isCheckDate = await _Oper.IsNotGreaterThan_DOEDate(operation_1);
        //    var IsBlackList_Agency = await _iOperation1.IsBlackList_Agency(model.AgencyID);
        //    var IsBlackList_ThaiCompany = await _iOperation1.IsBlackList_ThaiCompany(model.ThaiCompanyID);

        //    if (IsBlackList_Agency)
        //    {
        //        errmsg = "Agency တွင် ပြစ်ဒဏ်ရှိပါသည် အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
        //        ModelState.AddModelError("Error", errmsg);
        //        return View(model);
        //    }
        //    if (IsBlackList_ThaiCompany)
        //    {
        //        errmsg = "ထိုင်းCompany တွင်ပြစ်ဒဏ်ရှိပါသည် အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
        //        ModelState.AddModelError("Error", errmsg);
        //        return View(model);
        //    }
        //    else
        //    {
        //        var res = await _iOperation2.Create(model);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(model);
        //}

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Consumes("application/json")]
        public async Task<IActionResult> SaveEC([FromBody] Operation_2 inputData)
        {
            var res = await _iOperation2.Create(inputData);

            return Json(new { status = "success", url = "/Operation_2/Index" });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.operation_2s == null)
            {
                return NotFound();
            }

            var opt = await _iOperation2.getOperation2ById(id);
            if (opt == null)
            {
                return NotFound();
            }

            bool isLastRecord = await _iOperation2.CheckEC(opt);
            ViewData["operation"] = isLastRecord;
            return View(opt);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Operation_2 model)
        //{
        //    if (id != model.ID)
        //    {
        //        return NotFound();
        //    }

        //    ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", model.AgencyID);
        //    ViewData["DOEID"] = new SelectList(_context.DOEs, "ID", "DOE_NO", model.DOEID);
        //    ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName", model.ThaiCompanyID);


        //    //   var isCheckDate = await _Oper.IsNotGreaterThan_DOEDate(operation_1);
        //    var IsBlackList_Agency = await _iOperation1.IsBlackList_Agency(model.AgencyID);
        //    var IsBlackList_ThaiCompany = await _iOperation1.IsBlackList_ThaiCompany(model.ThaiCompanyID);


        //    if (IsBlackList_Agency)
        //    {
        //        errmsg = "Agency တွင် ပြစ်ဒဏ်ရှိပါသည် အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
        //        ModelState.AddModelError("Error", errmsg);
        //        return View(model);
        //    }
        //    if (IsBlackList_ThaiCompany)
        //    {
        //        errmsg = "ထိုင်းCompany တွင်ပြစ်ဒဏ်ရှိပါသည် အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
        //        ModelState.AddModelError("Error", errmsg);
        //        return View(model);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            await _iOperation2.Update(model);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(model);
        //}

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEC([FromBody] Operation_2 inputData)
        {
            var result = await _iOperation2.Update(inputData);

            return Json(new { status = "success", url = "/Operation_2/Index" });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.operation_2s == null)
            {
                return NotFound();
            }

            var opt = await _iOperation2.getOperation2ById(id);
            if (opt == null)
            {
                return NotFound();
            }

            return View(opt);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.operation_2s == null)
            {
                return Problem("Entity set 'ApplicationDbContext.operation_2s'  is null.");
            }
            await _iOperation2.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
