USE [GoApp_LPPA]
GO

/****** Object: SqlProcedure [dbo].[New_Backup] Script Date: 12/07/2018 9:46:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE New_Backup
	@filepath VARCHAR(100)
AS
BEGIN
	DECLARE @file VARCHAR(100)
--	BACKUP DATABASE GoApp_Lppa TO DISK = 'C:\Users\MiUsuario\Documents\LPPA\Database-20180709.bak'
	SET @filepath = REPLACE(@filepath, '\\', '\')
	SET @file = @filepath + 'GoApp_LPPA' + CONVERT(CHAR(10), GETDATE(), 121) + '.bak'
	BACKUP DATABASE GoApp_LPPA TO DISK = @file
END


