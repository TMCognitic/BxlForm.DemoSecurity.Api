CREATE PROCEDURE [dbo].[BFSP_AddCategory]
	@Name NVARCHAR(125)
AS
BEGIN
	INSERT INTO [Category] ([Name]) OUTPUT inserted.Id VALUES (@Name);
	RETURN 0
END
