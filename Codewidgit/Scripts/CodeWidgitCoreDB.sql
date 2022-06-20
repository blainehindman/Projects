USE [master]
GO
/****** Object:  Database [CodeWidgitCoreDB]    Script Date: 6/20/2022 4:49:03 PM ******/
CREATE DATABASE [CodeWidgitCoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CodeWidgitCoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CodeWidgitCoreDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CodeWidgitCoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CodeWidgitCoreDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CodeWidgitCoreDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CodeWidgitCoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CodeWidgitCoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CodeWidgitCoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CodeWidgitCoreDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CodeWidgitCoreDB] SET QUERY_STORE = OFF
GO
USE [CodeWidgitCoreDB]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 6/20/2022 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Rating_ID] [uniqueidentifier] NOT NULL,
	[Wigit_ID] [uniqueidentifier] NOT NULL,
	[Author_ID] [uniqueidentifier] NOT NULL,
	[Author_Username] [nchar](30) NOT NULL,
	[Comment_Date] [nchar](30) NOT NULL,
	[Edited] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Rating_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Likes]    Script Date: 6/20/2022 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Likes](
	[Like_ID] [uniqueidentifier] NOT NULL,
	[Widgit_ID] [uniqueidentifier] NOT NULL,
	[Author_ID] [uniqueidentifier] NOT NULL,
	[Author_Username] [nchar](30) NOT NULL,
	[Like_Date] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Likes] PRIMARY KEY CLUSTERED 
(
	[Like_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase_Record]    Script Date: 6/20/2022 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase_Record](
	[Transaction_ID] [uniqueidentifier] NOT NULL,
	[Widgit_ID] [uniqueidentifier] NOT NULL,
	[Widgit_Name] [nchar](30) NOT NULL,
	[Widgit_Description] [nchar](300) NOT NULL,
	[Creator_ID] [uniqueidentifier] NOT NULL,
	[Creator_Username] [nchar](30) NOT NULL,
	[Purchaser_ID] [uniqueidentifier] NOT NULL,
	[Purchaser_Username] [nchar](30) NOT NULL,
	[Widgit_Price] [float] NOT NULL,
	[Purchase_Date] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Purchase_Record] PRIMARY KEY CLUSTERED 
(
	[Transaction_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 6/20/2022 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[Rating_ID] [uniqueidentifier] NOT NULL,
	[Widgit_ID] [uniqueidentifier] NOT NULL,
	[Author_ID] [uniqueidentifier] NOT NULL,
	[Author_Username] [nchar](30) NOT NULL,
	[Rating_Date] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[Rating_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/20/2022 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[User_ID] [uniqueidentifier] NOT NULL,
	[First_Name] [nchar](30) NOT NULL,
	[Last_Name] [nchar](30) NOT NULL,
	[Username] [nchar](30) NOT NULL,
	[Password] [nchar](30) NOT NULL,
	[Birthday] [nchar](30) NOT NULL,
	[Date_Joined] [nchar](30) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Widgit]    Script Date: 6/20/2022 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Widgit](
	[Widgit_ID] [uniqueidentifier] NOT NULL,
	[Widgit_Name] [nchar](30) NOT NULL,
	[Widgit_Description] [nchar](300) NOT NULL,
	[Creator_ID] [uniqueidentifier] NOT NULL,
	[Creator_Username] [nchar](30) NOT NULL,
	[Published_Date] [nchar](30) NOT NULL,
	[Updated_Date] [nchar](30) NOT NULL,
	[Widgit_Price] [float] NOT NULL,
	[Widgit_Downloads] [int] NOT NULL,
	[Widgit_Rating] [float] NOT NULL,
	[Widgit_Likes_Count] [int] NOT NULL,
	[Widgit_Comments_Count] [int] NOT NULL,
 CONSTRAINT [PK_Widgit] PRIMARY KEY CLUSTERED 
(
	[Widgit_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [CodeWidgitCoreDB] SET  READ_WRITE 
GO
