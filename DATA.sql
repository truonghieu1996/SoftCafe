CREATE DATABASE QuanLyQuanCafe
GO
USE QuanLyQuanCafe
GO

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Ban chua dat ten',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'
)
GO
CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Hieu',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL DEFAULT 0 -- 1:Admin, 0:Staff
)
GO
CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chua dat ten'
)
GO
CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chua dat ten',
	idCategory INT NOT NULL,
	Price FLOAT NOT NULL DEFAULT 0

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateChecIn DATE NOT NULL,
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 --1:Da thanh toan, 0: chua thanh toan.

	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	Count INT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO

INSERT INTO dbo.Account

        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'tmhieu' , -- UserName - nvarchar(100)
          N'Trương Minh Hiếu' , -- DisplayName - nvarchar(100)
          N'12345' , -- PassWord - nvarchar(1000)
          1  -- Type - int
        )
GO
INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'ncthanh' , -- UserName - nvarchar(100)
          N'Nguyễn Công Thành' , -- DisplayName - nvarchar(100)
          N'12345' , -- PassWord - nvarchar(1000)
          0  -- Type - int
        )
GO
CREATE PROC USP_GetListAccountByUserName
@UserName NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @UserName
END
GO
CREATE PROC USP_Login
@UserName NVARCHAR(100), @PassWord NVARCHAR(1000)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName=@UserName AND PassWord=@PassWord
END
GO
DECLARE @i INT = 0
WHILE @i <= 10
BEGIN
	INSERT INTO dbo.TableFood (name) VALUES  ( N'Bàn ' + CAST(@i AS NVARCHAR(100)))
	 SET @i = @i + 1
END
GO
CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO
GO

--Thêm Category
INSERT INTO dbo.FoodCategory
        (  name )
VALUES  (
          N'Hải sản'  -- name - nvarchar(100)
          )
INSERT INTO dbo.FoodCategory
        ( name )
VALUES  (
          N'Giải khát'  -- name - nvarchar(100)
          )
INSERT INTO dbo.FoodCategory
        ( name )
VALUES  ( 
          N'Nướng'  -- name - nvarchar(100)
          )
INSERT INTO dbo.FoodCategory
        ( name )
VALUES  (
          N'Lẩu'  -- name - nvarchar(100)
          )


--thêm Food
GO
INSERT INTO dbo.Food
        (name, idCategory, Price )
VALUES  ( 
          N'Sửa', -- name - nvarchar(100)
          2, -- idCategory - int
          20000  -- Price - float
          )
INSERT INTO dbo.Food
        ( name, idCategory, Price )
VALUES  (
          N'Lipton', -- name - nvarchar(100)
          2, -- idCategory - int
          15000  -- Price - float
          )
INSERT INTO dbo.Food
        (name, idCategory, Price )
VALUES  (
          N'Cafe', -- name - nvarchar(100)
          2, -- idCategory - int
          12000  -- Price - float
          )
INSERT INTO dbo.Food
        ( name, idCategory, Price )
VALUES  (
          N'Rau má', -- name - nvarchar(100)
          2, -- idCategory - int
          12000  -- Price - float

		  )
--thêm Bill          
GO

INSERT INTO dbo.Bill
        (
          DateChecIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  (
          GETDATE() , -- DateChecIn - date
          NULL , -- DateCheckOut - date
          4 , -- idTable - int
          0  -- status - int
        )
INSERT INTO dbo.Bill
        (
          DateChecIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  (
          GETDATE() , -- DateChecIn - date
          NULL , -- DateCheckOut - date
          5 , -- idTable - int
          0  -- status - int
        )
INSERT INTO dbo.Bill
        (
          DateChecIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  (
          GETDATE() , -- DateChecIn - date
          GETDATE() , -- DateCheckOut - date
          6 , -- idTable - int
          1  -- status - int
        )
--Thêm BillInfo
GO
INSERT INTO dbo.BillInfo
        ( idBill, idFood, Count )
VALUES  (
          4, -- idBill - int
          1, -- idFood - int
          1  -- Count - int
          )
INSERT INTO dbo.BillInfo
        ( idBill, idFood, Count )
VALUES  (
          5, -- idBill - int
          2, -- idFood - int
          4  -- Count - int
          )
INSERT INTO dbo.BillInfo
        ( idBill, idFood, Count )
VALUES  (
          6, -- idBill - int
          3, -- idFood - int
          5  -- Count - int
          )
GO

GO
SELECT * FROM dbo.Bill WHERE idTable = 5 AND status = 0 
SELECT * FROM dbo.BillInfo WHERE idBill = 5

SELECT f.name, bi.Count, f.Price, f.Price*bi.Count AS TotalPrice FROM dbo.BillInfo AS bi,dbo.Bill AS b,dbo.Food AS f
WHERE bi.idBill=b.id AND bi.idFood=f.id AND b.idTable = 9

GO
ALTER PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT INTO dbo.Bill
	        (
	          DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status,
			  discount
	        )
	VALUES  (
	          GETDATE() , -- DateChecIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0,  -- status - int
			  0
	        )
END
GO
ALTER PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	
	DECLARE @isExitBillInfo INT
	DECLARE @foofCount INT = 1

	SELECT @isExitBillInfo = id, @foofCount = b.Count
	FROM dbo.BillInfo AS b
	WHERE b.idBill = @idBill AND b.idFood=@idFood
	IF (@isExitBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foofCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo SET Count = @foofCount + @count WHERE idBill = @idBill AND idFood = @idFood
		ELSE 
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT INTO dbo.BillInfo
				( idBill, idFood, Count )
		VALUES  (
				@idBill, -- idBill - int
				@idFood, -- idFood - int
				@count  -- Count - int
				)
	END	
END
GO
ALTER TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = idBill FROM Inserted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0
	UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
END
GO
ALTER TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT 
	SELECT @idBill = id FROM Inserted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill

	DECLARE @count INT = 0
	SELECT COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0

	IF(@count = 0)
		UPDATE dbo.TableFood  SET status = N'Trống' WHERE id = @idTable
END
GO
ALTER PROC USP_SwitchTable
@idTable1 INT , @idTable2 INT
AS 
BEGIN
DECLARE @idFirstBill INT
DECLARE @idSecondBill INT
DECLARE @isFirstTableEmty INT = 1
DECLARE @iSecondTableEmty INT = 1

SELECT @idSecondBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
IF(@idFirstBill IS NULL)
BEGIN
	INSERT INTO dbo.Bill
	        (
	          DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status
	        )
	VALUES  ( 
	          GETDATE() , -- DateChecIn - date
	          NULL , -- DateCheckOut - date
	          @idTable1 , -- idTable - int
	          0  -- status - int
	        )
	SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
END
SELECT @isFirstTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
IF(@idSecondBill IS NULL)
BEGIN
	INSERT INTO dbo.Bill
	        (
	          DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status
	        )
	VALUES  ( 
	          GETDATE() , -- DateChecIn - date
	          NULL , -- DateCheckOut - date
	          @idTable2 , -- idTable - int
	          0  -- status - int
	        )
	SELECT @idSecondBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
END

SELECT @iSecondTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSecondBill

SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill
UPDATE dbo.BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)

DROP TABLE IDBillInfoTable
IF(@isFirstTableEmty = 0)
	UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
IF(@iSecondTableEmty = 0)
	UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1 
END
GO
GO
ALTER PROC USP_GetBillByDate
@checkIn date, @checkOunt date
AS
BEGIN
SELECT tf.name AS [Tên bàn], b.totalPrice AS[Tổng tiền], b.DateCheckIn AS [Ngày vào],b.DateCheckOut AS [Ngày ra], b.discount AS [Giảm giá] 
FROM  dbo.Bill AS b , dbo.TableFood AS tf
WHERE b.DateCheckIn >= @checkIn AND b.DateCheckOut <= @checkOunt AND b.status =1 AND tf.id = b.idTable
END
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) 
RETURNS NVARCHAR(4000) 
AS 
BEGIN 
IF @strInput IS NULL 
RETURN @strInput IF @strInput = '' 
RETURN @strInput 
DECLARE @RT NVARCHAR(4000) 
DECLARE @SIGN_CHARS NCHAR(136) 
DECLARE @UNSIGN_CHARS NCHAR (136) 
SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
DECLARE @COUNTER int 
DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
BEGIN 
IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput 
END
GO
CREATE PROC USP_GetListFoodByID
@id INT
AS
BEGIN
	SELECT f.name AS [Tên món], f.Price AS [Giá] , fc.name AS [Danh mục] FROM dbo.Food AS f, dbo.FoodCategory AS fc WHERE f.idCategory = fc.id
END
GO
CREATE PROC USP_DeleteCateGoryByID
@id INT
AS
BEGIN
	DECLARE @CountIDCategory INT
	SELECT @CountIDCategory = COUNT(*) FROM dbo.Food WHERE idCategory = @id
	IF(@CountIDCategory = 0)
	BEGIN
		DELETE dbo.FoodCategory WHERE id=@id
	END
END
GO
CREATE PROC USP_DeleteTabeByID
@id INT
AS
BEGIN
	DECLARE @CountIDTable INT
	DECLARE @Status NVARCHAR(50)
	SELECT @CountIDTable = COUNT(*) FROM dbo.Bill WHERE	 idTable = @id
	SELECT @Status = [status] FROM dbo.TableFood WHERE id = @id
	IF(@CountIDTable = 0 AND @Status=N'Trống')
	BEGIN
		DELETE dbo.TableFood WHERE id = @id
	END
END
GO
SELECT * FROM Food f , FoodCategory fc WHERE f.idCategory = fc.id
SELECT * FROM dbo.Food AS f, dbo.FoodCategory AS fc WHERE f.idCategory = fc.id
GO

