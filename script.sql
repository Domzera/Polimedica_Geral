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
CREATE TABLE [Clientes] (
    [id] int NOT NULL IDENTITY,
    [Cliente] nvarchar(max) NOT NULL,
    [Cidade] nvarchar(max) NOT NULL,
    [Bairro] nvarchar(max) NOT NULL,
    [LojaPolimedica] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([id])
);

CREATE TABLE [Roteiros] (
    [Id] int NOT NULL IDENTITY,
    [Cliente] nvarchar(max) NULL,
    [Cidade] nvarchar(max) NULL,
    [Bairro] nvarchar(max) NULL,
    [Observacao] nvarchar(max) NULL,
    [Cartao] decimal(18,2) NOT NULL,
    [LojaPolimedica] nvarchar(max) NULL,
    [PedidoNf] nvarchar(max) NULL,
    [DinheiroCheque] decimal(18,2) NOT NULL,
    [Troco] decimal(18,2) NOT NULL,
    [Vendedor] nvarchar(max) NULL,
    [Responsavel] nvarchar(max) NULL,
    [Data] date NOT NULL,
    [Entregue] bit NOT NULL,
    CONSTRAINT [PK_Roteiros] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261015194912_initialMigration', N'10.0.13');

COMMIT;
GO

