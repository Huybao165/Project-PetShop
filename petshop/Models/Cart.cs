namespace petshop.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public product? product { get; set; }
        public int Qty { get; set; }
        public string? CartId { get; set; }
    }
}
