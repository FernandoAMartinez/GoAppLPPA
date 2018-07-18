CREATE DATABASE [LLPA_FINAL]
USE [LPPA_FINAL]
--Tablas
CREATE TABLE [dbo].[Bitacora] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Accion]      VARCHAR (50)  NULL,
    [Descripcion] VARCHAR (150) NULL,
    [Fecha]       VARCHAR(19)      NULL,
    [Usuario_Id]  INT           NULL,
    [DVH]         INT           NOT NULL
);

CREATE TABLE [dbo].[Perfil] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NULL,
    [DVH]         INT          NOT NULL
);

CREATE TABLE [dbo].[DVV] (
    [ID]    INT           NOT NULL,
    [TABLA] NVARCHAR (20) NOT NULL,
    [DVV]   INT           NOT NULL
);

CREATE TABLE [dbo].[Usuario] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [UserName]  VARCHAR (50)  NOT NULL,
    [Pass]      VARCHAR (100) NOT NULL,
    [IsBlocked] BIT           NOT NULL,
    [Tries]     INT           NOT NULL,
    [Perfil_Id] INT           NOT NULL,
    [DVH]       INT           NOT NULL
);

--Store Procedures
ALTER PROCEDURE Bitacora_Insert
	-- Add the parameters for the stored procedure here
	@Accion varchar(50),
	@Descripcion varchar(150),
	@Fecha datetime,
	@Usuario_Id int,
	@DVH int
AS
BEGIN
	
	INSERT INTO LPPA_FINAL.dbo.Bitacora (Accion, Descripcion, Fecha, Usuario_Id, DVH) VALUES
	(@Accion, @Descripcion, CONVERT(VARCHAR(19),GETDATE(),120), @Usuario_Id, @DVH)	--modificado fecha bitacora

END

CREATE PROCEDURE Bitacora_Select

AS
BEGIN
	SELECT * FROM LPPA_FINAL.dbo.Bitacora
	ORDER BY Id DESC;
END

CREATE PROCEDURE Perfil_Select 
	@Id int
AS
BEGIN
	SELECT * FROM LPPA_FINAL.dbo.Perfil
	WHERE Id = @Id
END


CREATE PROCEDURE Usuario_Select 
		@Id int = null,
		@UserName varchar(50) = null,
		@Password varchar(100) = null,
		@IsBlocked bit = null,
		@Tries int = null,
		@Perfil_Id int = null
AS
BEGIN
	SELECT [Id]
      ,[UserName]
      ,[Pass]
      ,[IsBlocked]
      ,[Tries]
      ,[Perfil_Id]
	FROM [LPPA_FINAL].[dbo].[Usuario]
	WHERE (Id = @Id OR @Id IS NULL)
	AND (UserName = @UserName OR @UserName IS NULL)
	AND (Pass = @Password OR @Password IS NULL)
	AND (IsBlocked = @IsBlocked OR @IsBlocked IS NULL)
	AND (Tries = @Tries OR @Tries IS NULL)
	AND (Perfil_Id = @Perfil_Id OR @Perfil_Id IS NULL)
END
--Se obtiene la tabla de dígitos verificadores verticales
CREATE PROCEDURE Digitos_Verticales
AS
BEGIN
	SELECT	ID		AS	"Id",
			TABLA	AS	"Tabla",
			DVV		AS	"DVV"
	FROM DVV
END

create procedure Select_Tables
as
begin
	select Tabla
	from DVV
end
--Store Procedure para obtener todos los dígitos verificadores de la tabla parámetro
--El campo de dígito verificador horizontal se debe llamar DVH
CREATE PROCEDURE Get_Digitos
	@tabla nvarchar(30)
AS
BEGIN
	DECLARE @SQL NVARCHAR(MAX)
	SET @SQL = N'SELECT	DVH AS "DVH" FROM ' + QUOTENAME(@tabla)
	EXEC (@SQL)
END


--Store Procedure para obtene todas las columnas de una tabla, sin la de Dígito verificador horizontal
--El campo de dígito verificador horizontal se debe llamar DVH
CREATE PROCEDURE Get_Columns
	@tabla nvarchar(30)
AS
BEGIN
	DECLARE @COLS NVARCHAR(MAX) = NULL
	SELECT @COLS = COALESCE(@COLS + ', ' + COLUMN_NAME, COLUMN_NAME)
	FROM INFORMATION_SCHEMA.COLUMNS ca
	WHERE CA.TABLE_NAME = @tabla
	AND COLUMN_NAME != 'DVH'
	DECLARE @SQL NVARCHAR(MAX)
	SET @SQL = N'SELECT ' + @COLS + ' FROM ' + @tabla 
	EXEC (@SQL)
END

--Backup
use [LPPA_FINAL]
CREATE PROCEDURE New_Backup
	@filepath NVARCHAR(100) = null
AS
BEGIN
	DECLARE @file VARCHAR(100)
--	BACKUP DATABASE GoApp_Lppa TO DISK = 'C:\Users\MiUsuario\Documents\LPPA\Database-20180709.bak'
	SET @filepath = REPLACE(@filepath, '\\', '\')
	SET @file = @filepath + 'GoApp_LPPA' + CONVERT(CHAR(10), GETDATE(), 121) + '.bak'
	BACKUP DATABASE LPPA_FINAL 
	TO DISK = @file
END

--Restore
USE [master]
CREATE PROCEDURE [dbo].[New_Restore]
	@filepath NVARCHAR(100) = null
AS
BEGIN
	ALTER DATABASE LPPA_FINAL SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	RESTORE DATABASE LPPA_FINAL
	FROM DISK = @filepath
	WITH REPLACE
END