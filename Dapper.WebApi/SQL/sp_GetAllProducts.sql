IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'sp_GetAllProducts')
BEGIN
DROP PROCEDURE dbo.sp_GetAllProducts;
END
GO

CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM Product
	
END