USE [master]
GO
/****** Object:  Database [ApsisDemo]    Script Date: 9.07.2021 18:09:25 ******/
CREATE DATABASE [ApsisDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApsisDemo', FILENAME = N'C:\Users\veyse\ApsisDemo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ApsisDemo_log', FILENAME = N'C:\Users\veyse\ApsisDemo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ApsisDemo] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApsisDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApsisDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApsisDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApsisDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApsisDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApsisDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApsisDemo] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ApsisDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApsisDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApsisDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApsisDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApsisDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApsisDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApsisDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApsisDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApsisDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ApsisDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApsisDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApsisDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApsisDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApsisDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApsisDemo] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ApsisDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApsisDemo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ApsisDemo] SET  MULTI_USER 
GO
ALTER DATABASE [ApsisDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApsisDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApsisDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApsisDemo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ApsisDemo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ApsisDemo] SET QUERY_STORE = OFF
GO
USE [ApsisDemo]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ApsisDemo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9.07.2021 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Apartments]    Script Date: 9.07.2021 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Floor] [int] NOT NULL,
	[DoorNumber] [int] NOT NULL,
	[Block] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Apartments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillPayments]    Script Date: 9.07.2021 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillPayments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[PayedDate] [datetime2](7) NOT NULL,
	[Status] [bit] NOT NULL,
	[CardDocumentId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_BillPayments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 9.07.2021 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[InvoiceDate] [datetime2](7) NOT NULL,
	[Amount] [float] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dueses]    Script Date: 9.07.2021 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dueses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[InvoiceDate] [datetime2](7) NOT NULL,
	[Amount] [float] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Dueses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DuesPayments]    Script Date: 9.07.2021 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DuesPayments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DuesId] [int] NOT NULL,
	[PayedDate] [datetime2](7) NOT NULL,
	[Status] [bit] NOT NULL,
	[CardDocumentId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DuesPayments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 9.07.2021 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 9.07.2021 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 9.07.2021 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9.07.2021 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[IdentityNumber] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[VehiclePlateNumber] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[JoinDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210618114401_init', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210619104759_changes', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210624171923_operationClaims', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210624214331_addedUser', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210629130211_cascade', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210630002236_update', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210702144112_NewUserColumns', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210702153002_ResidentDeleted', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210702213803_userchanges', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210704141348_paymentStatusAdded', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210707120014_cardDocument', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210707123155_cardDeleted', N'5.0.7')
GO
SET IDENTITY_INSERT [dbo].[Apartments] ON 

INSERT [dbo].[Apartments] ([Id], [UserId], [Type], [Floor], [DoorNumber], [Block], [Status]) VALUES (32, 5, N'2+1', 4, 3, N'E-3', 1)
INSERT [dbo].[Apartments] ([Id], [UserId], [Type], [Floor], [DoorNumber], [Block], [Status]) VALUES (33, 6, N'3+1', 6, 12, N'A-4', 1)
SET IDENTITY_INSERT [dbo].[Apartments] OFF
GO
SET IDENTITY_INSERT [dbo].[BillPayments] ON 

INSERT [dbo].[BillPayments] ([Id], [BillId], [PayedDate], [Status], [CardDocumentId]) VALUES (2, 17, CAST(N'2021-07-04T23:21:07.0380000' AS DateTime2), 1, N'')
INSERT [dbo].[BillPayments] ([Id], [BillId], [PayedDate], [Status], [CardDocumentId]) VALUES (4, 17, CAST(N'2021-07-05T16:23:25.0630000' AS DateTime2), 1, N'')
INSERT [dbo].[BillPayments] ([Id], [BillId], [PayedDate], [Status], [CardDocumentId]) VALUES (5, 18, CAST(N'2021-07-05T16:23:30.6950000' AS DateTime2), 1, N'')
INSERT [dbo].[BillPayments] ([Id], [BillId], [PayedDate], [Status], [CardDocumentId]) VALUES (6, 17, CAST(N'2021-07-05T18:12:34.2200000' AS DateTime2), 1, N'')
INSERT [dbo].[BillPayments] ([Id], [BillId], [PayedDate], [Status], [CardDocumentId]) VALUES (7, 18, CAST(N'2021-07-07T12:38:12.6270000' AS DateTime2), 1, N'60e58d6b425977907a5c686a')
INSERT [dbo].[BillPayments] ([Id], [BillId], [PayedDate], [Status], [CardDocumentId]) VALUES (8, 20, CAST(N'2021-07-07T12:39:22.8910000' AS DateTime2), 1, N'60e58d2ab35a18710a0a3293')
INSERT [dbo].[BillPayments] ([Id], [BillId], [PayedDate], [Status], [CardDocumentId]) VALUES (9, 17, CAST(N'2021-07-07T19:11:53.2630000' AS DateTime2), 1, N'60e59a88f73b0abef1fa8a70')
SET IDENTITY_INSERT [dbo].[BillPayments] OFF
GO
SET IDENTITY_INSERT [dbo].[Bills] ON 

INSERT [dbo].[Bills] ([Id], [UserId], [Type], [InvoiceDate], [Amount], [Status]) VALUES (17, 5, N'Doğalgaz', CAST(N'2021-07-03T13:28:26.9720000' AS DateTime2), 200, 0)
INSERT [dbo].[Bills] ([Id], [UserId], [Type], [InvoiceDate], [Amount], [Status]) VALUES (18, 6, N'Doğalgaz', CAST(N'2021-07-14T00:00:00.0000000' AS DateTime2), 200, 0)
INSERT [dbo].[Bills] ([Id], [UserId], [Type], [InvoiceDate], [Amount], [Status]) VALUES (19, 6, N'Doğalgaz', CAST(N'2021-07-16T00:00:00.0000000' AS DateTime2), 200, 0)
INSERT [dbo].[Bills] ([Id], [UserId], [Type], [InvoiceDate], [Amount], [Status]) VALUES (20, 5, N'Elektrik', CAST(N'2021-08-05T18:11:49.9210000' AS DateTime2), 230, 0)
SET IDENTITY_INSERT [dbo].[Bills] OFF
GO
SET IDENTITY_INSERT [dbo].[Dueses] ON 

INSERT [dbo].[Dueses] ([Id], [UserId], [InvoiceDate], [Amount], [Status]) VALUES (14, 5, CAST(N'2021-07-03T22:50:33.3010000' AS DateTime2), 300, 0)
INSERT [dbo].[Dueses] ([Id], [UserId], [InvoiceDate], [Amount], [Status]) VALUES (16, 6, CAST(N'2021-07-07T12:21:27.3050000' AS DateTime2), 500, 0)
INSERT [dbo].[Dueses] ([Id], [UserId], [InvoiceDate], [Amount], [Status]) VALUES (17, 6, CAST(N'2021-07-07T12:34:08.2070000' AS DateTime2), 220, 0)
SET IDENTITY_INSERT [dbo].[Dueses] OFF
GO
SET IDENTITY_INSERT [dbo].[DuesPayments] ON 

INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (11, 14, CAST(N'2021-07-04T22:54:02.0170000' AS DateTime2), 1, N'')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (12, 14, CAST(N'2021-07-05T13:56:07.5460000' AS DateTime2), 1, N'')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (13, 14, CAST(N'2021-07-05T14:12:43.9350000' AS DateTime2), 1, N'')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (14, 14, CAST(N'2021-07-04T22:54:02.0170000' AS DateTime2), 1, N'60e58d2ab35a18710a0a3293')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (15, 14, CAST(N'2021-07-07T12:03:36.0970000' AS DateTime2), 1, N'60e58d2ab35a18710a0a3293')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (16, 14, CAST(N'2021-07-07T12:05:15.3290000' AS DateTime2), 1, N'60e5902fff7f6b38410391c7')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (17, 14, CAST(N'2021-07-07T12:19:10.4980000' AS DateTime2), 1, N'60e58d2ab35a18710a0a3293')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (18, 14, CAST(N'2021-07-07T12:19:10.4980000' AS DateTime2), 1, N'60e59a88f73b0abef1fa8a70')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (19, 16, CAST(N'2021-07-07T12:21:43.7820000' AS DateTime2), 1, N'60e58d6b425977907a5c686a')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (21, 14, CAST(N'2021-07-07T12:34:13.5850000' AS DateTime2), 1, N'60e58d2ab35a18710a0a3293')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (22, 16, CAST(N'2021-07-07T12:38:04.5580000' AS DateTime2), 1, N'60e58d6b425977907a5c686a')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (23, 14, CAST(N'2021-07-07T12:39:16.1610000' AS DateTime2), 1, N'60e59a88f73b0abef1fa8a70')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (24, 14, CAST(N'2021-07-07T19:11:30.5530000' AS DateTime2), 1, N'60e58d2ab35a18710a0a3293')
INSERT [dbo].[DuesPayments] ([Id], [DuesId], [PayedDate], [Status], [CardDocumentId]) VALUES (25, 16, CAST(N'2021-07-08T13:26:22.1450000' AS DateTime2), 1, N'60e6fbc49d637fe0cac40a2a')
SET IDENTITY_INSERT [dbo].[DuesPayments] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([Id], [UserId], [Subject], [Content], [CreatedDate]) VALUES (2, 6, N'Ana sayfadaki buton çalışmıyor', N'Uygulamyaya gdsgsrsd', CAST(N'2021-07-05T16:25:09.6390000' AS DateTime2))
INSERT [dbo].[Messages] ([Id], [UserId], [Subject], [Content], [CreatedDate]) VALUES (3, 6, N'deneme', N'deneme içerik', CAST(N'2021-07-05T17:00:09.2790000' AS DateTime2))
INSERT [dbo].[Messages] ([Id], [UserId], [Subject], [Content], [CreatedDate]) VALUES (8, 5, N'deneme', N'deneme içerik2', CAST(N'2021-07-05T17:04:03.7700000' AS DateTime2))
INSERT [dbo].[Messages] ([Id], [UserId], [Subject], [Content], [CreatedDate]) VALUES (9, 5, N'sdf', N'deneme içerik', CAST(N'2021-07-05T17:06:37.8810000' AS DateTime2))
INSERT [dbo].[Messages] ([Id], [UserId], [Subject], [Content], [CreatedDate]) VALUES (10, 5, N'deneme', N'deneme içerik2', CAST(N'2021-07-07T12:41:26.7980000' AS DateTime2))
INSERT [dbo].[Messages] ([Id], [UserId], [Subject], [Content], [CreatedDate]) VALUES (11, 6, N'deneme', N'deneme içerik', CAST(N'2021-07-07T20:47:58.4510000' AS DateTime2))
INSERT [dbo].[Messages] ([Id], [UserId], [Subject], [Content], [CreatedDate]) VALUES (12, 5, N'e', N'e', CAST(N'2021-07-08T13:29:29.2580000' AS DateTime2))
INSERT [dbo].[Messages] ([Id], [UserId], [Subject], [Content], [CreatedDate]) VALUES (13, 5, N'e', N'e', CAST(N'2021-07-08T13:29:29.2580000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'admin')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 

INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (3, 5, 1)
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [IdentityNumber], [Phone], [VehiclePlateNumber], [Email], [PasswordSalt], [PasswordHash], [Status], [JoinDate]) VALUES (5, N'Veysel', N'Himmetoğlu', N'23456789878', N'5456756767', N'28AD3945', N'veysel@gmail.com', 0xA7944484CAE7777D2D89268D8CE91198528738D8E741A9CB805599B0E20A297B1CD4F61136B8D72EFEC7FC5E341AD1A7CC3C95C1DD01038FDE9DB56EE4FBD5E7B4D6AE7641BC25F779C1A3AD38B8F03A9DE42CCB9DD5DEC2A96261F2EEC2FEE89980EE678B5AF0358144D5221ED7C59B95F141BF6FE5361372DDD1A303290547, 0xD1DDAEFE72AC96C74A61B80289D5B3F531B97D8F1680C6FBF6AF44BB9D311D6DCB0D4163EEE98291833E0DC02F653EE9004A37FBE5B5980D74E2CBC323E221EF, 1, CAST(N'2021-07-04T00:07:38.8370000' AS DateTime2))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [IdentityNumber], [Phone], [VehiclePlateNumber], [Email], [PasswordSalt], [PasswordHash], [Status], [JoinDate]) VALUES (6, N'Deneme ', N'Kullanıcı', N'34545656765', N'5465676787', N'29-AD-3945', N'veysel2@gmail.com', 0xC8A17753C25565BF9D5B0A402E8682795BC36B83C6F4A53AD10DD64F2E8BFE73D043984AB531A5BD63E71DDE8BD601122DE1A9005BAA4F362772801ADAA8A952B79E1ADF330EE1C70A437C20886E212AFB3D5E134ABFF195B1D57C10C543034504DE292F8CCF92210A6E4C3222456AB0924CF6973FDDA42CC4A90699D274290A, 0xE914BAA587F45B3C807253FCE0F3434DFDB2A601A1400E576F0B291C272F73E064FFCED8202F8BC83D39C50A5D08D1277F0F45B00A0A3282392C30009B5A9B6D, 1, CAST(N'2021-07-08T12:58:27.2860000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Apartments_UserId]    Script Date: 9.07.2021 18:09:25 ******/
CREATE NONCLUSTERED INDEX [IX_Apartments_UserId] ON [dbo].[Apartments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BillPayments_BillId]    Script Date: 9.07.2021 18:09:25 ******/
CREATE NONCLUSTERED INDEX [IX_BillPayments_BillId] ON [dbo].[BillPayments]
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bills_UserId]    Script Date: 9.07.2021 18:09:25 ******/
CREATE NONCLUSTERED INDEX [IX_Bills_UserId] ON [dbo].[Bills]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Dueses_UserId]    Script Date: 9.07.2021 18:09:25 ******/
CREATE NONCLUSTERED INDEX [IX_Dueses_UserId] ON [dbo].[Dueses]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DuesPayments_DuesId]    Script Date: 9.07.2021 18:09:25 ******/
CREATE NONCLUSTERED INDEX [IX_DuesPayments_DuesId] ON [dbo].[DuesPayments]
(
	[DuesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Messages_UserId]    Script Date: 9.07.2021 18:09:25 ******/
CREATE NONCLUSTERED INDEX [IX_Messages_UserId] ON [dbo].[Messages]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserOperationClaims_OperationClaimId]    Script Date: 9.07.2021 18:09:25 ******/
CREATE NONCLUSTERED INDEX [IX_UserOperationClaims_OperationClaimId] ON [dbo].[UserOperationClaims]
(
	[OperationClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserOperationClaims_UserId]    Script Date: 9.07.2021 18:09:25 ******/
CREATE NONCLUSTERED INDEX [IX_UserOperationClaims_UserId] ON [dbo].[UserOperationClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Apartments] ADD  DEFAULT (N'') FOR [Type]
GO
ALTER TABLE [dbo].[Apartments] ADD  DEFAULT (N'') FOR [Block]
GO
ALTER TABLE [dbo].[BillPayments] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Status]
GO
ALTER TABLE [dbo].[BillPayments] ADD  DEFAULT (N'') FOR [CardDocumentId]
GO
ALTER TABLE [dbo].[Bills] ADD  DEFAULT (N'') FOR [Type]
GO
ALTER TABLE [dbo].[DuesPayments] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Status]
GO
ALTER TABLE [dbo].[DuesPayments] ADD  DEFAULT (N'') FOR [CardDocumentId]
GO
ALTER TABLE [dbo].[Messages] ADD  DEFAULT (N'') FOR [Subject]
GO
ALTER TABLE [dbo].[Messages] ADD  DEFAULT (N'') FOR [Content]
GO
ALTER TABLE [dbo].[Apartments]  WITH CHECK ADD  CONSTRAINT [FK_Apartments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Apartments] CHECK CONSTRAINT [FK_Apartments_Users_UserId]
GO
ALTER TABLE [dbo].[BillPayments]  WITH CHECK ADD  CONSTRAINT [FK_BillPayments_Bills_BillId] FOREIGN KEY([BillId])
REFERENCES [dbo].[Bills] ([Id])
GO
ALTER TABLE [dbo].[BillPayments] CHECK CONSTRAINT [FK_BillPayments_Bills_BillId]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_Users_UserId]
GO
ALTER TABLE [dbo].[Dueses]  WITH CHECK ADD  CONSTRAINT [FK_Dueses_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Dueses] CHECK CONSTRAINT [FK_Dueses_Users_UserId]
GO
ALTER TABLE [dbo].[DuesPayments]  WITH CHECK ADD  CONSTRAINT [FK_DuesPayments_Dueses_DuesId] FOREIGN KEY([DuesId])
REFERENCES [dbo].[Dueses] ([Id])
GO
ALTER TABLE [dbo].[DuesPayments] CHECK CONSTRAINT [FK_DuesPayments_Dueses_DuesId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Users_UserId]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_OperationClaims_OperationClaimId] FOREIGN KEY([OperationClaimId])
REFERENCES [dbo].[OperationClaims] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_OperationClaims_OperationClaimId]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [ApsisDemo] SET  READ_WRITE 
GO
