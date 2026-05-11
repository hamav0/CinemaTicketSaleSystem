-- create database База_Кинотеатра_Имя COLLATE Cyrillic_General_CI_AS;
use База_Кинотеатра_Имя
go
CREATE VIEW View_SessionCards AS
SELECT 
    S.Сеанс_ИД,
    R.Название,
    R.Возрастной_Рейтинг AS Рейтинг,
    R.Год_Производства AS Год,
    R.Хронометраж_Минут AS Длительность,
    S.Номер_Зала AS Зал,
    S.Дата_Время,
    FORMAT(S.Дата_Время, 'HH:mm') AS Время_Начала,
    ISNULL((SELECT STRING_AGG(Str.Название, ', ') 
            FROM База_Релизов.dbo.Страны Str JOIN База_Релизов.dbo.Релиз_Страны RS ON Str.Страна_ИД = RS.Страна_ИД 
            WHERE RS.Релиз_ИД = R.Релиз_ИД), 'Не указано') AS Страны,
   ISNULL((SELECT STRING_AGG(F.Название, ', ') 
            FROM База_Релизов.dbo.Форматы F JOIN Сеансы_Форматы SF ON F.Формат_ИД = SF.Формат_ИД 
            WHERE SF.Сеанс_ИД = S.Сеанс_ИД), 'Стандарт') AS Форматы,
    ISNULL((SELECT STRING_AGG(D.Название, ', ') 
            FROM База_Релизов.dbo.Дистрибьюторы D JOIN База_Релизов.dbo.Релиз_Дистрибьюторы RD ON D.Дистрибьютор_ИД = RD.Дистрибьютор_ИД 
            WHERE RD.Релиз_ИД = R.Релиз_ИД), 'Не указан') AS Дистрибьюторы
FROM База_Кинотеатра_Имя.dbo.Сеансы S
JOIN База_Релизов.dbo.Релизы R ON S.Релиз_ИД = R.Релиз_ИД
WHERE S.Дата_Время >= CAST(GETDATE() AS DATE);