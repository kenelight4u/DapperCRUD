IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'sp_DeleteById')
BEGIN
DROP PROCEDURE dbo.sp_DeleteById;
END
GO

CREATE PROCEDURE sp_DeleteById
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM Product WHERE Id = @Id
	
END