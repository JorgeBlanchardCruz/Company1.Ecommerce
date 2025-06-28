SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
    [Id] [int] NOT NULL,
    [FirstName] [varchar] (50) NOT NULL,
    [LastName] [varchar] (50) NOT NULL,
    [UserName] [varchar] (50) NOT NULL,
    [Password] [varchar] (50) NOT NULL
    CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED
    (
       [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT INTO Users(Id, FirstName, LastName, UserName, [Password])
VALUES (1, 'Jorge', 'Blanchard', 'Jorge', '123456')

GO
CREATE PROCEDURE UsersGetByUserAndPassword
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

