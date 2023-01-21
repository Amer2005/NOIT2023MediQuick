USE [master]
GO
/****** Object:  Database [MediQuick]    Script Date: 1/21/2023 6:32:17 PM ******/
CREATE DATABASE [MediQuick]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MediQuick', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MediQuick.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MediQuick_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MediQuick_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MediQuick] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MediQuick].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MediQuick] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MediQuick] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MediQuick] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MediQuick] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MediQuick] SET ARITHABORT OFF 
GO
ALTER DATABASE [MediQuick] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MediQuick] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MediQuick] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MediQuick] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MediQuick] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MediQuick] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MediQuick] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MediQuick] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MediQuick] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MediQuick] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MediQuick] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MediQuick] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MediQuick] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MediQuick] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MediQuick] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MediQuick] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MediQuick] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MediQuick] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MediQuick] SET  MULTI_USER 
GO
ALTER DATABASE [MediQuick] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MediQuick] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MediQuick] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MediQuick] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MediQuick] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MediQuick] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MediQuick] SET QUERY_STORE = ON
GO
ALTER DATABASE [MediQuick] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MediQuick]
GO
/****** Object:  Table [dbo].[Ambulance]    Script Date: 1/21/2023 6:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ambulance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[PatientId] [int] NULL,
	[DestinationHospitalId] [int] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
 CONSTRAINT [PK_Ambulance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AmbulancesDevices]    Script Date: 1/21/2023 6:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AmbulancesDevices](
	[AmbulanceId] [int] NOT NULL,
	[DeviceId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cardiogram]    Script Date: 1/21/2023 6:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cardiogram](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[File] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Cardiogram] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 1/21/2023 6:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hospital]    Script Date: 1/21/2023 6:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hospital](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LocationId] [int] NULL,
 CONSTRAINT [PK_Hospital] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 1/21/2023 6:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Latitude] [decimal](8, 6) NOT NULL,
	[Longitude] [decimal](9, 6) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 1/21/2023 6:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[SocialSecurityNumber] [nchar](10) NULL,
	[Sex] [varchar](10) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[LocationId] [int] NOT NULL,
	[DateOfBirth] [date] NULL,
	[ExtraInfo] [text] NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/21/2023 6:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role_User]    Script Date: 1/21/2023 6:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role_User](
	[RoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/21/2023 6:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[HospitalId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [MediQuick] SET  READ_WRITE 
GO
