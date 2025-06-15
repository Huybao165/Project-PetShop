using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace petshop.Migrations
{
    /// <inheritdoc />
    public partial class adg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "danhmucs",
                columns: new[] { "danhmucid", "danhmucname" },
                values: new object[] { 4, "Thuốc " });

            migrationBuilder.UpdateData(
                table: "dichvus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "dichviPrice", "dichvuDescription", "dichvuName", "img" },
                values: new object[] { 250000m, "Dịch vụ spa cao cấp cho thú cưng gồm tắm nước ấm, massage nhẹ nhàng và chăm sóc lông mềm mượt.", "Spa thú cưng thư giãn", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQOr2pvyZ7dan2ZdF2SLnOCAZ1y5H66Tos7JgW2Rt3Lw9rHEHHx9cbvmA655ZsT255bZZNqdB5fKfkcnIXt38F7GZZku0FYdm_yP9NmVZjvFnrCRW4N_vt5oQ" });

            migrationBuilder.InsertData(
                table: "dichvus",
                columns: new[] { "Id", "dichviPrice", "dichvuDescription", "dichvuName", "img" },
                values: new object[,]
                {
                    { 3, 150000m, "Dịch vụ tắm gội bằng sữa tắm chuyên dụng, kết hợp vệ sinh tai sạch sẽ cho thú cưng.", "Tắm rửa và vệ sinh tai", "https://iupets.vn/wp-content/uploads/2020/05/dich_vu_tam_cho_meo_gia_re.jpg" },
                    { 4, 100000m, "Dịch vụ cắt móng tay, móng chân và làm sạch bàn chân chuyên nghiệp cho chó mèo.", "Cắt móng và làm sạch bàn chân", "https://cdn.tgdd.vn/Files/2021/04/28/1346971/co-nen-cat-mong-cho-meo-khong-cach-cat-mong-cho-meo-don-gian-hieu-qua-202104281357440647.jpg" },
                    { 5, 120000m, "Dịch vụ cạo lông vùng kín giúp thú cưng sạch sẽ, hạn chế nhiễm khuẩn và mùi hôi.", "Cạo lông vệ sinh vùng kín", "https://kokopet.vn/wp-content/uploads/2025/01/Thiet-ke-chua-co-ten-15-1.png" },
                    { 6, 80000m, "Hỗ trợ chủ nuôi xây dựng chế độ ăn và chăm sóc cơ bản phù hợp với từng giống thú cưng.", "Tư vấn dinh dưỡng và sức khỏe cơ bản", "https://product.hstatic.net/200000731893/product/cham-soc-meo_8b9638608af64d62956ff622d3117d54.png" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "danhmucid", "description", "detail", "image", "istrending", "name", "price" },
                values: new object[,]
                {
                    { 7, 1, "Pate mềm dễ ăn, giàu omega 3 từ cá hồi.", "Khối lượng: 85g\r\nVị: Cá hồi\r\nPhù hợp: Mèo mọi lứa tuổi", "https://samyangvietnam.com/wp-content/uploads/2023/06/Pate-cho-meo-Dish-vi-Ca-ngu-trang-Ca-hoi.jpg", true, "Pate cho mèo vị cá hồi", 28000m },
                    { 8, 1, "Giảm rụng lông, dễ tiêu hóa, dành cho mèo lông dài.", "Khối lượng: 1.5kg\r\nHãng: Royal Cat\r\nVị: Gà", "https://www.vietpet.net/wp-content/uploads/2020/07/thuc-an-cho-meo-truong-thanh-long-dai-equilibrio-adult-cat-long-hair.jpg", false, "Thức ăn khô cho mèo lông dài", 135000m },
                    { 9, 1, "Bánh mềm thơm ngon, phù hợp huấn luyện.", "Khối lượng: 100g\r\nHình dạng nhỏ gọn\r\nKhông chất bảo quản", "https://image.made-in-china.com/202f0j00zAPhbfJyGeow/Beef-Flavor-Sticks-and-Cubes-Dog-Treats-Pet-Food-OEM-China.webp", false, "Bánh thưởng vị gà cho chó", 45000m },
                    { 10, 1, "Dành riêng cho chó con cần bổ sung canxi và dưỡng chất.", "Khối lượng: 1kg\r\nVị: Sữa\r\nĐộ tuổi: 1–12 tháng", "https://kinpetshop.com/wp-content/uploads/thuc-an-hat-smartheart-danh-cho-cho-con-vi-bo-va-sua-.jpg", true, "Thức ăn cho chó con vị sữa", 110000m },
                    { 11, 1, "Xúc xích mềm, giàu đạm, dễ tiêu hóa.", "Gói 5 cây\r\nVị: Bò\r\nThích hợp thưởng hoặc bổ sung dinh dưỡng", "https://bizweb.dktcdn.net/thumb/grande/100/448/728/products/0eb97941-3a66-4d93-816a-3e0f30a5bc26.jpg?v=1740718268027", false, "Xúc xích cho mèo vị bò", 18000m },
                    { 12, 2, "Áo ấm xinh xắn cho thú cưng mặc mùa lạnh.", "Chất liệu: Nỉ bông\r\nSize: S – XL\r\nMàu: Đỏ, Xám, Xanh", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-ln771hvcoa1k52", true, "Áo hoodie cho chó mèo", 75000m },
                    { 13, 2, "Luôn có nước sạch cho mèo, dung tích lớn.", "Dung tích: 2.5L\r\nChất liệu: Nhựa ABS\r\nDễ vệ sinh", "https://www.petmart.vn/wp-content/uploads/2023/05/bo-bat-an-binh-nuoc-tu-dong-cho-cho-meo-paw-opaque-food-water-feeder4.jpg", false, "Bình nước uống tự động cho mèo", 120000m },
                    { 14, 2, "Dễ gấp gọn, khung chắc chắn, có khay vệ sinh.", "Size: 60x45x50cm\r\nChất liệu: Sắt sơn tĩnh điện", "https://down-vn.img.susercontent.com/file/vn-11134207-7qukw-lk8yvh3djt1013", true, "Chuồng lưới gấp gọn cho chó", 350000m },
                    { 15, 2, "Tiện lợi đựng cả thức ăn và nước, chống trượt.", "Chất liệu: Nhựa PP\r\nKích thước: 30x15cm", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQiRjbpYDnxItiN5vCyXxVXlUKIMxod-k1gw&s", false, "Máng ăn đôi cho chó mèo", 65000m },
                    { 16, 2, "Khô nhanh, thấm nước cực tốt, mềm mại.", "Kích thước: 60x100cm\r\nChất liệu: Sợi microfiber", "https://down-vn.img.susercontent.com/file/ec6d9fd86b573fa7097c81f2924233e1", true, "Khăn tắm thú cưng siêu thấm", 40000m },
                    { 17, 3, "Chuột máy chạy tự động, thu hút mèo đuổi bắt.", "Chạy bằng pin AA\r\nChất liệu: Nhựa mềm\r\nKích thước: 12cm", "https://product.hstatic.net/200000263355/product/z4470610677922_b0082c16453b00e838ef44bf3fd330e5_ebd023487d514c019c06bd0d36862807_master.jpg", true, "Chuột đồ chơi chạy pin", 59000m },
                    { 18, 3, "Phát tiếng kêu khi cắn, giúp giảm căng thẳng.", "Chất liệu: Cao su mềm\r\nKích thước: 15cm\r\nMàu: Vàng, hồng", "https://miluxinh.com/wp-content/uploads/2022/05/136-xuong-cao-su-5.jpg", false, "Xương cao su phát âm cho chó", 30000m },
                    { 19, 3, "Cần câu dài, lông mềm có chuông thu hút mèo chơi.", "Chiều dài: 50cm\r\nChất liệu: Nhựa + lông vũ", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lxa17zvlb8pndb", false, "Cần câu lông có chuông", 32000m },
                    { 20, 3, "Bóng phát sáng khi lăn, giúp mèo chơi cả buổi tối.", "Pin tích hợp\r\nTự động xoay\r\nĐường kính: 6cm", "https://assets.aemi.vn/images_resized/2024/9/5/1725548389447-465935", true, "Quả bóng thông minh phát sáng", 95000m },
                    { 21, 3, "Bánh xe không gây ồn, cho hamster vận động mỗi ngày.", "Đường kính: 18cm\r\nChất liệu: Nhựa dày", "https://www.ubuy.vn/productimg/?image=aHR0cHM6Ly9tLm1lZGlhLWFtYXpvbi5jb20vaW1hZ2VzL0kvNDFDWkYxTStvb0wuX1NTNDAwXy5qcGc.jpg", false, "Bánh xe chạy cho hamster", 55000m },
                    { 22, 4, "Làm dịu và sát khuẩn nhẹ vùng mắt bị viêm.", "Dung tích: 10ml\r\nThành phần: Dung dịch sinh lý, kháng khuẩn nhẹ", "https://product.hstatic.net/200000350119/product/nho_mat_bio-gentadrop_c9f7984dd9d24410b938c0cf9f86583e_large.jpg", true, "Thuốc nhỏ mắt cho chó mèo", 70000m },
                    { 23, 4, "Giúp dưỡng móng, giảm khô nứt móng chân.", "Dung tích: 30ml\r\nThành phần: Vitamin E, dầu dưỡng", "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSt22RpGPKIqtt3cdPdLWYRl9JStjhRpb3Y3cyU-E_5tJcNFQ2ha5KMjUwFBTijsPPiaOAW99aBzdKrz3TygDioTEIE-ieoiZ7XFtzHy4scWCbj7DQFnZVL", false, "Gel dưỡng móng chân thú cưng", 55000m },
                    { 24, 4, "Ngăn ngừa và diệt ve rận cho chó mèo trong 1 tháng.", "Gói 1ml\r\nSử dụng 1 lần/tháng\r\nKhông độc hại", "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcS5o1ji-LB-r9OhjdasKBufIudKwsfpIJq6hhI5EfGR4xq1NL2zE65gkhHBu-C2PNXpFSGTs18bPGjpABCDzddfO5UgwYs02LQbhlv0SOH1wexrM-QkMyPY7w", true, "Thuốc nhỏ gáy phòng ve rận BioPet", 99000m },
                    { 25, 4, "Không cần nước, tiện lợi tắm khô khử mùi cho mèo.", "Dung tích: 100g\r\nMùi: Dâu\r\nDùng 1–2 lần/tuần", "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcTVWn-Qkahi7U3FbPGzV6yMQsHfvC6GSU4UiQFKUiPtXwd6-n5ATMvM4ufUaBe1jlhPzbn6ulOpbkmFIpMYPWsore604okaUMaXb32d5A9Yd6wFCXAIjk-shA", false, "Bột tắm khô cho mèo", 50000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dichvus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "dichvus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "dichvus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "dichvus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "danhmucs",
                keyColumn: "danhmucid",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "dichvus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "dichviPrice", "dichvuDescription", "dichvuName", "img" },
                values: new object[] { 200000m, "Dịch vụ chăm sóc toàn diện bao gồm tắm rửa, cắt tỉa lông, và kiểm tra sức khỏe cơ bản.", "Chăm sóc thú cưng", "https://images.unsplash.com/photo-1583512603805-3cc6b41f3edb?ixlib=rb-4.0.3&auto=format&fit=crop&w=1350&q=80" });
        }
    }
}
