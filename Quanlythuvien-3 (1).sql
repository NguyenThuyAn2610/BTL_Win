create database ThuVien
use ThuVien
go
select * from TaiKhoan
drop table Sach
create table Sach
( 
	MaSach nvarchar(30) not null primary key,
	TenSach nvarchar(30) not null,
	TacGia nvarchar(30),
	TinhTrangMuon nvarchar(30),
	NamXB date,
	SoLuongCoTheMuon int,
	ChuDe nvarchar(50),
	SoTien int,
)

create table TaiKhoan
(	
	Email nvarchar(100) primary key,
	MatKhau nvarchar(30) not null,
	TenDangNhap nvarchar(30) not null,
	Quyen nvarchar(30),	
)
delete TaiKhoan
insert into TaiKhoan(Email, MatKhau, TenDangNhap, Quyen) values (N'quan@gmail.com', N'1', N'quan', N'KhachHang') 
insert into TaiKhoan(Email, MatKhau, TenDangNhap, Quyen) values (N'kiet@gmail.com', N'1', N'kiet', N'KhachHang') 
insert into TaiKhoan(Email, MatKhau, TenDangNhap, Quyen) values (N'minh@gmail.com', N'1', N'minh', N'Admin')
insert into TaiKhoan(Email, MatKhau, TenDangNhap, Quyen) values (N'truong@gmail.com', N'1', N'truong', N'NhanVien')
insert into TaiKhoan(Email, MatKhau, TenDangNhap, Quyen) values (N'chien@gmail.com', N'1', N'chien', N'NhanVien')

create table TheKhachHang
(	
	MaTheKhachHang nvarchar(10) primary key constraint IDTKH default dbo.AUTO_IDTKH() not null,
	MaKH nvarchar(5),
	MaNV nvarchar(30) not null,
	NgayLap date not null,
	NgayHetHan date not null,
	TenKH nvarchar(100),
	SDT int,
	Email nvarchar(100)
)

create table PhieuTraSach
(
	MaPhieuTra nvarchar(5) primary key CONSTRAINT IDPTS DEFAULT DBO.AUTO_IDPTS(),
	MaSach nvarchar(30),
	MaKH nvarchar(5),
	MaNV nvarchar(5),
	TenSach nvarchar(30),
	NgayTaoPhieu date,
	TinhTrangSach nvarchar(100),
	Soluong nvarchar(30),
	NgayTraSach date,
	NgayHetHanMuon date,
	
)

create table PhieuThu
(	
	MaPhieuThu nvarchar(30) not null primary key constraint IDPT DEFAULT dbo.AUTO_IDPT(),
	Nam int,
	Thang int,
	MaNV nvarchar(30) not null,
	BangChu nvarchar(500) not null,
	SoTienThu float not null,
	NgayTaoPhieu date not null,
)

drop table PhieuThu
drop table PhieuChi

create table PhieuThanhLySach
(	
	MaNhanVien nvarchar(30) not null,
	MaPhieuThanhLy nvarchar(30) primary key constraint IDPTL default dbo.AUTO_IDPTL() not null,
	MaSach nvarchar(30) not null,
	TenSach nvarchar(100),
	NgayTao date not null,
	SoLuong int not null,
	LyDoThanhLy nvarchar(100),
)

create table PhieuPhat(
	MaPhieuPhat nvarchar(10) primary key constraint IDPP DEFAULT dbo.AUTO_IDPP(),
	MaKH nvarchar(5) ,
	MaSach nvarchar(30) ,
	MaNV nvarchar(30) ,
	TenSach nvarchar(30),
	SoTienPhat int,
	LyDoPhat nvarchar(100),
	NgayTaoPhieu date,
)

create table PhieuNhapSach
(	
	MaNV nvarchar(30),
	MaPhieuNhap nvarchar(30) primary key constraint IDPN default dbo.AUTO_IDPN() not null,
	MaSach nvarchar(30) not null,
	TenSach nvarchar(100),
	TacGia nvarchar(100),
	NgayTao date not null,
	SoLuong int not null,
	SoTienNhap int
)

drop table PhieuNhapSach


create table PhieuMuon(
	MaPhieuMuon nvarchar(5) primary key CONSTRAINT IDPM DEFAULT DBO.AUTO_IDPM(),
	MaSach nvarchar(30),
	MaNV nvarchar(5),
	MaKH nvarchar(5),
	TenSach nvarchar(30),
	NgayTaoPhieu date,
	Soluong nvarchar(30),
	NgayHetHanMuon date,
)

create table PhieuGiaHanSach
(
	MaPhieuGiaHan nvarchar(30) not null primary key constraint IDPGH DEFAULT dbo.AUTO_IDPGiaHanSach(),
	MaPhieuMuon nvarchar(5),
	MaSach nvarchar(30) not null,
	MaKH nvarchar(30) not null,
	MaNV nvarchar(30) not null,
	NgayGiaHan date not null,
	NgayTaoPhieu date not null,
	SoLuong int,
	TenSach nvarchar(100),
)

create table PhieuChi
(	
	MaPhieuChi nvarchar(30) not null primary key constraint IDPC DEFAULT dbo.AUTO_IDPC(),
	Nam int,
	Thang int,
	MaNV nvarchar(30) not null,
	BangChu nvarchar(500) not null,
	SoTienChi float not null,
	NgayTaoPhieu date not null,
)

create table NhanVienThuVien(
	MaNV nvarchar(30) primary key CONSTRAINT IDNV DEFAULT DBO.AUTO_IDNV(),
	TenNV nvarchar(30),
	SDT INT,
	Email nvarchar(100),
	ChucVu nvarchar(30),
)

create table KhachHang
(
	MaKH nvarchar(5)  primary key CONSTRAINT IDKH DEFAULT DBO.AUTO_IDKH(),
	TenKH nvarchar(30) not null,
	Email nvarchar(100) ,
	SDT int,
)

create table DoanhThu(
	Thang nvarchar(5),
	Nam nvarchar(5),
	SoTienThu int,
	SoTienChi int,
)

create table DanhSachChoPhieuTraSach(
	STT int identity primary key,
	MaSach nvarchar(30) ,
	MaKH nvarchar(5),
	TenSach nvarchar(30),
	TinhTrangSach nvarchar(100),
	Soluong nvarchar(30),
	NgayTraSach date,
	NgayHetHanMuon date,
)

create table DanhSachChoMuonSach(
	STT int identity primary key,
	MaSach nvarchar(30) ,
	MaKH nvarchar(5),
	TenSach nvarchar(30),
	NgayTaoPhieu date,
	Soluong nvarchar(30),
	NgayHetHanMuon date,
)

CREATE FUNCTION AUTO_IDTKH()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaTheKhachHang) FROM TheKhachHang) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaTheKhachHang, 3)) FROM TheKhachHang
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'TH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'TH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

create FUNCTION AUTO_IDPTS()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuTra) FROM PhieuTraSach) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuTra, 3)) FROM PhieuTraSach
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PT00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PT0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

create FUNCTION AUTO_IDPT()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuThu) FROM PhieuThu) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuThu, 3)) FROM PhieuThu
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PT00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PT0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

CREATE FUNCTION AUTO_IDPTL()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuThanhLy) FROM PhieuThanhLySach) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuThanhLy, 3)) FROM PhieuThanhLySach
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PN00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PN0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

create FUNCTION AUTO_IDPP()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuPhat) FROM PhieuPhat) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuPhat, 3)) FROM PhieuPhat
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PP00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PP0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

CREATE FUNCTION AUTO_IDPN()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuNhap) FROM PhieuNhapSach) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuNhap, 3)) FROM PhieuNhapSach
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PN00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PN0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

create FUNCTION AUTO_IDPM()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuMuon) FROM PhieuMuon) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuMuon, 3)) FROM PhieuMuon
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PM00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PM00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

create FUNCTION AUTO_IDPGiaHanSach()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuPhat) FROM PhieuPhat) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuPhat, 3)) FROM PhieuPhat
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PhieuGiaHan00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PhieuGiaHan0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

create FUNCTION AUTO_IDPC()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuChi) FROM PhieuChi) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuChi, 3)) FROM PhieuChi
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PC00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PC0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

CREATE FUNCTION AUTO_IDNV()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaNV) FROM NhanVienThuVien) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaNV, 3)) FROM NhanVienThuVien
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'NV00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'NV0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

CREATE FUNCTION AUTO_IDKH()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MAKH) FROM KHACHHANG) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAKH, 3)) FROM KHACHHANG
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'KH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'KH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

select * from TaiKhoan






























select * from Sach
CREATE FUNCTION AUTO_IDB()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaSach) FROM SachNhap) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaSach, 3)) FROM SachNhap
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'SACH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'SACH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
create table SachNhap(
	MaSach nvarchar(10) primary key constraint IDB DEFAULT DBO.AUTO_IDB(),


)



drop table Sach

alter table Sach
add SoTien int not null



-- Tạo trigger
drop trigger trg_UpdateTinhTrangMuon
go
CREATE TRIGGER trg_UpdateTinhTrangMuon
ON Sach
AFTER UPDATE
AS
BEGIN
    -- Kiểm tra các cột bị cập nhật
    IF UPDATE(SoLuongCoTheMuon)
    BEGIN
        -- Cập nhật giá trị của cột TinhTrangMuon
        UPDATE Sach
        SET TinhTrangMuon = 
            CASE 
                WHEN SoLuongCoTheMuon > 0 THEN N'Có thể mượn' 
                ELSE N'Không thể mượn' 
            END
        FROM inserted i
        WHERE i.MaSach = Sach.MaSach
    END
END;




create TRIGGER trg_UpdateTinhTrangMuon
ON Sach
AFTER UPDATE
AS
BEGIN
    -- Kiểm tra các cột bị cập nhật
    IF UPDATE(SoLuongCoTheMuon)
    BEGIN
        -- Cập nhật giá trị của cột TinhTrangMuon
       UPDATE Sach
        SET TinhTrangMuon = 
            CASE 
                WHEN SoLuongCoTheMuon > 0 THEN N'Có thể mượn' 
                ELSE N'Không thể mượn' 
            END
    END
END;


select MaSach, TenSach, TacGia, TinhTrangMuon, NamXB, SoLuongCoTheMuon, ChuDe from Sach

select * from Sach where SoTien >30000

select * from Sach

update Sach set SoLuongCoTheMuon = 0 where MaSach = N'DaoDuc'

delete Sach where MaSach = N'đã'

update Sach set SoLuongCoTheMuon = 0 where MaSach = N'CNTT'
drop table Sach

delete Sach
insert into Sach(MaSach, TenSach, TacGia,TinhTrangMuon,NamXB,SoLuongCoTheMuon,ChuDe, SoTien) values(N'CNTT', N'CSDL', N'Nguyễn Văn A', N'Có thể mượn', N'11-11-2020', 2, N'Dữ liệu',20000 )
insert into Sach(MaSach, TenSach, TacGia,TinhTrangMuon,NamXB,SoLuongCoTheMuon,ChuDe, SoTien) values(N'KhoaHoc', N'Vu Tru', N'Nguyễn Văn B', N'Có thể mượn', N'12-10-2018', 0, N'Khoa học',14000 )
insert into Sach(MaSach, TenSach, TacGia,TinhTrangMuon,NamXB,SoLuongCoTheMuon,ChuDe,SoTien) values(N'DaoDuc', N'GDCD', N'Nguyễn Văn C', N'Có thể mượn', N'11-11-2019', 3, N'Đạo đức',35000 )
insert into Sach(MaSach, TenSach, TacGia,TinhTrangMuon,NamXB,SoLuongCoTheMuon,ChuDe,SoTien) values(N'NgoaiNgu', N'Tieng Anh', N'Nguyễn Văn D', N'Có thể mượn', N'09-01-2022', 3, N'Ngoại ngữ',14000 )
insert into Sach(MaSach, TenSach, TacGia,TinhTrangMuon,NamXB,SoLuongCoTheMuon,ChuDe,SoTien) values(N'TonGiao', N'Phat giao', N'Nguyễn Văn E', N'Có thể mượn', N'10-12-2023', 6, N'Tôn giáo',21000 )
insert into Sach(MaSach, TenSach, TacGia,TinhTrangMuon,NamXB,SoLuongCoTheMuon,ChuDe,SoTien) values(N'TreEm', N'Truyen co tich', N'Nguyễn Văn F', N'Có thể mượn', N'12-12-2021', 0, N'Trẻ em',25000 )
insert into Sach(MaSach, TenSach, TacGia,TinhTrangMuon,NamXB,SoLuongCoTheMuon,ChuDe,SoTien) values(N'88999', N'Truyen co tich', N'Nguyễn Văn F', N'Có thể mượn', N'11-16-2021', 0, N'Trẻ em',30000 )
update SachCopy set TinhTrang = N'Không thể mượn' where MaSachCopy = N'CNTT_4'


delete TaiKhoan where Quyen = N'NhanVienKho'
drop table KhachHang
select * from TaiKhoan where Quyen <> N'Admin'
select * from KhachHang where Email = N'vancute@gmail.com'
select * from TaiKhoan
select * from NhanVienThuVien
delete TaiKhoan where Email = N'van@gmail.com'




drop table TaiKhoan
select * from KhachHang
select * from TaiKhoan
select * from NhanVienThuVien
select * from TaiKhoan
delete TaiKhoan where Email = N'duong123@gmail.com'
create table KhachHang
(
	MaKH nvarchar(5)  primary key CONSTRAINT IDKH DEFAULT DBO.AUTO_IDKH(),
	TenKH nvarchar(30) not null,
	Email nvarchar(100) ,
	SDT int,
)
delete KhachHang
insert into KhachHang(MaKH, TenKH, Email, SDT) values(N'', N'quan', N'quan@gmail.com', '0856474699')
insert into KhachHang( TenKH, Email, SDT) values( N'quan', N'quan@gmail.com', '0856474699')
insert into KhachHang( TenKH, Email, SDT) values( N'kiet', N'kiet@gmail.com', '0856474699')
drop trigger set_maKhachHang

CREATE FUNCTION AUTO_IDKH()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MAKH) FROM KHACHHANG) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAKH, 3)) FROM KHACHHANG
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'KH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'KH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

drop function AUTO_IDNV

CREATE FUNCTION AUTO_IDNV()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaNV) FROM NhanVienThuVien) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaNV, 3)) FROM NhanVienThuVien
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'NV00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'NV0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

drop table NhanVienThuVien
create table NhanVienThuVien(
	MaNV nvarchar(30) primary key CONSTRAINT IDNV DEFAULT DBO.AUTO_IDNV(),
	TenNV nvarchar(30),
	SDT INT,
	Email nvarchar(100),
	ChucVu nvarchar(30),
)


EXEC sp_rename 'PhieuNhapSach.MaNhanVien', 'MaNV', 'COLUMN';

select * from PhieuNhapSach


update Sach set SoLuongCoTheMuon = 10 where MaSach = N'NgoaiNgu'

delete TaiKhoan where Email = N'abc@gmail.com'
select * from Sach
select * from TaiKhoan
SELECT * FROM NhanVienThuVien
select * from KhachHang
select * from ChiTietPhieuMuonSach
delete NhanVienThuVien
use ThuVien
INSERT INTO NhanVienThuVien(TenNV, SDT, Email, ChucVu) values(N'chien', 123456788, N'chien@gmail.com',  N'NhanVienKho')
INSERT INTO NhanVienThuVien(TenNV, SDT, Email, ChucVu) values(N'truong', 123456788, N'truong@gmail.com', N'ThuThu')
update NhanVienThuVien set ChucVu = N'NhanVienKho' where TenNV = N'an'
delete ChiTietPhieuMuonSach where MaNV = N'NV003'

select MaNV from ChiTietPhieuMuonSach where MaNV = N'NV003'
create table ThuThu
(
	MaThuThu nvarchar(30) not null primary key,
	TenThuThu nvarchar(30) not null,
	GioiTinh bit not null,
	Email nvarchar(100),
	SDT int,
	TienLuong float,
)

create table PhieuMuon()
drop table PhieuTra
select * from Sach
select * from KhachHang
select * from NhanVienThuVien
select * from ChiTietPhieuMuonSach



delete ChiTietPhieuMuonSach where MaSach = N'KhoaHoc'
insert into ChiTietPhieuMuonSach(MaPhieuMuon,MaSach,TenSach,MaKH,MaNV,NgayHetHanMuon,NgayTao,SoLuong ) values(1, N'88999', N'KH002', N'NV001', N'04/26/2023', N'04/24/2023')
insert into ChiTietPhieuMuonSach(MaPhieuMuon,MaSach,TenSach,MaKH,MaNV,NgayHetHanMuon,NgayTao,SoLuong ) values(1, N'CNTT', N'KH002', N'NV001', N'04/26/2023', N'04/24/2023')
insert into ChiTietPhieuMuonSach(MaPhieuMuon,MaSach,TenSach,MaKH,MaNV,NgayHetHanMuon,NgayTao,SoLuong ) values(1, N'DaoDuc', N'KH002', N'NV001', N'04/26/2023', N'04/24/2023')
insert into ChiTietPhieuMuonSach(MaPhieuMuon,MaSach,TenSach,MaKH,MaNV,NgayHetHanMuon,NgayTao,SoLuong ) values(1, N'TreEm', N'KH002', N'NV002', N'04/26/2023', N'04/24/2023')
insert into PhieuMuon(MaPhieuMuon) values(1)
insert into PhieuMuon(MaPhieuMuon) values(2)
insert into PhieuMuon(MaPhieuMuon) values(3)
drop table PhieuMuon
drop table ChiTietPhieuMuonSach
drop table DanhSachChoMuonSach

INSERT INTO PhieuMuon(TenPhieu) values(N'Phiếu1');
INSERT INTO PhieuMuon(TenPhieu) values(N'Phiếu2');
INSERT INTO PhieuMuon(TenPhieu) values(N'Phiếu3');
INSERT INTO PhieuMuon(TenPhieu) values(N'Phiếu4');
INSERT INTO PhieuMuon(TenPhieu) values(N'Phiếu5');

select MaSach, TenSach, MaNV, NgayHetHanMuon, NgayTao, SoLuong  from ChiTietPhieuMuonSach where MaKH = N'KH003'

SELECT * from PhieuMuon where MaKH =N'KH001'

drop table PhieuMuon
select * from PhieuMuon


delete DanhSachChoMuonSach where STT = 2

delete KhachHang where MaKH = N'KH003'
drop function  AUTO_IDPM
delete TaiKhoan where Email = N'vancute@gmail.com'
create FUNCTION AUTO_IDPM()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuMuon) FROM PhieuMuon) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuMuon, 3)) FROM PhieuMuon
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PM00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PM00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END



drop table PhieuMuon
select MaSach, TenSach, MaKH, MaNV, NgayHetHanMuon, NgayTao, SoLuong from ChiTietPhieuMuonSach
select * from DanhSachChoMuonSach
select * from PhieuMuon
delete DanhSachChoMuonSach where STT = 4
create table DanhSachChoMuonSach(
	STT int identity primary key,
	MaSach nvarchar(30) ,
	MaKH nvarchar(5),
	TenSach nvarchar(30),
	NgayTaoPhieu date,
	Soluong nvarchar(30),
	NgayHetHanMuon date,
)

select MaSach, TenSach, MaKH, MaNV, NgayHetHanMuon, NgayTao, SoLuong from ChiTietPhieuMuonSach


INSERT INTO PhieuTra(TenPhieu) values(N'Phiếu1');
INSERT INTO PhieuTra(TenPhieu) values(N'Phiếu2');
INSERT INTO PhieuTra(TenPhieu) values(N'Phiếu3');
INSERT INTO PhieuTra(TenPhieu) values(N'Phiếu4');
INSERT INTO PhieuTra(TenPhieu) values(N'Phiếu5');


select * from KhachHang
select * from NhanVienThuVien
select * from PhieuTraSach
select * from DanhSachChoPhieuTraSach
select * from TaiKhoan

drop table DanhSachChoPhieuTraSach
create table DanhSachChoPhieuTraSach(
	STT int identity primary key,
	MaSach nvarchar(30) ,
	MaKH nvarchar(5),
	TenSach nvarchar(30),
	TinhTrangSach nvarchar(100),
	Soluong nvarchar(30),
	NgayTraSach date,
	NgayHetHanMuon date,
)
insert into PhieuTra()

drop table PhieuTraSach

create table PhieuTraSach(
	MaPhieuTra nvarchar(5) primary key CONSTRAINT IDPTS DEFAULT DBO.AUTO_IDPTS(),
	MaSach nvarchar(30),
	MaKH nvarchar(5),
	MaNV nvarchar(5),
	TenSach nvarchar(30),
	NgayTaoPhieu date,
	TinhTrangSach nvarchar(100),
	Soluong nvarchar(30),
	NgayTraSach date,
	NgayHetHanMuon date,
	
)

drop table ChiTietPhieuTraSach
select * from PhieuTraSach
select * from ChiTietPhieuTraSach where MaKH = N'KH002'
insert into ChiTietPhieuTraSach(MaPhieuTra, MaSach, MaKH, MaNhanVienTao, TenSach, NgayTaoPhieu, TinhTrangSach, Soluong, NgayTraSach, NgayHetHanMuon) values(N'PT001', N'Sach1', N'KH002', N'NV002', N'ABC', N'04/22/2023', N'OK', N'2', N'02/12/2023', N'11/11/2023')
insert into ChiTietPhieuTraSach(MaPhieuTra, MaSach, MaKH, MaNhanVienTao, TenSach, NgayTaoPhieu, TinhTrangSach, Soluong, NgayTraSach, NgayHetHanMuon) values(N'PT001', N'Sach1', N'KH002', N'NV002', N'ABC', N'04/22/2023', N'OK', N'2', N'02/12/2023', N'11/11/2023')
insert into ChiTietPhieuTraSach(MaPhieuTra, MaSach, MaKH, MaNhanVienTao, TenSach, NgayTaoPhieu, TinhTrangSach, Soluong, NgayTraSach, NgayHetHanMuon) values(N'PT001', N'KhoaHoc', N'KH002', N'NV002', N'Vu Tru1', N'04/22/2023', N'OK', N'2', N'02/12/2023', N'11/11/2023')
insert into ChiTietPhieuTraSach(MaPhieuTra, MaSach, MaKH, MaNhanVienTao, TenSach, NgayTaoPhieu, TinhTrangSach, Soluong, NgayTraSach, NgayHetHanMuon) values(N'PT001', N'Sach1', N'KH002', N'NV001', N'ABC', N'04/22/2023', N'OK', N'2', N'02/12/2023', N'11/11/2023')
create FUNCTION AUTO_IDPTS()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuTra) FROM PhieuTraSach) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuTra, 3)) FROM PhieuTraSach
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PT00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PT0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

drop function AUTO_IDPTS
SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUTO_IDPTS]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT')



create TRIGGER UpdateTinhTrangSach ON ChiTietPhieuTraSach
AFTER INSERT
AS
BEGIN
  UPDATE ChiTietPhieuTraSach
  SET TinhTrangSach = N'Cần được cập nhật lại'
  WHERE TinhTrangSach IS NULL
END





create FUNCTION AUTO_IDPP()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuPhat) FROM PhieuPhat) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuPhat, 3)) FROM PhieuPhat
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PP00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PP0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
select * from PhieuPhat
drop table PhieuPhat

select * from PhieuPhat


create table QuanLyThuVien
(
	MaQLTV nvarchar(30) not null primary key,
	TenQLTV nvarchar(30) not null,
	GioiTinh bit not null,
	Email nvarchar(100) foreign key references TaiKhoan(Email),
	SDT int,
	
)

create table NhanVienKho
(
	MaNVK nvarchar(30) not null primary key,
	TenNVK nvarchar(30) not null,
	GioiTinh bit not null,
	Email nvarchar(100) foreign key references TaiKhoan(Email),
	SDT int,
	
)



create FUNCTION AUTO_IDPGiaHanSach()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuPhat) FROM PhieuPhat) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuPhat, 3)) FROM PhieuPhat
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PhieuGiaHan00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PhieuGiaHan0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
create table PhieuGiaHanSach
(
	MaPhieuGiaHan nvarchar(30) not null primary key constraint IDPGH DEFAULT dbo.AUTO_IDPGiaHanSach(),
	MaPhieuMuon nvarchar(5),
	MaSach nvarchar(30) not null,
	MaKH nvarchar(30) not null,
	MaNV nvarchar(30) not null,
	NgayGiaHan date not null,
	NgayTaoPhieu date not null,
	SoLuong int,
	TenSach nvarchar(100),
)
select * from PhieuMuon
SELECT * FROM PhieuGiaHanSach
drop table PhieuGiaHanSach
create FUNCTION AUTO_IDPT()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuThu) FROM PhieuThu) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuThu, 3)) FROM PhieuThu
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PT00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PT0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END


create FUNCTION AUTO_IDPC()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuChi) FROM PhieuChi) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuChi, 3)) FROM PhieuChi
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PC00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PC0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

DROP TABLE pHIEUTHU
create table PhieuThu
(	
	MaPhieuThu nvarchar(30) not null primary key constraint IDPT DEFAULT dbo.AUTO_IDPT(),
	Nam int,
	Thang int,
	MaNV nvarchar(30) not null,
	BangChu nvarchar(30) not null,
	SoTienThu float not null,
	NgayTaoPhieu date not null,
)
DROP TABLE PhieuChi
create table PhieuChi
(	
	MaPhieuChi nvarchar(30) not null primary key constraint IDPC DEFAULT dbo.AUTO_IDPC(),
	Nam int,
	Thang int,
	MaNV nvarchar(30) not null,
	BangChu nvarchar(30) not null,
	SoTienChi float not null,
	NgayTaoPhieu date not null,
)
use ThuVien
drop table KhoSach
create table KhoSach(
	STT int identity primary key,
	MaSach nvarchar(30),
	foreign key (MaSach) references Sach(MaSach),
	TenSach nvarchar(100),
	TacGia nvarchar(100),
	SoLuong int,
)
minh
create table PhieuNhapSach
(	
	MaNV nvarchar(30),
	MaPhieuNhap nvarchar(30) primary key constraint IDPN default dbo.AUTO_IDPN() not null,
	MaSach nvarchar(30) not null,
	TenSach nvarchar(100),
	NgayTao date not null,
	SoLuong int not null,
	SoTienNhap int
)

create table DoanhThu(
	Thang nvarchar(5),
	Nam nvarchar(5),
	SoTienThu int,
	SoTienChi int,
)


select * from Sach

select * from dbo.Sach where TacGia = N'Nguyễn Văn F'
select * from DoanhThu
insert into DoanhThu(Thang, Nam, SoTienThu, SoTienChi) values(N'5', N'2023', NULL, 20000)
select * from PhieuNhapSach
drop table DoanhThu
drop function AUTO_IDPN
CREATE FUNCTION AUTO_IDPN()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuNhap) FROM PhieuNhapSach) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuNhap, 3)) FROM PhieuNhapSach
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PN00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PN0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END




CREATE FUNCTION AUTO_IDPTL()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhieuThanhLy) FROM PhieuThanhLySach) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieuThanhLy, 3)) FROM PhieuThanhLySach
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PN00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PN0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

drop table PhieuThanhLySach

select * from PhieuThanhLySach
CREATE FUNCTION AUTO_IDTKH()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaTheKhachHang) FROM TheKhachHang) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaTheKhachHang, 3)) FROM TheKhachHang
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'TH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'TH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

drop function AUTO_IDTKH
drop table TheKhachHang

select * from KhachHang
select * from TheKhachHang
create table TheKhachHang
(	
	MaTheKhachHang nvarchar(10) primary key constraint IDTKH default dbo.AUTO_IDTKH() not null,
	MaKH nvarchar(5),
	MaNV nvarchar(30) not null,
	NgayLap date not null,
	NgayHetHan date not null,
	TenKH nvarchar(100),
	SDT int,
	Email nvarchar(100)
)

create table TheKhachHangVip
(	
	MaTheVip int primary key not null,
	MaTheKhachHang int not null,
	MaThuThu nvarchar(30) not null,
	NgayHetHan date not null,
	foreign key (MaTheKhachHang) references TheKhachHang(MaTheKhachHang),
	foreign key (MaThuThu)references ThuThu(MaThuThu),
)

create table BangLuong
(
	MaBangLuong nvarchar(30) primary key not null,
	BangChu nvarchar(30) not null,
	MaNVK nvarchar(30) not null,
	MaThuThu nvarchar(30) not null,
	MaQLTV nvarchar(30) not null,
	NgayTao date,
	TongSoTien float,
	foreign key (MaNVK) references NhanVienKho(MaNVK),
	foreign key (MaQLTV) references QuanLyThuVien(MaQLTV),
	foreign key (MaThuThu) references ThuThu(MaThuThu),
)






