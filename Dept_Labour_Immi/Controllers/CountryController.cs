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
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICountry _iCountry;
        string errmsg;
        public CountryController(ApplicationDbContext context, ICountry iCountry)
        {
            _context = context;
            _iCountry = iCountry;
        }

        public async Task<IActionResult> Index()
        {
            var countryList = await _iCountry.getCountryList();
            return View(countryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Country country)
        {
            bool isExist = _iCountry.CountryExists(country);

            if (isExist)
            {
                errmsg = "နိူင်ငံအမည်သည် ရှိနေပါသည်။";
                ModelState.AddModelError("Error", errmsg);
                return View(country);
            }
            else
            {
                Country result = await _iCountry.Create(country);
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.countries == null)
            {
                return NotFound();
            }
            var country = await _iCountry.getCountryById(id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.countries == null)
            {
                return NotFound();
            }

            var country = await _iCountry.getCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            
            return View(country);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Country country)
        {
            if (id != country.ID)
            {
                return NotFound();
            }
            bool isExist = _iCountry.CountryExists(country);

            if (isExist)
            {
                errmsg = "နိူင်ငံအမည်သည် ရှိနေပါသည်။";
                ModelState.AddModelError("Error", errmsg);
                return View(country);
            }
            else
            {
                var result = await _iCountry.Update(country);
                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }
    }
}
