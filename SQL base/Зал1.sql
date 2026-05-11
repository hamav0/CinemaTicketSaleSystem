DECLARE @HallTable NVARCHAR(10) = 'Зал1';
DECLARE @SeatSize INT = 37;
DECLARE @StandardGap INT = 12; -- Зазор между обычными креслами
DECLARE @SofaGap INT = 4;     -- Уменьшенный зазор внутри дивана
DECLARE @AisleWidth INT = 2 * (@SeatSize + @StandardGap);  -- Ширина лестницы/прохода

-- Очистка перед генерацией (для тестов)
EXEC('DELETE FROM ' + @HallTable);

DECLARE @r INT = 1;
DECLARE @TotalRows INT = 7;
DECLARE @X BIT = 0;

WHILE @r <= @TotalRows
BEGIN
    DECLARE @s INT = 1;
    DECLARE @SeatsInThisRow INT = CASE @r
    WHEN 4 THEN 13
    WHEN 5 THEN 13
    WHEN 6 THEN 13
    WHEN 7 THEN 16
    ELSE 11 END;
    SET @StandardGap = 12;
    DECLARE @CurrentPosX INT = 100 + (CASE @r WHEN 7 THEN 0 ELSE 1 END) * (@SeatSize + @StandardGap) + 10; -- Базовый отступ ряда
    DECLARE @BasePosY INT = 100 + (@r - 1) * (@SeatSize + @StandardGap) + 6; -- Базовая линия ряда
    
    -- Смещение для рядов с отступом
    -- IF @r IN (1, 2, 3) SET @CurrentPosX = 200; 

    WHILE @s <= @SeatsInThisRow
    BEGIN
        SET @StandardGap = 12;
        -- 1. ЛОГИКА ПРОПУСКОВ (ЛЕСТНИЦЫ)
        -- Например, после 5-го места идет широкий проход
        IF @s = 12 AND @r > 3 AND @r < 7 SET @CurrentPosX = @CurrentPosX + @AisleWidth;

        -- 2. ОПРЕДЕЛЕНИЕ ТИПА (Для примера: последние 2 ряда - диваны)
        
        DECLARE @Type INT
        SET @Type = 1;
        IF @r = 7 SET @Type = 2;
         -- Центральные места в средних рядах
        IF @s BETWEEN 6 AND 7 SET @Type = 2;

        -- 3. ФОРМИРОВАНИЕ ID И ВСТАВКА
        DECLARE @SeatID NVARCHAR(10) = 's' + CAST(@r AS NVARCHAR) + '_' + CAST(@s AS NVARCHAR);
        
        DECLARE @Sql NVARCHAR(MAX) = 'INSERT INTO ' + @HallTable + 
            ' (Место_ИД, Тип_Места, Координата_X, Координата_Y) VALUES ' +
            '(''' + @SeatID + ''', ' + CAST(@Type AS NVARCHAR) + ', ' + 
            CAST(@CurrentPosX AS NVARCHAR) + ', ' + CAST(@BasePosY AS NVARCHAR) + ')';
        EXEC sp_executesql @Sql;

        -- 5. РАСЧЕТ ШАГА ДЛЯ СЛЕДУЮЩЕГО КРЕСЛА
        -- Если текущее и следующее места — части одного дивана (например, 1-2, 3-4)
        IF @r = 7 SET @StandardGap = @StandardGap * 2;
        DECLARE @NextGap INT;
        IF @Type = 2 AND (@X = 0) 
        BEGIN
            SET @NextGap = @SofaGap; -- Тесный зазор внутри дивана
            SET @X = 1;
        END
            ELSE 
        BEGIN
            SET @NextGap = @StandardGap  -- Обычный зазор 
            SET @X = 0;
        END

        SET @CurrentPosX = @CurrentPosX + @SeatSize + @NextGap;
        SET @s = @s + 1;
    END
    SET @r = @r + 1;
END