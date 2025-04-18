Build started...
Build succeeded.
The Entity Framework tools version '8.0.8' is older than that of the runtime '8.0.15'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'Preco' on entity type 'Produto'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
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

CREATE TABLE [Produtos] (
    [ProdutoId] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Imagem] nvarchar(max) NOT NULL,
    [Preco] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([ProdutoId])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProdutoId', N'Imagem', N'Nome', N'Preco') AND [object_id] = OBJECT_ID(N'[Produtos]'))
    SET IDENTITY_INSERT [Produtos] ON;
INSERT INTO [Produtos] ([ProdutoId], [Imagem], [Nome], [Preco])
VALUES (1, N'manga.jpg', N'Manga', 7.5),
(2, N'banana.jpg', N'Banana', 4.0),
(3, N'goiaba.jpg', N'Goiaba', 12.0),
(4, N'granola.jpg', N'Granola', 22.0),
(5, N'maca.jpg', N'Ma├º├ú', 8.5),
(6, N'melancia.jpg', N'Melancia', 15.0),
(7, N'uva.jpg', N'Uva', 20.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProdutoId', N'Imagem', N'Nome', N'Preco') AND [object_id] = OBJECT_ID(N'[Produtos]'))
    SET IDENTITY_INSERT [Produtos] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250411175346_CreateDatabase', N'8.0.15');
GO

COMMIT;
GO


