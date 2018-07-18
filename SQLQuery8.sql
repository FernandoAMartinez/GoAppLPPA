--SELECT *
--FROM Bitacora
--
--CREATE TABLE DVV(
--ID INT NOT NULL,
--TABLA NVARCHAR(20) NOT NULL,
--DVV	INT	NOT NULL
--)
--
--INSERT INTO DVV VALUES (1, 'Usuario', (SELECT SUM(DVH) FROM Usuario)),(2,'Bitacora',(SELECT SUM(DVH) FROM Bitacora)),(3,'Perfil',(SELECT SUM(DVH) FROM Perfil))
--
--select * from dvv
--
---- 1. seleccionar todas las tablas a iterar 
--	list<string> tablas = SELECT TABLA FROM DVV
--
---- 2. para cada tabla obtener el DV de cada registro y comparar con el cálculo
--	@id = select top 1 id from tabla
--	for each tabla in tablas
--		SET @DV = (SELECT DVH FROM tabla WHERE ID = @ID)
--		IF(@DV = Get_DV())
--		{
--			return ok;
--		}
--		else
--		{
--			registro = new registro(campos[]);
--			listaTablas.Add(registro);
--			return null;
--		}
--		set @id = select top 1 id from table where id > @id
--
---- 2.1
--DECLARE @ID INT = 1
--SELECT * FROM Bitacora WHERE Id = @ID
--SELECT TOP 1 * FROM Bitacora WHERE Id > @ID
--
--create procedure Select_Tables
--as
--begin
--	select Tabla
--	from DVV
--end
--
--exec Select_Tables
--
--select * 
--from (select top 1 *
--	  from (select Tabla from DVV)

--Se obtiene la tabla de dígitos verificadores verticales
CREATE PROCEDURE Digitos_Verticales
AS
BEGIN
	SELECT	ID		AS	"Id",
			TABLA	AS	"Tabla",
			DVV		AS	"DVV"
	FROM DVV
END

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

SELECT CONVERT(VARCHAR(19), GETDATE(), 120)
SELECT GETDATE()

DECLARE @TESTDATE VARCHAR(19)
SET @TESTDATE = (SELECT CONVERT(VARCHAR(19), GETDATE(), 120))
SELECT @TESTDATE

DECLARE @DATETIME DATETIME
SET @DATETIME = @TESTDATE
SELECT @DATETIME

tablaHorarios = select horarios
