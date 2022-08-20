IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'sp_UpdateProduct')
BEGIN
DROP PROCEDURE dbo.sp_UpdateProduct;
END
GO

CREATE PROCEDURE sp_UpdateProduct
	@Id int, @Name nvarchar(50), @Description nvarchar(MAX), @Barcode nvarchar(50), @Rate decimal(18, 2), @ModifiedOn datetime2
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Product 
	SET Name = @Name, Description = @Description, Barcode = @Barcode, Rate = @Rate, ModifiedOn = @ModifiedOn  WHERE Id = @Id

END