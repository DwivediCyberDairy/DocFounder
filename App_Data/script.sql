USE [master]
GO
/****** Object:  Database [Demo_Project_DB]    Script Date: 2/24/2023 11:44:29 PM ******/
CREATE DATABASE [Demo_Project_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Demo_Project_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Demo_Project_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Demo_Project_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Demo_Project_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Demo_Project_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Demo_Project_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Demo_Project_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Demo_Project_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Demo_Project_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Demo_Project_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Demo_Project_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Demo_Project_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Demo_Project_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Demo_Project_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Demo_Project_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Demo_Project_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Demo_Project_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Demo_Project_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Demo_Project_DB] SET QUERY_STORE = OFF
GO
USE [Demo_Project_DB]
GO
/****** Object:  Table [dbo].[AreaMaster]    Script Date: 2/24/2023 11:44:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreaMaster](
	[Area_Id] [int] IDENTITY(1,1) NOT NULL,
	[Area_Name] [varchar](50) NULL,
	[Related_City_Id] [int] NULL,
 CONSTRAINT [PK_AreaMaster] PRIMARY KEY CLUSTERED 
(
	[Area_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CityMaster]    Script Date: 2/24/2023 11:44:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CityMaster](
	[City_Id] [int] IDENTITY(1,1) NOT NULL,
	[City_Name] [varchar](50) NULL,
 CONSTRAINT [PK_CityMaster] PRIMARY KEY CLUSTERED 
(
	[City_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnquiryMaster]    Script Date: 2/24/2023 11:44:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnquiryMaster](
	[Enquiry_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[EmailId] [varchar](120) NULL,
	[MobileNo] [varchar](20) NULL,
	[Enquiry_Message] [varchar](max) NULL,
	[Enquiry_DateTime] [datetime] NULL,
 CONSTRAINT [PK_EnquiryMaster] PRIMARY KEY CLUSTERED 
(
	[Enquiry_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackMaster]    Script Date: 2/24/2023 11:44:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackMaster](
	[Feedback_Id] [int] IDENTITY(1,1) NOT NULL,
	[Submitted_By] [varchar](120) NULL,
	[Topic] [varchar](150) NULL,
	[Star_Rating] [int] NULL,
	[Message] [varchar](max) NULL,
	[Submitted_On] [datetime] NULL,
 CONSTRAINT [PK_FeedbackMaster] PRIMARY KEY CLUSTERED 
(
	[Feedback_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginMaster]    Script Date: 2/24/2023 11:44:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginMaster](
	[UserId] [varchar](120) NOT NULL,
	[User_Password] [varchar](250) NULL,
	[User_Type] [varchar](20) NULL,
	[User_Status] [bit] NULL,
	[Login_Count] [int] NULL,
	[Last_Login_DateTime] [datetime] NULL,
 CONSTRAINT [PK_LoginMaster] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UploadManager]    Script Date: 2/24/2023 11:44:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UploadManager](
	[Upload_Id] [int] IDENTITY(1,1) NOT NULL,
	[Title_of_File] [varchar](150) NULL,
	[Description] [varchar](500) NULL,
	[Uploaded_BY] [varchar](120) NULL,
	[File_Name] [varchar](200) NULL,
	[Folder_Name] [varchar](40) NULL,
	[File_Type] [varchar](10) NULL,
	[File_Size_In_KB] [float] NULL,
	[Upload_DT] [datetime] NULL,
	[Is_Del] [bit] NULL,
 CONSTRAINT [PK_UploadManager] PRIMARY KEY CLUSTERED 
(
	[Upload_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 2/24/2023 11:44:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[Name] [varchar](70) NULL,
	[Gender] [varchar](10) NULL,
	[EmailId] [varchar](120) NOT NULL,
	[MobileNo] [varchar](20) NULL,
	[Related_City_Id] [int] NULL,
	[Related_Area_Id] [int] NULL,
	[Address] [varchar](max) NULL,
	[Picture_File_Name] [varchar](250) NULL,
	[DateTime_of_Reg] [datetime] NULL,
	[Is_Del] [bit] NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AreaMaster] ON 

INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (1, N'Sitapur', 1)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (2, N'Kalukuwan', 2)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (3, N'Bedipuliya', 1)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (4, N'Karwi', 1)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (5, N'Jankikund', 3)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (6, N'Gupt Godawari', 3)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (7, N'Nayagaon', 3)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (8, N'Rajapur', 1)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (9, N'Atrra', 2)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (10, N'Tindwari', 2)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (11, N'Badausha', 2)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (12, N'Chitra', 1)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (13, N'Ramghat', 1)
INSERT [dbo].[AreaMaster] ([Area_Id], [Area_Name], [Related_City_Id]) VALUES (14, N'Rajendra Nagar', 3)
SET IDENTITY_INSERT [dbo].[AreaMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[CityMaster] ON 

INSERT [dbo].[CityMaster] ([City_Id], [City_Name]) VALUES (1, N'Chitrakoot')
INSERT [dbo].[CityMaster] ([City_Id], [City_Name]) VALUES (2, N'Banda')
INSERT [dbo].[CityMaster] ([City_Id], [City_Name]) VALUES (3, N'Satna')
SET IDENTITY_INSERT [dbo].[CityMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[FeedbackMaster] ON 

INSERT [dbo].[FeedbackMaster] ([Feedback_Id], [Submitted_By], [Topic], [Star_Rating], [Message], [Submitted_On]) VALUES (1, N'neha@gmail.com', NULL, NULL, NULL, CAST(N'2023-01-19T19:51:27.623' AS DateTime))
SET IDENTITY_INSERT [dbo].[FeedbackMaster] OFF
GO
INSERT [dbo].[LoginMaster] ([UserId], [User_Password], [User_Type], [User_Status], [Login_Count], [Last_Login_DateTime]) VALUES (N'erakashrathaur9554@gmail.com', N'876@sFMRGZ', N'USER', 1, 7, CAST(N'2023-01-10T19:35:59.410' AS DateTime))
INSERT [dbo].[LoginMaster] ([UserId], [User_Password], [User_Type], [User_Status], [Login_Count], [Last_Login_DateTime]) VALUES (N'garima@gmail.com', N'123', N'USER', 1, 1, CAST(N'2023-01-18T16:55:14.607' AS DateTime))
INSERT [dbo].[LoginMaster] ([UserId], [User_Password], [User_Type], [User_Status], [Login_Count], [Last_Login_DateTime]) VALUES (N'neeraj@gmail.com', N'123@Neeraj', N'USER', 1, 0, NULL)
INSERT [dbo].[LoginMaster] ([UserId], [User_Password], [User_Type], [User_Status], [Login_Count], [Last_Login_DateTime]) VALUES (N'neha@gmail.com', N'123', N'USER', 1, 8, CAST(N'2023-01-20T19:19:27.943' AS DateTime))
INSERT [dbo].[LoginMaster] ([UserId], [User_Password], [User_Type], [User_Status], [Login_Count], [Last_Login_DateTime]) VALUES (N'rathore9554@gmail.com', N'876@aPZHS', N'USER', 1, 1, CAST(N'2023-01-10T19:50:22.373' AS DateTime))
INSERT [dbo].[LoginMaster] ([UserId], [User_Password], [User_Type], [User_Status], [Login_Count], [Last_Login_DateTime]) VALUES (N'shreyaa06singh@gmail.com', N'123@Shreya', N'USER', 1, 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[UploadManager] ON 

INSERT [dbo].[UploadManager] ([Upload_Id], [Title_of_File], [Description], [Uploaded_BY], [File_Name], [Folder_Name], [File_Type], [File_Size_In_KB], [Upload_DT], [Is_Del]) VALUES (1, N'Test File', NULL, N'erakashrathaur9554@gmail.com', N'wh1f4nly.jyu_10_01_YY__06_59_51SRS For E-StudyCorner (2).docx', N'Students Uploaded Assignments', N'.DOCX', 422, CAST(N'2023-01-10T18:59:51.627' AS DateTime), 0)
INSERT [dbo].[UploadManager] ([Upload_Id], [Title_of_File], [Description], [Uploaded_BY], [File_Name], [Folder_Name], [File_Type], [File_Size_In_KB], [Upload_DT], [Is_Del]) VALUES (2, N'Test File', N'Assignment of C notes', N'erakashrathaur9554@gmail.com', N'cpn3nxam.loz_10_01_YY__07_04_16AMIT''s Resume.docx', N'Students Uploaded Assignments', N'.DOCX', 97, CAST(N'2023-01-10T19:04:16.837' AS DateTime), 0)
INSERT [dbo].[UploadManager] ([Upload_Id], [Title_of_File], [Description], [Uploaded_BY], [File_Name], [Folder_Name], [File_Type], [File_Size_In_KB], [Upload_DT], [Is_Del]) VALUES (3, N'Result of C Language', N'All Student Restult of C File', N'erakashrathaur9554@gmail.com', N'bkxgyuuv.lnc_10_01_YY__07_37_11filetrackerlogo.png', N'Students Uploaded Assignments', N'.PNG', 57, CAST(N'2023-01-10T19:37:11.200' AS DateTime), 0)
INSERT [dbo].[UploadManager] ([Upload_Id], [Title_of_File], [Description], [Uploaded_BY], [File_Name], [Folder_Name], [File_Type], [File_Size_In_KB], [Upload_DT], [Is_Del]) VALUES (4, N'Test File', N'adfafsf', N'rathore9554@gmail.com', N'rzj0pv4h.cvl_10_01_YY__07_55_59sli3.jpg', N'Students Uploaded Assignments', N'.JPG', 8, CAST(N'2023-01-10T19:55:59.140' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[UploadManager] OFF
GO
INSERT [dbo].[UserMaster] ([Name], [Gender], [EmailId], [MobileNo], [Related_City_Id], [Related_Area_Id], [Address], [Picture_File_Name], [DateTime_of_Reg], [Is_Del]) VALUES (N'Sunita Devi', N'Female', N'erakashrathaur9554@gmail.com', N'7752833051', 3, 6, N'Tikri', N'4nfkck3y.pwq_07_01_YY__07_24_21img.png', CAST(N'2023-01-07T19:24:21.583' AS DateTime), 0)
INSERT [dbo].[UserMaster] ([Name], [Gender], [EmailId], [MobileNo], [Related_City_Id], [Related_Area_Id], [Address], [Picture_File_Name], [DateTime_of_Reg], [Is_Del]) VALUES (N'Akash Rathaur', N'Male', N'garima@gmail.com', N'9554506076', 1, 1, N'konch', N'aquguveg.yot_07_01_YY__05_29_27img.png', CAST(N'2023-01-07T17:29:27.100' AS DateTime), 0)
INSERT [dbo].[UserMaster] ([Name], [Gender], [EmailId], [MobileNo], [Related_City_Id], [Related_Area_Id], [Address], [Picture_File_Name], [DateTime_of_Reg], [Is_Del]) VALUES (N'Neeraj Rathaur', N'Male', N'neeraj@gmail.com', N'7752833051', 1, 1, N'495, Jay Prakash Nagar Konch Jalaun Uttar Pradesh Inida Pin-Code 285205', N'k25w4zta.mbp_05_01_YY__11_30_38NNNNN.jpg', CAST(N'2023-01-05T23:30:38.560' AS DateTime), 0)
INSERT [dbo].[UserMaster] ([Name], [Gender], [EmailId], [MobileNo], [Related_City_Id], [Related_Area_Id], [Address], [Picture_File_Name], [DateTime_of_Reg], [Is_Del]) VALUES (N'Neha Rathaur', N'Female', N'neha@gmail.com', N'8909878903', 2, 9, N'jalaun', N'tkjux3ra.hkk_06_01_YY__04_24_14Screenshot_2022-04-04-18-48-44-455_com.google.android.gm.jpg', CAST(N'2023-01-06T16:24:14.177' AS DateTime), 0)
INSERT [dbo].[UserMaster] ([Name], [Gender], [EmailId], [MobileNo], [Related_City_Id], [Related_Area_Id], [Address], [Picture_File_Name], [DateTime_of_Reg], [Is_Del]) VALUES (N'Reena Yadav', N'Female', N'rathore9554@gmail.com', N'9876545678', 1, 1, N'konch', NULL, CAST(N'2023-01-10T19:48:41.200' AS DateTime), 0)
INSERT [dbo].[UserMaster] ([Name], [Gender], [EmailId], [MobileNo], [Related_City_Id], [Related_Area_Id], [Address], [Picture_File_Name], [DateTime_of_Reg], [Is_Del]) VALUES (N'Shreya Singh', N'Female', N'shreyaa06singh@gmail.com', N'9919461842', 1, 1, N'Katharia Post Katharia Ballia Uttar Pradesh Pin-Code 221713', N'pi2t0nwe.pmg_05_01_YY__11_41_50IMG_20220507_125620.jpg', CAST(N'2023-01-05T23:41:50.870' AS DateTime), 0)
GO
ALTER TABLE [dbo].[AreaMaster]  WITH CHECK ADD  CONSTRAINT [FK_AreaMaster_CityMaster] FOREIGN KEY([Related_City_Id])
REFERENCES [dbo].[CityMaster] ([City_Id])
GO
ALTER TABLE [dbo].[AreaMaster] CHECK CONSTRAINT [FK_AreaMaster_CityMaster]
GO
ALTER TABLE [dbo].[FeedbackMaster]  WITH CHECK ADD  CONSTRAINT [FK_FeedbackMaster_UserMaster] FOREIGN KEY([Submitted_By])
REFERENCES [dbo].[UserMaster] ([EmailId])
GO
ALTER TABLE [dbo].[FeedbackMaster] CHECK CONSTRAINT [FK_FeedbackMaster_UserMaster]
GO
ALTER TABLE [dbo].[UploadManager]  WITH CHECK ADD  CONSTRAINT [FK_UploadManager_UserMaster] FOREIGN KEY([Uploaded_BY])
REFERENCES [dbo].[UserMaster] ([EmailId])
GO
ALTER TABLE [dbo].[UploadManager] CHECK CONSTRAINT [FK_UploadManager_UserMaster]
GO
ALTER TABLE [dbo].[UserMaster]  WITH CHECK ADD  CONSTRAINT [FK_UserMaster_AreaMaster] FOREIGN KEY([Related_Area_Id])
REFERENCES [dbo].[AreaMaster] ([Area_Id])
GO
ALTER TABLE [dbo].[UserMaster] CHECK CONSTRAINT [FK_UserMaster_AreaMaster]
GO
ALTER TABLE [dbo].[UserMaster]  WITH CHECK ADD  CONSTRAINT [FK_UserMaster_CityMaster] FOREIGN KEY([Related_City_Id])
REFERENCES [dbo].[CityMaster] ([City_Id])
GO
ALTER TABLE [dbo].[UserMaster] CHECK CONSTRAINT [FK_UserMaster_CityMaster]
GO
USE [master]
GO
ALTER DATABASE [Demo_Project_DB] SET  READ_WRITE 
GO
