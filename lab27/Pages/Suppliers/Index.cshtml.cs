using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab27;

namespace lab27.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly WarehouseContext _context;

        public IndexModel(WarehouseContext context)
        {
            _context = context;
        }

        public IList<Supplier> Suppliers { get; set; }

        public async Task OnGetAsync()
        {
            Suppliers = await _context.Suppliers.ToListAsync();
        }
    }
}
