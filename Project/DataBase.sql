USE [master]
GO
/****** Object:  Database [PRN_DB]    Script Date: 4/5/2020 6:26:14 PM ******/
CREATE DATABASE [PRN_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN_DB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PRN_DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PRN_DB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PRN_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PRN_DB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRN_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRN_DB] SET  MULTI_USER 
GO
ALTER DATABASE [PRN_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PRN_DB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PRN_DB]
GO
/****** Object:  Table [dbo].[Export]    Script Date: 4/5/2020 6:26:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Export](
	[ExportID] [nchar](50) NULL,
	[ProductID] [nchar](10) NULL,
	[DateExport] [datetime] NULL,
	[NumberPackageExport] [int] NULL,
	[NumberSubpackageExport] [int] NULL,
	[PriceExport] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Import]    Script Date: 4/5/2020 6:26:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Import](
	[ImportID] [nchar](50) NULL,
	[ProductID] [nchar](10) NOT NULL,
	[DateImport] [datetime] NULL,
	[ImportFrom] [nchar](100) NULL,
	[NumberPackageImport] [int] NULL,
	[PriceImport] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/5/2020 6:26:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [nchar](10) NOT NULL,
	[ProductName] [nvarchar](150) NULL,
	[Description] [nvarchar](150) NULL,
	[PackageID] [nchar](50) NULL,
	[NumbersPackage] [int] NULL,
	[PriceOnePackage] [float] NULL,
	[PriceToExportPackage] [float] NULL,
	[SubPackage] [nvarchar](50) NULL,
	[NumberSubPackage] [int] NULL,
	[CountSubExport] [int] NULL,
	[PriceToExportSub] [float] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserApp]    Script Date: 4/5/2020 6:26:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserApp](
	[Username] [nchar](50) NOT NULL,
	[Password] [nchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_UserApp] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Export] ([ExportID], [ProductID], [DateExport], [NumberPackageExport], [NumberSubpackageExport], [PriceExport]) VALUES (N'admin                                             ', N'ka        ', CAST(N'2020-04-05 15:32:19.000' AS DateTime), 1, 2, 3)
INSERT [dbo].[Export] ([ExportID], [ProductID], [DateExport], [NumberPackageExport], [NumberSubpackageExport], [PriceExport]) VALUES (N'admin                                             ', N'ka        ', CAST(N'2020-04-05 15:33:24.000' AS DateTime), 1, 2, 3)
INSERT [dbo].[Export] ([ExportID], [ProductID], [DateExport], [NumberPackageExport], [NumberSubpackageExport], [PriceExport]) VALUES (N'admin                                             ', N'5         ', CAST(N'2020-04-05 18:16:07.000' AS DateTime), 10000, 0, 100000)
INSERT [dbo].[Export] ([ExportID], [ProductID], [DateExport], [NumberPackageExport], [NumberSubpackageExport], [PriceExport]) VALUES (N'admin                                             ', N'5         ', CAST(N'2020-04-05 18:20:53.000' AS DateTime), 1000, 0, 10000)
INSERT [dbo].[Export] ([ExportID], [ProductID], [DateExport], [NumberPackageExport], [NumberSubpackageExport], [PriceExport]) VALUES (N'admin                                             ', N'5         ', CAST(N'2020-04-05 18:21:04.000' AS DateTime), 1000, 0, 10000)
INSERT [dbo].[Import] ([ImportID], [ProductID], [DateImport], [ImportFrom], [NumberPackageImport], [PriceImport]) VALUES (N'admin                                             ', N'5         ', CAST(N'2020-04-05 08:36:58.000' AS DateTime), N'a                                                                                                   ', 80000, 2000)
INSERT [dbo].[Import] ([ImportID], [ProductID], [DateImport], [ImportFrom], [NumberPackageImport], [PriceImport]) VALUES (N'admin                                             ', N'5         ', CAST(N'2020-04-05 18:08:04.000' AS DateTime), N'a                                                                                                   ', 10000, 20000000)
INSERT [dbo].[Import] ([ImportID], [ProductID], [DateImport], [ImportFrom], [NumberPackageImport], [PriceImport]) VALUES (N'admin                                             ', N'5         ', CAST(N'2020-04-05 18:09:26.000' AS DateTime), N'a                                                                                                   ', 100000, 200000000)
INSERT [dbo].[Import] ([ImportID], [ProductID], [DateImport], [ImportFrom], [NumberPackageImport], [PriceImport]) VALUES (N'admin                                             ', N'5         ', CAST(N'2020-04-05 18:09:48.000' AS DateTime), N'a                                                                                                   ', 5555, 11110000)
INSERT [dbo].[Import] ([ImportID], [ProductID], [DateImport], [ImportFrom], [NumberPackageImport], [PriceImport]) VALUES (N'admin                                             ', N'5         ', CAST(N'2020-04-05 18:13:09.000' AS DateTime), N'a                                                                                                   ', 5000, 10000000)
INSERT [dbo].[Import] ([ImportID], [ProductID], [DateImport], [ImportFrom], [NumberPackageImport], [PriceImport]) VALUES (N'admin                                             ', N'5         ', CAST(N'2020-04-05 18:14:03.000' AS DateTime), N'a                                                                                                   ', 100000, 200000000)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Description], [PackageID], [NumbersPackage], [PriceOnePackage], [PriceToExportPackage], [SubPackage], [NumberSubPackage], [CountSubExport], [PriceToExportSub], [Status]) VALUES (N'5         ', N'Bột giặc', N'omo', N'túi                                               ', 208564, 2000, 10, N'', 0, 0, 0, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Description], [PackageID], [NumbersPackage], [PriceOnePackage], [PriceToExportPackage], [SubPackage], [NumberSubPackage], [CountSubExport], [PriceToExportSub], [Status]) VALUES (N'9         ', N'9', N'9', N'9                                                 ', 9, 9, 9, N'9', 9, 0, 9, 0)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Description], [PackageID], [NumbersPackage], [PriceOnePackage], [PriceToExportPackage], [SubPackage], [NumberSubPackage], [CountSubExport], [PriceToExportSub], [Status]) VALUES (N'ka        ', N'pepsi', N'ban khong cho', N'thung                                             ', 4, 5, 1, N'lon', 5, 1, 1, 1)
INSERT [dbo].[UserApp] ([Username], [Password], [Status]) VALUES (N'admin                                             ', N'123                                               ', 1)
ALTER TABLE [dbo].[Export]  WITH CHECK ADD  CONSTRAINT [FK_Export_UserApp] FOREIGN KEY([ExportID])
REFERENCES [dbo].[UserApp] ([Username])
GO
ALTER TABLE [dbo].[Export] CHECK CONSTRAINT [FK_Export_UserApp]
GO
ALTER TABLE [dbo].[Import]  WITH CHECK ADD  CONSTRAINT [FK_Import_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Import] CHECK CONSTRAINT [FK_Import_Product]
GO
ALTER TABLE [dbo].[Import]  WITH CHECK ADD  CONSTRAINT [FK_Import_UserApp] FOREIGN KEY([ImportID])
REFERENCES [dbo].[UserApp] ([Username])
GO
ALTER TABLE [dbo].[Import] CHECK CONSTRAINT [FK_Import_UserApp]
GO
USE [master]
GO
ALTER DATABASE [PRN_DB] SET  READ_WRITE 
GO
