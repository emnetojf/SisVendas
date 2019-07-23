using Microsoft.EntityFrameworkCore; // async
using SisVendas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVendas.Services
{
    public class DepartamentoService
    {
        private readonly SisVendasContext _context;

        public DepartamentoService(SisVendasContext context)
        {
            _context = context;
        }

      
        // Async
        public async Task<System.Collections.Generic.List<Departamento>> FindAllAsync()
        {
            return await _context.Departamentos.OrderBy(depto => depto.strDepto).ToListAsync();
        }
    }
}
