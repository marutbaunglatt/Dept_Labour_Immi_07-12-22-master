using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Models;
using Dept_Labour_Immi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Dept_Labour_Immi.Enum;

namespace Dept_Labour_Immi.Controllers
{
    // [Authorize]
    [Authorize(Roles = ConstantValues.User_Admin_Officer)]
    public class PenaltyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPenalty _penalty;
        public PenaltyController(ApplicationDbContext context, IPenalty penalty)
        {
            _context = context;
            _penalty = penalty;
        }

        // GET: Blacklists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _penalty.GetPenaltylist();
            return View(applicationDbContext);
        }

        // GET: Blacklists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.penalties == null)
            {
                return NotFound();
            }

            var blacklist = await _penalty.GetPenaltyById(id);
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Reason,FromDate,Todate,Remark,IsActive,penaltyType,AgencyID")] Penalty penalty)
        {
            var res = await _penalty.createPenalty(penalty);
            return RedirectToAction(nameof(Index));

            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", penalty.AgencyID);
            return View(penalty);
        }

        // GET: Blacklists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.penalties == null)
            {
                return NotFound();
            }

            var penalty = await _penalty.GetPenaltyById(id);
            if (penalty == null)
            {
                return NotFound();
            }
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", penalty.AgencyID);
            return View(penalty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Reason,FromDate,Todate,Remark,IsActive,penaltyType,AgencyID")] Penalty penalty)
        {
            if (id != penalty.Id)
            {
                return NotFound(penalty);
            }

            var res = await _penalty.UpdatePenalty(penalty);

            return RedirectToAction(nameof(Index));

            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", penalty.AgencyID);
            return View(penalty);
        }

        // GET: Blacklists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.penalties == null)
            {
                return NotFound();
            }

            var penalty = await _penalty.GetPenaltyById(id);
            if (penalty == null)
            {
                return NotFound();
            }

            return View(penalty);
        }

        // POST: Blacklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.blacklists == null)
            {
                return Problem("Entity set 'ApplicationDbContext.penalties'  is null.");
            }
            var penalty = await _penalty.GetPenaltyById(id);
            if (penalty != null)
            {
                var res = await _penalty.DeletePenalty(penalty);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
