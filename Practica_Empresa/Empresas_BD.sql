USE [master]
GO
/****** Object:  Database [Empresas]    Script Date: 05/06/2020 12:28:23 a. m. ******/
CREATE DATABASE [Empresas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Empresas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Empresas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Empresas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Empresas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Empresas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Empresas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Empresas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Empresas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Empresas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Empresas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Empresas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Empresas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Empresas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Empresas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Empresas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Empresas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Empresas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Empresas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Empresas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Empresas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Empresas] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Empresas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Empresas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Empresas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Empresas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Empresas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Empresas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Empresas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Empresas] SET RECOVERY FULL 
GO
ALTER DATABASE [Empresas] SET  MULTI_USER 
GO
ALTER DATABASE [Empresas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Empresas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Empresas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Empresas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Empresas] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Empresas', N'ON'
GO
ALTER DATABASE [Empresas] SET QUERY_STORE = OFF
GO
USE [Empresas]
GO
/****** Object:  Table [dbo].[empresas]    Script Date: 05/06/2020 12:28:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empresas](
	[Nombre] [varchar](30) NULL,
	[Representante] [varchar](30) NULL,
	[RNC] [varchar](30) NULL,
	[Direccion] [varchar](30) NULL,
	[Borrado] [int] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[empresas] ON 

INSERT [dbo].[empresas] ([Nombre], [Representante], [RNC], [Direccion], [Borrado], [ID]) VALUES (N'Ser Salud', N'Orlando Soto', N'1-24-02441-2', N'Churchill', 1, 1)
INSERT [dbo].[empresas] ([Nombre], [Representante], [RNC], [Direccion], [Borrado], [ID]) VALUES (N'Ser Salud', N'Orlando Soto', N'1-24-02441-2', N'Churchill', 1, 2)
INSERT [dbo].[empresas] ([Nombre], [Representante], [RNC], [Direccion], [Borrado], [ID]) VALUES (N'Empresa Baez', N'Migdalia Baez', N'1-23-45678-9', N'Hainamosa', 0, 3)
INSERT [dbo].[empresas] ([Nombre], [Representante], [RNC], [Direccion], [Borrado], [ID]) VALUES (N'Empresa Reyes', N'Carlos Reyes', N'1-26-45678-2', N'Hainamosa', 0, 4)
INSERT [dbo].[empresas] ([Nombre], [Representante], [RNC], [Direccion], [Borrado], [ID]) VALUES (N'Empresa Gonzalez', N'Katiuska Gonzalez', N'1-26-45678-6', N'New Jersey', 0, 5)
SET IDENTITY_INSERT [dbo].[empresas] OFF
USE [master]
GO
ALTER DATABASE [Empresas] SET  READ_WRITE 
GO
