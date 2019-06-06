using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SisVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace SisVendas.Services
{
    public class ClienteService
    {
        //Cria o realcionamento com SisVendasContext

        private readonly SisVendasContext _context;

        public ClienteService(SisVendasContext context)
        {
            _context = context;
        }


        // GET: Clientes
        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: Cliente ID
        public async Task<Cliente> FindByIDAsync(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(cli => cli.IdCli == id);
        }


        // Insert: Cliente 
        public async Task InsertAsync(Cliente cliente)
        {
            try
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // Remove: Cliente 
        public async Task RemoveAsync(int id)
        {
            // Verifica se ID existe
            bool HasAny = await _context.Clientes.AnyAsync(Cliente => Cliente.IdCli == id);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }

            try
            {
                Cliente cliente = await _context.Clientes.FindAsync(id);
                _context.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // Update: Cliente 
        public async Task UpdateAsync(Cliente cliente)
        {
            // Verifica se ID existe
            bool HasAny = await _context.Clientes.AnyAsync(Cliente => Cliente.IdCli == cliente.IdCli);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }

            try
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}

        
