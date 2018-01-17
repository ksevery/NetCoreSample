using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveDemoNetCore.Data;
using LiveDemoNetCore.Models;

namespace LiveDemoNetCore.Controllers
{
    public class ElephantsController : Controller
    {
        private readonly ZooContext _context;

        public ElephantsController(ZooContext context)
        {
            _context = context;
        }

        // GET: Elephants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Elephant.ToListAsync());
        }

        // GET: Elephants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elephant = await _context.Elephant
                .SingleOrDefaultAsync(m => m.Id == id);
            if (elephant == null)
            {
                return NotFound();
            }

            return View(elephant);
        }

        // GET: Elephants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Elephants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Species")] Elephant elephant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elephant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(elephant);
        }

        // GET: Elephants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elephant = await _context.Elephant.SingleOrDefaultAsync(m => m.Id == id);
            if (elephant == null)
            {
                return NotFound();
            }
            return View(elephant);
        }

        // POST: Elephants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Species")] Elephant elephant)
        {
            if (id != elephant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elephant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElephantExists(elephant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(elephant);
        }

        // GET: Elephants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elephant = await _context.Elephant
                .SingleOrDefaultAsync(m => m.Id == id);
            if (elephant == null)
            {
                return NotFound();
            }

            return View(elephant);
        }

        // POST: Elephants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var elephant = await _context.Elephant.SingleOrDefaultAsync(m => m.Id == id);
            _context.Elephant.Remove(elephant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElephantExists(int id)
        {
            return _context.Elephant.Any(e => e.Id == id);
        }
    }
}
