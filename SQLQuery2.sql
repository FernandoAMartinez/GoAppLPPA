USE [GoApp_LPPA]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[New_Backup]
		@filepath = N'C:\\Users\\fernando.b.martinez\\Documents\\UAI\\'

SELECT	@return_value as 'Return Value'

GO
