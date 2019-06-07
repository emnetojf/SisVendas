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
    public class ProdutosController : Controller
    {

        //Cria o realcionamento com ProdutoService

        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }



        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var prodlist = await _produtoService.FindAllAsync();
            return View(prodlist);
        }



        // GET: Produto/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoService.FindByIDAsync(id.Value);


            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }



        // GET: Produtos/Create
        public async Task<IActionResult> Create()
        {
            if (ModelState.IsValid)
            {
                return View();

            }

            var produtos = await _produtoService.FindAllAsync();
            var vwModel = new ProdutoFormViewModel { Produtos = produtos };
            return View(vwModel);
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            // Se o modelo não foi validado

            if (!ModelState.IsValid)
            {
                var produtos = await _produtoService.FindAllAsync();
                ProdutoFormViewModel vwModel = new ProdutoFormViewModel { Produtos = produtos};
                return View(vwModel);
            }

            await _produtoService.InsertAsync(produto);
            return RedirectToAction(nameof(Index));
        }


        // GET: Produtos/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoService.FindByIDAsync(id.Value);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }


        // POST: Produtos/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _produtoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        // GET: Produtos/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoService.FindByIDAsync(id.Value);


            if (produto == null)
            {
                return NotFound();
            }

            var produtos = await _produtoService.FindAllAsync();
            ProdutoFormViewModel vwModel = new ProdutoFormViewModel { Produtos = produtos};

            return View(vwModel);
        }


        // POST: Clientes/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.IdProd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _produtoService.UpdateAsync(produto);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != produto.IdProd)
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
                var produtos = await _produtoService.FindAllAsync();
                ProdutoFormViewModel vwModel = new ProdutoFormViewModel { Produtos = produtos };
                return View(vwModel);
            }
        }


    }
}
