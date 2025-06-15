using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using petshop.Models;
using petshop.Models.Interface;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace petshop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        // Hiển thị giỏ hàng
        public IActionResult Index()
        {
            var cartItems = _cartRepository.GetAllCartItems();
            var cartTotal = _cartRepository.GetCartTotal();

            ViewBag.Total = cartTotal.ToString("N0") + " VNĐ"; // định dạng tiền

            UpdateCartCount(); // Cập nhật số lượng sản phẩm trong session

            return View(cartItems);
        }

        // Thêm sản phẩm vào giỏ – chỉ yêu cầu login nếu chưa có
        public IActionResult Add(int id, string returnUrl = null)
        {
            if (!User.Identity.IsAuthenticated)
            {
                var redirectUrl = Url.Action("Add", "Cart", new { id = id, returnUrl = returnUrl ?? Url.Action("Index", "Cart") });
                return RedirectToPage("/Account/Login", new { area = "Identity", returnUrl = redirectUrl });
            }

            var product = _cartRepository.GetProductById(id);
            if (product == null)
                return NotFound();

            _cartRepository.AddCart(product);
            UpdateCartCount();

            if (!string.IsNullOrEmpty(returnUrl))
                return LocalRedirect(returnUrl);

            return RedirectToAction("Index");
        }

        // Tăng số lượng sản phẩm
        [HttpPost]
        public async Task<IActionResult> Increase(int id)
        {
            await _cartRepository.IncreaseQuantity(id.ToString());
            return RedirectToAction("Index");
        }

        // Giảm số lượng sản phẩm
        [HttpPost]
        public async Task<IActionResult> Decrease(int id)
        {
            await _cartRepository.DecreaseQuantity(id.ToString());
            return RedirectToAction("Index");
        }

        // Xoá sản phẩm khỏi giỏ
        public IActionResult Remove(int id)
        {
            var product = _cartRepository.GetProductById(id);
            if (product != null)
            {
                _cartRepository.RemoveCart(product);
            }

            UpdateCartCount();
            return RedirectToAction("Index");
        }

        // Xoá toàn bộ giỏ
        public IActionResult Clear()
        {
            _cartRepository.ClearCart();
            HttpContext.Session.SetInt32("CartCount", 0);
            return RedirectToAction("Index");
        }

        // Thanh toán – bắt buộc login
        [HttpGet]
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(OrderViewModel model)
        {
            var cartItems = _cartRepository.GetAllCartItems();

            if (!ModelState.IsValid)
                return View(model);

            if (cartItems == null || !cartItems.Any())
            {
                TempData["Error"] = "Giỏ hàng trống.";
                return RedirectToAction("Index");
            }

            var order = new
            {
                FullName = model.FullName,
                Phone = model.Phone,
                Address = model.Address,
                Items = cartItems,
                Total = _cartRepository.GetCartTotal()
            };

            _cartRepository.ClearCart();
            HttpContext.Session.SetInt32("CartCount", 0);

            return View("OrderConfirmation", order);
        }

        private void UpdateCartCount()
        {
            var totalItems = _cartRepository.GetAllCartItems().Sum(item => item.Qty);
            HttpContext.Session.SetInt32("CartCount", totalItems);
        }
    }
}
