using Microsoft.AspNetCore.Mvc;
using petshop.Models.Interface;
using petshop.Models;
using System;
using System.Linq;
using petshop.Data;

namespace petshop.Controllers
{
    public class DichvuController : Controller
    {
        private readonly IDichvuRepository dichvuRepository;
        private readonly PetShopContextDb _context;

        public DichvuController(IDichvuRepository dichvuRepository, PetShopContextDb context)
        {
            this.dichvuRepository = dichvuRepository;
            _context = context;
        }

        // Danh sách dịch vụ
        public IActionResult Index()
        {
            var list = dichvuRepository.GetAllProducts();
            return View(list);
        }

        // Hiển thị form đặt lịch (GET)
        [HttpGet]
        public IActionResult DatLich(int id)
        {
            var dichvu = dichvuRepository.GetProductById(id);
            if (dichvu == null)
            {
                return NotFound();
            }

            var model = new DatLichViewModel
            {
                DichVuId = dichvu.Id,
                TenDichVu = dichvu.dichvuName
            };

            return View(model);
        }

        // Xử lý đặt lịch (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DatLich(DatLichViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var datLich = new LichHen
            {
                DichVuId = model.DichVuId,
                TenKhach = model.TenKhach,
                SoDienThoai = model.SoDienThoai,
                NgayDat = DateTime.Now
            };

            _context.LichHens.Add(datLich);
            _context.SaveChanges();

            TempData["Success"] = "Đặt lịch thành công. Chúng tôi sẽ liên hệ bạn sớm!";
            return RedirectToAction("Index");
        }
    }
}
