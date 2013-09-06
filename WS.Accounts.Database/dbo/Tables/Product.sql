CREATE TABLE [dbo].[Product]
(
	[ProductId] INT NOT NULL IDENTITY (1,1),
	[Description] VARCHAR(255) NOT NULL,
	CONSTRAINT PK_Product PRIMARY KEY ([ProductId])
)
