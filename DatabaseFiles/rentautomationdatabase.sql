USE [master]
GO
/****** Object:  Database [rentautomationdatabase]    Script Date: 29.04.2019 08:00:57 ******/
CREATE DATABASE [rentautomationdatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'rentautomationdatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\rentautomationdatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'rentautomationdatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\rentautomationdatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [rentautomationdatabase] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [rentautomationdatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [rentautomationdatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [rentautomationdatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [rentautomationdatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [rentautomationdatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [rentautomationdatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [rentautomationdatabase] SET  MULTI_USER 
GO
ALTER DATABASE [rentautomationdatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [rentautomationdatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [rentautomationdatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [rentautomationdatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [rentautomationdatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [rentautomationdatabase] SET QUERY_STORE = OFF
GO
USE [rentautomationdatabase]
GO
/****** Object:  Table [dbo].[addresstable]    Script Date: 29.04.2019 08:00:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[addresstable](
	[addressnumber] [int] IDENTITY(1,1) NOT NULL,
	[neighborhood] [nvarchar](255) NULL,
	[street] [nvarchar](255) NULL,
	[district] [nvarchar](255) NULL,
	[city] [nvarchar](255) NULL,
	[buildnumber] [int] NULL,
	[isactive] [int] NULL,
 CONSTRAINT [PK_addresstable] PRIMARY KEY CLUSTERED 
(
	[addressnumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[companytable]    Script Date: 29.04.2019 08:00:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companytable](
	[companynumber] [int] IDENTITY(1,1) NOT NULL,
	[companyname] [nvarchar](255) NULL,
	[city] [nvarchar](50) NULL,
	[addressnumber] [int] NULL,
	[vehiclecount] [int] NULL,
	[rate] [int] NULL,
	[isactive] [int] NULL,
 CONSTRAINT [PK_companytable] PRIMARY KEY CLUSTERED 
(
	[companynumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customertable]    Script Date: 29.04.2019 08:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customertable](
	[customernumber] [int] IDENTITY(1,1) NOT NULL,
	[membernumber] [int] NULL,
 CONSTRAINT [PK_customertable] PRIMARY KEY CLUSTERED 
(
	[customernumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[membertable]    Script Date: 29.04.2019 08:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[membertable](
	[membernumber] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[lastname] [nvarchar](50) NULL,
	[username] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[birthdate] [date] NULL,
	[age] [int] NULL,
	[isactive] [int] NULL,
 CONSTRAINT [PK_membertable] PRIMARY KEY CLUSTERED 
(
	[membernumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personneltable]    Script Date: 29.04.2019 08:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personneltable](
	[personnelnumber] [int] IDENTITY(1,1) NOT NULL,
	[membernumber] [int] NULL,
	[companynumber] [int] NULL,
 CONSTRAINT [PK_personneltable] PRIMARY KEY CLUSTERED 
(
	[personnelnumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[renttable]    Script Date: 29.04.2019 08:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[renttable](
	[rentnumber] [int] NOT NULL,
	[membernumber] [int] NULL,
	[vehiclenumber] [int] NULL,
	[rentdatebegin] [date] NULL,
	[rentdateend] [date] NULL,
	[beginkm] [int] NULL,
	[endkm] [int] NULL,
	[totalprice] [decimal](18, 2) NULL,
	[isactive] [int] NULL,
 CONSTRAINT [PK_renttable] PRIMARY KEY CLUSTERED 
(
	[rentnumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rezervtable]    Script Date: 29.04.2019 08:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rezervtable](
	[rezervnumber] [int] IDENTITY(1,1) NOT NULL,
	[membernumber] [int] NULL,
	[vehiclenumber] [int] NULL,
	[rezervdate] [date] NULL,
	[isactive] [int] NULL,
 CONSTRAINT [PK_rezervtable] PRIMARY KEY CLUSTERED 
(
	[rezervnumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehicletable]    Script Date: 29.04.2019 08:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehicletable](
	[vehiclenumber] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[model] [nvarchar](50) NULL,
	[licenseage] [int] NULL,
	[minimumagelimit] [int] NULL,
	[dailykmlimit] [int] NULL,
	[currentkm] [int] NULL,
	[airbag] [int] NULL,
	[trunkvolume] [float] NULL,
	[seatcount] [int] NULL,
	[dailyrentprice] [decimal](18, 2) NULL,
	[companynumber] [int] NULL,
	[isactive] [int] NULL,
	[istaken] [int] NULL,
 CONSTRAINT [PK_vehicletable] PRIMARY KEY CLUSTERED 
(
	[vehiclenumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[addresstable] ADD  CONSTRAINT [DF_addresstable_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[companytable] ADD  CONSTRAINT [DF_companytable_rate]  DEFAULT ((0)) FOR [rate]
GO
ALTER TABLE [dbo].[membertable] ADD  CONSTRAINT [DF_membertable_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[renttable] ADD  CONSTRAINT [DF_renttable_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[rezervtable] ADD  CONSTRAINT [DF_rezervtable_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[companytable]  WITH CHECK ADD  CONSTRAINT [FK_companytable_addresstable] FOREIGN KEY([addressnumber])
REFERENCES [dbo].[addresstable] ([addressnumber])
GO
ALTER TABLE [dbo].[companytable] CHECK CONSTRAINT [FK_companytable_addresstable]
GO
ALTER TABLE [dbo].[customertable]  WITH CHECK ADD  CONSTRAINT [FK_Customer_membertable] FOREIGN KEY([membernumber])
REFERENCES [dbo].[membertable] ([membernumber])
GO
ALTER TABLE [dbo].[customertable] CHECK CONSTRAINT [FK_Customer_membertable]
GO
ALTER TABLE [dbo].[personneltable]  WITH CHECK ADD  CONSTRAINT [FK_personneltable_companytable] FOREIGN KEY([companynumber])
REFERENCES [dbo].[companytable] ([companynumber])
GO
ALTER TABLE [dbo].[personneltable] CHECK CONSTRAINT [FK_personneltable_companytable]
GO
ALTER TABLE [dbo].[personneltable]  WITH CHECK ADD  CONSTRAINT [FK_personneltable_membertable] FOREIGN KEY([membernumber])
REFERENCES [dbo].[membertable] ([membernumber])
GO
ALTER TABLE [dbo].[personneltable] CHECK CONSTRAINT [FK_personneltable_membertable]
GO
ALTER TABLE [dbo].[renttable]  WITH CHECK ADD  CONSTRAINT [FK_renttable_membertable] FOREIGN KEY([membernumber])
REFERENCES [dbo].[membertable] ([membernumber])
GO
ALTER TABLE [dbo].[renttable] CHECK CONSTRAINT [FK_renttable_membertable]
GO
ALTER TABLE [dbo].[renttable]  WITH CHECK ADD  CONSTRAINT [FK_renttable_vehicletable] FOREIGN KEY([vehiclenumber])
REFERENCES [dbo].[vehicletable] ([vehiclenumber])
GO
ALTER TABLE [dbo].[renttable] CHECK CONSTRAINT [FK_renttable_vehicletable]
GO
ALTER TABLE [dbo].[rezervtable]  WITH CHECK ADD  CONSTRAINT [FK_rezervtable_membertable] FOREIGN KEY([membernumber])
REFERENCES [dbo].[membertable] ([membernumber])
GO
ALTER TABLE [dbo].[rezervtable] CHECK CONSTRAINT [FK_rezervtable_membertable]
GO
ALTER TABLE [dbo].[rezervtable]  WITH CHECK ADD  CONSTRAINT [FK_rezervtable_vehicletable] FOREIGN KEY([vehiclenumber])
REFERENCES [dbo].[vehicletable] ([vehiclenumber])
GO
ALTER TABLE [dbo].[rezervtable] CHECK CONSTRAINT [FK_rezervtable_vehicletable]
GO
ALTER TABLE [dbo].[vehicletable]  WITH CHECK ADD  CONSTRAINT [FK_vehicletable_companytable] FOREIGN KEY([companynumber])
REFERENCES [dbo].[companytable] ([companynumber])
GO
ALTER TABLE [dbo].[vehicletable] CHECK CONSTRAINT [FK_vehicletable_companytable]
GO
USE [master]
GO
ALTER DATABASE [rentautomationdatabase] SET  READ_WRITE 
GO
