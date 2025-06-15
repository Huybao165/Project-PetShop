namespace petshop.Models.Interface
{
    public interface ICartRepository
    {
        void AddCart(product product);
        int RemoveCart(product product);
        List<Cart> GetAllCartItems();
        void ClearCart();
        decimal GetCartTotal();
        Task<bool> IncreaseQuantity(string productId);
        Task<bool> DecreaseQuantity(string productId);

        // THÊM HÀM NÀY ĐỂ LẤY SẢN PHẨM
        product? GetProductById(int id);
    }
}
