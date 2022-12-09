using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Enum;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Controllers
{
    [Authorize(Roles = ConstantValues.User_Admin_Officer)]
    public class ThaiSendingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IThaiSending _ThaiSending;

        public ThaiSendingController(ApplicationDbContext context, IThaiSending thai)
        {
            _context = context;
            _ThaiSending = thai;
        }

        public async Task<IActionResult> Index()
        {
            List<ThaiSending> lst = new List<ThaiSending>();
            lst = await _ThaiSending.GetListThaiSending();
            return View(lst);
        }
        public async Task<IActionResult> Details(string id)
        {
            ThaiSending model = new ThaiSending();
            if (id == null)
            {
                return NotFound();
            }
            model = await _ThaiSending.GetThaiSendingByID(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        public IActionResult create()
        {
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName");
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ThaiSending thaiSending)
        {
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", thaiSending.AgencyID);
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName", thaiSending.ThaiCompanyID);

            if (thaiSending is not null)
            {
                var res = await _ThaiSending.createThaiSending(thaiSending);
                return RedirectToAction(nameof(Index));
            }
            return View(thaiSending);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thaiSending = await _ThaiSending.GetThaiSendingByID(id);
            if (thaiSending == null)
            {
                return NotFound();
            }
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", thaiSending.AgencyID);
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName", thaiSending.ThaiCompanyID);
            return View(thaiSending);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ThaiSending model)
        {
            if (id != model.ThaiSendingId)
            {
                return NotFound();
            }

            try
            {
                await _ThaiSending.UpdateThaiSending(model);
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
