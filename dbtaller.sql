USE [master]
GO
/****** Object:  Database [dbtaller]    Script Date: 30/07/2023 12:13:36 ******/
CREATE DATABASE [dbtaller]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbtaller', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbtaller.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbtaller_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbtaller_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dbtaller] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbtaller].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbtaller] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbtaller] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbtaller] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbtaller] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbtaller] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbtaller] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbtaller] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbtaller] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbtaller] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbtaller] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbtaller] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbtaller] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbtaller] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbtaller] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbtaller] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbtaller] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbtaller] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbtaller] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbtaller] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbtaller] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbtaller] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbtaller] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbtaller] SET RECOVERY FULL 
GO
ALTER DATABASE [dbtaller] SET  MULTI_USER 
GO
ALTER DATABASE [dbtaller] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbtaller] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbtaller] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbtaller] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbtaller] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbtaller] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbtaller', N'ON'
GO
ALTER DATABASE [dbtaller] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbtaller] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbtaller]
GO
/****** Object:  Table [dbo].[Auto]    Script Date: 30/07/2023 12:13:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auto](
	[placa] [char](6) NOT NULL,
	[marca] [varchar](20) NULL,
	[modelo] [varchar](20) NULL,
	[color] [varchar](20) NULL,
	[año] [int] NULL,
	[combustible] [varchar](20) NULL,
 CONSTRAINT [PK_Auto] PRIMARY KEY CLUSTERED 
(
	[placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'123ZQC', N'Peugeot', N'qqqqq', N'eeeeee', 2022, N'gnv')
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'987GFA', N'Mitsubishi', N'ASDAD', N'DASDAS', 2022, N'gnv')
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'ASDASD', N'Mazda', N'ASDASD', N'ASDASD', 2022, N'glp')
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'ddd123', N'Toyota', N'ddddddd', N'ddddddddd', 2020, N'glp')
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'JKL190', N'Mitsubishi', N'ASDAS', N'DASASD', 2020, N'gnv')
INSERT [dbo].[Auto] ([placa], [marca], [modelo], [color], [año], [combustible]) VALUES (N'MNB192', N'Toyota', N'asd', N'asd', 2022, N'gnv')
GO
USE [master]
GO
ALTER DATABASE [dbtaller] SET  READ_WRITE 
GO
