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
    [Authorize(Roles = ConstantValues.User_Admin_Officer)]
    public class BlacklistsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBlacklist _blacklist;
        public BlacklistsController(ApplicationDbContext context, IBlacklist blacklist)
        {
            _context = context;
            _blacklist = blacklist;
        }

        // GET: Blacklists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _blacklist.GetBlacklist();
            return View(applicationDbContext);
        }

        // GET: Blacklists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.blacklists == null)
            {
                return NotFound();
            }

            var blacklist = await _blacklist.GetBlacklistById(id);
            if (blacklist == null)
            {
                return NotFound();
            }

            return View(blacklist);
        }

        // GET: Blacklists/Create
        public IActionResult Create()
        {
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName");
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName");
            return View();
        }

        // POST: Blacklists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Reason,FromDate,Todate,Remark,IsActive,penaltyType,AgencyID,ThaiCompanyID")] Blacklist blacklist)
        {
            var res = await _blacklist.createBlacklist(blacklist);
            return RedirectToAction(nameof(Index));

            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", blacklist.AgencyID);
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName", blacklist.ThaiCompanyID);
            return View(blacklist);
        }

        // GET: Blacklists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.blacklists == null)
            {
                return NotFound();
            }

            var blacklist = await _blacklist.GetBlacklistById(id);
            if (blacklist == null)
            {
                return NotFound();
            }
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", blacklist.AgencyID);
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName", blacklist.ThaiCompanyID);
            return View(blacklist);
        }

        // POST: Blacklists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Reason,FromDate,Todate,Remark,IsActive,penaltyType,AgencyID,ThaiCompanyID")] Blacklist blacklist)
        {
            if (id != blacklist.Id)
            {
                return NotFound(blacklist);
            }

            var res = await _blacklist.UpdateBlacklist(blacklist);

            return RedirectToAction(nameof(Index));

            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", blacklist.AgencyID);
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "CompanyName", blacklist.ThaiCompanyID);
            return View(blacklist);
        }

        // GET: Blacklists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.blacklists == null)
            {
                return NotFound();
            }

            var blacklist = await _blacklist.GetBlacklistById(id);
            if (blacklist == null)
            {
                return NotFound();
            }

            return View(blacklist);
        }

        // POST: Blacklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.blacklists == null)
            {
                return Problem("Entity set 'ApplicationDbContext.blacklists'  is null.");
            }
            var blacklist = await _blacklist.GetBlacklistById(id);
            if (blacklist != null)
            {
                var res = await _blacklist.DeleteBlackList(blacklist);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BlacklistExists(int id)
        {
            return _context.blacklists.Any(e => e.Id == id);
        }
    }
}
