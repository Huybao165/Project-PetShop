using petshop.Data;
using petshop.Models.Interface;

namespace petshop.Models.Service
{
    public class ProductRepository:IProductRepository
    {
        private PetShopContextDb db;
        public ProductRepository(PetShopContextDb db)
        {
            this.db = db;
        }
        public IEnumerable<product> GetAllProducts()
        {
            return db.products;
        }
        public product? GetProductDetail(int id)
        {
            return db.products.FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<product> Gettrending()
        {
            return db.products.Where(p => p.istrending);
        }
    }
}
