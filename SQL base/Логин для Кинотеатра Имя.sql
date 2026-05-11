use База_Кинотеатра_Имя
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARBINARY(64) NOT NULL, -- Храним хеш, а не пароль!
);
go
CREATE PROCEDURE add_user
@Username NVARCHAR(50),
@Password NVARCHAR(50)
AS
BEGIN
    DECLARE @PasswordHash VARBINARY(64);
    SET @PasswordHash = HASHBYTES('SHA2_256', @Password);
    
    INSERT INTO Users (Username, PasswordHash)
    VALUES (@Username, @PasswordHash);
END;
go
use База_Кинотеатра_Имя
exec add_user 'sa','123';
go
use База_Кинотеатра_Имя
exec add_user 'Dima','123';
go
use База_Кинотеатра_Имя
exec add_user 'Sergei','321';

GRANT SELECT ON Users TO public;
GO