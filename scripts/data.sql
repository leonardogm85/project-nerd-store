USE [DbNerdStore]

DECLARE @ShirtId UNIQUEIDENTIFIER = '23a4ca11-4fbe-4961-ac22-2a91f146dec6'
DECLARE @MugId UNIQUEIDENTIFIER = '6a17e4f4-6303-47ef-902b-535797660099'

INSERT INTO [dbo].[Categories]
	([Id],
	[Name],
	[Code])

VALUES

	(@ShirtId, -- Id
	'Shirt', -- Name
	101), -- Code

	(@MugId, -- Id
	'Mug', -- Name
	102) -- Code

INSERT INTO [dbo].[Products]
	([Id],
	[Name],
	[Description],
	[Price],
	[Image],
	[QuantityInStock],
	[MinimumStock],
	[Active],
	[CreatedAt],
	[CategoryId],
	[Width],
	[Height],
	[Depth])

VALUES

	('7c7d75bf-21cf-44cf-bc9d-27acf3ba69ad', -- Id
	'Shirt Code Coffee Grey', -- Name
	'Shirt 100% cotton, resistant to washing and high temperatures.', -- Description
	59.90, -- Price
	'shirt3.jpg', -- Image
	50, -- QuantityInStock
	10, -- MinimumStock
	1, -- Active
	GETDATE(), -- CreateAt
	@ShirtId, -- CategoryId
	9, -- Width
	8, -- Height
	2), -- Depth

	('3a53438d-1e75-4990-95a8-2e886b0a0db0', -- Id
	'Shirt Program Debug Black', -- Name
	'Shirt 100% cotton, resistant to washing and high temperatures.', -- Description
	49.90, -- Price
	'shirt4.jpg', -- Image
	40, -- QuantityInStock
	10, -- MinimumStock
	1, -- Active
	GETDATE(), -- CreateAt
	@ShirtId, -- CategoryId
	2, -- Width
	7, -- Height
	3), -- Depth

	('8179f1da-4595-499b-a217-2ef895c0c648', -- Id
	'Shirt Software Developer Grey', -- Name
	'Shirt 100% cotton, resistant to washing and high temperatures.', -- Description
	39.90, -- Price
	'shirt1.jpg', -- Image
	30, -- QuantityInStock
	10, -- MinimumStock
	1, -- Active
	GETDATE(), -- CreateAt
	@ShirtId, -- CategoryId
	8, -- Width
	6, -- Height
	4), -- Depth

	('647446ce-4406-4dcc-8453-5ec74c3aa162', -- Id
	'Shirt Code Coffee Black', -- Name
	'Shirt 100% cotton, resistant to washing and high temperatures.', -- Description
	29.90, -- Price
	'shirt2.jpg', -- Image
	20, -- QuantityInStock
	10, -- MinimumStock
	1, -- Active
	GETDATE(), -- CreateAt
	@ShirtId, -- CategoryId
	3, -- Width
	5, -- Height
	5), -- Depth

	('a792b43c-aa65-4947-8292-a787b1e16eb3', -- Id
	'Mug I Turn Coffee into Code', -- Name
	'Porcelain mug with thermal printing.', -- Description
	15.80, -- Price
	'mug3.jpg', -- Image
	15, -- QuantityInStock
	5, -- MinimumStock
	1, -- Active
	GETDATE(), -- CreateAt
	@MugId, -- CategoryId
	7, -- Width
	4, -- Height
	6), -- Depth

	('4dc75890-84f1-48be-841e-c44dfaf71fa3', -- Id
	'Mug Star Bugs Coffee', -- Name
	'Porcelain mug with thermal printing.',  -- Description
	25.80, -- Price
	'mug1.jpg', -- Image
	25, -- QuantityInStock
	5, -- MinimumStock
	1, -- Active
	GETDATE(), -- CreateAt
	@MugId, -- CategoryId
	4, -- Width
	3, -- Height
	7), -- Depth

	('14eca13b-42b2-45fd-9386-c7b0f0cf4542', -- Id
	'Mug Programmer Code', -- Name
	'Porcelain mug with thermal printing.', -- Description
	35.80, -- Price
	'mug2.jpg', -- Image
	35, -- QuantityInStock
	5, -- MinimumStock
	1, -- Active
	GETDATE(), -- CreateAt
	@MugId, -- CategoryId
	6, -- Width
	2, -- Height
	8), -- Depth

	('36e5b0ba-cfc8-42d0-a4a6-d170a59f1001', -- Id
	'Mug No Coffee No Code', -- Name
	'Porcelain mug with thermal printing.', -- Description
	45.80, -- Price
	'mug4.jpg', -- Image
	45, -- QuantityInStock
	5, -- MinimumStock
	1, -- Active
	GETDATE(), -- CreateAt
	@MugId, -- CategoryId
	5, -- Width
	1, -- Height
	9) -- Depth

INSERT INTO [dbo].[Vouchers]
	([Id],
    [Code],
    [Value],
    [Quantity],
    [DiscountType],
    [ValidUntil],
    [CreatedAt],
    [UsedAt],
    [Used],
    [Active])

VALUES

	('c8aed0b9-8dc6-4cdf-9a77-0f6a518fb156', -- Id
	'20-dollars', -- Code
	20, -- Value
	0, -- Quantity
	2, -- DiscountType
	DATEADD(YEAR, 1, GETDATE()), -- ValidUntil
	GETDATE(), -- CreatedAt
	NULL, -- UsedAt
	0, -- Used
	1), -- Active
	

	('cb8c91fb-fd94-44ad-ba7d-87492010f9f2', -- Id
	'10-off', -- Code
	10, -- Value
	50, -- Quantity
	1, -- DiscountType
	DATEADD(YEAR, 1, GETDATE()), -- ValidUntil
	GETDATE(), -- CreatedAt
	NULL, -- UsedAt
	0, -- Used
	1) -- Active

--INSERT INTO [dbo].[AspNetUsers]
--	([Id],
--	[UserName],
--	[NormalizedUserName],
--	[Email],
--	[NormalizedEmail],
--	[EmailConfirmed],
--	[PasswordHash],
--	[SecurityStamp],
--	[ConcurrencyStamp],
--	[PhoneNumberConfirmed],
--	[TwoFactorEnabled],
--	[LockoutEnabled],
--	[AccessFailedCount])

--VALUES

--	('d7c084ed-bf90-459a-9c43-9fdbd66b2429', -- Id
--	'teste@teste.com', -- UserName
--	'TESTE@TESTE.COM', -- NormalizedUserName
--	'teste@teste.com', -- Email
--	'TESTE@TESTE.COM', -- NormalizedEmail
--	1, -- EmailConfirmed
--	'AQAAAAEAACcQAAAAEKobwX24LXiIN9F2mftsVH4PTWni1bEqnPvgmZyejI5mQTUWT61wAU9vhV5lKXh0tw==', -- PasswordHash
--	'KDYV6LQ7BQWX4HNTABNHA6IZFHUS3X4F', -- SecurityStamp
--	'30e196b8-0cd8-4d0a-8a38-5df39c45cdc6', -- ConcurrencyStamp
--	0, -- PhoneNumberConfirmed
--	0, -- TwoFactorEnabled
--	1, -- LockoutEnabled
--	0) -- AccessFailedCount
