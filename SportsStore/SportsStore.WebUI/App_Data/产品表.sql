CREATE TABLE [Products]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Name] nvarchar(100) not null,
	[Description] nvarchar(500) not null,
	[Category] nvarchar(50) not null,
	[Price] decimal(16,2) not null
)
