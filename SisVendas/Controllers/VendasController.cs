using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SisVendas.Models;
using SisVendas.Models.ViewModels;
using SisVendas.Services;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace SisVendas.Controllers
{
    public class VendasController : Controller
    {

        //Cria o realcionamento com ProdutoService

        private readonly VendasService _vendasService;
        private readonly VendedorService _vendedorService;
        private readonly ClienteService _clienteService;
        private readonly FormaPagtoService _formaPagtoService;
        private readonly ProdutoService _produtoService;

        public VendasController(VendasService vendasService, ProdutoService produtoService, VendedorService vendedorService, ClienteService clienteService, FormaPagtoService formaPagtoService)
        {
            _vendasService = vendasService;
            _produtoService = produtoService;
            _formaPagtoService = formaPagtoService;
            _vendedorService = vendedorService;
            _clienteService = clienteService;
        }




        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var vendlist = await _vendasService.FindAllAsync();
            return View(vendlist);
        }



        // GET: Vendas/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qryItemVendas = await _vendasService.FindItemVendaByIDAsync(id.Value);

            if (qryItemVendas == null)
            {
                return NotFound();
            }

            double Totalvenda = 0.00;

            for (int i = 0; i < qryItemVendas.Count; i++)
            {
                Totalvenda += qryItemVendas[i].douQuant * qryItemVendas[i].douValor;
            }


           ViewBag.Totalvenda = Totalvenda.ToString("F2");


            var venda = await _vendasService.FindByIDAsync(id.Value);

            if (venda == null)
            {
                return NotFound();
            }

            ViewBag.ItemVendas = qryItemVendas;
            
            return View(venda);
           
        }




        // GET: Vendas/Create
        public async Task<IActionResult> Create()
        {

            var clientes = await _clienteService.FindAllAsync();
            var vendedores = await _vendedorService.FindAllAsync();
            var formapagtos = await _formaPagtoService.FindAllAsync();
            var produtos = await _produtoService.FindAllAsync();
            var vwModel = new VendasFormViewModel {  Clientes = clientes, Vendedores = vendedores, FormaPagtos = formapagtos, Produtos = produtos };

            return View(vwModel);
        }

        // POST: Vendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendas venda)
        {
            // Se o modelo não foi validado

            if (!ModelState.IsValid)
            {
                var vendas = await _vendasService.FindAllAsync();

                VendasFormViewModel vwModel = new VendasFormViewModel { Vendas = vendas };
                return View(vwModel);
            }

            // Grava os dados
            await _vendasService.InsertAsync(venda);

            // Recupera a Venda gravada para selecionar o IdVend
            var VendID = venda.IdVenda;

            // Recupera a lista de itens produtos 
            System.Collections.Generic.List<ItemVendas> listItemVendas = JsonConvert.DeserializeObject<System.Collections.Generic.List<ItemVendas>>(venda.ListaProdutos);

            ItemVendas itemVendas;           

            for (int i = 0; i < listItemVendas.Count; i++)
            {
                itemVendas = new ItemVendas
                {
                    VendasId = VendID,
                    ProdutoId = listItemVendas[i].ProdutoId,
                    douQuant = listItemVendas[i].douQuant,
                    douValor = listItemVendas[i].douValor
                };

                // Grava os dados itens
                await _vendasService.InsertItensVendAsync(itemVendas);
            }
            
            return RedirectToAction(nameof(Index));
        }


        // GET: Vendas/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _vendasService.FindByIDAsync(id.Value);

            if (venda == null)
            {
                return NotFound();
            }

            var qryItemVendas = await _vendasService.FindItemVendaByIDAsync(id.Value);

            if (qryItemVendas == null)
            {
                return NotFound();
            }


            double Totalvenda = 0.00;

            for (int i = 0; i < qryItemVendas.Count; i++)
            {
                Totalvenda += qryItemVendas[i].douQuant * qryItemVendas[i].douValor;
            }


            ViewBag.Totalvenda = Totalvenda.ToString("F2");

            ViewBag.ItemVendas = qryItemVendas;

            return View(venda);
        }


        // POST: Vendas/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
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



        // GET: Vendas/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _vendasService.FindByIDAsync(id.Value);


            if (venda == null)
            {
                return NotFound();
            }


            var qryItemVendas = await _vendasService.FindItemVendaByIDAsync(id.Value);

            if (qryItemVendas == null)
            {
                return NotFound();
            }


            double Totalvenda = 0.00;

            ArrayList ListaProdutos = new ArrayList();
            ItemVendas itemVendas;

            for (int i = 0; i < qryItemVendas.Count; i++)
            {
                itemVendas = new ItemVendas
                {
                    ProdutoId = qryItemVendas[i].ProdutoId,
                    douQuant = qryItemVendas[i].douQuant,
                    douValor = qryItemVendas[i].douValor
                };

                ListaProdutos.Add(itemVendas);
                

                Totalvenda += qryItemVendas[i].douQuant * qryItemVendas[i].douValor;
            }

            
            ViewBag.Totalvenda = Totalvenda.ToString("F2");

            ViewBag.ItemVendas = qryItemVendas;

           
            

            var clientes = await _clienteService.FindAllAsync();
            var vendedores = await _vendedorService.FindAllAsync();
            var formapagtos = await _formaPagtoService.FindAllAsync();
            var produtos = await _produtoService.FindAllAsync();
          
            VendasFormViewModel vwModel = new VendasFormViewModel { Venda = venda, Clientes = clientes, Vendedores = vendedores, FormaPagtos = formapagtos, Produtos = produtos};
            return View(vwModel);
        }


        // POST: Vendas/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendas venda)
        {
            if (id != venda.IdVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vendasService.UpdateAsync(venda);

                    // Exclui os itens para adiciona-los novamente
                    await _vendasService.RemoveItensVendAsync(venda.IdVenda);

                    // Recupera a lista de itens produtos 
                    System.Collections.Generic.List<ItemVendas> listItemVendas = JsonConvert.DeserializeObject<System.Collections.Generic.List<ItemVendas>>(venda.ListaProdutos);

                    ItemVendas itemVendas;


                    for (int i = 0; i < listItemVendas.Count; i++)
                    {
                        itemVendas = new ItemVendas
                        {
                            VendasId = id,
                            ProdutoId = listItemVendas[i].ProdutoId,
                            douQuant = listItemVendas[i].douQuant,
                            douValor = listItemVendas[i].douValor
                        };

                        // Grava os dados itens
                        await _vendasService.InsertItensVendAsync(itemVendas);
                    }
                                                         

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != venda.IdVenda)
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
                var vend = await _vendasService.FindAllAsync();
                VendasFormViewModel vwModel = new VendasFormViewModel { Vendas = vend };
                return View(vwModel);
            }
        }

    }
}


