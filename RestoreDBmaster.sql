﻿ALTER PROCEDURE [dbo].[New_Restore]
	@filepath NVARCHAR(100) = null
AS
BEGIN
	ALTER DATABASE GoApp_LPPA SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	RESTORE DATABASE GoApp_LPPA
	FROM DISK = @filepath
	WITH REPLACE
END