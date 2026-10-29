CREATE DATABASE Cafe;

USE Cafe;

CREATE TABLE BanAn (
    MaBan INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(20) CONSTRAINT DF_BanAn_TrangThai DEFAULT N'Trống'
);


CREATE TABLE DanhMuc (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
);

CREATE TABLE MonAn (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    MaDanhMuc INT CONSTRAINT FK_MonAn_DanhMuc FOREIGN KEY REFERENCES DanhMuc(MaDanhMuc) ON DELETE CASCADE,
    DonGia DECIMAL(18,2) NOT NULL CONSTRAINT CK_MonAn_DonGia CHECK (DonGia >= 0)
);


CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT CONSTRAINT FK_HoaDon_BanAn FOREIGN KEY REFERENCES BanAn(MaBan),
    GioVao DATETIME DEFAULT GETDATE(),
    GioRa DATETIME NULL,
    TongTien DECIMAL(18,2) DEFAULT 0,
    TrangThai BIT DEFAULT 0 -- 0: Chưa thanh toán, 1: Đã thanh toán
);


CREATE TABLE ChiTietHoaDon (
    MaHoaDon INT CONSTRAINT FK_CTHD_HoaDon FOREIGN KEY REFERENCES HoaDon(MaHoaDon),
    MaMon INT CONSTRAINT FK_CTHD_MonAn FOREIGN KEY REFERENCES MonAn(MaMon),
    SoLuong INT NOT NULL CONSTRAINT CK_CTHD_SoLuong CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHoaDon, MaMon)
);



INSERT INTO BanAn (TenBan, TrangThai) VALUES 
(N'Bàn 01', N'Trống'), (N'Bàn 02', N'Trống'), (N'Bàn 03', N'Trống'),
(N'Bàn 04', N'Trống'), (N'Bàn 05', N'Trống'), (N'Bàn 06', N'Trống'),
(N'Bàn 07', N'Trống'), (N'Bàn 08', N'Trống');

INSERT INTO DanhMuc (TenDanhMuc) VALUES 
(N'Cà phê'), (N'Trà sữa'), (N'Đồ ăn nhẹ');

INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia) VALUES 
(N'Cà phê đen', 1, 25000),
(N'Cà phê sữa', 1, 29000),
(N'Bạc xỉu', 1, 32000),
(N'Trà sữa trân châu', 2, 35000),
(N'Trà đào cam sả', 2, 39000),
(N'Bánh mì que', 3, 15000),
(N'Hướng dương', 3, 12000);
GO

select * from MonAn;
