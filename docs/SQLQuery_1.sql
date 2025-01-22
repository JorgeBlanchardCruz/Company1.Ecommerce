SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UsersGetByUserAndPassword]
(
    @UserName varchar(50),
    @Password varchar(50)
)
AS
BEGIN
    SELECT Id, FirstName, LastName, UserName, NULL as Password
    FROM Users
    WHERE UserName = @UserName and Password = @Password
END
GO
