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
using Dept_Labour_Immi.Enum;

namespace Dept_Labour_Immi.Controllers
{
    //  [Authorize]
    [Authorize(Roles = ConstantValues.User_Admin_Entry)]
    public class ThaiCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IThaiCompany _iThaiCompany;
        string errmsg;

        public ThaiCompaniesController(ApplicationDbContext context, IThaiCompany iThaiCompany)
        {
            _context = context;
            _iThaiCompany = iThaiCompany;
        }

        public async Task<IActionResult> Index()
        {
            var thaiCompanyList = await _iThaiCompany.getThaiCompanyList();
            return View(thaiCompanyList);
        }
        public IActionResult Create()
        {
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CompanyName,AgencyID,CompanyType,Owner,OwnerCode")] ThaiCompany thaiCompany)
        {
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", thaiCompany.AgencyID);

            bool isExist = _iThaiCompany.ThaiCompanyNoExists(thaiCompany);

            if (isExist)
            {
                errmsg = "ထိုင်းကုမ္ပဏီအမည် သည် ရှိနေပါသည်။";
                ModelState.AddModelError("Error", errmsg);
                return View(thaiCompany);
            }
            else
            {
                ThaiCompany tc = await _iThaiCompany.Create(thaiCompany);
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.thaiCompanies == null)
            {
                return NotFound();
            }
            ThaiCompany thaiCompany = new ThaiCompany();
            thaiCompany = await _iThaiCompany.getThaiCompanyById(id);
            thaiCompany.blacklists = await _iThaiCompany.GetBlackListByThaiCompanyID(id);
            if (thaiCompany == null)
            {
                return NotFound();
            }

            return View(thaiCompany);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.thaiCompanies == null)
            {
                return NotFound();
            }

            var thaiCompany = await _iThaiCompany.getThaiCompanyById(id);
            if (thaiCompany == null)
            {
                return NotFound();
            }
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", thaiCompany.AgencyID);
            return View(thaiCompany);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CompanyName,AgencyID,CompanyType,Owner,OwnerCode")] ThaiCompany thaiCompany)
        {
            if (id != thaiCompany.ID)
            {
                return NotFound();
            }
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", thaiCompany.AgencyID);
            bool isExist = _iThaiCompany.ThaiCompanyNoExists(thaiCompany);

            if (isExist)
            {
                errmsg = "ထိုင်းကုမ္ပဏီအမည် သည် ရှိနေပါသည်။";
                ModelState.AddModelError("Error", errmsg);
                return View(thaiCompany);
            }
            else
            {
                var result = await _iThaiCompany.Update(thaiCompany);
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.thaiCompanies == null)
            {
                return NotFound();
            }

            var thaiCompany = await _iThaiCompany.getThaiCompanyById(id); ;
            if (thaiCompany == null)
            {
                return NotFound();
            }

            return View(thaiCompany);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.thaiCompanies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.thaiCompanies'  is null.");
            }
            await _iThaiCompany.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
