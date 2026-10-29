# BÁO CÁO BÀI TẬP 5.3: HỆ THỐNG QUẢN LÝ QUÁN CAFE (POS CAFE SYSTEM)

## MỤC 1: THÔNG TIN SINH VIÊN
- **Họ và tên sinh viên:** LÊ ĐỨC KHÁNH
- **Mã sinh viên:** 24810310438
- **Tên Đề tài / Bài tập:** Bài tập 5.3 - Hệ thống Quản lý Quán Cafe & Bán hàng (POS Cafe System)

---

## MỤC 2: HƯỚNG DẪN CÀI ĐẶT & CHẠY DỰ ÁN

### Các bước cài đặt:
1. Mở **SQL Server Management Studio (SSMS)**, chạy file `Database/ScriptDB.sql` để khởi tạo CSDL `CafePOSDB` và dữ liệu mẫu.
2. Mở file `.sln` bằng **Visual Studio 2022**.
3. Sửa lại chuỗi kết nối `ConnectionString` trong file `DAL/DatabaseHelper.cs` cho phù hợp với máy cá nhân.
4. Restore gói `Microsoft.Data.SqlClient`.
5. Bấm `F5` hoặc gõ `dotnet run` để Build & Run dự án.

---

## MỤC 3: HÌNH ẢNH KẾT QUẢ CÁC MÀN HÌNH CHỨC NĂNG

1. **Màn hình Chính / Tổng quan:**
<img width="1101" height="718" alt="image" src="https://github.com/user-attachments/assets/039e3a40-494d-4e61-8f4c-0819958ce50f" />


2. **Màn hình Quản lý Danh mục / Thêm Sửa Xóa (CRUD):**
<img width="1097" height="718" alt="image" src="https://github.com/user-attachments/assets/6fd1f869-b4c0-464e-a103-47e10bfebb08" />


3. **Màn hình Thực thi Nghiệp vụ chính (Gọi món tại bàn):**
<img width="1101" height="717" alt="image" src="https://github.com/user-attachments/assets/0fae518b-0314-40ac-a0b5-5b599f8a819d" />


4. **Màn hình Báo cáo - Thống kê (Thanh toán):**
<img width="1100" height="721" alt="image" src="https://github.com/user-attachments/assets/f4d38f09-b49b-49ce-a238-e0ad75772e47" />


5. **Minh họa Xử lý lỗi & Giao dịch (Rollback / Validation):**
<img width="1098" height="717" alt="image" src="https://github.com/user-attachments/assets/90ad97bd-614f-46c3-9b55-1e4c86bead49" />
