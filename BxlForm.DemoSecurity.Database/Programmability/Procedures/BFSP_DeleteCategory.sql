CREATE PROCEDURE [dbo].[BFSP_DeleteCategory]
	@Id int
AS
BEGIN
	Delete From Category Where Id = @Id
	RETURN 0
END
