# ECommerceApp - Ứng dụng Thương mại điện tử

Ứng dụng web thương mại điện tử được xây dựng bằng ASP.NET Core MVC với đầy đủ chức năng cho khách hàng và admin.

## Cấu trúc dự án

### Controllers
- **HomeController**: Trang chủ hiển thị sản phẩm
- **ProductController**: Xem danh sách và chi tiết sản phẩm
- **CartController**: Quản lý giỏ hàng
- **OrderController**: Đặt hàng và xem đơn hàng
- **AccountController**: Đăng ký, đăng nhập, quản lý tài khoản
- **AdminController**: Dashboard admin
- **AdminProductController**: Quản lý sản phẩm (CRUD)
- **AdminCategoryController**: Quản lý danh mục (CRUD)
- **AdminOrderController**: Quản lý đơn hàng
- **AdminUserController**: Quản lý người dùng

### Models
- **User**: Người dùng
- **Product**: Sản phẩm
- **Category**: Danh mục
- **Order**: Đơn hàng
- **OrderDetail**: Chi tiết đơn hàng
- **Cart**: Giỏ hàng
- **CartItem**: Sản phẩm trong giỏ hàng

## Chức năng khách hàng

| Trang | Controller | Action | Chức năng |
|-------|------------|--------|-----------|
| Trang chủ | HomeController | Index | Hiển thị sản phẩm |
| Xem sản phẩm | ProductController | List, Details(int id) | Xem danh sách và chi tiết sản phẩm |
| Giỏ hàng | CartController | Index, AddToCart(int id), Remove(int id) | Xem và chỉnh sửa giỏ hàng |
| Thanh toán | OrderController | Checkout, Confirm | Đặt đơn hàng |
| Đăng ký/Đăng nhập | AccountController | Register, Login, Logout | Xác thực người dùng |
| Đơn hàng của tôi | OrderController | MyOrders | Xem đơn hàng đã đặt |

## Chức năng Admin

| Trang | Controller | Action | Chức năng |
|-------|------------|--------|-----------|
| Dashboard | AdminController | Dashboard | Tổng quan hệ thống |
| Quản lý sản phẩm | AdminProductController | Index, Create, Edit, Delete | CRUD sản phẩm |
| Quản lý danh mục | AdminCategoryController | Index, Create, Edit, Delete | CRUD danh mục |
| Quản lý đơn hàng | AdminOrderController | Index, Details, UpdateStatus | Theo dõi và cập nhật đơn hàng |
| Quản lý người dùng | AdminUserController | Index, Delete | Danh sách và xóa tài khoản |

## Cài đặt và chạy

### Yêu cầu hệ thống
- .NET 8.0 SDK
- SQL Server hoặc SQL Server LocalDB
- Visual Studio 2022 hoặc VS Code

### Các bước cài đặt

1. **Clone dự án**
   ```bash
   git clone <repository-url>
   cd ECommerceApp
   ```

2. **Cài đặt dependencies**
   ```bash
   dotnet restore
   ```

3. **Tạo database**
   ```bash
   dotnet ef database update
   ```

4. **Chạy ứng dụng**
   ```bash
   dotnet run
   ```

5. **Truy cập ứng dụng**
   - Khách hàng: http://localhost:5000
   - Admin: http://localhost:5000/Admin
   - Tài khoản admin mặc định: admin/admin123

## Cấu hình

### Connection String
Chỉnh sửa connection string trong `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-server;Database=ECommerceApp;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### Seed Data
Dự án đã có sẵn dữ liệu mẫu:
- 3 danh mục: Điện tử, Thời trang, Sách
- 3 sản phẩm mẫu
- 1 tài khoản admin

## Tính năng chính

### Khách hàng
- Đăng ký/Đăng nhập tài khoản
- Xem danh sách sản phẩm theo danh mục
- Tìm kiếm sản phẩm
- Thêm sản phẩm vào giỏ hàng
- Quản lý giỏ hàng (thêm, sửa, xóa)
- Đặt hàng và thanh toán
- Xem lịch sử đơn hàng
- Cập nhật thông tin cá nhân

### Admin
- Dashboard với thống kê tổng quan
- Quản lý sản phẩm (thêm, sửa, xóa, ẩn/hiện)
- Quản lý danh mục sản phẩm
- Quản lý đơn hàng (xem chi tiết, cập nhật trạng thái)
- Quản lý người dùng (xem danh sách, khóa/mở khóa, reset password)
- Xuất báo cáo đơn hàng

## Công nghệ sử dụng

- **Backend**: ASP.NET Core 8.0 MVC
- **Database**: Entity Framework Core với SQL Server
- **Frontend**: HTML, CSS, JavaScript, Bootstrap
- **Authentication**: Session-based authentication
- **Validation**: Data Annotations

## Cấu trúc database

Dự án sử dụng Entity Framework Code First với các bảng:
- Users
- Categories
- Products
- Orders
- OrderDetails
- Carts
- CartItems

## Phát triển thêm

### TODO List
- [ ] Thêm chức năng thanh toán online
- [ ] Thêm chức năng đánh giá sản phẩm
- [ ] Thêm chức năng gửi email
- [ ] Thêm chức năng upload ảnh sản phẩm
- [ ] Thêm chức năng báo cáo thống kê
- [ ] Thêm chức năng quản lý kho hàng
- [ ] Thêm chức năng mã giảm giá
- [ ] Thêm chức năng tìm kiếm nâng cao

### API Endpoints
Dự án có thể mở rộng thêm Web API cho mobile app:
- `/api/products` - Quản lý sản phẩm
- `/api/orders` - Quản lý đơn hàng
- `/api/users` - Quản lý người dùng
- `/api/cart` - Quản lý giỏ hàng

## Liên hệ

Nếu có vấn đề hoặc câu hỏi, vui lòng tạo issue trên repository. 