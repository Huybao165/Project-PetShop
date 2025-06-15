namespace petshop.Models
{
    public class danhmuc
    {
        public int danhmucid { get; set; }
        public string danhmucname { get; set; }
        public List<product> products { get; set; }

    }
}