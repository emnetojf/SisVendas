using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisVendas.Models;
using SisVendas.Models.ViewModels;
using SisVendas.Services;

namespace SisVendas.Controllers
{
    public class VendedoresController : Controller
    {


        //Cria o realcionamento com ProdutoService

        private readonly VendedorService _vendedorService;

        public VendedoresController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }


        // GET: Vendedores/Login
        [HttpGet]
<<<<<<< HEAD
        public IActionResult Login(int? id)
        {

            HttpContext.Session.SetString("IdUserLogado", string.Empty);
            HttpContext.Session.SetString("NomeUserLogado", string.Empty);

=======
        public IActionResult Login()
        {
>>>>>>> 7693781e8a6c592bd17689265d4c755874553199
            return View();
        }

        // POST: Vendedores/Login
        [HttpPost]
        public async Task<IActionResult> Login(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var loginok = await _vendedorService.ValidarLoginAsync(vendedor);

                if (loginok != null)
                {
<<<<<<< HEAD
                    String IdLogin = loginok.IdVend.ToString();
                    HttpContext.Session.SetString("IdUserLogado", IdLogin);
                    HttpContext.Session.SetString("NomeUserLogado", loginok.StrNomeVend);
=======
>>>>>>> 7693781e8a6c592bd17689265d4c755874553199
                    return RedirectToAction("index", "Home");
                }
                else
                {
<<<<<<< HEAD
                    TempData["ErroLogin"] = "Email ou Senha inválidos";
                }
            }

            return View();
        }

=======
                    TempData["ErroLogin"] = "Email ou Senha inválidos";    
                }
            }
            
            return View();
        }
                                           
>>>>>>> 7693781e8a6c592bd17689265d4c755874553199




        // GET: Vendedores
        public async Task<IActionResult> Index()
        {
            var vendlist = await _vendedorService.FindAllAsync();
            return View(vendlist);
        }



        // GET: Vendedor/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _vendedorService.FindByIDAsync(id.Value);


            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }



        // GET: Vendedores/Create
        public async Task<IActionResult> Create()
        {
            var vendedores = await _vendedorService.FindAllAsync();
            var vwModel = new VendedorFormViewModel { Vendedores = vendedores };
            return View(vwModel);
        }

        // POST: Vendedores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            // Se o modelo não foi validado

            if (!ModelState.IsValid)
            {
                var vendedores = await _vendedorService.FindAllAsync();
                VendedorFormViewModel vwModel = new VendedorFormViewModel { Vendedores = vendedores };
                return View(vwModel);
            }

            await _vendedorService.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }


        // GET: Vendedores/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _vendedorService.FindByIDAsync(id.Value);

            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }


        // POST: Vendedores/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _vendedorService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        // GET: Vendedores/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _vendedorService.FindByIDAsync(id.Value);


            if (vendedor == null)
            {
                return NotFound();
            }

            VendedorFormViewModel vwModel = new VendedorFormViewModel { Vendedor = vendedor };
            return View(vwModel);
        }


        // POST: Vendedores/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.IdVend)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vendedorService.UpdateAsync(vendedor);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != vendedor.IdVend)
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
                var vendedores = await _vendedorService.FindAllAsync();
                VendedorFormViewModel vwModel = new VendedorFormViewModel { Vendedores = vendedores };
                return View(vwModel);
            }
        }



    }
}
