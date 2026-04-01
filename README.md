"# ECoffeeApplication"



Remove-Migration



Add-Migration Init



Update-Database



INSERT INTO ECoffeeDb.dbo.Roles

(Id, Name, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)

VALUES(NEXT VALUE FOR ECoffeeDb.dbo.global\_seq, N'Manager', '2026-03-25 00:00:00.000', '2026-03-25 00:00:00.000', N'system', N'system');

INSERT INTO ECoffeeDb.dbo.Roles

(Id, Name, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)

VALUES(NEXT VALUE FOR ECoffeeDb.dbo.global\_seq, N'Cashier', '2026-03-25 00:00:00.000', '2026-03-25 00:00:00.000', N'system', N'system');

INSERT INTO ECoffeeDb.dbo.Roles

(Id, Name, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)

VALUES(NEXT VALUE FOR ECoffeeDb.dbo.global\_seq, N'Barista', '2026-03-25 00:00:00.000', '2026-03-25 00:00:00.000', N'system', N'system');





INSERT INTO ECoffeeDb.dbo.Users (Id, Email, PasswordHash, FullName, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Address, DateOfBirth)

VALUES(NEXT VALUE FOR ECoffeeDb.dbo.global\_seq, N'admin@gmail.com', N'AQAAAAIAAYagAAAAEPyXI8rf0o3S0kCgtKy/AQ4bUwUn+Beohx1QKbyR6QjC+YyPdby0P2AtxRtP8L5tEw==', N'Hoàng Bá Hà', '2026-03-25 00:00:00.000', '2026-03-25 00:00:00.000', N'system', N'system', N'TP.HCM', '2026-03-25');

INSERT INTO ECoffeeDb.dbo.UserRoles

(UserId, RoleId)

VALUES(4, 1);

