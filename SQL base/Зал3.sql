DECLARE @HallTable NVARCHAR(10) = 'Зал3';
DECLARE @SeatSize INT = 37;
DECLARE @StandardGap INT = 12; -- Зазор между обычными креслами
DECLARE @SofaGap INT = 30;     -- Уменьшенный зазор внутри дивана
DECLARE @AisleWidth INT = 40;  -- Ширина лестницы/прохода

-- Очистка перед генерацией (для тестов)
EXEC('DELETE FROM ' + @HallTable);

DECLARE @r INT = 1;
DECLARE @TotalRows INT = 15;
DECLARE @X BIT = 0;

WHILE @r <= @TotalRows
BEGIN
    DECLARE @s INT = 1;
    DECLARE @SeatsInThisRow INT = CASE @r
    WHEN 14 THEN 28
    WHEN 15 THEN 24
    WHEN 1 THEN 22
    WHEN 2 THEN 26
    WHEN 3 THEN 28
    ELSE 40 END;
    SET @StandardGap = 12;
    DECLARE @CurrentPosX INT = 100 + (CASE @r WHEN 1 THEN 10 WHEN 2 THEN 8 WHEN 3 THEN 7 ELSE 0 END) * (@SeatSize + @StandardGap) + (CASE WHEN @r > 13 THEN 15 ELSE 0 END); -- Базовый отступ ряда
    DECLARE @BasePosY INT = 156 + (CASE WHEN @r > 3 THEN 20 ELSE 0 END) + (@r - 1) * (@SeatSize + @StandardGap) + (CASE WHEN @r = 15 THEN 40 ELSE 0 END); -- Базовая линия ряда
    
    -- Смещение для рядов с отступом
    -- IF @r IN (1, 2, 3) SET @CurrentPosX = 200; 

    WHILE @s <= @SeatsInThisRow
    BEGIN
        SET @StandardGap = 12;
        -- 1. ЛОГИКА ПРОПУСКОВ (ЛЕСТНИЦЫ)
        -- Например, после 5-го места идет широкий проход
        -- IF @s = 6 AND @r = X SET @CurrentPosX = @CurrentPosX + @AisleWidth;

        -- 2. ОПРЕДЕЛЕНИЕ ТИПА (Для примера: последние 2 ряда - диваны)
        
        DECLARE @Type INT
        SET @Type = 1;
        IF @r > (@TotalRows - 2) SET @Type = 2;
         -- Центральные места в средних рядах - VIP (тип 3)
        IF @r = 6 AND @s BETWEEN 17 AND 24 SET @Type = 3;
        ELSE IF @r = 7 AND @s BETWEEN 15 AND 26 SET @Type = 3;
        ELSE IF @r = 8 AND @s BETWEEN 15 AND 26 SET @Type = 3;
        ELSE IF @r = 9 AND @s BETWEEN 15 AND 26 SET @Type = 3;
        ELSE IF @r = 10 AND @s BETWEEN 13 AND 28 SET @Type = 3;
        ELSE IF @r = 11 AND @s BETWEEN 13 AND 28 SET @Type = 3;
        ELSE IF @r = 12 AND @s BETWEEN 11 AND 30 SET @Type = 3;
        ELSE IF @r = 13 AND @s BETWEEN 11 AND 30 SET @Type = 3;

        -- 3. ЛОГИКА КРИВИЗНЫ IMAX
        -- Реализуем "V-образный" изгиб для первых трех рядов
        DECLARE @CurveOffset INT = 0;
        IF @r <= 3 
        BEGIN
            -- Идем вниз до середины, потом вверх
            IF @r = 1 AND @s BETWEEN 1 AND 7 SET @CurveOffset = (8 - @s) * 8;
            ELSE IF @r = 1 AND @s BETWEEN 16 AND 22 SET @CurveOffset = (@s - 15) * 8;
            ELSE IF @r = 2 AND @s BETWEEN 1 AND 8 SET @CurveOffset = (9 - @s) * 7;
            ELSE IF @r = 2 AND @s BETWEEN 19 AND 26 SET @CurveOffset = (@s - 18) * 7;
            ELSE IF @r = 3 AND @s BETWEEN 1 AND 8 SET @CurveOffset = (9 - @s) * 7;
            ELSE IF @r = 3 AND @s BETWEEN 21 AND 28 SET @CurveOffset = (@s - 20) * 7;
            -- Чем дальше от центра, тем выше (или наоборот)
        END

        

        -- 4. ФОРМИРОВАНИЕ ID И ВСТАВКА
        DECLARE @SeatID NVARCHAR(10) = 's' + CAST(@r AS NVARCHAR) + '_' + CAST(@s AS NVARCHAR);
        
        DECLARE @Sql NVARCHAR(MAX) = 'INSERT INTO ' + @HallTable + 
            ' (Место_ИД, Тип_Места, Координата_X, Координата_Y) VALUES ' +
            '(''' + @SeatID + ''', ' + CAST(@Type AS NVARCHAR) + ', ' + 
            CAST(@CurrentPosX AS NVARCHAR) + ', ' + CAST(@BasePosY - @CurveOffset AS NVARCHAR) + ')';
        EXEC sp_executesql @Sql;

        -- РАСЧЕТ ШАГА ДЛЯ ОПРЕДЕЛЁННОГО РЯДА
        IF @r > 13 SET @StandardGap = @StandardGap * 4 - 14;

        -- 5. РАСЧЕТ ШАГА ДЛЯ СЛЕДУЮЩЕГО КРЕСЛА
        -- Если текущее и следующее места — части одного дивана (например, 1-2, 3-4)
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