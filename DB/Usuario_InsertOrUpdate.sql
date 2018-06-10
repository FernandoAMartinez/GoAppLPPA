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
CREATE PROCEDURE Usuario_InsertOrUpdate
	-- Add the parameters for the stored procedure here
		@Id int ,
		@UserName varchar(50) ,
		@Password varchar(100),
		@IsBlocked bit ,
		@Tries int ,
		@Perfil_Id int 
AS
BEGIN
	
	DECLARE @Count int 

	SELECT @Count = Count(*) FROM GoApp_LPPA.dbo.Usuario WHERE Id = @Id

	IF @Count > 0 
		UPDATE GoApp_LPPA.dbo.Usuario SET UserName = @UserName, Pass = @Password, IsBlocked = @IsBlocked,
		Tries = @Tries, Perfil_Id = @Perfil_Id WHERE Id = @Id
	ELSE
		INSERT INTO GoApp_LPPA.dbo.Usuario (UserName, Pass, IsBlocked, Tries, Perfil_Id) VALUES (@UserName, @Password, @IsBLocked
		,@Tries, @Perfil_Id)

END
GO
