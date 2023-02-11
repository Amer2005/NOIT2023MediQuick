USE [master]
GO
/****** Object:  Database [MediQuick]    Script Date: 2/11/2023 5:44:26 PM ******/
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
/****** Object:  User [Amer]    Script Date: 2/11/2023 5:44:26 PM ******/
CREATE USER [Amer] FOR LOGIN [Amer] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Amer]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [Amer]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [Amer]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [Amer]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [Amer]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Amer]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Amer]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [Amer]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [Amer]
GO
/****** Object:  Table [dbo].[Ambulance]    Script Date: 2/11/2023 5:44:27 PM ******/
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
	[UserId] [int] NULL,
 CONSTRAINT [PK_Ambulance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AmbulancesDevices]    Script Date: 2/11/2023 5:44:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AmbulancesDevices](
	[AmbulanceId] [int] NOT NULL,
	[DeviceId] [int] NOT NULL,
 CONSTRAINT [PK_AmbulancesDevices] PRIMARY KEY CLUSTERED 
(
	[AmbulanceId] ASC,
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cardiogram]    Script Date: 2/11/2023 5:44:27 PM ******/
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
/****** Object:  Table [dbo].[Device]    Script Date: 2/11/2023 5:44:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hospital]    Script Date: 2/11/2023 5:44:27 PM ******/
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
/****** Object:  Table [dbo].[Location]    Script Date: 2/11/2023 5:44:27 PM ******/
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
/****** Object:  Table [dbo].[Patient]    Script Date: 2/11/2023 5:44:27 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 2/11/2023 5:44:27 PM ******/
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
/****** Object:  Table [dbo].[Role_User]    Script Date: 2/11/2023 5:44:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role_User](
	[RoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Role_User] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/11/2023 5:44:27 PM ******/
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
ALTER TABLE [dbo].[Ambulance]  WITH CHECK ADD  CONSTRAINT [FK_Ambulance_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Ambulance] CHECK CONSTRAINT [FK_Ambulance_Location]
GO
ALTER TABLE [dbo].[Ambulance]  WITH CHECK ADD  CONSTRAINT [FK_Ambulance_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
GO
ALTER TABLE [dbo].[Ambulance] CHECK CONSTRAINT [FK_Ambulance_Patient]
GO
ALTER TABLE [dbo].[Ambulance]  WITH CHECK ADD  CONSTRAINT [FK_Ambulance_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Ambulance] CHECK CONSTRAINT [FK_Ambulance_User]
GO
ALTER TABLE [dbo].[AmbulancesDevices]  WITH CHECK ADD  CONSTRAINT [FK_AmbulancesDevices_Ambulance] FOREIGN KEY([AmbulanceId])
REFERENCES [dbo].[Ambulance] ([Id])
GO
ALTER TABLE [dbo].[AmbulancesDevices] CHECK CONSTRAINT [FK_AmbulancesDevices_Ambulance]
GO
ALTER TABLE [dbo].[AmbulancesDevices]  WITH CHECK ADD  CONSTRAINT [FK_AmbulancesDevices_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([Id])
GO
ALTER TABLE [dbo].[AmbulancesDevices] CHECK CONSTRAINT [FK_AmbulancesDevices_Device]
GO
ALTER TABLE [dbo].[Cardiogram]  WITH CHECK ADD  CONSTRAINT [FK_Cardiogram_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
GO
ALTER TABLE [dbo].[Cardiogram] CHECK CONSTRAINT [FK_Cardiogram_Patient]
GO
ALTER TABLE [dbo].[Hospital]  WITH CHECK ADD  CONSTRAINT [FK_Hospital_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Hospital] CHECK CONSTRAINT [FK_Hospital_Location]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Location]
GO
ALTER TABLE [dbo].[Role_User]  WITH CHECK ADD  CONSTRAINT [FK_Role_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Role_User] CHECK CONSTRAINT [FK_Role_User_Role]
GO
ALTER TABLE [dbo].[Role_User]  WITH CHECK ADD  CONSTRAINT [FK_Role_User_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Role_User] CHECK CONSTRAINT [FK_Role_User_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Hospital] FOREIGN KEY([HospitalId])
REFERENCES [dbo].[Hospital] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Hospital]
GO
USE [master]
GO
ALTER DATABASE [MediQuick] SET  READ_WRITE 
GO
