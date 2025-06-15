namespace petshop.Models.Interface
{
    public interface IDichvuRepository
    {
        IEnumerable<dichvu> GetAllProducts();
        dichvu GetProductById(int id);
    }
}
