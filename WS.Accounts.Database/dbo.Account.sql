CREATE TABLE [dbo].[Table]
(
	[AccountId] INT NOT NULL IDENTITY (1,1),
	[Description] VARCHAR(255) NOT NULL,
	[Balance] MONEY NOT NULL,
	CONSTRAINT PK_Account PRIMARY KEY ([AccountId])
)
