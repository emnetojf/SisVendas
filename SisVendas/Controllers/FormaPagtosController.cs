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
    public class FormaPagtosController : Controller
    {
        

        private readonly FormaPagtoService _formaPagtoService;

        public FormaPagtosController(FormaPagtoService formaPagtoService)
        {
            _formaPagtoService = formaPagtoService;
        }

        // GET: FormaPagtos
        public async Task<IActionResult> Index()
        {
            var pagtolist = await _formaPagtoService.FindAllAsync();
            return View(pagtolist);
        }

        // GET: FormaPagtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagto = await _formaPagtoService.FindByIDAsync(id.Value);


            if (formaPagto == null)
            {
                return NotFound();
            }

            return View(formaPagto);
        }

        // GET: FormaPagtos/Create
        public async Task<IActionResult> Create()
        {
            var formaPagtos = await _formaPagtoService.FindAllAsync();
            var vwModel = new FormaPagtoFormViewModel { formaPagtos = formaPagtos};
            return View(vwModel);
        }

        // POST: FormaPagtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormaPagto formaPagto)
        {
            // Se o modelo não foi validado

            if (!ModelState.IsValid)
            {
                var formaPagtos = await _formaPagtoService.FindAllAsync();
                FormaPagtoFormViewModel viewModel = new FormaPagtoFormViewModel { formaPagtos = formaPagtos};
                return View(viewModel);
            }

            await _formaPagtoService.InsertAsync(formaPagto);
            return RedirectToAction(nameof(Index));

        }

        // GET: FormaPagtos/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagto = await _formaPagtoService.FindByIDAsync(id.Value);

            if (formaPagto == null)
            {
                return NotFound();
            }

            return View(formaPagto);
        }


        // POST: FormaPagtos/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _formaPagtoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        // GET: FormaPagtos/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagto = await _formaPagtoService.FindByIDAsync(id.Value);


            if (formaPagto == null)
            {
                return NotFound();
            }


            FormaPagtoFormViewModel viewModel = new FormaPagtoFormViewModel { FormaPagto = formaPagto };
            return View(viewModel);
        }


        // POST: FormaPagtos/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FormaPagto formaPagto)
        {
            if (id != formaPagto.IdPagto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _formaPagtoService.UpdateAsync(formaPagto);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != formaPagto.IdPagto)
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
                var formaPagtos = await _formaPagtoService.FindAllAsync();
                FormaPagtoFormViewModel viewModel = new FormaPagtoFormViewModel{ formaPagtos = formaPagtos };
                return View(viewModel);
            }
        }



    }
}
