-- create database База_Релизов COLLATE Cyrillic_General_CI_AS;
use База_Релизов
-- Основная таблица Релизов
CREATE TABLE Релизы (
    Релиз_ИД INT PRIMARY KEY IDENTITY(1,1),
    Название NVARCHAR(255) NOT NULL,
    Оригинальное_Название NVARCHAR(255) NULL,
    Возрастной_Рейтинг VARCHAR(10) NULL,
    Хронометраж_Минут INT NULL,
    Язык NVARCHAR(50) NULL,
    Описание_Сюжета NVARCHAR(MAX) NULL,
    Год_Производства DATE NULL,
);

-- Таблица Страны
CREATE TABLE Страны (
    Страна_ИД INT PRIMARY KEY IDENTITY(1,1),
    Название NVARCHAR(255) NOT NULL
);
-- Таблица Дистрибьюторов
CREATE TABLE Дистрибьюторы (
    Дистрибьютор_ИД INT PRIMARY KEY IDENTITY(1,1),
    Название NVARCHAR(255) NOT NULL
);

-- Таблица Форматов
CREATE TABLE Форматы (
    Формат_ИД INT PRIMARY KEY IDENTITY(1,1),
    Название NVARCHAR(50) NOT NULL UNIQUE
);

-- Таблица Жанров
CREATE TABLE Жанры (
    Жанр_ИД INT PRIMARY KEY IDENTITY(1,1),
    Название NVARCHAR(50) NOT NULL UNIQUE
);

-- Таблица Актеров
CREATE TABLE Актеры (
    Актер_ИД INT PRIMARY KEY IDENTITY(1,1),
    Полное_Имя NVARCHAR(200) NOT NULL
);

-- Таблица Режиссеров
CREATE TABLE Режиссеры (
    Режиссер_ИД INT PRIMARY KEY IDENTITY(1,1),
    Полное_Имя NVARCHAR(200) NOT NULL
);
-- Релиз - Страна
CREATE TABLE Релиз_Страны (
    Релиз_ИД INT NOT NULL,
    Страна_ИД INT NOT NULL,
    FOREIGN KEY (Релиз_ИД) REFERENCES Релизы(Релиз_ИД),
    FOREIGN KEY (Страна_ИД) REFERENCES Страны(Страна_ИД)
);

-- Релиз - Дистрибьютор
CREATE TABLE Релиз_Дистрибьюторы (
    Релиз_ИД INT NOT NULL,
    Дистрибьютор_ИД INT NOT NULL,
    FOREIGN KEY (Релиз_ИД) REFERENCES Релизы(Релиз_ИД),
    FOREIGN KEY (Дистрибьютор_ИД) REFERENCES Дистрибьюторы(Дистрибьютор_ИД)
);

-- Релиз - Формат
CREATE TABLE Релиз_Форматы (
    Релиз_ИД INT NOT NULL,
    Формат_ИД INT NOT NULL,
    FOREIGN KEY (Релиз_ИД) REFERENCES Релизы(Релиз_ИД),
    FOREIGN KEY (Формат_ИД) REFERENCES Форматы(Формат_ИД)
);

-- Релиз - Жанр
CREATE TABLE Релиз_Жанры (
    Релиз_ИД INT NOT NULL,
    Жанр_ИД INT NOT NULL,
    FOREIGN KEY (Релиз_ИД) REFERENCES Релизы(Релиз_ИД),
    FOREIGN KEY (Жанр_ИД) REFERENCES Жанры(Жанр_ИД)
);

-- Релиз - Актер
CREATE TABLE Релиз_Актеры (
    Релиз_ИД INT NOT NULL,
    Актер_ИД INT NOT NULL,
    FOREIGN KEY (Релиз_ИД) REFERENCES Релизы(Релиз_ИД),
    FOREIGN KEY (Актер_ИД) REFERENCES Актеры(Актер_ИД)
);

-- Релиз - Режиссер
CREATE TABLE Релиз_Режиссеры (
    Релиз_ИД INT NOT NULL,
    Режиссер_ИД INT NOT NULL,
    FOREIGN KEY (Релиз_ИД) REFERENCES Релизы(Релиз_ИД),
    FOREIGN KEY (Режиссер_ИД) REFERENCES Режиссеры(Режиссер_ИД)
);

GRANT SELECT ON Релизы TO public;
GRANT SELECT ON Страны TO public;
GRANT SELECT ON Дистрибьюторы TO public;
GRANT SELECT ON Форматы TO public;
GRANT SELECT ON Жанры TO public;
GRANT SELECT ON Актеры TO public;
GRANT SELECT ON Режиссеры TO public;
GRANT SELECT ON Релиз_Страны TO public;
GRANT SELECT ON Релиз_Дистрибьюторы TO public;
GRANT SELECT ON Релиз_Форматы TO public;
GRANT SELECT ON Релиз_Жанры TO public;
GRANT SELECT ON Релиз_Актеры TO public;
GRANT SELECT ON Релиз_Режиссеры TO public;
