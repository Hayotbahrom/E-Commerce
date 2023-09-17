CREATE TABLE [Products] (
  [Id] bigint,
  [Name] varchar(50),
  [SellerId] bigint,
  [Price] decimal,
  [CategoryId] bigint,
  [CreatedAt] datatime
)
GO

CREATE TABLE [Sellers] (
  [Id] bigint,
  [FirstName] varchar(50),
  [Lastname] varchar(50),
  [CountryCode] bigint,
  [CreatedAt] datatime
)
GO

CREATE TABLE [Users] (
  [id] bigint,
  [FirstName] varchar(50),
  [Lastname] varchar(50),
  [Email] varchar(50),
  [Password] varchar(50),
  [CountryCode] bigint,
  [CreatedAt] datetime
)
GO

CREATE TABLE [Countries] (
  [Id] bigint,
  [Name] varchar(50),
  [CountryCode] bigint
)
GO

CREATE TABLE [Categories] (
  [Id] bigint,
  [Name] varchar(50)
)
GO

CREATE TABLE [Cart] (
  [Id] bigint,
  [UserId] bigint,
  [OrderId] bigint,
  [CreatedAt] datatime
)
GO

CREATE TABLE [Orders] (
  [Id] bigint,
  [ProductId] bigint,
  [Quantity] int
)
GO

ALTER TABLE [Products] ADD FOREIGN KEY ([SellerId]) REFERENCES [Sellers] ([Id])
GO

ALTER TABLE [Countries] ADD FOREIGN KEY ([CountryCode]) REFERENCES [Sellers] ([CountryCode])
GO

ALTER TABLE [Products] ADD FOREIGN KEY ([Id]) REFERENCES [Orders] ([ProductId])
GO

ALTER TABLE [Cart] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([id])
GO

ALTER TABLE [Categories] ADD FOREIGN KEY ([Id]) REFERENCES [Products] ([CategoryId])
GO

ALTER TABLE [Users] ADD FOREIGN KEY ([CountryCode]) REFERENCES [Countries] ([CountryCode])
GO

ALTER TABLE [Cart] ADD FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id])
GO
