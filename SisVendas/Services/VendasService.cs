using Microsoft.EntityFrameworkCore;
using SisVendas.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

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
        public async Task<System.Collections.Generic.List<Vendas>> FindAllAsync()
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

            var venda = await _context.Vendas
                                 .Include(v => v.Cliente)
                                 .Include(v => v.Pagto)
                                 .Include(v => v.Vendedor)
                                 .FirstOrDefaultAsync(vend => vend.IdVenda == id);
            return venda;
        }


        // GET: Vendas ClienteId, VendedorId, DtVend

        public async Task<Vendas> FindByVendaAsync(Vendas venda)
        {
            return await _context.Vendas
                                 .FirstOrDefaultAsync(v => v.dtVenda == venda.dtVenda && v.VendedorId == venda.VendedorId && v.ClienteId == venda.ClienteId);
        }


        // GET: ItemVendas ID

        public async Task<System.Collections.Generic.List<ItemVendas>> FindItemVendaByIDAsync(int? id)
        {
            return await _context.ItemVendas
                                 .Include(i => i.Produto)
                                 .Include(i => i.Vendas)
                                 .Include(i => i.Vendas.Cliente)
                                 .Include(i => i.Vendas.Pagto)
                                 .Include(i => i.Vendas.Vendedor)
                                 .Where(m => m.VendasId == id)
                                 .ToListAsync();
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
                 await _context.Database.ExecuteSqlCommandAsync(
                      "Insert into ItemVendas Values(@VendasId, @ProdutoId, @douQuant, @douValor)",
                        new SqlParameter("VendasId", itemVendas.VendasId),
                        new SqlParameter("ProdutoId", itemVendas.ProdutoId),
                        new SqlParameter("douQuant", itemVendas.douQuant),
                        new SqlParameter("douValor", itemVendas.douValor)
                );               
               
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

            // Exclui os Itens da Venda
            await RemoveItensVendAsync(id);

            // Exclui a Venda
            var vendas = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(vendas);
            await _context.SaveChangesAsync();

        }

        public async Task RemoveItensVendAsync(int id)
        {
            await _context.Database.ExecuteSqlCommandAsync($"Delete from ItemVendas where VendasId = {id}");           
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

            try
            {
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
