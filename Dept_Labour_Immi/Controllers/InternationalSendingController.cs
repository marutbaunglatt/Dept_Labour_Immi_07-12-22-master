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
using Microsoft.CodeAnalysis;
using Dept_Labour_Immi.Enum;

namespace Dept_Labour_Immi.Controllers
{
    //[Authorize]
    [Authorize(Roles = ConstantValues.User_Admin_Officer)]
    public class InternationalSendingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IInternationalSending _iSending;
        string errmsg="";
        public InternationalSendingController(ApplicationDbContext context, IInternationalSending iSending)
        {
            _context = context;
            _iSending = iSending;
        }

        public async Task<IActionResult> Index()
        {
            var sendingList = await _iSending.getIntlSendingList();
            return View(sendingList);
        }
        public IActionResult Create()
        {
            ViewData["CountryID"] = new SelectList(_context.countries, "ID", "Name");
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName");
            ViewData["ServiceThaiWorkerID"] = new SelectList(_context.serviceforThaiWorkers, "ID", "ID");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InternationalSending model)
        {
            bool isExist = _iSending.IsExists(model);

            if (isExist)
            {
                errmsg = "ထိုအချက်အလက်များသည် ရှိနေပါသည်။";
                ModelState.AddModelError("Error", errmsg);
                return View(model);
            }
            else
            {
                InternationalSending result = await _iSending.Create(model);
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.internationalSendings == null)
            {
                return NotFound();
            }
            var intl = await _iSending.getIntlSendingById(id);
            if (intl == null)
            {
                return NotFound();
            }

            return View(intl);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.internationalSendings == null)
            {
                return NotFound();
            }

            ViewData["CountryID"] = new SelectList(_context.countries, "ID", "Name");
            ViewData["AgencyID"] = new SelectList(_context.agencies, "Id", "AgencyName");
            ViewData["ServiceThaiWorkerID"] = new SelectList(_context.serviceforThaiWorkers, "ID", "ID");

            var intl = await _iSending.getIntlSendingById(id);
            if (intl == null)
            {
                return NotFound();
            }
            
            return View(intl);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InternationalSending model)
        {
            if (id != model.ID)
            {
                return NotFound();
            }
            bool isExist = _iSending.IsExists(model);

            if (isExist)
            {
                errmsg = "ထိုအချက်အလက်များသည် ရှိနေပါသည်။";
                ModelState.AddModelError("Error", errmsg);
                return View(model);
            }
            else
            {
                var result = await _iSending.Update(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
