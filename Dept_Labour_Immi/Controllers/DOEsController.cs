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
    //[Authorize]
    [Authorize(Roles = ConstantValues.User_Admin_Entry)]
    public class DOEsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDOE _iDOE;
        string errmsg;
        public DOEsController(ApplicationDbContext context, IDOE iDOE)
        {
            _context = context;
            _iDOE = iDOE;
        }

        public async Task<IActionResult> Index()
        {
            var doeList = await _iDOE.getDOEList();
            return View(doeList);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DOEs == null)
            {
                return NotFound();
            }

            var dOE = await _iDOE.getDOEById(id);

            if (dOE == null)
            {
                return NotFound();
            }

            return View(dOE);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DOE_NO,DOE_Date")] DOE dOE)
        {
            bool isExist = _iDOE.DOENoExists(dOE);

            if (isExist)
            {
                errmsg = "စာအမှတ်ရှိနေပါသည် ပြန်လည်စစ်ဆေးပါ။";
                ModelState.AddModelError("Error", errmsg);
                return View(dOE);
            }
            else
            {
                DOE doe = await _iDOE.Create(dOE);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DOEs == null)
            {
                return NotFound();
            }

            var dOE = await _iDOE.getDOEById(id);
            if (dOE == null)
            {
                return NotFound();
            }
            return View(dOE);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DOE_NO,DOE_Date")] DOE dOE)
        {
            if (id != dOE.ID)
            {
                return NotFound();
            }
            bool isExist = _iDOE.DOENoExists(dOE);
            if (isExist)
            
            {
                errmsg = "စာအမှတ်ရှိနေပါသည် ပြန်လည်စစ်ဆေးပါ။";
                ModelState.AddModelError("Error", errmsg);
                return View(dOE);
            }
            else
            {
                var doe = await _iDOE.Update(dOE);
                return RedirectToAction(nameof(Index));
                
            }
            return View(dOE);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DOEs == null)
            {
                return NotFound();
            }

            var dOE = await _iDOE.getDOEById(id);
            if (dOE == null)
            {
                return NotFound();
            }

            return View(dOE);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DOEs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DOEs'  is null.");
            }
            await _iDOE.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
