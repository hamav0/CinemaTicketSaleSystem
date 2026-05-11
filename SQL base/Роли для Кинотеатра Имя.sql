use База_Кинотеатра_Имя
exec sp_addrole 'sys_admin'
exec sp_addrole 'Кассир'
grant delete, insert, update, select to sys_admin grant execute to sys_admin
grant insert, update, select on Места to Кассир
grant insert, update, select, alter on View_SessionCards to Кассир
grant UPDATE on Сеансы to Кассир;
grant SELECT on Заказы to Кассир;
grant SELECT on Зал1 to Кассир;
grant SELECT on Зал2 to Кассир;
grant SELECT on Зал3 to Кассир;
grant EXECUTE on Ввод_Заказы to Кассир;
grant EXECUTE on Ввод_Места to Кассир;
-- пример
use master
create login Sergei with password = '321';
create login Dima with password = '123';
use База_Кинотеатра_Имя

create user Sergei_sys for login Sergei;
alter role sys_admin add member Sergei_sys;

create user Dima_k for login Dima;
alter role Кассир add member Dima_k;

-- с доступом к База_Релизов надо быть повнимательнее
-- так как она вроде далось а вроде не сразу
-- за sa может быть всё хорошо, а вот когда я логинился на Dima
-- тогда были проблемы с select, что странновато

