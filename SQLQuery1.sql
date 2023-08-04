INSERT INTO Roles (RoleName)
VALUES ('Admin'),
       ('User'),
       ('Employer');

       CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    RoleName NVARCHAR(50) NOT NULL
);

ALTER TABLE IsVerenKayit
ADD RoleID INT NOT NULL default  3  REFERENCES Roles(RoleID);



--select K.KullaniciID , K.KullaniciAdi  , R.RoleName   from Kullanici as K , Roles as R  where R.RoleID = K.RoleID 

--ALTER TABLE Kullanici
--ADD CONSTRAINT UQ_Mail UNIQUE (Mail);

