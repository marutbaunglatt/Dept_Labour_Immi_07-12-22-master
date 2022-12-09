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
    // [Authorize]
    [Authorize(Roles = ConstantValues.User_Admin_Entry)]
    public class AgenciesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAgencies _agencies;
        public AgenciesController(ApplicationDbContext context, IAgencies agencies)
        {
            _context = context;
            _agencies = agencies;
        }

        // GET: Agencies
        public async Task<IActionResult> Index()
        {
            var res = await _agencies.GetAgencyList();
            return View(res);
        }

        // GET: Agencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.agencies == null)
            {
                return NotFound();
            }
            Agency agency = new Agency();
            agency = await _agencies.GetAgencyById(id);
            if (agency == null)
            {
                return NotFound();
            }
            agency.BODList = await _agencies.GetBODByAgencyId(agency.BOD_Name,agency.Id);
            agency.PenaltyList = await _agencies.GetPenaltyByAgencyId(id);

            return View(agency);
        }
        // GET: Agencies/Create
        public async Task<IActionResult> CreateAsync()
        {
            // ViewData["BOD_Name"] = new SelectList(_context.bODs.Where(x => x.Position == "Managing Director"), "Id", "Name");
            Agency oper = new Agency();
            oper.BODList = await _agencies.BODList();
            return View(oper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AgencyName,LicenseStartDate,LicenseEndDate,Address,RegNo,BOD_Name,Phone")] Agency agency)
        {
            await _agencies.createAgency(agency);
            return RedirectToAction(nameof(Index));
        }

        // GET: Agencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //ViewData["BOD_Name"] = new SelectList(_context.bODs.Where(x => x.Position == "Managing Director"), "ID", "Name");

            // Agency agency = new Agency();

            if (id == null || _context.agencies == null)
            {
                return NotFound();
            }

            var agency = await _agencies.GetAgencyById(id);
            agency.BODList = await _agencies.BODList();
            if (agency == null)
            {
                return NotFound();
            }
            return View(agency);
        }

        // POST: Agencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AgencyName,LicenseStartDate,LicenseEndDate,Address,RegNo,BOD_Name,Phone")] Agency agency)
        {
            if (id != agency.Id)
            {
                return NotFound();
            }
            await _agencies.UpdateAgency(agency);
            return RedirectToAction(nameof(Index));

        }

        // GET: Agencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.agencies == null)
            {
                return NotFound();
            }

            var agency = await _agencies.GetAgencyById(id);
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

        // POST: Agencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.agencies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.agencies'  is null.");
            }
            var agency = await _agencies.GetAgencyById(id);
            if (agency != null)
            {
                await _agencies.DeleteAgency(agency);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
