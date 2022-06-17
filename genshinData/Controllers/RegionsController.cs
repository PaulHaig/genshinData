using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using genshinData.Data;
using genshinData.Models;
using genshinData.Models.ViewModels;

namespace genshinData.Controllers
{
    public class RegionsController : Controller
    {
        private readonly ApplicationDbContext context;

        public RegionsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Regions
        public async Task<IActionResult> Index()
        {
              return context.Regiones != null ? 
                          View(await context.Regiones.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Regiones'  is null.");
        }

        // GET: Regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Regiones == null)
            {
                return NotFound();
            }

            var region = await context.Regiones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // GET: Regions/Create
        public IActionResult Create()
        {
            return View(new RegionCreateModel());
        }

        // POST: Regions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegionCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var region = new Region
                {
                    Name = model.Name
                };

                context.Regiones.Add(region);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Regions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await context.Regiones
                .SingleOrDefaultAsync(y => y.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            var model = new RegionEditModel
            {
                Name = region.Name
            };

            ViewBag.regionId = region.Id;

            return View(model);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, RegionEditModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await context.Regiones
                .SingleOrDefaultAsync(y => y.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                region.Name = model.Name;
            }

            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Regiones == null)
            {
                return NotFound();
            }

            var region = await context.Regiones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (context.Regiones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Regiones'  is null.");
            }
            var region = await context.Regiones.FindAsync(id);
            if (region != null)
            {
                context.Regiones.Remove(region);
            }
            
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionExists(int id)
        {
          return (context.Regiones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
