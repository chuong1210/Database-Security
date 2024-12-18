


--a. Viết script tạo Database có tên QLSVNhom.
/*----------------------------------------------------------
MASV: 2033224643
HO TEN: Đặng Văn Thái
LAB: 04
NGAY: 3/10/2024
----------------------------------------------------------*/
--CAU LENH TAO DB
CREATE DATABASE QLSVNhom;
USE QLSVNhom;

 --b. Viết script tạo mới các Table SINHVIEN, NHANVIEN, LOP như mô tả trên.
/*----------------------------------------------------------
MASV: 2033224643
HO TEN: Đặng Văn Thái
LAB: 04
NGAY: 3/10/2024
----------------------------------------------------------*/
--CAC CAU LENH TAO TB
CREATE TABLE NHANVIEN (
    MANV VARCHAR(20) NOT NULL,
    HOTEN NVARCHAR(100) NOT NULL,
    EMAIL VARCHAR(20),
    LUONG VARBINARY(MAX),
    TENDN NVARCHAR(100) NOT NULL UNIQUE,
    MATKHAU VARBINARY(MAX) NOT NULL,
	PUBKEY VARCHAR(20),
    CONSTRAINT PK_NV PRIMARY KEY (MANV)
);
ALTER TABLE NHANVIEN
ALTER COLUMN  PUBKEY VARCHAR(600)


CREATE TABLE LOP (
    MALOP VARCHAR(20) NOT NULL,
    TENLOP NVARCHAR(100) NOT NULL,
    MANV VARCHAR(20),
    CONSTRAINT PK_LOP PRIMARY KEY (MALOP),
    CONSTRAINT FK_LOP_NV FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
);
CREATE TABLE SINHVIEN (
    MASV NVARCHAR(20) NOT NULL,
    HOTEN NVARCHAR(100) NOT NULL,
    NGAYSINH DATETIME,
    DIACHI NVARCHAR(200),
    MALOP VARCHAR(20),
    TENDN NVARCHAR(100) NOT NULL UNIQUE,
    MATKHAU VARBINARY(MAX) NOT NULL,
    CONSTRAINT PK_SV PRIMARY KEY (MASV),
    CONSTRAINT FK_SV_LOP FOREIGN KEY (MALOP) REFERENCES LOP(MALOP)
    
);
GO
CREATE TABLE HOCPHAN (
    MAHP NVARCHAR(20) PRIMARY KEY,        
    TENHP NVARCHAR(100),
    SOTC INT

);
GO
CREATE TABLE BANGDIEM (
    MASV NVARCHAR(20),                     
    MAHP NVARCHAR(20),                     
    DIEMTHI VARBINARY(MAX),                   
    PRIMARY KEY (MASV, MAHP),
    CONSTRAINT FK_BANGDIEM_SV FOREIGN KEY (MASV) REFERENCES SINHVIEN(MASV),
    CONSTRAINT FK_BANGDIEM_HP FOREIGN KEY (MAHP) REFERENCES HOCPHAN(MAHP)

);
GO
--c) Viết các Stored procedure sau
/*----------------------------------------------------------
MASV: 2033224643
HO TEN: Đặng Văn Thái
LAB: 04
NGAY: 3/10/2024
----------------------------------------------------------*/
--CAU LENH TAO STORED PROCEDURE
--i. Stored dùng để thêm mới dữ liệu (Insert) vào table SINHVIEN
CREATE OR ALTER PROCEDURE SP_INS_ENCRYPT_SINHVIEN
    @MASV    NVARCHAR(20),     
    @HOTEN   NVARCHAR(100),      --Đầu vào: MASV, HOTEN, NGAYSINH, DIACHI, MALOP, TENDN, MATKHAU
    @NGAYSINH DATETIME,          --MATKHAU đã được mã hoá ở dạng MD5 ở Client  
    @DIACHI  NVARCHAR(200),
    @MALOP   VARCHAR(20),
    @TENDN   NVARCHAR(100),
    @MATKHAU VARCHAR(MAX)
AS
BEGIN
    IF EXISTS (SELECT * FROM DBO.SINHVIEN WHERE MASV = @MASV)  
    BEGIN RAISERROR(N'MASV bị trùng',16,1); END
    ELSE
    BEGIN
        IF EXISTS (SELECT * FROM DBO.SINHVIEN WHERE TENDN = @TENDN)
        BEGIN RAISERROR(N'TENDN bị trùng',16,1); END
        ELSE
        BEGIN
            IF EXISTS (SELECT * FROM DBO.LOP WHERE MALOP = @MALOP)
            BEGIN 
                INSERT INTO DBO.SINHVIEN VALUES (@MASV, @HOTEN, @NGAYSINH, @DIACHI, @MALOP, @TENDN,
                                                HASHBYTES('SHA1', @MATKHAU)); 
            END
            ELSE
            BEGIN RAISERROR(N'MALOP không tồn tại',16,1); END
        END
    END
END
GO

EXEC SP_INS_ENCRYPT_SINHVIEN 'SV02', 'NGUYEN VAN A', '1/1/1990',
    '280 AN DUONG VUONG', 'CNTT-K35', '123', '12345';

GO

--ii. Stored dùng để thêm mới dữ liệu (Insert) vào table NHANVIEN,
CREATE OR ALTER PROCEDURE SP_INS_ENCRYPT_NHANVIEN
    @MANV VARCHAR(20), 
    @HOTEN NVARCHAR(100),       
    @EMAIL VARCHAR(100),        
    @TENDN VARCHAR(50), 
    @LUONGCB VARCHAR(MAX),         -- Dữ liệu lương đã được mã hóa
    @MATKHAU VARCHAR(MAX),       -- Mật khẩu đã được mã hóa SHA1
    @PUB NVARCHAR(200)           -- Khóa công khai từ client
AS
BEGIN
    -- Kiểm tra xem MANV đã tồn tại chưa
	 DECLARE @HASHPASSWORD VARBINARY(20);
    DECLARE @ENCRYPTEDLUONG VARBINARY(MAX);

    -- Mã hóa MATKHAU bằng SHA1
    SET @HASHPASSWORD = HASHBYTES('SHA1', @MATKHAU);
	 SET @ENCRYPTEDLUONG = CONVERT(VARBINARY(MAX), @LUONGCB,@MATKHAU); 
    IF EXISTS (SELECT * FROM DBO.NHANVIEN WHERE MANV = @MANV) 
    BEGIN 
        RAISERROR(N'MANV bị trùng!', 16, 1); 
        RETURN; 
    END 

    -- Kiểm tra xem TENDN đã tồn tại chưa
    IF EXISTS (SELECT * FROM DBO.NHANVIEN WHERE TENDN = @TENDN) 
    BEGIN 
        RAISERROR(N'TENDN bị trùng!', 16, 1); 
        RETURN; 
    END 

    -- Thêm nhân viên mới vào bảng NHANVIEN
    INSERT INTO DBO.NHANVIEN (MANV, HOTEN, EMAIL, TENDN, LUONG, MATKHAU) 
    VALUES 
    (@MANV, @HOTEN, @EMAIL, @TENDN, 
    @ENCRYPTEDLUONG, 
   @HASHPASSWORD )
END

EXEC SP_INS_ENCRYPT_NHANVIEN 'NV02', 'NGUYEN VAN A', 'NVA@',
    '1', 'bbbbbb', '1','PUBPUB';


GO
--iii) Stored dùng để truy vấn dữ liệu nhân viên (NHANVIEN)
CREATE OR ALTER PROCEDURE SP_SEL_ENCRYPT_NHANVIEN
AS
BEGIN
    SELECT MANV, HOTEN, EMAIL, CONVERT(VARCHAR(MAX), LUONG, 1) AS "LUONG"
    FROM DBO.NHANVIEN
END
GO

EXEC SP_SEL_ENCRYPT_NHANVIEN
GO
--d. 
/*----------------------------------------------------------
MASV: 2033224643
HO TEN: Đặng Văn Thái
LAB: 04
NGAY: 3/10/2024
----------------------------------------------------------*/
--Viết Stored để đăng nhập
CREATE OR ALTER PROCEDURE SP_LOGIN_ENCRYPT
    @USERNAME VARCHAR(MAX),    --Đầu vào: USERNAME, PASSWORD (đã mã hoá)
    @PASSWORD VARCHAR(100)
AS
BEGIN
    DECLARE @MATKHAU VARBINARY(MAX);
      SET @MATKHAU = HASHBYTES('MD5', @PASSWORD);
    IF (SELECT COUNT(*) FROM DBO.SINHVIEN WHERE TENDN = @USERNAME AND MATKHAU = @MATKHAU) > 0
    BEGIN                                           --Kiểm tra đăng nhập với tài khoản SINHVIEN
        PRINT N'Dăng nhập thành công'; 
    END 
    ELSE 
    BEGIN 
        IF EXISTS (SELECT TENDN FROM DBO.NHANVIEN WHERE TENDN = @USERNAME AND MATKHAU = @MATKHAU) 
        BEGIN                                       --Kiểm tra đăng nhập với tài khoản NHANVIEN
            PRINT N'Dăng nhập thành công'; 
        END 
        ELSE 
        BEGIN 
            RAISERROR(N'Tài khoản không tồn tại!', 16, 1); 
        END 
    END
END
EXEC SP_LOGIN_ENCRYPT 'NVA', '12345';  -- Giả sử tài khoản nhân viên NV01 đã tồn tại và mật khẩu đã được mã hóa là 'bbbbbbbb'


-- Đăng nhập với tài khoản là nhân viên (MANV, MATKHAU)
CREATE OR ALTER PROCEDURE SP_LOGIN_ENCRYPT_NHANVIEN
    @USERNAME NVARCHAR(100),    -- Tên đăng nhập
    @PASSWORD NVARCHAR(100)      -- Mật khẩu đã mã hóa
AS
BEGIN
    DECLARE @MATKHAU VARBINARY(MAX);
      SET @MATKHAU = HASHBYTES('MD5', @PASSWORD);

    IF EXISTS (SELECT 1 FROM NHANVIEN WHERE TENDN = @USERNAME AND MATKHAU = @MATKHAU)
    BEGIN
        PRINT N'Dăng nhập thành công'; 
    END 
    ELSE 
    BEGIN 
        RAISERROR(N'Tài khoản không tồn tại!', 16, 1); 
    END 
END

GO
--Viết Stored để xác định loại tài khoản
CREATE OR ALTER PROCEDURE SP_TYPE 
    @USERNAME NVARCHAR(100),    --Đầu vào: USERNAME
    @TYPE INT OUTPUT            --Đầu ra: TYPE (loại tài khoản)
AS
BEGIN
    SET @TYPE = 0;
    IF (SELECT TENDN FROM DBO.SINHVIEN WHERE TENDN = @USERNAME) IS NOT NULL
    BEGIN
        SET @TYPE = 1;  -- Tài khoản sinh viên (mã hóa mật khẩu bằng MD5)
    END
    ELSE 
    BEGIN
        IF EXISTS (SELECT TENDN FROM DBO.NHANVIEN WHERE TENDN = @USERNAME) 
        BEGIN
            SET @TYPE = 2;  -- Tài khoản nhân viên (mã hóa mật khẩu bằng SHA1)
        END
        ELSE 
        BEGIN
            RAISERROR(N'Tài khoản không tồn tại!', 16, 1);
        END
    END
END



-- Xây dựng (lập trình) màn hình quản lý nhân viên
CREATE PROCEDURE SP_VALIDATE_LOGIN
    @TENDN NVARCHAR(100),
    @MATKHAU VARBINARY(MAX)
AS
BEGIN
    SELECT COUNT(*) 
    FROM NHANVIEN 
    WHERE TENDN = @TENDN AND MATKHAU = @MATKHAU;
END


CREATE OR ALTER PROCEDURE SP_INS_PUBLIC_ENCRYPT_NHANVIEN
    @MANV VARCHAR(20),              -- Mã nhân viên
    @HOTEN NVARCHAR(100),           -- Họ tên
    @EMAIL VARCHAR(100),            -- Email
    @LUONG VARBINARY(MAX),          -- Lương (đã mã hóa RSA từ client)
    @TENDN NVARCHAR(100),           -- Tên đăng nhập
    @MK VARBINARY(MAX),             -- Mật khẩu (đã được mã hóa SHA1 từ client)
    @PUB NVARCHAR(500)              -- Khóa công khai
AS
BEGIN
    -- Kiểm tra xem MANV đã tồn tại chưa
    IF EXISTS (SELECT * FROM DBO.NHANVIEN WHERE MANV = @MANV)
    BEGIN 
        RAISERROR(N'Mã nhân viên đã tồn tại!', 16, 1); 
        RETURN;
    END
    
    -- Kiểm tra xem TENDN đã tồn tại chưa
    IF EXISTS (SELECT * FROM DBO.NHANVIEN WHERE TENDN = @TENDN)
    BEGIN 
        RAISERROR(N'Tên đăng nhập đã tồn tại!', 16, 1); 
        RETURN;
    END
    
    -- Thêm nhân viên mới
    INSERT INTO DBO.NHANVIEN (MANV, HOTEN, EMAIL, LUONG, TENDN, MATKHAU,PUBKEY)
    VALUES (@MANV, @HOTEN, @EMAIL, @LUONG, @TENDN, @MK,@PUB);
END
GO



CREATE PROCEDURE SP_SEL_ALL_NHANVIEN
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        MANV,
        HOTEN,
        EMAIL,
        LUONG,
        MATKHAU
    FROM 
        NHANVIEN;
END


	 CREATE OR ALTER PROCEDURE SP_UPD_NHANVIEN
    @MANV NVARCHAR(50),
    @HOTEN NVARCHAR(100),
    @EMAIL NVARCHAR(100),
    @LUONG VARBINARY(MAX), 
    @MK VARBINARY(MAX)  
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM NHANVIEN WHERE MANV = @MANV)
    BEGIN
        UPDATE NHANVIEN
        SET HOTEN = @HOTEN,
            EMAIL = @EMAIL,
            LUONG = @LUONG,
            MATKHAU = @MK
        WHERE MANV = @MANV;
        
        RETURN 0;
    END
    ELSE
    BEGIN
        RETURN 1; 
    END
END
 exec SP_SEL_ALL_NHANVIEN
 exec SP_GET_STUDENT_SCORES 'sv02'
CREATE PROCEDURE SP_DEL_NHANVIEN
    @MANV NVARCHAR(50)
AS
BEGIN
    DELETE FROM NHANVIEN WHERE MANV = @MANV
END
GO
-- Xây dựng (lập trình) màn hình quản lý lớp học
CREATE PROCEDURE SP_SEL_ALL_CLASSES
AS
BEGIN
    SELECT * FROM LOP;
END;

GO

CREATE PROCEDURE SP_INS_CLASS
    @MALOP VARCHAR(20),
    @TENLOP NVARCHAR(100),
    @MANV VARCHAR(20)
AS
BEGIN
    INSERT INTO LOP (MALOP, TENLOP, MANV)
    VALUES (@MALOP, @TENLOP, @MANV);
END;

GO

CREATE PROCEDURE SP_UPD_CLASS
    @MALOP VARCHAR(20),
    @TENLOP NVARCHAR(100),
    @MANV VARCHAR(20)
AS
BEGIN
    UPDATE LOP
    SET TENLOP = @TENLOP, MANV = @MANV
    WHERE MALOP = @MALOP;
END;

GO

CREATE PROCEDURE SP_DEL_CLASS
    @MALOP VARCHAR(20)
AS
BEGIN
    DELETE FROM LOP
    WHERE MALOP = @MALOP;
END;

GO
-- Xây dựng (lập trình) màn hình sinh viên của từng lớp (lưu ý chỉ được phép thay đổi 
-- thông tin của những sinh viên thuộc lớp mà nhân viên đó quản lý)
CREATE PROCEDURE SP_SEL_STUDENTS_BY_CLASS
    @MALOP VARCHAR(20)
AS
BEGIN
    SELECT * FROM SINHVIEN
    WHERE MALOP = @MALOP;
END;

exec SP_SEL_STUDENTS_BY_CLASS 'CNTT-K35' 
GO

CREATE PROCEDURE SP_SEL_CLASSES_BY_EMPLOYEE
    @MANV VARCHAR(20)
AS
BEGIN
    SELECT * FROM LOP
    WHERE MANV = @MANV;
END;

GO

CREATE PROCEDURE SP_SEL_ALL_EMPLOYEES
AS
BEGIN
    SELECT MANV, HOTEN FROM NHANVIEN;
END;






--Xây dựng (lập trình) nhập bảng điểm của từng sinh viên, trong đó cột điểm thi sẽ được 
-- mã hóa bằng chính Public Key của nhân viên (đã đăng nhập)

CREATE or alter PROCEDURE SP_GET_STUDENTS_BY_EMPLOYEE
    @MANV NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT S.MASV, S.HOTEN , L.TENLOP
    FROM SINHVIEN S
    JOIN LOP L ON S.MALOP = L.MALOP
    WHERE L.MANV = @MANV;
END
GO


CREATE or alter PROCEDURE SP_INSERT_SCORE
    @MASV NVARCHAR(20),
    @MAHP NVARCHAR(20),
    @DIEMTHI VARBINARY(MAX), 
    @PUBKEY NVARCHAR(500)     
AS
BEGIN

    INSERT INTO BANGDIEM (MASV, MAHP, DIEMTHI)
    VALUES (@MASV, @MAHP, @DIEMTHI);
END
GO
CREATE PROCEDURE SP_UPDATE_SCORE
    @MASV VARCHAR(20),
    @MAHP VARCHAR(20),
    @DIEMTHI VARBINARY(MAX)
AS
BEGIN
    UPDATE BANGDIEM
    SET DIEMTHI = @DIEMTHI
    WHERE MASV = @MASV AND MAHP = @MAHP;
END;

CREATE PROCEDURE SP_DELETE_SCORE
    @MASV VARCHAR(20),
    @MAHP VARCHAR(20)
AS
BEGIN
    DELETE FROM BANGDIEM
    WHERE MASV = @MASV AND MAHP = @MAHP;
END;

CREATE PROCEDURE SP_GET_STUDENT_SCORES
    @MASV NVARCHAR(50)
AS
BEGIN
    SELECT HP.MAHP, HP.TENHP, BD.DIEMTHI
    FROM BANGDIEM BD
    JOIN HOCPHAN HP ON BD.MAHP = HP.MAHP
    WHERE BD.MASV = @MASV
END

--c) Viết các Stored procedure sau
/*----------------------------------------------------------
MASV: 2033224643
HO TEN: Đặng Văn Thái
LAB: 04
NGAY: 3/10/2024
----------------------------------------------------------*/
--CAU LENH TAO STORED PROCEDURE
--i. Stored dùng để thêm mới dữ liệu (Insert) vào table SINHVIEN
CREATE ASYMMETRIC KEY MyRSAKey
WITH ALGORITHM = RSA_512
ENCRYPTION BY PASSWORD = 'StrongPassword123!';


CREATE OR ALTER PROCEDURE SP_INS_PUBLIC_ENCRYPT_NHANVIEN
    @MANV INT,
    @HOTEN NVARCHAR(100),
    @EMAIL NVARCHAR(100),
    @LUONGCB DECIMAL(18, 2),
    @TENDN NVARCHAR(50),
    @MK NVARCHAR(50),
    @PUB NVARCHAR(50)
AS
BEGIN
    -- Mã hóa MATKHAU bằng SHA1
    DECLARE @HashedPassword VARBINARY(20) = HASHBYTES('SHA1', @MK);

    -- Khai báo biến cho LUONG
    DECLARE @EncryptedLuong VARBINARY(MAX);

    -- Mã hóa LUONG bằng khóa bất đối xứng
    SET @EncryptedLuong = EncryptByAsymKey(AsymKey_ID('MyRSAKey'), CAST(@LUONGCB AS NVARCHAR(50)));

    -- Thêm dữ liệu vào bảng SINHVIEN
    INSERT INTO NHANVIEN (MANV, HOTEN, EMAIL, LUONG, TENDN, MATKHAU, PUBKEY)
    VALUES (@MANV, @HOTEN, @EMAIL, @EncryptedLuong, @TENDN, @HashedPassword, @PUB);
END;


EXEC SP_INS_PUBLIC_ENCRYPT_NHANVIEN
    @MANV = 12,
    @HOTEN = N'Nguyen Van A',
    @EMAIL = 'nguyenvana@.com',
    @LUONGCB = 10000000,
    @TENDN = 'nv_aa',
    @MK = 'MatKhauA123',
    @PUB = 'PublicKey_NV_A';


