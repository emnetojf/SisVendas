using Microsoft.EntityFrameworkCore;
using SisVendas.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisVendas.Services
{
    public class VendedorService
    {

        //Cria o realcionamento com SisVendasContext

        private readonly SisVendasContext _context;

        public VendedorService(SisVendasContext context)
        {
            _context = context;
        }


        // GET: Login
        public async Task<Vendedor> ValidarLoginAsync(Vendedor vendedor)
        {   
            return await _context.Vendedor.FirstOrDefaultAsync(vend => vend.strEmail == vendedor.strEmail && vend.strSenha == vendedor.strSenha);
        }


                     

        // GET: Vendedor
        public async Task<System.Collections.Generic.List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        // GET: Vendedor ID
        public async Task<Vendedor> FindByIDAsync(int id)
        {
            return await _context.Vendedor.FirstOrDefaultAsync(vend => vend.IdVend == id);
        }


        // Insert: Vendedor  
        public async Task InsertAsync(Vendedor vendedor)
        {
            try
            {
                _context.Add(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // Remove: Vendedor 
        public async Task RemoveAsync(int id)
        {
            // Verifica se ID existe
            bool HasAny = await _context.Vendedor.AnyAsync(vend => vend.IdVend == id);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }

            try
            {
                Vendedor vendedor = await _context.Vendedor.FindAsync(id);
                _context.Remove(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // Update: Produto 
        public async Task UpdateAsync(Vendedor vendedor)
        {
            // Verifica se ID existe
            bool HasAny = await _context.Vendedor.AnyAsync(vend => vend.IdVend == vendedor.IdVend);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }

            try
            {
                _context.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



    }
}
