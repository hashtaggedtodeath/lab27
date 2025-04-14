using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab27;

namespace lab27.Pages.Sales
{
    public class IndexModel : PageModel
    {
        private readonly lab27.WarehouseContext _context;

        public IndexModel(lab27.WarehouseContext context)
        {
            _context = context;
        }

        public IList<Sale> Sale { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Sale = await _context.Sales
                .Include(s => s.Customers)
                .Include(s => s.Products)
                .Include(s => s.Suppliers).ToListAsync();
        }
    }
}
