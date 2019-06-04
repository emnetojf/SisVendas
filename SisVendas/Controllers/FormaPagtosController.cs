using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisVendas.Models;

namespace SisVendas.Controllers
{
    public class FormaPagtosController : Controller
    {
        private readonly SisVendasContext _context;

        public FormaPagtosController(SisVendasContext context)
        {
            _context = context;
        }

        // GET: FormaPagtos
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormaPagtos.ToListAsync());
        }

        // GET: FormaPagtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagto = await _context.FormaPagtos
                .FirstOrDefaultAsync(m => m.IdPagto == id);
            if (formaPagto == null)
            {
                return NotFound();
            }

            return View(formaPagto);
        }

        // GET: FormaPagtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormaPagtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPagto,strPagto")] FormaPagto formaPagto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formaPagto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaPagto);
        }

        // GET: FormaPagtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagto = await _context.FormaPagtos.FindAsync(id);
            if (formaPagto == null)
            {
                return NotFound();
            }
            return View(formaPagto);
        }

        // POST: FormaPagtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPagto,strPagto")] FormaPagto formaPagto)
        {
            if (id != formaPagto.IdPagto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formaPagto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaPagtoExists(formaPagto.IdPagto))
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
            return View(formaPagto);
        }

        // GET: FormaPagtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagto = await _context.FormaPagtos
                .FirstOrDefaultAsync(m => m.IdPagto == id);
            if (formaPagto == null)
            {
                return NotFound();
            }

            return View(formaPagto);
        }

        // POST: FormaPagtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formaPagto = await _context.FormaPagtos.FindAsync(id);
            _context.FormaPagtos.Remove(formaPagto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaPagtoExists(int id)
        {
            return _context.FormaPagtos.Any(e => e.IdPagto == id);
        }
    }
}
