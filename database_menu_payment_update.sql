USE ECoffeeDb;
GO

IF COL_LENGTH('dbo.Menus', 'IsActive') IS NULL
BEGIN
    ALTER TABLE dbo.Menus
    ADD IsActive BIT NOT NULL CONSTRAINT DF_Menus_IsActive DEFAULT(1);
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM dbo.Categories
    WHERE Name = N'Cà phê'
)
BEGIN
    INSERT INTO dbo.Categories (Id, Name, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)
    VALUES (NEXT VALUE FOR dbo.global_seq, N'Cà phê', GETDATE(), GETDATE(), N'system', N'system');
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM dbo.Categories
    WHERE Name = N'Trà sữa'
)
BEGIN
    INSERT INTO dbo.Categories (Id, Name, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)
    VALUES (NEXT VALUE FOR dbo.global_seq, N'Trà sữa', GETDATE(), GETDATE(), N'system', N'system');
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM dbo.Categories
    WHERE Name = N'Nước ép'
)
BEGIN
    INSERT INTO dbo.Categories (Id, Name, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)
    VALUES (NEXT VALUE FOR dbo.global_seq, N'Nước ép', GETDATE(), GETDATE(), N'system', N'system');
END
GO

PRINT N'Đã cập nhật schema cho Menu và Payment.';
PRINT N'Bạn chỉ cần chạy script này trong SQL Server Management Studio 2022 trước khi mở app.';
GO
