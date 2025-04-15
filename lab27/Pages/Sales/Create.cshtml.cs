using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab27;

namespace lab27.Pages.Sales
{
    public class CreateModel : PageModel
    {
        private readonly WarehouseContext _context;

        public CreateModel(WarehouseContext context)
        {
            _context = context;
        }

        public class SaleViewModel
        {
            public int ProductID { get; set; }
            public int SupplierID { get; set; }
            public int CustomerID { get; set; }
            public int QuantitySold { get; set; }
            public decimal TotalAmount { get; set; }

            public SelectList Products { get; set; } = default!;
            public SelectList Suppliers { get; set; } = default!;
            public SelectList Customers { get; set; } = default!;
        }

        [BindProperty]
        public SaleViewModel SaleVM { get; set; } = new();

        public void OnGet()
        {
            LoadSelectLists();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    LoadSelectLists();
                    return Page();
                }

                var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == SaleVM.ProductID);
                if (product == null)
                {
                    ModelState.AddModelError("", "Product not found.");
                    LoadSelectLists();
                    return Page();
                }

                var sale = new Sale
                {
                    ProductID = SaleVM.ProductID,
                    SupplierID = SaleVM.SupplierID,
                    CustomerID = SaleVM.CustomerID,
                    QuantitySold = SaleVM.QuantitySold,
                    TotalAmount = product.PurchasePrice * SaleVM.QuantitySold
                };

                _context.Sales.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ошибка: " + ex.Message);
                LoadSelectLists();
                return Page();
            }
        }

        private void LoadSelectLists()
        {
            SaleVM.Products = new SelectList(_context.Products, "ProductID", "Name");
            SaleVM.Suppliers = new SelectList(_context.Suppliers, "SupplierID", "Name");
            SaleVM.Customers = new SelectList(_context.Customers, "CustomerID", "Name");
        }
    }
}
