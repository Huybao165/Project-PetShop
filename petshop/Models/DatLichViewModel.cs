using System.ComponentModel.DataAnnotations;

namespace petshop.Models
{
    public class DatLichViewModel
    {
        public int DichVuId { get; set; }
        public string? TenDichVu { get; set; }


        public string TenKhach { get; set; }

      
        public string SoDienThoai { get; set; }
    }
}
