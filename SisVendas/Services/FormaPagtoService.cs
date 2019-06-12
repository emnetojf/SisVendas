using Microsoft.EntityFrameworkCore;
using SisVendas.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisVendas.Services
{
    public class FormaPagtoService
    {

        //Cria o realcionamento com SisVendasContext

        private readonly SisVendasContext _context;

        public FormaPagtoService(SisVendasContext context)
        {
            _context = context;
        }


        // GET: Pagtos
        public async Task<List<FormaPagto>> FindAllAsync()
        {
            return await _context.FormaPagtos.ToListAsync();
        }

        // GET: Pagto ID
        public async Task<FormaPagto> FindByIDAsync(int id)
        {
            return await _context.FormaPagtos.FirstOrDefaultAsync(pagto => pagto.IdPagto == id);
        }


        // Insert: Pagtos 
        public async Task InsertAsync(FormaPagto formaPagto)
        {
            try
            {
                _context.Add(formaPagto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // Remove: Pagtos 
        public async Task RemoveAsync(int id)
        {
            // Verifica se ID existe
            bool HasAny = await _context.FormaPagtos.AnyAsync(Pagto => Pagto.IdPagto == id);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }

            try
            {
                FormaPagto formaPagto = await _context.FormaPagtos.FindAsync(id);
                _context.Remove(formaPagto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // Update: Pagtos 
        public async Task UpdateAsync(FormaPagto formaPagto)
        {
            // Verifica se ID existe
            bool HasAny = await _context.FormaPagtos.AnyAsync(Pagto => Pagto.IdPagto == formaPagto.IdPagto);

            if (!HasAny)
            {
                throw new Exception("Id não existe");
            }

            try
            {
                _context.Update(formaPagto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
