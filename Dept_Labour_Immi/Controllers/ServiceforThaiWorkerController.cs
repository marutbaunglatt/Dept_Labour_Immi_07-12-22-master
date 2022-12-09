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
    public class ServiceforThaiWorkerController : Controller
    {
        string errmsg = "";
        private readonly ApplicationDbContext _context;
        private readonly IServiceforThaiWorker _repo;
        public ServiceforThaiWorkerController(ApplicationDbContext context, IServiceforThaiWorker repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: ServiceforThaiWorkerList
        public async Task<IActionResult> Index()
        {

            var ServiceforThaiWorkerList = await _repo.getServiceforThaiWorkerList();
            return View(ServiceforThaiWorkerList);
        }

        // GET: ServiceforThaiWorkerList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.serviceforThaiWorkers == null)
            {
                return NotFound();
            }

            var model = await _repo.getServiceforThaiWorkeryId(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: serviceforThaiWorkers/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceforThaiWorker model)
        {
            ServiceforThaiWorker resModel = await _repo.Create(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: serviceforThaiWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.serviceforThaiWorkers == null)
            {
                return NotFound();
            }
            var model = await _repo.getServiceforThaiWorkeryId(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceforThaiWorker model)
        {
            if (id != model.ID)
            {
                return NotFound();
            }
            var resModel = await _repo.Update(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: serviceforThaiWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.serviceforThaiWorkers == null)
            {
                return NotFound();
            }

            var model = await _repo.getServiceforThaiWorkeryId(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: serviceforThaiWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.serviceforThaiWorkers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.serviceforThaiWorkers'  is null.");
            }
            await _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
