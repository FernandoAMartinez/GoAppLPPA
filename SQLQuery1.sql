CREATE PROCEDURE New_Backup
	@filepath varchar(50)
AS
BEGIN
--	BACKUP DATABASE GoApp_Lppa TO DISK = 'C:\Users\MiUsuario\Documents\LPPA\Database-20180709.bak'
	BACKUP DATABASE GoApp_LPPA TO DISK = @filepath
END

CREATE DATABASE LPPA_FINAL
USE LPPA_FINAL
CREATE TABLE [dbo].[Bitacora] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Accion]      VARCHAR (50)  NULL,
    [Descripcion] VARCHAR (150) NULL,
    [Fecha]       DATETIME      NULL,
    [Usuario_Id]  INT           NULL,
	[DVH]		  INT			NOT NULL
);

CREATE TABLE [dbo].[Usuario] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [UserName]  VARCHAR (50)  NOT NULL,
    [Pass]      VARCHAR (100) NOT NULL,
    [IsBlocked] BIT           NOT NULL,
    [Tries]     INT           NOT NULL,
    [Perfil_Id] INT           NOT NULL,
	[DVH]		INT			  NOT NULL
);

CREATE TABLE [dbo].[Perfil] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NULL,
	[DVH]		  INT	       NOT NULL
);
