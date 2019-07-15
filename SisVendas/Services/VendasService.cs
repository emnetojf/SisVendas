using Microsoft.EntityFrameworkCore;
using SisVendas.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisVendas.Services
{
    public class VendasService
    {

        //Cria o realcionamento com SisVendasContext

        private readonly SisVendasContext _context;

        public VendasService(SisVendasContext context)
        {
            _context = context;
        }


        // GET: Vendas
        public async Task<List<Vendas>> FindAllAsync()
        {
            return await _context.Vendas
                                 .Include(v => v.Cliente)
                                 .Include(v => v.Pagto)
                                 .Include(v => v.Vendedor)                                 
                                 .ToListAsync();
        }



        // GET: Vendas ID
        public async Task<Vendas> FindByIDAsync(int id)
        {
            return await _context.Vendas
                                 .Include(v => v.Cliente)
                                 .Include(v => v.Pagto)
                                 .Include(v => v.Vendedor)
                                 .FirstOrDefaultAsync(vend => vend.IdVenda == id);
        }


        // GET: Vendas ClienteId, VendedorId, DtVend
        
        public async Task<Vendas> FindByVendaAsync(Vendas venda)
        {
            return await _context.Vendas
                                 .FirstOrDefaultAsync(v => v.dtVenda == venda.dtVenda && v.VendedorId == venda.VendedorId && v.ClienteId == venda.ClienteId);
        }
        

        // Insert: Vendas 
        public async Task InsertAsync(Vendas vendas)
        {
            try
            {                
                _context.Add(vendas);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }


        // Insert: ItensVendas 
        
        public async Task InsertItensVendAsync(ItemVendas itemVendas)
        {
            try
            {
                _context.ItemVendas.Add(itemVendas);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        


        // Remove: Vendas 
        public async Task RemoveAsync(int id)
        {
            // Verifica se ID existe
            bool HasAny = await _context.Vendas.AnyAsync(vend => vend.IdVenda == id);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }


            // Verifica se IDVendas no Item Vendas existe
            HasAny = await _context.ItemVendas.AnyAsync(item => item.VendasId == id);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }

            /*           
            try
            {
                
                ItemVendas itemVendas = await _context.ItemVendas.FindAsync(id);
                /*
                _context.Remove(itemVendas);
                await _context.SaveChangesAsync();
                
                Vendas venda = await _context.Vendas.FindAsync(id);
                venda.ItemVendas.Remove(itemVendas);

                _context.Remove(venda);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            */    
        }


        // Update: Vendas 
        public async Task UpdateAsync(Vendas vendas)
        {
            // Verifica se ID existe
            bool HasAny = await _context.Vendas.AnyAsync(vend => vend.IdVenda == vendas.IdVenda);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }

            /*
            , ItemVendas itemVendas

            // Verifica se IDVendas no Item Vendas existe
            HasAny = await _context.ItemVendas.AnyAsync(item => item.VendasId == itemVendas.VendasId);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }
            
            /*
            try
            {
                _context.Update(itemVendas);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            */

            try
            {
                //vendas.ItemVendas.Add(itemVendas);
                _context.Update(vendas);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
