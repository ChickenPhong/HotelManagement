USE [master]
GO
/****** Object:  Database [hoteldb]    Script Date: 5/3/2025 12:21:07 PM ******/
CREATE DATABASE [hoteldb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hoteldb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\hoteldb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hoteldb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\hoteldb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [hoteldb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hoteldb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hoteldb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hoteldb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hoteldb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hoteldb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hoteldb] SET ARITHABORT OFF 
GO
ALTER DATABASE [hoteldb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [hoteldb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hoteldb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hoteldb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hoteldb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hoteldb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hoteldb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hoteldb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hoteldb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hoteldb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [hoteldb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hoteldb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hoteldb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hoteldb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hoteldb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hoteldb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hoteldb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hoteldb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [hoteldb] SET  MULTI_USER 
GO
ALTER DATABASE [hoteldb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hoteldb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hoteldb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hoteldb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hoteldb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [hoteldb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [hoteldb] SET QUERY_STORE = ON
GO
ALTER DATABASE [hoteldb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [hoteldb]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 5/3/2025 12:21:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[cid] [int] IDENTITY(1,1) NOT NULL,
	[cname] [nvarchar](50) NULL,
	[mobile] [bigint] NOT NULL,
	[nationality] [nvarchar](50) NULL,
	[gender] [nvarchar](10) NULL,
	[dob] [varchar](50) NOT NULL,
	[idproof] [varchar](250) NOT NULL,
	[address] [nvarchar](100) NULL,
	[checkin] [varchar](250) NOT NULL,
	[checkout] [varchar](250) NULL,
	[chekout] [varchar](250) NULL,
	[roomid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customerRequest]    Script Date: 5/3/2025 12:21:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customerRequest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](1) NOT NULL,
	[Request] [nvarchar](255) NOT NULL,
	[EmployeeName] [nvarchar](255) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 5/3/2025 12:21:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[eid] [int] IDENTITY(1,1) NOT NULL,
	[ename] [nvarchar](50) NULL,
	[mobile] [bigint] NOT NULL,
	[gender] [nvarchar](10) NULL,
	[emailid] [varchar](120) NOT NULL,
	[username] [varchar](150) NOT NULL,
	[pass] [varchar](150) NOT NULL,
	[role] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[eid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rooms]    Script Date: 5/3/2025 12:21:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rooms](
	[roomid] [int] IDENTITY(1,1) NOT NULL,
	[roomNo] [varchar](250) NOT NULL,
	[roomType] [nvarchar](50) NULL,
	[bed] [nvarchar](50) NULL,
	[price] [bigint] NOT NULL,
	[booked] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[roomid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [address], [checkin], [checkout], [chekout], [roomid]) VALUES (19, N'Nguyễn Văn Ba', 986725172, N'Việt Nam', N'Nam', N'3/20/1987', N'0787283621832', N'77 Lê Lợi, phường Bến Nghé', N'4/28/2025', N'5/2/2025', N'YES', 24)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [address], [checkin], [checkout], [chekout], [roomid]) VALUES (20, N'Nguyễn Văn Sỹ', 786543232, N'Việt Nam', N'Nam', N'2/1/1992', N'078234111223', N'43 Hoàng Hoa Thám, phường 25 Quận Bình Thạnh', N'4/25/2025', N'5/3/2025', N'YES', 23)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [address], [checkin], [checkout], [chekout], [roomid]) VALUES (21, N'Trần Huỳnh Hoa', 873451242, N'Việt Nam', N'Nam', N'4/1/2000', N'08728423914124', N'23 Trần Hưng đạo, Phường Bến Nghé, Quận 1', N'3/26/2025', N'4/5/2025', N'YES', 24)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [address], [checkin], [checkout], [chekout], [roomid]) VALUES (22, N'Nguyễn Lê Văn Mỹ', 871293212, N'Việt Nam', N'Nữ', N'5/3/1999', N'079746222125', N'34 Phan Văn Trị, Phường 11, Quận Bình Thạnh', N'4/29/2025', N'4/30/2025', N'YES', 23)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [address], [checkin], [checkout], [chekout], [roomid]) VALUES (24, N'Trần Thị Thu Huyền', 8976452321, N'Việt Nam', N'Nữ', N'5/27/2004', N'072423999876', N'34/1/23 Lê Văn Duyệt, Quận Bình Thạnh', N'5/1/2025', NULL, N'NO', 25)
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[customerRequest] ON 

INSERT [dbo].[customerRequest] ([Id], [RoomNo], [Request], [EmployeeName], [Status]) VALUES (1, N'2', N'Rượu', N'Tran Huynh Sang', N'Đã gửi yêu cầu')
INSERT [dbo].[customerRequest] ([Id], [RoomNo], [Request], [EmployeeName], [Status]) VALUES (2, N'1', N'Dọn phòng', N'Tô Quốc Bình', N'Đã gửi yêu cầu')
INSERT [dbo].[customerRequest] ([Id], [RoomNo], [Request], [EmployeeName], [Status]) VALUES (3, N'1', N'Nước ngọt', N'Tran Huynh Sang', N'Đã gửi yêu cầu')
SET IDENTITY_INSERT [dbo].[customerRequest] OFF
GO
SET IDENTITY_INSERT [dbo].[employee] ON 

INSERT [dbo].[employee] ([eid], [ename], [mobile], [gender], [emailid], [username], [pass], [role]) VALUES (10, N'Nguyen Dang Khoi', 784324567, N'Male', N'khoidb@gmail.com', N'gay', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Quản lý')
INSERT [dbo].[employee] ([eid], [ename], [mobile], [gender], [emailid], [username], [pass], [role]) VALUES (11, N'Tran Huynh Sang', 78657354, N'Male', N'Sang24@gmail.com', N'sang', N'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', N'Nhân viên lễ tân')
INSERT [dbo].[employee] ([eid], [ename], [mobile], [gender], [emailid], [username], [pass], [role]) VALUES (13, N'Trần Quốc Phong', 897652312, N'Nam', N'phong134@gmail.com', N'phong', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Quản lý')
INSERT [dbo].[employee] ([eid], [ename], [mobile], [gender], [emailid], [username], [pass], [role]) VALUES (14, N'Tô Quốc Bình', 765323432, N'Nam', N'toquocbinh@gmail.com', N'NULL', N'+zKQACKMxaJMJkxXE53ov4VPyG/Bi/HASrYaK1y0uSE=', N'Nhân viên dọn dẹp')
SET IDENTITY_INSERT [dbo].[employee] OFF
GO
SET IDENTITY_INSERT [dbo].[rooms] ON 

INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (23, N'1', N'Có máy lạnh', N'Giường đôi', 250000, N'NO')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (24, N'2', N'Có máy lạnh', N'Giường đơn', 200000, N'NO')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (25, N'3', N'Không có máy lạnh', N'Giường đơn', 120000, N'YES')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (26, N'4', N'Có máy lạnh', N'Giường ba', 320000, N'NO')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (27, N'5', N'Có máy lạnh', N'Giường đơn', 200000, N'NO')
SET IDENTITY_INSERT [dbo].[rooms] OFF
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT ('NO') FOR [chekout]
GO
ALTER TABLE [dbo].[rooms] ADD  DEFAULT ('NO') FOR [booked]
GO
ALTER TABLE [dbo].[customer]  WITH CHECK ADD FOREIGN KEY([roomid])
REFERENCES [dbo].[rooms] ([roomid])
GO
USE [master]
GO
ALTER DATABASE [hoteldb] SET  READ_WRITE 
GO
