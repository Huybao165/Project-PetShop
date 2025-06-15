namespace petshop.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<product> Products { get; set; }
        public IEnumerable<danhmuc> Danhmucs { get; set; }

        public int? SelectedCategoryId { get; set; }
        public string SearchTerm { get; set; }
        public string SortOrder { get; set; }

     
    }

}
