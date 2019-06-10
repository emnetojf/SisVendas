using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisVendas.Models;
using SisVendas.Models.ViewModels;
using SisVendas.Services;

namespace SisVendas.Controllers
{
    public class VendasController : Controller
    {
        //Cria o realcionamento com ProdutoService

        private readonly VendasService _vendasService;

        public VendasController(VendasService vendasService)
        {
            _vendasService = vendasService;
        }



        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var vendaslist = await _vendasService.FindAllAsync();
            return View(vendaslist);
        }

                              
        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _vendasService.FindByIDAsync(id.Value);
           

            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }



        // GET: Vendas/Create
        public async Task<IActionResult> Create()
        {
            var vendas = await _vendasService.FindAllAsync();
            var vwModel = new VendasFormViewModel { Vendas = vendas};
            return View(vwModel);

        }


                     

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendas vendas)
        {
            var vendaslist = await _vendasService.FindAllAsync();
            return View(vendaslist);

        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _vendasService.FindByIDAsync(id.Value);
            
           
            if (vendas == null)
            {
                return NotFound();
            }

           

            VendasFormViewModel vwModel = new VendasFormViewModel { Venda = vendas};
            return View(vwModel);
           
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendas vendas, ItemVendas itemVendas)
        {
            if (id != vendas.IdVenda)
            {
                return NotFound();
            }

            if (id != itemVendas.VendasId)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    await _vendasService.UpdateAsync(vendas, itemVendas);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != vendas.IdVenda || id != itemVendas.VendasId)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
            }
            else
            {
                List<Vendas> vendaslist = await _vendasService.FindAllAsync();  
                VendasFormViewModel vwModel = new VendasFormViewModel { Vendas = vendaslist};
                return View(vwModel);
            }
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _vendasService.FindByIDAsync(id.Value);
            
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
            try
            {
                await _vendasService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
    }
}
