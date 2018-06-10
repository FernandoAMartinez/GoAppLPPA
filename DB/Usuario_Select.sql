-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
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
	FROM [GoApp_LPPA].[dbo].[Usuario]
	WHERE (Id = @Id OR @Id IS NULL)
	AND (UserName = @UserName OR @UserName IS NULL)
	AND (Pass = @Password OR @Password IS NULL)
	AND (IsBlocked = @IsBlocked OR @IsBlocked IS NULL)
	AND (Tries = @Tries OR @Tries IS NULL)
	AND (Perfil_Id = @Perfil_Id OR @Perfil_Id IS NULL)
END
GO
