-- create database База_Кинотеатра_Имя COLLATE Cyrillic_General_CI_AS;
use База_Кинотеатра_Имя

-- Таблица Сеансов
CREATE TABLE Сеансы (
    Сеанс_ИД INT PRIMARY KEY IDENTITY(1,1),
    Релиз_ИД INT NOT NULL,
    Номер_Зала INT NOT NULL,
    Дата_Время DATETIME NOT NULL
);
CREATE TABLE Заказы (
    Заказ_ИД INT PRIMARY KEY IDENTITY(1,1),
    Сеанс_ИД INT NOT NULL,
    Сумма_Оплаты MONEY
    FOREIGN KEY (Сеанс_ИД) REFERENCES Сеансы(Сеанс_ИД)
);
-- Таблица мест
CREATE TABLE Места (
    Заказ_ИД INT NOT NULL,
    Место_ИД NVARCHAR(10) NOT NULL,
    FOREIGN KEY (Заказ_ИД) REFERENCES Заказы(Заказ_ИД)
);
--
-- Таблица форматов сеансов
CREATE TABLE Сеансы_Форматы (
    Сеанс_ИД INT NOT NULL,
    Формат_ИД INT NOT NULL,
    FOREIGN KEY (Сеанс_ИД) REFERENCES Сеансы(Сеанс_ИД)
);
