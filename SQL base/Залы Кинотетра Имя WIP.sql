-- create database База_Кинотеатра_Имя COLLATE Cyrillic_General_CI_AS;
use База_Кинотеатра_Имя


-- Таблица мест
CREATE TABLE Места (
    Заказ_ИД INT NOT NULL,
    Место_ИД NVARCHAR(10) NOT NULL,
    FOREIGN KEY (Заказ_ИД) REFERENCES Заказы(Заказ_ИД)
);
-- таблица Места уже существует, она приведена в качестве примера

CREATE TABLE Зал1 (
    Место_ИД NVARCHAR(10) NOT NULL,
    Тип_Места INT NOT NULL,
    Координата_X INT NOT NULL,
    Координата_Y INT NOT NULL
);

CREATE TABLE Зал2 (
    Место_ИД NVARCHAR(10) NOT NULL,
    Тип_Места INT NOT NULL,
    Координата_X INT NOT NULL,
    Координата_Y INT NOT NULL
);

CREATE TABLE Зал3 (
    Место_ИД NVARCHAR(10) NOT NULL,
    Тип_Места INT NOT NULL,
    Координата_X INT NOT NULL,
    Координата_Y INT NOT NULL
);

