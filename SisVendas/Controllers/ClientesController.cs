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
    public class ClientesController : Controller
    {
        //Cria o realcionamento com ClienteService

        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }



        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var clilist = await _clienteService.FindAllAsync();
            return View(clilist);
        }



        // GET: Cliente/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.FindByIDAsync(id.Value);


            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }



        // GET: Clientes/Create
        public async Task<IActionResult> Create()
        {
            if (ModelState.IsValid)
            {
                return View();
                                
            }

            var clientes = await _clienteService.FindAllAsync();
            var vwModel = new ClienteFormViewModel { Clientes = clientes };
            return View(vwModel);
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            // Se o modelo não foi validado

            if (!ModelState.IsValid)
            {
                var clientes = await _clienteService.FindAllAsync();
                ClienteFormViewModel viewModel = new ClienteFormViewModel { Clientes = clientes };
                return View(viewModel);
            }

            await _clienteService.InsertAsync(cliente);
            return RedirectToAction(nameof(Index));
        }


        // GET: Clientes/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.FindByIDAsync(id.Value);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }


        // POST: Clientes/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clienteService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        // GET: Clientes/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.FindByIDAsync(id.Value);


            if (cliente == null)
            {
                return NotFound();
            }

            var clientes = await _clienteService.FindAllAsync();
            ClienteFormViewModel viewModel = new ClienteFormViewModel { Clientes = clientes };

            return View(viewModel);
        }


        // POST: Clientes/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (id != cliente.IdCli)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _clienteService.UpdateAsync(cliente);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != cliente.IdCli)
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
                var clientes = await _clienteService.FindAllAsync();
                ClienteFormViewModel viewModel = new ClienteFormViewModel { Clientes = clientes };
                return View(viewModel);
            }
        }
                     

    }          
}
