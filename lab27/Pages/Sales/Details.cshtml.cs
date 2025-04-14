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
    public class DetailsModel : PageModel
    {
        private readonly lab27.WarehouseContext _context;

        public DetailsModel(lab27.WarehouseContext context)
        {
            _context = context;
        }

        public Sale Sale { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.FirstOrDefaultAsync(m => m.SaleID == id);
            if (sale == null)
            {
                return NotFound();
            }
            else
            {
                Sale = sale;
            }
            return Page();
        }
    }
}
