using Microsoft.EntityFrameworkCore;
using petshop.Data;
using petshop.Models.Interface;

namespace petshop.Models.Service
{
    public class CartRepository : ICartRepository
    {
        private PetShopContextDb db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartRepository(PetShopContextDb db)
        {
            this.db = db;
        }
        public CartRepository(PetShopContextDb db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            _httpContextAccessor = httpContextAccessor;

            InitializeCartId();
        }
        private void InitializeCartId()
        {
            ISession? session = _httpContextAccessor.HttpContext?.Session;
            string? storedCartId = session?.GetString("CartId");

            if (string.IsNullOrEmpty(storedCartId))
            {
                CartId = Guid.NewGuid().ToString();
                session?.SetString("CartId", CartId);
            }
            else
            {
                CartId = storedCartId;
            }
        }
        public List<Cart>? carts { get; set; }
        public string? CartId { get; set; }


        public static CartRepository GetCart(IServiceProvider services)
        {
            // Get both required services from the IServiceProvider
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            PetShopContextDb context = services.GetService<PetShopContextDb>()
                ?? throw new Exception("Error initializing PetShopContextDb");
            IHttpContextAccessor httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);


            return new CartRepository(context, httpContextAccessor)
            {
                CartId = cartId
            };
        }

        public void AddCart(product product)
        {
            var CartItem = db.Carts.FirstOrDefault(s =>
                s.product.Id == product.Id && s.CartId == CartId);

            if (CartItem == null)
            {
                CartItem = new Cart
                {
                    CartId = CartId,
                    product = product,
                    Qty = 1,
                };
                db.Carts.Add(CartItem);
            }
            else
            {
                CartItem.Qty++;
            }

            db.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = db.Carts
                .Where(s => s.CartId == CartId);

            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();
        }

        public List<Cart> GetAllCartItems()
        {
            return carts ??= db.Carts
                .Where(s => s.CartId == CartId)
                .Include(p => p.product)
                .ToList();
        }

        public decimal GetCartTotal()
        {
            var totalCost = db.Carts
                .Where(s => s.CartId == CartId)
                .Select(s => s.product.price * s.Qty)
                .Sum();

            return totalCost;
        }

        public int RemoveCart(product product)
        {
            var CartItem = db.Carts.FirstOrDefault(s =>
                s.product.Id == product.Id && s.CartId == CartId);

            var quantity = 0;

            if (CartItem != null)
            {
                db.Carts.Remove(CartItem);
            }

            db.SaveChanges();
            return quantity;
        }
        public async Task<bool> IncreaseQuantity(string productId)
        {
            if (!int.TryParse(productId, out int parsedProductId))
            {
                return false;
            }

            var cartItem = await db.Carts.FirstOrDefaultAsync(s =>
                s.product.Id == parsedProductId && s.CartId == CartId);
            if (cartItem == null)
            {
                return false;
            }

            cartItem.Qty++;
            await db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DecreaseQuantity(string productId)
        {

            if (!int.TryParse(productId, out int parsedProductId))
            {
                return false;
            }
            var cartItem = await db.Carts.FirstOrDefaultAsync(s =>
                s.product.Id == parsedProductId && s.CartId == CartId);

            if (cartItem == null)
            {
                return false;
            }

            if (cartItem.Qty > 1)
            {
                cartItem.Qty--;
            }
            else
            {

                db.Carts.Remove(cartItem);
            }

            await db.SaveChangesAsync();
            return true;
        }
        public product? GetProductById(int id)
        {
            return db.products.FirstOrDefault(p => p.Id == id);
        }
    }
}
