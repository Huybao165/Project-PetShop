namespace petshop.Models.Interface
{
    public interface IProductRepository
    {
        IEnumerable<product> Gettrending();
        IEnumerable<product> GetAllProducts();
        product GetProductDetail(int id);
    }
}
