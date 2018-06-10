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
CREATE PROCEDURE Bitacora_Insert
	-- Add the parameters for the stored procedure here
	@Accion varchar(50),
	@Descripcion varchar(150),
	@Fecha datetime,
	@Usuario_Id int 
AS
BEGIN
	
	INSERT INTO GoApp_LPPA.dbo.Bitacora (Accion, Descripcion, Fecha, Usuario_Id) VALUES
	(@Accion, @Descripcion, @Fecha, @Usuario_Id)

END
GO
