MODULE ĐÃ THÊM
1. Menu
- Xem danh sách món
- Thêm món
- Sửa món
- Đổi trạng thái đang bán / ngừng bán
- Quản lý giá S / M / L
- Quản lý tồn kho và mức nhập lại

2. Payment
- Danh sách loại thanh toán
- Create payment
- Xem payment
- Tạo QR
- Check thanh toán thành công (đánh dấu Paid)

CÁCH CHẠY
1. Mở SQL Server Management Studio 2022
2. Chạy file database_menu_payment_update.sql
3. Mở solution ECoffeeApp.sln bằng Visual Studio 2022
4. Restore NuGet packages
5. Run app
6. Vào menu Quản lý > Menu hoặc Quản lý > Thanh toán

LƯU Ý
- Kết nối hiện đang dùng: Server=localhost,9999;Database=ECoffeeDb;User Id=sa;Password=SqlServer@2024;TrustServerCertificate=True
- Payment tạo QR ở mức nội bộ demo cho desktop app, phù hợp yêu cầu tạo / hiển thị QR trong form.
