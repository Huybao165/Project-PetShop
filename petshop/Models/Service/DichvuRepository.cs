using Microsoft.EntityFrameworkCore;
using petshop.Data;
using petshop.Models.Interface;

namespace petshop.Models.Service
{
    public class DichvuRepository:IDichvuRepository
    {
        private PetShopContextDb db;
        public DichvuRepository(PetShopContextDb db)
        {   
            this.db = db;
        }
        public IEnumerable<dichvu> GetAllProducts()
        {
            return db.dichvus;
        }
        public dichvu GetProductById(int id) 
        {
            return db.dichvus.FirstOrDefault(d => d.Id== id);
        }
    }
}