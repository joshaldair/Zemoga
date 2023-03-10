USE [master]
GO
/****** Object:  Database [zemoga]    Script Date: 9/02/2023 10:05:13 a. m. ******/
CREATE DATABASE [zemoga]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'zemoga', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\zemoga.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'zemoga_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\zemoga_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [zemoga] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [zemoga].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [zemoga] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [zemoga] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [zemoga] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [zemoga] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [zemoga] SET ARITHABORT OFF 
GO
ALTER DATABASE [zemoga] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [zemoga] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [zemoga] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [zemoga] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [zemoga] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [zemoga] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [zemoga] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [zemoga] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [zemoga] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [zemoga] SET  DISABLE_BROKER 
GO
ALTER DATABASE [zemoga] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [zemoga] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [zemoga] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [zemoga] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [zemoga] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [zemoga] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [zemoga] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [zemoga] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [zemoga] SET  MULTI_USER 
GO
ALTER DATABASE [zemoga] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [zemoga] SET DB_CHAINING OFF 
GO
ALTER DATABASE [zemoga] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [zemoga] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [zemoga] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [zemoga] SET QUERY_STORE = OFF
GO
USE [zemoga]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/02/2023 10:05:13 a. m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 9/02/2023 10:05:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 9/02/2023 10:05:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [text] NOT NULL,
	[PostID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 9/02/2023 10:05:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [text] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsApproved] [bit] NOT NULL,
	[IsPending] [bit] NOT NULL,
	[IsBlocked] [bit] NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 9/02/2023 10:05:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/02/2023 10:05:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ProfileId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230207144442_GenerateTables', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230208040106_GenerateTables1', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230208221144_GenerateTables2', N'6.0.0')
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (1, N'string', CAST(N'2023-02-07T20:14:52.3899516' AS DateTime2), N'system', CAST(N'2023-02-08T17:48:21.5268436' AS DateTime2), N'system', 0)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (2, N'Daddy Yankee', CAST(N'2023-02-07T22:49:34.0234357' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (3, N'Madonna', CAST(N'2023-02-07T22:50:07.0911848' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (4, N'Blink 182', CAST(N'2023-02-07T22:50:12.6881895' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (5, N'Don Omar', CAST(N'2023-02-07T22:50:19.9523232' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (6, N'Karol G', CAST(N'2023-02-07T22:50:29.4594981' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (7, N'Batman', CAST(N'2023-02-07T22:50:34.2924798' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (8, N'Superman', CAST(N'2023-02-07T22:50:38.1094648' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (9, N'Ironman', CAST(N'2023-02-07T22:50:44.7579880' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (10, N'Megaman', CAST(N'2023-02-07T22:50:51.0661622' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (11, N'Xborg', CAST(N'2023-02-07T22:50:56.6510538' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (12, N'Kadita', CAST(N'2023-02-07T22:51:00.0809927' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (13, N'Hayabusa', CAST(N'2023-02-07T22:51:05.3695690' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (14, N'Sobusa', CAST(N'2023-02-07T22:51:09.5700158' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (15, N'Embusa', CAST(N'2023-02-07T22:51:13.0066849' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (16, N'Pantera verde', CAST(N'2023-02-07T22:51:39.1932063' AS DateTime2), N'system', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Authors] OFF
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [Description], [PostID], [UserID], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (5, N'Awesome', 3, 4, CAST(N'2023-02-08T18:15:36.7940680' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Comments] ([Id], [Description], [PostID], [UserID], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (6, N'Congrats', 3, 5, CAST(N'2023-02-08T18:16:51.1421099' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Comments] ([Id], [Description], [PostID], [UserID], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (7, N'Congrats', 4, 5, CAST(N'2023-02-08T18:16:56.1669404' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Comments] ([Id], [Description], [PostID], [UserID], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (8, N'Excelent nice work', 4, 1, CAST(N'2023-02-08T18:17:16.0877450' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Comments] ([Id], [Description], [PostID], [UserID], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (9, N'No Bad', 4, 6, CAST(N'2023-02-08T18:17:37.3035869' AS DateTime2), N'system', NULL, NULL, 1)
INSERT [dbo].[Comments] ([Id], [Description], [PostID], [UserID], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (10, N'TestTest', 4, 6, CAST(N'2023-02-08T18:18:18.6600089' AS DateTime2), N'system', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Description], [Title], [AuthorId], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive], [IsApproved], [IsPending], [IsBlocked]) VALUES (3, N'La vaca y el pollito', N'Felices por siempre', 3, CAST(N'2023-02-08T08:39:40.0247682' AS DateTime2), N'system', CAST(N'2023-02-08T17:14:48.7714737' AS DateTime2), N'system', 1, 1, 0, 0)
INSERT [dbo].[Posts] ([Id], [Description], [Title], [AuthorId], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive], [IsApproved], [IsPending], [IsBlocked]) VALUES (4, N'string', N'string', 3, CAST(N'2023-02-08T08:44:00.5036839' AS DateTime2), N'system', CAST(N'2023-02-08T17:07:17.1837167' AS DateTime2), N'system', 0, 0, 0, 1)
INSERT [dbo].[Posts] ([Id], [Description], [Title], [AuthorId], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive], [IsApproved], [IsPending], [IsBlocked]) VALUES (5, N'GIlete Peligroso', N'ALgo de MArvel', 10, CAST(N'2023-02-08T08:44:00.5036839' AS DateTime2), N'system', NULL, NULL, 1, 1, 0, 0)
SET IDENTITY_INSERT [dbo].[Posts] OFF
SET IDENTITY_INSERT [dbo].[Profiles] ON 

INSERT [dbo].[Profiles] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (1, N'Editor', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Profiles] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (2, N'Writer', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Profiles] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (3, N'Admin', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Profiles] ([Id], [name], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (4, N'Public', NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Profiles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [Password], [ProfileId], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (1, N'developer', N'cRDtpNCeBiql5KOQsKVyrA0sAiA=', 3, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [ProfileId], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (4, N'escritor', N'cRDtpNCeBiql5KOQsKVyrA0sAiA=', 2, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [ProfileId], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (5, N'supervisor', N'cRDtpNCeBiql5KOQsKVyrA0sAiA=', 1, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [ProfileId], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [IsActive]) VALUES (6, N'publico', N'cRDtpNCeBiql5KOQsKVyrA0sAiA=', 4, NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Index [IX_Comments_PostID]    Script Date: 9/02/2023 10:05:13 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Comments_PostID] ON [dbo].[Comments]
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_UserID]    Script Date: 9/02/2023 10:05:13 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Comments_UserID] ON [dbo].[Comments]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Posts_AuthorId]    Script Date: 9/02/2023 10:05:13 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Posts_AuthorId] ON [dbo].[Posts]
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_ProfileId]    Script Date: 9/02/2023 10:05:13 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Users_ProfileId] ON [dbo].[Users]
(
	[ProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Posts] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsApproved]
GO
ALTER TABLE [dbo].[Posts] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsPending]
GO
ALTER TABLE [dbo].[Posts] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsBlocked]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Post_Comment] FOREIGN KEY([PostID])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Post_Comment]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_User1_Comment] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_User1_Comment]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Post_Author] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Post_Author]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Profile] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Profile]
GO
USE [master]
GO
ALTER DATABASE [zemoga] SET  READ_WRITE 
GO
