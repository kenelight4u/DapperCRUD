IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'sp_GetProductById')
BEGIN
DROP PROCEDURE dbo.sp_GetProductById;
END
GO

CREATE PROCEDURE sp_GetProductById
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM Product WHERE Id = @Id
	
END