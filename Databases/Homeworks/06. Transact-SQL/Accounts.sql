USE [master]
GO
/****** Object:  Database [Accounts]    Script Date: 22.8.2014 г. 14:14:44 ч. ******/
CREATE DATABASE [Accounts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Accounts', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Accounts.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Accounts_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Accounts_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Accounts] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Accounts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Accounts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Accounts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Accounts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Accounts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Accounts] SET ARITHABORT OFF 
GO
ALTER DATABASE [Accounts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Accounts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Accounts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Accounts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Accounts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Accounts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Accounts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Accounts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Accounts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Accounts] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Accounts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Accounts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Accounts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Accounts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Accounts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Accounts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Accounts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Accounts] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Accounts] SET  MULTI_USER 
GO
ALTER DATABASE [Accounts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Accounts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Accounts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Accounts] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Accounts] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Accounts]
GO
/****** Object:  UserDefinedFunction [dbo].[ufn_CalcInterest]    Script Date: 22.8.2014 г. 14:14:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[ufn_CalcInterest](@sum money, @yearlyInterestRate float, @months int)
	RETURNS money
AS
BEGIN
	return (@sum + (@sum * @yearlyInterestRate/100 * 12/@months) )
END
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 22.8.2014 г. 14:14:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NULL,
	[Balance] [money] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 22.8.2014 г. 14:14:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[OldSum] [money] NOT NULL,
	[NewSum] [money] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 22.8.2014 г. 14:14:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[SSN] [nvarchar](50) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountId], [PersonId], [Balance]) VALUES (1, 1, 100.0000)
INSERT [dbo].[Accounts] ([AccountId], [PersonId], [Balance]) VALUES (2, 1, 1000.0000)
INSERT [dbo].[Accounts] ([AccountId], [PersonId], [Balance]) VALUES (3, 2, 500.5000)
INSERT [dbo].[Accounts] ([AccountId], [PersonId], [Balance]) VALUES (4, 3, 806.7000)
INSERT [dbo].[Accounts] ([AccountId], [PersonId], [Balance]) VALUES (5, 4, 30000.0000)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [SSN]) VALUES (1, N'Peter', N'Petrov', N'123456789')
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [SSN]) VALUES (2, N'George', N'Brown', N'987654321')
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [SSN]) VALUES (3, N'Michael', N'Ivanov', N'11111111')
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [SSN]) VALUES (4, N'Pesho', N'Telerikov', N'999999999')
SET IDENTITY_INSERT [dbo].[Persons] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([PersonId])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Accounts]
GO
/****** Object:  StoredProcedure [dbo].[usp_DepositMoney]    Script Date: 22.8.2014 г. 14:14:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_DepositMoney](@Account int, @money money) 
AS
	BEGIN TRAN
		Update Accounts
		Set Balance = Balance + @money
		where PersonId = @Account
	COMMIT TRAN

GO
/****** Object:  StoredProcedure [dbo].[usp_GiveInterest]    Script Date: 22.8.2014 г. 14:14:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_GiveInterest](@Account int, @InterestRate float) 
AS
	Update Accounts 
	Set Balance = [dbo].[ufn_CalcInterest] (Balance, @InterestRate, 1)
	where PersonId = @Account 

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectPersonsByBalance]    Script Date: 22.8.2014 г. 14:14:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_SelectPersonsByBalance](@balance money) 
AS
	Select p.FirstName + ' ' + p.LastName as [Full name] from Persons p
		inner join Accounts a on p.PersonId=a.PersonId
		Where a.Balance>@balance

GO
/****** Object:  StoredProcedure [dbo].[usp_ShowFullName]    Script Date: 22.8.2014 г. 14:14:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_ShowFullName]
AS
	Select FirstName + ' ' + LastName as [Full name] from Persons

GO
/****** Object:  StoredProcedure [dbo].[usp_WithdrawMoney]    Script Date: 22.8.2014 г. 14:14:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_WithdrawMoney](@Account int, @money money) 
AS
	BEGIN TRAN
		Update Accounts
		Set Balance = Balance - @money
		where PersonId = @Account
	COMMIT TRAN

GO
/****** Object:  Trigger [dbo].[tr_BalanceChanged]    Script Date: 22.8.2014 г. 14:14:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tr_BalanceChanged] ON [dbo].[Accounts] FOR INSERT, UPDATE, DELETE
AS
	Begin
		Insert into Logs(AccountId, OldSum, NewSum) Select i.AccountID, d.Balance, i.Balance from inserted i, deleted d
	End;

GO
USE [master]
GO
ALTER DATABASE [Accounts] SET  READ_WRITE 
GO
