using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using petshop.Data;
using petshop.Models;


namespace petshop.Controllers
{
    public class DanhmucController : Controller
    {
        private readonly PetShopContextDb _context;

        public DanhmucController(PetShopContextDb context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
     string sortOrder = "",
     string searchTerm = "",
     int? categoryId = null)
        {
            var query = _context.products.Include(p => p.danhmucs).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(p => p.name.Contains(searchTerm));

            if (categoryId.HasValue)
                query = query.Where(p => p.danhmucid == categoryId.Value);

            query = sortOrder switch
            {
                "price_asc" => query.OrderBy(p => p.price),
                "price_desc" => query.OrderByDescending(p => p.price),
                _ => query.OrderBy(p => p.name),
            };

            var products = await query.ToListAsync();

            var viewModel = new ProductListViewModel
            {
                Products = products,
                Danhmucs = await _context.danhmucs.ToListAsync(),
                SelectedCategoryId = categoryId,
                SearchTerm = searchTerm,
                SortOrder = sortOrder,

                // Bỏ PagingInfo
               // PagingInfo = null
            };

            return View(viewModel);
        }
    }
}
