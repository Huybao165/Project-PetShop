using Microsoft.EntityFrameworkCore;
using petshop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace petshop.Data
{
    public class PetShopContextDb : IdentityDbContext
    {
        public PetShopContextDb(DbContextOptions<PetShopContextDb> options) : base(options)
        {
        }
        public DbSet<product> products { get; set; }
        public DbSet<danhmuc> danhmucs { get; set; }
        public DbSet<dichvu> dichvus { get; set; }
        public DbSet<Contact> ContactMessages  { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<LichHen> LichHens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<product>()
                .HasOne(p => p.danhmucs)
                .WithMany(c => c.products)
                .HasForeignKey(p => p.danhmucid);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<dichvu>().HasData(
                new dichvu
                {
                    Id = 1,
                    dichvuName = "Chăm sóc thú cưng",
                    img = "https://images.unsplash.com/photo-1583512603805-3cc6b41f3edb?ixlib=rb-4.0.3&auto=format&fit=crop&w=1350&q=80",
                    dichvuDescription= "Dịch vụ chăm sóc toàn diện bao gồm tắm rửa, cắt tỉa lông, và kiểm tra sức khỏe cơ bản.",
                    dichviPrice = 200000,
                },
                 new dichvu
                 {
                     Id = 2,
                     dichvuName = "Spa thú cưng thư giãn",
                     img = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQOr2pvyZ7dan2ZdF2SLnOCAZ1y5H66Tos7JgW2Rt3Lw9rHEHHx9cbvmA655ZsT255bZZNqdB5fKfkcnIXt38F7GZZku0FYdm_yP9NmVZjvFnrCRW4N_vt5oQ",
                     dichvuDescription = "Dịch vụ spa cao cấp cho thú cưng gồm tắm nước ấm, massage nhẹ nhàng và chăm sóc lông mềm mượt.",
                     dichviPrice = 250000,
                 },
                 new dichvu
                 {
                     Id = 3,
                     dichvuName = "Tắm rửa và vệ sinh tai",
                     img = "https://iupets.vn/wp-content/uploads/2020/05/dich_vu_tam_cho_meo_gia_re.jpg",
                     dichvuDescription = "Dịch vụ tắm gội bằng sữa tắm chuyên dụng, kết hợp vệ sinh tai sạch sẽ cho thú cưng.",
                     dichviPrice = 150000,
                 },
new dichvu
{
    Id = 4,
    dichvuName = "Cắt móng và làm sạch bàn chân",
    img = "https://cdn.tgdd.vn/Files/2021/04/28/1346971/co-nen-cat-mong-cho-meo-khong-cach-cat-mong-cho-meo-don-gian-hieu-qua-202104281357440647.jpg",
    dichvuDescription = "Dịch vụ cắt móng tay, móng chân và làm sạch bàn chân chuyên nghiệp cho chó mèo.",
    dichviPrice = 100000,
},
new dichvu
{
    Id = 5,
    dichvuName = "Cạo lông vệ sinh vùng kín",
    img = "https://kokopet.vn/wp-content/uploads/2025/01/Thiet-ke-chua-co-ten-15-1.png",
    dichvuDescription = "Dịch vụ cạo lông vùng kín giúp thú cưng sạch sẽ, hạn chế nhiễm khuẩn và mùi hôi.",
    dichviPrice = 120000,
},
new dichvu
{
    Id = 6,
    dichvuName = "Tư vấn dinh dưỡng và sức khỏe cơ bản",
    img = "https://product.hstatic.net/200000731893/product/cham-soc-meo_8b9638608af64d62956ff622d3117d54.png",
    dichvuDescription = "Hỗ trợ chủ nuôi xây dựng chế độ ăn và chăm sóc cơ bản phù hợp với từng giống thú cưng.",
    dichviPrice = 80000,
}

                );
            modelBuilder.Entity<danhmuc>().HasData(
               new danhmuc
               {
                   danhmucid = 1,
                   danhmucname = "Thức ăn ",
               },
               new danhmuc
               {
                   danhmucid = 2,
                   danhmucname = "Phụ kiện",
               },
               new danhmuc
               {
                   danhmucid = 3,
                   danhmucname = "Đồ chơi ",
               },
                new danhmuc
                {
                    danhmucid = 4,
                    danhmucname = "Thuốc ",
                }
               
               );
            modelBuilder.Entity<product>().HasData(
                new product
                {
                    Id = 1,
                    name = "Cát vệ sinh cho mèo",
                    danhmucid = 2,
                    price = 1000000,
                    description = "Thức ăn Royal Canin được thiết kế đặc biệt để đáp ứng nhu cầu dinh dưỡng của mèo ở mọi lứa tuổi. Thành phần giàu protein, vitamin và khoáng chất giúp mèo khỏe mạnh và lông bóng mượt.",
                    detail = "Thành phần: Protein gà, gạo, ngô, chất xơ thực vật, vitamin A, D3, E...\r\n\r\nTrọng lượng: 2kg\r\n\r\nPhù hợp: Mèo từ 6 tháng tuổi trở lên",
                    image = "https://bizweb.dktcdn.net/thumb/grande/100/348/235/products/e781c917-30a3-4c3d-a2e6-bdf5432c9eaf.jpg",
                    istrending = true
                },
                new product
                {
                    Id = 2,
                    name = "Cat Foods",
                    danhmucid = 1,
                    price = 320000,
                    description = "Thức ăn hạt dành cho mèo sống trong nhà, giúp kiểm soát lông rụng và giảm mùi phân.",
                    detail = "Thành phần: Protein gà, ngô, chất xơ, vitamin...\r\n\r\nTrọng lượng: 2kg\r\n\r\nPhù hợp: Mèo trưởng thành",
                    image = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-m04hrajmdip91c",
                    istrending = true
                },

new product
{
    Id = 3,
    name = "Bát ăn inox cho mèo",
    danhmucid = 2,
    price = 45000,
    description = "Bát ăn inox cao cấp không gỉ, dễ vệ sinh và an toàn cho mèo.",
    detail = "Chất liệu: Inox 304\r\n\r\nĐường kính: 15cm\r\n\r\nMàu sắc: Bạc",
    image = "https://product.hstatic.net/200000264739/product/bat_an_don_inox_cao_cap_van_trai_tim_cho_cho_meo_2_42709d2ac68b4fce874c17975a091cac_master.jpg",
    istrending = false
},

new product
{
    Id = 4,
    name = "Cây cào móng 3 tầng cho mèo",
    danhmucid = 2,
    price = 260000,
    description = "Phụ kiện giúp mèo cào móng, vui chơi và vận động tại nhà.",
    detail = "Chất liệu: Gỗ ép, vải nỉ\r\n\r\nChiều cao: 70cm\r\n\r\nMàu sắc: Xám",
    image = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lz7fabp7r99d4e",
    istrending = true
},

new product
{
    Id = 5,
    name = "Chuột đồ chơi có lông",
    danhmucid = 3,
    price = 20000,
    description = "Chuột đồ chơi mềm, có lông mô phỏng như thật, giúp mèo giải trí và vận động.",
    detail = "Chất liệu: Vải lông, nhựa\r\n\r\nChiều dài: 8cm\r\n\r\nMàu sắc: Trắng, nâu",
    image = "https://product.hstatic.net/200000264739/product/chuot_long_30441f2fd56a4ac38b52f4a42e78fcb9_master.jpg",
    istrending = false
},

new product
{
    Id = 6,
    name = "Cần câu lông cho mèo",
    danhmucid = 3,
    price = 30000,
    description = "Cần câu có lông vũ tạo hứng thú chơi đùa cho mèo, tăng vận động và tương tác.",
    detail = "Chiều dài: 45cm\r\n\r\nChất liệu: Nhựa, lông vũ\r\n\r\nPhù hợp: Mọi giống mèo",
    image = "https://down-vn.img.susercontent.com/file/3a50c8e02c615173c2dafd844273bda2",
    istrending = true
},
 new product
 {
     Id = 7,
     name = "Pate cho mèo vị cá hồi",
     danhmucid = 1,
     price = 28000,
     description = "Pate mềm dễ ăn, giàu omega 3 từ cá hồi.",
     detail = "Khối lượng: 85g\r\nVị: Cá hồi\r\nPhù hợp: Mèo mọi lứa tuổi",
     image = "https://samyangvietnam.com/wp-content/uploads/2023/06/Pate-cho-meo-Dish-vi-Ca-ngu-trang-Ca-hoi.jpg",
     istrending = true
 },
new product
{
    Id = 8,
    name = "Thức ăn khô cho mèo lông dài",
    danhmucid = 1,
    price = 135000,
    description = "Giảm rụng lông, dễ tiêu hóa, dành cho mèo lông dài.",
    detail = "Khối lượng: 1.5kg\r\nHãng: Royal Cat\r\nVị: Gà",
    image = "https://www.vietpet.net/wp-content/uploads/2020/07/thuc-an-cho-meo-truong-thanh-long-dai-equilibrio-adult-cat-long-hair.jpg",
    istrending = false
},
new product
{
    Id = 9,
    name = "Bánh thưởng vị gà cho chó",
    danhmucid = 1,
    price = 45000,
    description = "Bánh mềm thơm ngon, phù hợp huấn luyện.",
    detail = "Khối lượng: 100g\r\nHình dạng nhỏ gọn\r\nKhông chất bảo quản",
    image = "https://image.made-in-china.com/202f0j00zAPhbfJyGeow/Beef-Flavor-Sticks-and-Cubes-Dog-Treats-Pet-Food-OEM-China.webp",
    istrending = false
},
new product
{
    Id = 10,
    name = "Thức ăn cho chó con vị sữa",
    danhmucid = 1,
    price = 110000,
    description = "Dành riêng cho chó con cần bổ sung canxi và dưỡng chất.",
    detail = "Khối lượng: 1kg\r\nVị: Sữa\r\nĐộ tuổi: 1–12 tháng",
    image = "https://kinpetshop.com/wp-content/uploads/thuc-an-hat-smartheart-danh-cho-cho-con-vi-bo-va-sua-.jpg",
    istrending = true
},
new product
{
    Id = 11,
    name = "Xúc xích cho mèo vị bò",
    danhmucid = 1,
    price = 18000,
    description = "Xúc xích mềm, giàu đạm, dễ tiêu hóa.",
    detail = "Gói 5 cây\r\nVị: Bò\r\nThích hợp thưởng hoặc bổ sung dinh dưỡng",
    image = "https://bizweb.dktcdn.net/thumb/grande/100/448/728/products/0eb97941-3a66-4d93-816a-3e0f30a5bc26.jpg?v=1740718268027",
    istrending = false
},
new product
{
    Id = 12,
    name = "Áo hoodie cho chó mèo",
    danhmucid = 2,
    price = 75000,
    description = "Áo ấm xinh xắn cho thú cưng mặc mùa lạnh.",
    detail = "Chất liệu: Nỉ bông\r\nSize: S – XL\r\nMàu: Đỏ, Xám, Xanh",
    image = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-ln771hvcoa1k52",
    istrending = true
},
new product
{
    Id = 13,
    name = "Bình nước uống tự động cho mèo",
    danhmucid = 2,
    price = 120000,
    description = "Luôn có nước sạch cho mèo, dung tích lớn.",
    detail = "Dung tích: 2.5L\r\nChất liệu: Nhựa ABS\r\nDễ vệ sinh",
    image = "https://www.petmart.vn/wp-content/uploads/2023/05/bo-bat-an-binh-nuoc-tu-dong-cho-cho-meo-paw-opaque-food-water-feeder4.jpg",
    istrending = false
},
new product
{
    Id = 14,
    name = "Chuồng lưới gấp gọn cho chó",
    danhmucid = 2,
    price = 350000,
    description = "Dễ gấp gọn, khung chắc chắn, có khay vệ sinh.",
    detail = "Size: 60x45x50cm\r\nChất liệu: Sắt sơn tĩnh điện",
    image = "https://down-vn.img.susercontent.com/file/vn-11134207-7qukw-lk8yvh3djt1013",
    istrending = true
},
new product
{
    Id = 15,
    name = "Máng ăn đôi cho chó mèo",
    danhmucid = 2,
    price = 65000,
    description = "Tiện lợi đựng cả thức ăn và nước, chống trượt.",
    detail = "Chất liệu: Nhựa PP\r\nKích thước: 30x15cm",
    image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQiRjbpYDnxItiN5vCyXxVXlUKIMxod-k1gw&s",
    istrending = false
},
new product
{
    Id = 16,
    name = "Khăn tắm thú cưng siêu thấm",
    danhmucid = 2,
    price = 40000,
    description = "Khô nhanh, thấm nước cực tốt, mềm mại.",
    detail = "Kích thước: 60x100cm\r\nChất liệu: Sợi microfiber",
    image = "https://down-vn.img.susercontent.com/file/ec6d9fd86b573fa7097c81f2924233e1",
    istrending = true
},
new product
{
    Id = 17,
    name = "Chuột đồ chơi chạy pin",
    danhmucid = 3,
    price = 59000,
    description = "Chuột máy chạy tự động, thu hút mèo đuổi bắt.",
    detail = "Chạy bằng pin AA\r\nChất liệu: Nhựa mềm\r\nKích thước: 12cm",
    image = "https://product.hstatic.net/200000263355/product/z4470610677922_b0082c16453b00e838ef44bf3fd330e5_ebd023487d514c019c06bd0d36862807_master.jpg",
    istrending = true
},
new product
{
    Id = 18,
    name = "Xương cao su phát âm cho chó",
    danhmucid = 3,
    price = 30000,
    description = "Phát tiếng kêu khi cắn, giúp giảm căng thẳng.",
    detail = "Chất liệu: Cao su mềm\r\nKích thước: 15cm\r\nMàu: Vàng, hồng",
    image = "https://miluxinh.com/wp-content/uploads/2022/05/136-xuong-cao-su-5.jpg",
    istrending = false
},
new product
{
    Id = 19,
    name = "Cần câu lông có chuông",
    danhmucid = 3,
    price = 32000,
    description = "Cần câu dài, lông mềm có chuông thu hút mèo chơi.",
    detail = "Chiều dài: 50cm\r\nChất liệu: Nhựa + lông vũ",
    image = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lxa17zvlb8pndb",
    istrending = false
},
new product
{
    Id = 20,
    name = "Quả bóng thông minh phát sáng",
    danhmucid = 3,
    price = 95000,
    description = "Bóng phát sáng khi lăn, giúp mèo chơi cả buổi tối.",
    detail = "Pin tích hợp\r\nTự động xoay\r\nĐường kính: 6cm",
    image = "https://assets.aemi.vn/images_resized/2024/9/5/1725548389447-465935",
    istrending = true
},
new product
{
    Id = 21,
    name = "Bánh xe chạy cho hamster",
    danhmucid = 3,
    price = 55000,
    description = "Bánh xe không gây ồn, cho hamster vận động mỗi ngày.",
    detail = "Đường kính: 18cm\r\nChất liệu: Nhựa dày",
    image = "https://www.ubuy.vn/productimg/?image=aHR0cHM6Ly9tLm1lZGlhLWFtYXpvbi5jb20vaW1hZ2VzL0kvNDFDWkYxTStvb0wuX1NTNDAwXy5qcGc.jpg",
    istrending = false
},
new product
{
    Id = 22,
    name = "Thuốc nhỏ mắt cho chó mèo",
    danhmucid = 4,
    price = 70000,
    description = "Làm dịu và sát khuẩn nhẹ vùng mắt bị viêm.",
    detail = "Dung tích: 10ml\r\nThành phần: Dung dịch sinh lý, kháng khuẩn nhẹ",
    image = "https://product.hstatic.net/200000350119/product/nho_mat_bio-gentadrop_c9f7984dd9d24410b938c0cf9f86583e_large.jpg",
    istrending = true
},
new product
{
    Id = 23,
    name = "Gel dưỡng móng chân thú cưng",
    danhmucid = 4,
    price = 55000,
    description = "Giúp dưỡng móng, giảm khô nứt móng chân.",
    detail = "Dung tích: 30ml\r\nThành phần: Vitamin E, dầu dưỡng",
    image = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSt22RpGPKIqtt3cdPdLWYRl9JStjhRpb3Y3cyU-E_5tJcNFQ2ha5KMjUwFBTijsPPiaOAW99aBzdKrz3TygDioTEIE-ieoiZ7XFtzHy4scWCbj7DQFnZVL",
    istrending = false
},
new product
{
    Id = 24,
    name = "Thuốc nhỏ gáy phòng ve rận BioPet",
    danhmucid = 4,
    price = 99000,
    description = "Ngăn ngừa và diệt ve rận cho chó mèo trong 1 tháng.",
    detail = "Gói 1ml\r\nSử dụng 1 lần/tháng\r\nKhông độc hại",
    image = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcS5o1ji-LB-r9OhjdasKBufIudKwsfpIJq6hhI5EfGR4xq1NL2zE65gkhHBu-C2PNXpFSGTs18bPGjpABCDzddfO5UgwYs02LQbhlv0SOH1wexrM-QkMyPY7w",
    istrending = true
},
new product
{
    Id = 25,
    name = "Bột tắm khô cho mèo",
    danhmucid = 4,
    price = 50000,
    description = "Không cần nước, tiện lợi tắm khô khử mùi cho mèo.",
    detail = "Dung tích: 100g\r\nMùi: Dâu\r\nDùng 1–2 lần/tuần",
    image = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcTVWn-Qkahi7U3FbPGzV6yMQsHfvC6GSU4UiQFKUiPtXwd6-n5ATMvM4ufUaBe1jlhPzbn6ulOpbkmFIpMYPWsore604okaUMaXb32d5A9Yd6wFCXAIjk-shA",
    istrending = false
}


                );

        }
    }
}

