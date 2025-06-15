namespace petshop.Models
{
    public class product
    {
        public int Id { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public decimal price { get; set; }
        public bool istrending { get; set; }
        public int danhmucid { get; set; }
        public danhmuc? danhmucs { get; set; }
    }
}
