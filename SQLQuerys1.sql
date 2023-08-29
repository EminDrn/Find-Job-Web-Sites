drop table ilanTanitim

ALTER TABLE Ilan DROP COLUMN IlanTanitimId;
alter table Ilan add IlanTanitim nvarchar(max) not null default 'Ürün Tanitimi Girilmedi'