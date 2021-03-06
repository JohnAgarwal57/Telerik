USE [master]
GO
/****** Object:  Database [Persons]    Script Date: 20.8.2014 г. 16:36:42 ч. ******/
CREATE DATABASE [Persons]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Persons', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Persons.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Persons_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Persons_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Persons] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Persons].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Persons] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Persons] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Persons] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Persons] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Persons] SET ARITHABORT OFF 
GO
ALTER DATABASE [Persons] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Persons] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Persons] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Persons] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Persons] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Persons] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Persons] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Persons] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Persons] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Persons] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Persons] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Persons] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Persons] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Persons] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Persons] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Persons] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Persons] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Persons] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Persons] SET  MULTI_USER 
GO
ALTER DATABASE [Persons] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Persons] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Persons] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Persons] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Persons] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Persons]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 20.8.2014 г. 16:36:42 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Adresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Continents]    Script Date: 20.8.2014 г. 16:36:42 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 20.8.2014 г. 16:36:42 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 20.8.2014 г. 16:36:42 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Towns]    Script Date: 20.8.2014 г. 16:36:42 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Towns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([Id], [Name], [TownId]) VALUES (1, N'Mladost 1, bl.111, en.3, fl.1, ap.3', 1)
INSERT [dbo].[Addresses] ([Id], [Name], [TownId]) VALUES (2, N'Sunset blv, 111', 4)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([Id], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (2, N'Africa')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (3, N'Asia')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (4, N'South America')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (5, N'North America')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (6, N'Australia')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (7, N'Antartic')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (2, N'Germany', 1)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (3, N'USA', 5)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (4, N'Brasil', 4)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (5, N'Australia', 6)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [AddressId]) VALUES (1, N'Ivan', N'Ivanov', 1)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [AddressId]) VALUES (2, N'John', N'Brown', 2)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (2, N'Plovdiv', 1)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (3, N'Berlin', 2)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (4, N'Los Angeles', 3)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (5, N'Sidney', 5)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([Id])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [Persons] SET  READ_WRITE 
GO
