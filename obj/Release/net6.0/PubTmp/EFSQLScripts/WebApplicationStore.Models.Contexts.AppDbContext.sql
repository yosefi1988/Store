IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802142406_initDb')
BEGIN
    CREATE TABLE [employees] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Family] nvarchar(max) NULL,
        [Company] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_employees] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802142406_initDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240802142406_initDb', N'6.0.32');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240802163025_addIdentity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240802163025_addIdentity', N'6.0.32');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Description] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Family] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Name] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [BdCountry] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [Logo] nvarchar(max) NULL,
        CONSTRAINT [PK_BdCountry] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [BdPaymentStatusType] (
        [Id] int NOT NULL IDENTITY,
        [Status] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_BdPaymentStatusType] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [BdSendStatusType] (
        [Id] int NOT NULL IDENTITY,
        [Status] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_BdSendStatusType] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [BdShoppingBasketType] (
        [Id] int NOT NULL IDENTITY,
        [Status] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_BdShoppingBasketType] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [BdSizeType] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_BdSizeType] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [BdTax] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [TaxPercentage] int NULL,
        [CountryId] int NULL,
        CONSTRAINT [PK_BdTax] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [ScAdmin] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NULL,
        [IsLocked] bit NULL,
        [Description] nvarchar(max) NULL,
        [UserId1] nvarchar(450) NULL,
        CONSTRAINT [PK_ScAdmin] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ScAdmin_AspNetUsers_UserId1] FOREIGN KEY ([UserId1]) REFERENCES [AspNetUsers] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdCategory] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [Code] int NULL,
        CONSTRAINT [PK_SdCategory] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdColor] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [ColorCode] nvarchar(max) NULL,
        CONSTRAINT [PK_SdColor] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdCoupon] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(max) NULL,
        [CouponPercent] int NULL,
        [MaxRialValue] int NULL,
        [ExpireDate] datetime2 NULL,
        CONSTRAINT [PK_SdCoupon] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdProduct] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Code] int NULL,
        CONSTRAINT [PK_SdProduct] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [BdState] (
        [Id] int NOT NULL IDENTITY,
        [CountryId] int NULL,
        [Title] nvarchar(max) NULL,
        CONSTRAINT [PK_BdState] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BdState_BdCountry_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [BdCountry] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdShoppingBasket] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NULL,
        [StatusId] int NULL,
        [CreatedOn] datetime2 NULL,
        [UserId1] nvarchar(450) NULL,
        CONSTRAINT [PK_SdShoppingBasket] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SdShoppingBasket_AspNetUsers_UserId1] FOREIGN KEY ([UserId1]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_SdShoppingBasket_BdShoppingBasketType_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [BdShoppingBasketType] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdProductCategory] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [CategoryId] int NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_SdProductCategory] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SdProductCategory_SdCategory_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [SdCategory] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SdProductCategory_SdProduct_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [SdProduct] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdProductCharge] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NULL,
        [SaleTaxId] int NULL,
        [BuyInvoiceNumber] nvarchar(max) NULL,
        [ChargeDate] datetime2 NULL,
        [BuyPrice] int NULL,
        [BuyCount] int NULL,
        [PercentInterest] int NULL,
        [PercentWages] int NULL,
        [Idddl] nvarchar(max) NULL,
        CONSTRAINT [PK_SdProductCharge] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SdProductCharge_BdTax_SaleTaxId] FOREIGN KEY ([SaleTaxId]) REFERENCES [BdTax] ([Id]),
        CONSTRAINT [FK_SdProductCharge_SdProduct_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [SdProduct] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [BdCity] (
        [Id] int NOT NULL IDENTITY,
        [StateId] int NULL,
        [Title] nvarchar(max) NULL,
        CONSTRAINT [PK_BdCity] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BdCity_BdState_StateId] FOREIGN KEY ([StateId]) REFERENCES [BdState] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [BdSendBoxPrice] (
        [Id] int NOT NULL IDENTITY,
        [Price] int NULL,
        [StateId] int NULL,
        [Title] nvarchar(max) NULL,
        CONSTRAINT [PK_BdSendBoxPrice] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BdSendBoxPrice_BdState_StateId] FOREIGN KEY ([StateId]) REFERENCES [BdState] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [BdSendProductsPrice] (
        [Id] int NOT NULL IDENTITY,
        [Price] int NULL,
        [StateId] int NULL,
        [ProductId] int NULL,
        [Title] nvarchar(max) NULL,
        CONSTRAINT [PK_BdSendProductsPrice] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BdSendProductsPrice_BdState_StateId] FOREIGN KEY ([StateId]) REFERENCES [BdState] ([Id]),
        CONSTRAINT [FK_BdSendProductsPrice_SdProduct_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [SdProduct] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdTransaction] (
        [Id] int NOT NULL IDENTITY,
        [ShoppingBasketId] int NULL,
        [SumTaxAmount] int NULL,
        [DiscountCodeId] int NULL,
        [DiscountAmount] int NULL,
        [SendAmount] int NULL,
        [SumShoppingBasketPrice] int NULL,
        [SumShoppingBasketDiscount] int NULL,
        [AmountForPay] int NULL,
        [PaymentStatusId] int NULL,
        [PaymentTrackingNo] nvarchar(max) NULL,
        [PaymentDate] datetime2 NULL,
        CONSTRAINT [PK_SdTransaction] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SdTransaction_BdPaymentStatusType_PaymentStatusId] FOREIGN KEY ([PaymentStatusId]) REFERENCES [BdPaymentStatusType] ([Id]),
        CONSTRAINT [FK_SdTransaction_SdCoupon_DiscountCodeId] FOREIGN KEY ([DiscountCodeId]) REFERENCES [SdCoupon] ([Id]),
        CONSTRAINT [FK_SdTransaction_SdShoppingBasket_ShoppingBasketId] FOREIGN KEY ([ShoppingBasketId]) REFERENCES [SdShoppingBasket] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdProductChargesProperty] (
        [Id] int NOT NULL IDENTITY,
        [ProductChargeId] int NULL,
        [ColorId] int NULL,
        [Discount] int NULL,
        [RemainingCount] int NULL,
        CONSTRAINT [PK_SdProductChargesProperty] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SdProductChargesProperty_SdColor_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [SdColor] ([Id]),
        CONSTRAINT [FK_SdProductChargesProperty_SdProductCharge_ProductChargeId] FOREIGN KEY ([ProductChargeId]) REFERENCES [SdProductCharge] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdAddress] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NULL,
        [CityId] int NULL,
        [Address] nvarchar(max) NULL,
        [IsDefault] bit NULL,
        [FullName] nvarchar(max) NULL,
        [MobileNo] nvarchar(max) NULL,
        [UserId1] nvarchar(450) NULL,
        CONSTRAINT [PK_SdAddress] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SdAddress_AspNetUsers_UserId1] FOREIGN KEY ([UserId1]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_SdAddress_BdCity_CityId] FOREIGN KEY ([CityId]) REFERENCES [BdCity] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdSendBox] (
        [Id] int NOT NULL IDENTITY,
        [ShoppingBasketId] int NULL,
        [TransactionId] int NULL,
        [SendPriceId] int NULL,
        [SendTypeTitle] nvarchar(max) NULL,
        [CityId] int NULL,
        [Address] nvarchar(max) NULL,
        [FullName] nvarchar(max) NULL,
        [MobileNo] nvarchar(max) NULL,
        [SendDate] datetime2 NULL,
        [SendStatusId] int NULL,
        [SendTrackingNo] nvarchar(max) NULL,
        CONSTRAINT [PK_SdSendBox] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SdSendBox_BdCity_CityId] FOREIGN KEY ([CityId]) REFERENCES [BdCity] ([Id]),
        CONSTRAINT [FK_SdSendBox_BdSendBoxPrice_SendPriceId] FOREIGN KEY ([SendPriceId]) REFERENCES [BdSendBoxPrice] ([Id]),
        CONSTRAINT [FK_SdSendBox_BdSendStatusType_SendStatusId] FOREIGN KEY ([SendStatusId]) REFERENCES [BdSendStatusType] ([Id]),
        CONSTRAINT [FK_SdSendBox_SdShoppingBasket_ShoppingBasketId] FOREIGN KEY ([ShoppingBasketId]) REFERENCES [SdShoppingBasket] ([Id]),
        CONSTRAINT [FK_SdSendBox_SdTransaction_TransactionId] FOREIGN KEY ([TransactionId]) REFERENCES [SdTransaction] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdImage] (
        [Id] int NOT NULL IDENTITY,
        [ProductChargePropertiesId] int NULL,
        [ImageUrl] nvarchar(max) NULL,
        [CreatedOn] datetime2 NULL,
        CONSTRAINT [PK_SdImage] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SdImage_SdProductChargesProperty_ProductChargePropertiesId] FOREIGN KEY ([ProductChargePropertiesId]) REFERENCES [SdProductChargesProperty] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdProductSize] (
        [Id] int NOT NULL IDENTITY,
        [SizeId] int NOT NULL,
        [ProductChargePropertiesId] int NOT NULL,
        [Value] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_SdProductSize] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SdProductSize_BdSizeType_SizeId] FOREIGN KEY ([SizeId]) REFERENCES [BdSizeType] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SdProductSize_SdProductChargesProperty_ProductChargePropertiesId] FOREIGN KEY ([ProductChargePropertiesId]) REFERENCES [SdProductChargesProperty] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdShoppingBasketObject] (
        [Id] int NOT NULL IDENTITY,
        [ShoppingBasketId] int NOT NULL,
        [ProductChargePropertiesId] int NOT NULL,
        [Price] int NULL,
        [OldPrice] int NULL,
        [Count] int NULL,
        [AddDate] datetime2 NULL,
        CONSTRAINT [PK_SdShoppingBasketObject] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SdShoppingBasketObject_SdProductChargesProperty_ProductChargePropertiesId] FOREIGN KEY ([ProductChargePropertiesId]) REFERENCES [SdProductChargesProperty] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SdShoppingBasketObject_SdShoppingBasket_ShoppingBasketId] FOREIGN KEY ([ShoppingBasketId]) REFERENCES [SdShoppingBasket] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE TABLE [SdVote] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [ProductChargePropertiesId] int NOT NULL,
        [Star] tinyint NULL,
        [Comment] nvarchar(max) NULL,
        [UserId1] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_SdVote] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SdVote_AspNetUsers_UserId1] FOREIGN KEY ([UserId1]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SdVote_SdProductChargesProperty_ProductChargePropertiesId] FOREIGN KEY ([ProductChargePropertiesId]) REFERENCES [SdProductChargesProperty] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_BdCity_StateId] ON [BdCity] ([StateId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_BdSendBoxPrice_StateId] ON [BdSendBoxPrice] ([StateId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_BdSendProductsPrice_ProductId] ON [BdSendProductsPrice] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_BdSendProductsPrice_StateId] ON [BdSendProductsPrice] ([StateId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_BdState_CountryId] ON [BdState] ([CountryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_ScAdmin_UserId1] ON [ScAdmin] ([UserId1]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdAddress_CityId] ON [SdAddress] ([CityId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdAddress_UserId1] ON [SdAddress] ([UserId1]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdImage_ProductChargePropertiesId] ON [SdImage] ([ProductChargePropertiesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdProductCategory_CategoryId] ON [SdProductCategory] ([CategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdProductCategory_ProductId] ON [SdProductCategory] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdProductCharge_ProductId] ON [SdProductCharge] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdProductCharge_SaleTaxId] ON [SdProductCharge] ([SaleTaxId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdProductChargesProperty_ColorId] ON [SdProductChargesProperty] ([ColorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdProductChargesProperty_ProductChargeId] ON [SdProductChargesProperty] ([ProductChargeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdProductSize_ProductChargePropertiesId] ON [SdProductSize] ([ProductChargePropertiesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdProductSize_SizeId] ON [SdProductSize] ([SizeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdSendBox_CityId] ON [SdSendBox] ([CityId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdSendBox_SendPriceId] ON [SdSendBox] ([SendPriceId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdSendBox_SendStatusId] ON [SdSendBox] ([SendStatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdSendBox_ShoppingBasketId] ON [SdSendBox] ([ShoppingBasketId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdSendBox_TransactionId] ON [SdSendBox] ([TransactionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdShoppingBasket_StatusId] ON [SdShoppingBasket] ([StatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdShoppingBasket_UserId1] ON [SdShoppingBasket] ([UserId1]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdShoppingBasketObject_ProductChargePropertiesId] ON [SdShoppingBasketObject] ([ProductChargePropertiesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdShoppingBasketObject_ShoppingBasketId] ON [SdShoppingBasketObject] ([ShoppingBasketId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdTransaction_DiscountCodeId] ON [SdTransaction] ([DiscountCodeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdTransaction_PaymentStatusId] ON [SdTransaction] ([PaymentStatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdTransaction_ShoppingBasketId] ON [SdTransaction] ([ShoppingBasketId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdVote_ProductChargePropertiesId] ON [SdVote] ([ProductChargePropertiesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    CREATE INDEX [IX_SdVote_UserId1] ON [SdVote] ([UserId1]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808123652_updateuser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240808123652_updateuser', N'6.0.32');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [BdSendProductsPrice];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [ScAdmin];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdAddress];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdImage];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdProductCategory];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdProductSize];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdSendBox];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdShoppingBasketObject];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdVote];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdCategory];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [BdSizeType];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [BdCity];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [BdSendBoxPrice];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [BdSendStatusType];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdTransaction];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdProductChargesProperty];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [BdState];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [BdPaymentStatusType];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdCoupon];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdShoppingBasket];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdColor];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdProductCharge];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [BdCountry];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [BdShoppingBasketType];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [BdTax];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DROP TABLE [SdProduct];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Description');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [Description];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Family');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [Family];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Name');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [Name];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Age] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808193841_updateuser2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240808193841_updateuser2', N'6.0.32');
END;
GO

COMMIT;
GO

