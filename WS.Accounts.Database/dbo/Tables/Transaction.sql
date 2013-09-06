CREATE TABLE [dbo].[Transaction]
(
	[TransactionId] INT NOT NULL IDENTITY(1,1),
	[AccountId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[Reference] VARCHAR(255) NOT NULL,
	[Date] DATETIME NOT NULL,
	[Amount] MONEY NOT NULL,
	CONSTRAINT PK_Transaction PRIMARY KEY ([TransactionId]),
	CONSTRAINT FK_Transaction_Account FOREIGN KEY ([AccountId]) REFERENCES dbo.Account([AccountId]),
	CONSTRAINT FK_Transaction_Product FOREIGN KEY ([ProductId]) REFERENCES dbo.Product([ProductId])
)
