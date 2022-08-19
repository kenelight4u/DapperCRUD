IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'sp_AddProduct')
BEGIN
DROP PROCEDURE dbo.sp_AddProduct;
END
GO

CREATE PROCEDURE sp_AddProduct
	@Name nvarchar(50), @Description nvarchar(MAX), @Barcode nvarchar(50), @Rate decimal(18, 2), @AddedOn datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Product (Name, Description, Barcode, Rate, AddedOn) VALUES (@Name, @Description, @Barcode, @Rate, @AddedOn)

	--SELECT CAST(SCOPE_IDENTITY() as int);
	
END