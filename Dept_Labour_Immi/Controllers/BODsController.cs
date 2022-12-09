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
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore.Internal;
using Dept_Labour_Immi.Repositories;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Enum;

namespace Dept_Labour_Immi.Controllers
{
    //  [Authorize]
    [Authorize(Roles = ConstantValues.User_Admin_Entry)]
    public class BODsController : Controller
    {
        string errmsg = "";
        private readonly ApplicationDbContext _context;
        private readonly IBOD _repo;
        public BODsController(ApplicationDbContext context ,IBOD repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: BODs
        public async Task<IActionResult> Index(string searchString,string SearchAgency)
        {
            var bodList = await _repo.getBODList();
            if (bodList is not null)
            {
                foreach (var item in bodList)
                {
                    if (item.RegionID is not null && item.RegionID != "--")
                    {
                        item.RegionName = Enum.RegionsEnum.GetName(typeof(RegionsEnum), Convert.ToInt32(item.RegionID));
                    }
                }
            }
            return View(bodList);
        }

        // GET: BODs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bODs == null)
            {
                return NotFound();
            }

            var bOD = await _repo.getBODById(id);
            if (bOD is not null && bOD.RegionID is not null && bOD.RegionID != "--")
            {
                bOD.RegionName = Enum.RegionsEnum.GetName(typeof(RegionsEnum), Convert.ToInt32(bOD.RegionID));
               
            }
            if (bOD == null)
            {
                return NotFound();
            }

            return View(bOD);
        }

        // GET: BODs/Create
        public IActionResult Create()
        {
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName");
           
            return View();
        }

        // POST: BODs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Position,RegionID,NRC,Phone,AgencyID")] BOD bOD)
        {
            //if (ModelState.IsValid)
            //{
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", bOD.AgencyID);

            bool isExist = _repo.BODExistsInOtherCompany(bOD);

            if (isExist)
            {
                errmsg = "မှတ်ပုံတင်ပြီးသောအဖွဲ.၀င်ဖြစ်ပါသည် အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
                ModelState.AddModelError("Error", errmsg);
                return View(bOD);
            }
            else
            {
                BOD boD = await _repo.Create(bOD);
                return RedirectToAction(nameof(Index));
            }
            //}
            
            return View(bOD);
        }

        // GET: BODs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.bODs == null)
            {
                return NotFound();
            }

            //var bOD = await _context.bODs.FindAsync(id);
            var bOD = await _repo.getBODById(id);
            if (bOD == null)
            {
                return NotFound();
            }
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", bOD.AgencyID);
            return View(bOD);
        }

        // POST: BODs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Position,RegionID,NRC,Phone,AgencyID")] BOD bOD)
        {
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName", bOD.AgencyID);
            if (id != bOD.ID)
            {
                return NotFound();
            }

            bool isExist = _repo.BODExistsInOtherCompany(bOD);
            if (isExist)
            {
                errmsg = "မှတ်ပုံတင်ပြီးသောအဖွဲ.၀င်ဖြစ်ပါသည် အချက်အလက်များကို ပြန်လည်စစ်ဆေးပါ";
                ModelState.AddModelError("Error", errmsg);
                return View(bOD);
            }
            else 
            {
                var bod = await _repo.Update(bOD);
                return RedirectToAction(nameof(Index)); 

            }
            return View(bOD);
        }

        // GET: BODs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bODs == null)
            {
                return NotFound();
            }

            var bOD = await _repo.getBODById(id);
            if (bOD == null)
            {
                return NotFound();
            }

            return View(bOD);
        }

        // POST: BODs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bODs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.bODs'  is null.");
            }
            await _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
