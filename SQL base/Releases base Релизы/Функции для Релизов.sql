USE База_Релизов;
GO
-- Функция для ввода данных в таблицу "Релизы"
CREATE PROCEDURE Ввод_Релизы
    @Название NVARCHAR(255),
    @Оригинальное_Название NVARCHAR(255) = NULL,
    @Возрастной_Рейтинг VARCHAR(10) = NULL,
    @Хронометраж_Минут INT = NULL,
    @Язык NVARCHAR(50) = NULL,
    @Описание_Сюжета NVARCHAR(MAX) = NULL,
    @Год_Производства DATE = NULL
AS
BEGIN
    INSERT INTO Релизы (Название, Оригинальное_Название, Возрастной_Рейтинг, Хронометраж_Минут, Язык, Описание_Сюжета, Год_Производства)
    VALUES (@Название, @Оригинальное_Название, @Возрастной_Рейтинг, @Хронометраж_Минут, @Язык, @Описание_Сюжета, @Год_Производства);
END;
GO

-- Функция для ввода данных в таблицу "Страны"
CREATE PROCEDURE Ввод_Страны
    @Название NVARCHAR(255)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Страны WHERE Название = @Название)
    BEGIN
        INSERT INTO Страны (Название)
        VALUES (@Название);
    END;
END;
GO

-- Функция для ввода данных в таблицу "Дистрибьюторы"
CREATE PROCEDURE Ввод_Дистрибьюторы
    @Название NVARCHAR(255)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Дистрибьюторы WHERE Название = @Название)
    BEGIN
        INSERT INTO Дистрибьюторы (Название)
        VALUES (@Название);
    END;
END;
GO

-- Функция для ввода данных в таблицу "Форматы"
CREATE PROCEDURE Ввод_Форматы
    @Название NVARCHAR(50)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Форматы WHERE Название = @Название)
    BEGIN
        INSERT INTO Форматы (Название)
        VALUES (@Название);
    END;
END;
GO

-- Функция для ввода данных в таблицу "Жанры"
CREATE PROCEDURE Ввод_Жанры
    @Название NVARCHAR(50)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Жанры WHERE Название = @Название)
    BEGIN
        INSERT INTO Жанры (Название)
        VALUES (@Название);
    END;
END;
GO

-- Функция для ввода данных в таблицу "Актеры"
CREATE PROCEDURE Ввод_Актеры
    @Полное_Имя NVARCHAR(200)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Актеры WHERE Полное_Имя = @Полное_Имя)
    BEGIN
        INSERT INTO Актеры (Полное_Имя)
        VALUES (@Полное_Имя);
    END;
END;
GO

-- Функция для ввода данных в таблицу "Режиссеры"
CREATE PROCEDURE Ввод_Режиссеры
    @Полное_Имя NVARCHAR(200)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Режиссеры WHERE Полное_Имя = @Полное_Имя)
    BEGIN
        INSERT INTO Режиссеры (Полное_Имя)
        VALUES (@Полное_Имя);
    END;
END;
GO
-- лишнее, или нет? если бы был ввод тогда бы в форме было бы foreach

-- Функция для ввода данных в таблицу "Релиз_Страны"
CREATE PROCEDURE Ввод_Релиз_Страны
    @Релиз_ИД INT,
    @Страна_ИД INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Релиз_Страны WHERE Релиз_ИД = @Релиз_ИД AND Страна_ИД = @Страна_ИД)
    BEGIN
        INSERT INTO Релиз_Страны (Релиз_ИД, Страна_ИД)
        VALUES (@Релиз_ИД, @Страна_ИД);
    END;
END;
GO

-- Функция для ввода данных в таблицу "Релиз_Дистрибьюторы"
CREATE PROCEDURE Ввод_Релиз_Дистрибьюторы
    @Релиз_ИД INT,
    @Дистрибьютор_ИД INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Релиз_Дистрибьюторы WHERE Релиз_ИД = @Релиз_ИД AND Дистрибьютор_ИД = @Дистрибьютор_ИД)
    BEGIN
        INSERT INTO Релиз_Дистрибьюторы (Релиз_ИД, Дистрибьютор_ИД)
        VALUES (@Релиз_ИД, @Дистрибьютор_ИД);
    END;
END;
GO

-- Функция для ввода данных в таблицу "Релиз_Форматы"
CREATE PROCEDURE Ввод_Релиз_Форматы
    @Релиз_ИД INT,
    @Формат_ИД INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Релиз_Форматы WHERE Релиз_ИД = @Релиз_ИД AND Формат_ИД = @Формат_ИД)
    BEGIN
        INSERT INTO Релиз_Форматы (Релиз_ИД, Формат_ИД)
        VALUES (@Релиз_ИД, @Формат_ИД);
    END;
END;
GO

-- Функция для ввода данных в таблицу "Релиз_Жанры"
CREATE PROCEDURE Ввод_Релиз_Жанры
    @Релиз_ИД INT,
    @Жанр_ИД INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Релиз_Жанры WHERE Релиз_ИД = @Релиз_ИД AND Жанр_ИД = @Жанр_ИД)
    BEGIN
        INSERT INTO Релиз_Жанры (Релиз_ИД, Жанр_ИД)
        VALUES (@Релиз_ИД, @Жанр_ИД);
    END;
END;
GO

-- Функция для ввода данных в таблицу "Релиз_Актеры"
CREATE PROCEDURE Ввод_Релиз_Актеры
    @Релиз_ИД INT,
    @Актер_ИД INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Релиз_Актеры WHERE Релиз_ИД = @Релиз_ИД AND Актер_ИД = @Актер_ИД)
    BEGIN
        INSERT INTO Релиз_Актеры (Релиз_ИД, Актер_ИД)
        VALUES (@Релиз_ИД, @Актер_ИД);
    END;
END;
GO

-- Функция для ввода данных в таблицу "Релиз_Режиссеры"
CREATE PROCEDURE Ввод_Релиз_Режиссеры
    @Релиз_ИД INT,
    @Режиссер_ИД INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Релиз_Режиссеры WHERE Релиз_ИД = @Релиз_ИД AND Режиссер_ИД = @Режиссер_ИД)
    BEGIN
        INSERT INTO Релиз_Режиссеры (Релиз_ИД, Режиссер_ИД)
        VALUES (@Релиз_ИД, @Режиссер_ИД);
    END;
END;
GO
