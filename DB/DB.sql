Create database GoApp_LPPA

USE GoApp_LPPA

CREATE TABLE Usuario (
	Id int NOT NULL IDENTITY(1,1), 
	UserName varchar(50) not null,
	Pass varchar(100) not null,
	IsBlocked bit not null default 0,
	Tries int not null default 0,
	Perfil_Id int not null,
	CONSTRAINT PK_Usuario PRIMARY KEY (Id)
)

CREATE TABLE Perfil (
	Id int NOT NULL IDENTITY(1,1), 
	Descripcion varchar(50),
	CONSTRAINT PK_Perfil PRIMARY KEY (Id)
)

CREATE TABLE Bitacora (
	Id int NOT NULL IDENTITY(1,1), 
	Accion varchar(50),
	Descripcion varchar(150),
	Fecha datetime,
	Usuario_Id int,
	CONSTRAINT PK_Bitacora PRIMARY KEY (Id)
)

INSERT INTO Perfil (Descripcion) VALUES ('Master'), ('Administrador'), ('Cliente')