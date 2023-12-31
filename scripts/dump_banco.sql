USE [master]
GO
/****** Object:  Database [fiotec]    Script Date: 01/07/2023 23:27:21 ******/
CREATE DATABASE [fiotec]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'fiotec', FILENAME = N'E:\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\fiotec.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'fiotec_log', FILENAME = N'E:\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\fiotec_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [fiotec] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [fiotec].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [fiotec] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [fiotec] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [fiotec] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [fiotec] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [fiotec] SET ARITHABORT OFF 
GO
ALTER DATABASE [fiotec] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [fiotec] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [fiotec] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [fiotec] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [fiotec] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [fiotec] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [fiotec] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [fiotec] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [fiotec] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [fiotec] SET  DISABLE_BROKER 
GO
ALTER DATABASE [fiotec] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [fiotec] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [fiotec] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [fiotec] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [fiotec] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [fiotec] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [fiotec] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [fiotec] SET RECOVERY FULL 
GO
ALTER DATABASE [fiotec] SET  MULTI_USER 
GO
ALTER DATABASE [fiotec] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [fiotec] SET DB_CHAINING OFF 
GO
ALTER DATABASE [fiotec] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [fiotec] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [fiotec] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [fiotec] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'fiotec', N'ON'
GO
ALTER DATABASE [fiotec] SET QUERY_STORE = ON
GO
ALTER DATABASE [fiotec] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [fiotec]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01/07/2023 23:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Relatorio]    Script Date: 01/07/2023 23:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relatorio](
	[Id] [uniqueidentifier] NOT NULL,
	[SolicitanteId] [uniqueidentifier] NOT NULL,
	[DataSolicitacao] [datetime] NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[DataAplicacaoVacina] [datetime] NOT NULL,
	[QuantidadeVacinados] [bigint] NOT NULL,
 CONSTRAINT [PK_Relatorio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitante]    Script Date: 01/07/2023 23:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitante](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cpf] [varchar](11) NOT NULL,
 CONSTRAINT [PK_Solicitante] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Relatorio_SolicitanteId]    Script Date: 01/07/2023 23:27:21 ******/
CREATE NONCLUSTERED INDEX [IX_Relatorio_SolicitanteId] ON [dbo].[Relatorio]
(
	[SolicitanteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Relatorio]  WITH CHECK ADD  CONSTRAINT [FK_Relatorio_Solicitante_SolicitanteId] FOREIGN KEY([SolicitanteId])
REFERENCES [dbo].[Solicitante] ([Id])
GO
ALTER TABLE [dbo].[Relatorio] CHECK CONSTRAINT [FK_Relatorio_Solicitante_SolicitanteId]
GO
USE [master]
GO
ALTER DATABASE [fiotec] SET  READ_WRITE 
GO
