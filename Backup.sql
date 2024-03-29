USE [master]
GO
/****** Object:  Database [MaisEventos]    Script Date: 26/01/2023 08:44:55 ******/
CREATE DATABASE [MaisEventos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MaisEventos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MaisEventos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MaisEventos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MaisEventos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MaisEventos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MaisEventos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MaisEventos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MaisEventos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MaisEventos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MaisEventos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MaisEventos] SET ARITHABORT OFF 
GO
ALTER DATABASE [MaisEventos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MaisEventos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MaisEventos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MaisEventos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MaisEventos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MaisEventos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MaisEventos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MaisEventos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MaisEventos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MaisEventos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MaisEventos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MaisEventos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MaisEventos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MaisEventos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MaisEventos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MaisEventos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MaisEventos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MaisEventos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MaisEventos] SET  MULTI_USER 
GO
ALTER DATABASE [MaisEventos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MaisEventos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MaisEventos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MaisEventos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MaisEventos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MaisEventos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MaisEventos] SET QUERY_STORE = OFF
GO
USE [MaisEventos]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evento]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Evento] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eventos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataHora] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Preco] [decimal](6, 2) NULL,
	[CategoriaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Data] [datetime2](3) NOT NULL,
	[TipoEvento] [int] NOT NULL,
	[Mensagem] [varchar](200) NULL,
	[exception] [varchar](400) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioEvento]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioEvento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[EventoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Senha] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Eventos]  WITH CHECK ADD FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categorias] ([Id])
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD FOREIGN KEY([TipoEvento])
REFERENCES [dbo].[Evento] ([Id])
GO
ALTER TABLE [dbo].[UsuarioEvento]  WITH CHECK ADD FOREIGN KEY([EventoId])
REFERENCES [dbo].[Eventos] ([Id])
GO
ALTER TABLE [dbo].[UsuarioEvento]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[BuscarUsuarioPorNome]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BuscarUsuarioPorNome]

@Nome nvarchar(max)

AS
BEGIN

select [Nome], [Senha] from Usuarios where Nome = @Nome
end	
GO
/****** Object:  StoredProcedure [dbo].[DeletarPorIdUsuario]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeletarPorIdUsuario]
	@Id INT
AS
BEGIN

	DELETE FROM Usuarios WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertUser]
	@Nome VARCHAR(MAX),
	@Email VARCHAR(MAX),
	@Senha VARCHAR(MAX)
AS
BEGIN

INSERT INTO [dbo].[Usuarios]
           ([Nome]
           ,[Email]
           ,[Senha])
     VALUES
           (@Nome
           ,@Email
           ,@Senha)

END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarLog]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarLog]
  @Data datetime2(3),
  @TipoEvento int,
  @Mensagem varchar(200),
  @Exception varchar(400) null
AS
BEGIN
 INSERT INTO [dbo].[Logs]
           ([Data]
           ,[TipoEvento]
           ,[Mensagem]
           ,[exception])
     VALUES
           (@Data
           ,@TipoEvento
           ,@Mensagem
           ,@Exception)

END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllUsers]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectAllUsers]
AS
BEGIN
SELECT [Id]
      ,[Nome]
      ,[Email]
      ,[Senha]
  FROM [MaisEventos].[dbo].[Usuarios]

END
GO
/****** Object:  StoredProcedure [dbo].[SelectUserByid]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectUserByid] 
	@Id INT
AS
BEGIN
	SELECT [Id]
      ,[Nome]
      ,[Email]
      ,[Senha]
  FROM [MaisEventos].[dbo].[Usuarios] WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserById]    Script Date: 26/01/2023 08:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUserById]
	@Nome NVARCHAR(MAX),
	@Email NVARCHAR(MAX),
	@Senha VARCHAR(200)
AS
BEGIN
	UPDATE Usuarios SET Nome = @Nome, Email = @Email, Senha = @Senha WHERE Nome = @Nome
END
GO
USE [master]
GO
ALTER DATABASE [MaisEventos] SET  READ_WRITE 
GO
