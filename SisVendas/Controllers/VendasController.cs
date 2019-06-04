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
    public class VendasController : Controller
    {
        private readonly SisVendasContext _context;

        public VendasController(SisVendasContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var sisVendasContext = _context.Vendas.Include(v => v.Cliente).Include(v => v.Pagto).Include(v => v.Vendedor);
            return View(await sisVendasContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Pagto)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCli", "strNomeCli");
            ViewData["PagtoId"] = new SelectList(_context.FormaPagtos, "IdPagto", "strPagto");
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "IdVend", "strEmail");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenda,VendedorId,ClienteId,PagtoId,dtVenda,Status")] Vendas vendas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCli", "strNomeCli", vendas.ClienteId);
            ViewData["PagtoId"] = new SelectList(_context.FormaPagtos, "IdPagto", "strPagto", vendas.PagtoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "IdVend", "strEmail", vendas.VendedorId);
            return View(vendas);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas.FindAsync(id);
            if (vendas == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCli", "strNomeCli", vendas.ClienteId);
            ViewData["PagtoId"] = new SelectList(_context.FormaPagtos, "IdPagto", "strPagto", vendas.PagtoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "IdVend", "strEmail", vendas.VendedorId);
            return View(vendas);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenda,VendedorId,ClienteId,PagtoId,dtVenda,Status")] Vendas vendas)
        {
            if (id != vendas.IdVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendasExists(vendas.IdVenda))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCli", "strNomeCli", vendas.ClienteId);
            ViewData["PagtoId"] = new SelectList(_context.FormaPagtos, "IdPagto", "strPagto", vendas.PagtoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "IdVend", "strEmail", vendas.VendedorId);
            return View(vendas);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Pagto)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendas = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(vendas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendasExists(int id)
        {
            return _context.Vendas.Any(e => e.IdVenda == id);
        }
    }
}
