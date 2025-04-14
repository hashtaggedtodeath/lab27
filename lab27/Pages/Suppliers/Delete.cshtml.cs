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
    public class DeleteModel : PageModel
    {
        private readonly WarehouseContext _context;

        public DeleteModel(WarehouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Supplier Supplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Supplier = await _context.Suppliers.FindAsync(id);

            if (Supplier == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Supplier = await _context.Suppliers.FindAsync(id);

            if (Supplier != null)
            {
                _context.Suppliers.Remove(Supplier);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
