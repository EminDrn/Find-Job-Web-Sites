----ALTER TABLE Ilan
----ADD ilanEklenmeTarihi DATETIME DEFAULT GETDATE();
----ALTER TABLE Ilan
----ALTER COLUMN ilanEklenmeTarihi DATETIME DEFAULT GETDATE();

--ALTER TABLE Ilan
--ALTER COLUMN ilanEklenmeTarihi DROP default;