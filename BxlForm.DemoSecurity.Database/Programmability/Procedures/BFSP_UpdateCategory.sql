CREATE PROCEDURE [dbo].[BFSP_UpdateCategory]
	@Id int,
	@Name NVARCHAR(125)
AS
BEGIN
	UPDATE Category SET [Name] = @Name Where Id = @Id;
	RETURN 0
END
