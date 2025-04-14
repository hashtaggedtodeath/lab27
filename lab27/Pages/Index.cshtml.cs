// Pages/Suppliers/Index.cshtml.cs
using lab27;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
