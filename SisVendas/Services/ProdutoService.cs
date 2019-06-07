using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SisVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace SisVendas.Services
{
    public class ProdutoService
    {

        //Cria o realcionamento com SisVendasContext

        private readonly SisVendasContext _context;

        public ProdutoService(SisVendasContext context)
        {
            _context = context;
        }


        // GET: Produtos
        public async Task<List<Produto>> FindAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        // GET: Produto ID
        public async Task<Produto> FindByIDAsync(int id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(prod => prod.IdProd == id);
        }


        // Insert: Produto  
        public async Task InsertAsync(Produto produto)
        {
            try
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // Remove: Produto 
        public async Task RemoveAsync(int id)
        {
            // Verifica se ID existe
            bool HasAny = await _context.Produtos.AnyAsync(prod => prod.IdProd == id);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }

            try
            {
                Produto produto  = await _context.Produtos.FindAsync(id);
                _context.Remove(produto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // Update: Produto 
        public async Task UpdateAsync(Produto produto)
        {
            // Verifica se ID existe
            bool HasAny = await _context.Produtos.AnyAsync(prod => prod.IdProd == produto.IdProd);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }

            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }





    }
}
