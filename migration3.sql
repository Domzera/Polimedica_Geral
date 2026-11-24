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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261022204132_initialMigration'
)
BEGIN
    CREATE TABLE [Clientes] (
        [id] int NOT NULL IDENTITY,
        [Cliente] nvarchar(max) NOT NULL,
        [Cidade] nvarchar(max) NOT NULL,
        [Bairro] nvarchar(max) NOT NULL,
        [LojaPolimedica] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Clientes] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261022204132_initialMigration'
)
BEGIN
    CREATE TABLE [Roteiros] (
        [Id] int NOT NULL IDENTITY,
        [Cliente] nvarchar(max) NOT NULL,
        [Cidade] nvarchar(max) NOT NULL,
        [Bairro] nvarchar(max) NOT NULL,
        [Observacao] nvarchar(max) NOT NULL,
        [Cartao] decimal(18,2) NOT NULL,
        [LojaPolimedica] nvarchar(max) NOT NULL,
        [PedidoNf] nvarchar(max) NOT NULL,
        [DinheiroCheque] decimal(18,2) NOT NULL,
        [Troco] decimal(18,2) NOT NULL,
        [Vendedor] nvarchar(max) NOT NULL,
        [Responsavel] nvarchar(max) NOT NULL,
        [Data] date NULL,
        [Periodo] nvarchar(max) NOT NULL,
        [Entregue] bit NULL,
        CONSTRAINT [PK_Roteiros] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261022204132_initialMigration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20261022204132_initialMigration', N'10.0.13');
END;

COMMIT;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106113751_migration2'
)
BEGIN
    DECLARE @var nvarchar(max);
    SELECT @var = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roteiros]') AND [c].[name] = N'PedidoNf');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [Roteiros] DROP CONSTRAINT ' + @var + ';');
    ALTER TABLE [Roteiros] ALTER COLUMN [PedidoNf] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106113751_migration2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20261106113751_migration2', N'10.0.13');
END;

COMMIT;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261123130949_migration3'
)
BEGIN
    DROP TABLE [Clientes];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261123130949_migration3'
)
BEGIN
    DECLARE @var1 nvarchar(max);
    SELECT @var1 = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roteiros]') AND [c].[name] = N'Vendedor');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Roteiros] DROP CONSTRAINT ' + @var1 + ';');
    ALTER TABLE [Roteiros] ALTER COLUMN [Vendedor] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261123130949_migration3'
)
BEGIN
    DECLARE @var2 nvarchar(max);
    SELECT @var2 = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roteiros]') AND [c].[name] = N'Responsavel');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Roteiros] DROP CONSTRAINT ' + @var2 + ';');
    ALTER TABLE [Roteiros] ALTER COLUMN [Responsavel] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261123130949_migration3'
)
BEGIN
    DECLARE @var3 nvarchar(max);
    SELECT @var3 = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roteiros]') AND [c].[name] = N'Periodo');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Roteiros] DROP CONSTRAINT ' + @var3 + ';');
    ALTER TABLE [Roteiros] ALTER COLUMN [Periodo] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261123130949_migration3'
)
BEGIN
    DECLARE @var4 nvarchar(max);
    SELECT @var4 = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roteiros]') AND [c].[name] = N'Observacao');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Roteiros] DROP CONSTRAINT ' + @var4 + ';');
    ALTER TABLE [Roteiros] ALTER COLUMN [Observacao] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261123130949_migration3'
)
BEGIN
    DECLARE @var5 nvarchar(max);
    SELECT @var5 = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roteiros]') AND [c].[name] = N'LojaPolimedica');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Roteiros] DROP CONSTRAINT ' + @var5 + ';');
    ALTER TABLE [Roteiros] ALTER COLUMN [LojaPolimedica] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261123130949_migration3'
)
BEGIN
    DECLARE @var6 nvarchar(max);
    SELECT @var6 = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roteiros]') AND [c].[name] = N'Cliente');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Roteiros] DROP CONSTRAINT ' + @var6 + ';');
    ALTER TABLE [Roteiros] ALTER COLUMN [Cliente] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261123130949_migration3'
)
BEGIN
    DECLARE @var7 nvarchar(max);
    SELECT @var7 = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roteiros]') AND [c].[name] = N'Cidade');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Roteiros] DROP CONSTRAINT ' + @var7 + ';');
    ALTER TABLE [Roteiros] ALTER COLUMN [Cidade] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261123130949_migration3'
)
BEGIN
    DECLARE @var8 nvarchar(max);
    SELECT @var8 = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roteiros]') AND [c].[name] = N'Bairro');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Roteiros] DROP CONSTRAINT ' + @var8 + ';');
    ALTER TABLE [Roteiros] ALTER COLUMN [Bairro] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261123130949_migration3'
)
BEGIN
    CREATE TABLE [Vendas] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [UserType] nvarchar(max) NULL,
        [Data] date NOT NULL,
        [Conta] nvarchar(max) NULL,
        [Valor] decimal(18,2) NOT NULL,
        [QuantAtend] int NOT NULL,
        CONSTRAINT [PK_Vendas] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261123130949_migration3'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20261123130949_migration3', N'10.0.13');
END;

COMMIT;
GO

