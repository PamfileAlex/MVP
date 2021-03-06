USE [master]
GO
/****** Object:  Database [SchoolPlatform]    Script Date: 05/27/2021 10:03:16 PM ******/
CREATE DATABASE [SchoolPlatform]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SchoolPlatform', FILENAME = N'D:\ProgramFiles\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SchoolPlatform.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SchoolPlatform_log', FILENAME = N'D:\ProgramFiles\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SchoolPlatform_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SchoolPlatform] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SchoolPlatform].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SchoolPlatform] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SchoolPlatform] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SchoolPlatform] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SchoolPlatform] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SchoolPlatform] SET ARITHABORT OFF 
GO
ALTER DATABASE [SchoolPlatform] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SchoolPlatform] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SchoolPlatform] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SchoolPlatform] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SchoolPlatform] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SchoolPlatform] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SchoolPlatform] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SchoolPlatform] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SchoolPlatform] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SchoolPlatform] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SchoolPlatform] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SchoolPlatform] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SchoolPlatform] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SchoolPlatform] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SchoolPlatform] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SchoolPlatform] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SchoolPlatform] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SchoolPlatform] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SchoolPlatform] SET  MULTI_USER 
GO
ALTER DATABASE [SchoolPlatform] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SchoolPlatform] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SchoolPlatform] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SchoolPlatform] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SchoolPlatform] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SchoolPlatform] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SchoolPlatform] SET QUERY_STORE = OFF
GO
USE [SchoolPlatform]
GO
/****** Object:  Table [dbo].[Absence]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absence](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentSubjectID] [int] NOT NULL,
	[Semester] [bit] NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_Absence] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SpecializationID] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Year] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinalGrade]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinalGrade](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentSubjectID] [int] NOT NULL,
	[Semester] [bit] NOT NULL,
	[Value] [real] NOT NULL,
 CONSTRAINT [PK_FinalGrade] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentSubjectID] [int] NOT NULL,
	[Semester] [bit] NOT NULL,
	[Value] [real] NOT NULL,
	[Thesis] [bit] NOT NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialization]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Specialization] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentSubject]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSubject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
 CONSTRAINT [PK_StudentSubject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectSpecialization]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectSpecialization](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NOT NULL,
	[SpecializationID] [int] NOT NULL,
	[Thesis] [bit] NOT NULL,
 CONSTRAINT [PK_SubjectSpecialization] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherSubjectClass]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherSubjectClass](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
 CONSTRAINT [PK_TeacherSubjectClass] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeachingMaterial]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeachingMaterial](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherSubjectClassID] [int] NOT NULL,
	[Semester] [bit] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Path] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TeachingMaterial] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[Role] [int] NOT NULL,
	[ClassID] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Absence] ON 

INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1014, 2023, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1015, 2023, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1016, 2023, 0, 3)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1017, 2025, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1018, 2025, 0, 1)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1019, 2025, 1, 1)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1020, 2024, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1021, 2024, 1, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1022, 2026, 0, 1)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1023, 2026, 1, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1024, 2026, 1, 1)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1025, 2045, 0, 3)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1026, 2045, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1027, 2045, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1028, 2045, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1029, 2045, 1, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1030, 2045, 1, 1)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1031, 2024, 1, 1)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1032, 2024, 0, 1)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1033, 2024, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1034, 2029, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1035, 2029, 0, 3)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1036, 2030, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1037, 2030, 0, 1)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1038, 2030, 1, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1039, 2025, 1, 1)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1040, 2023, 1, 1)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1041, 2055, 0, 1)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1042, 2055, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1043, 2055, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1044, 2055, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1045, 2060, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1046, 2060, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1047, 2060, 0, 2)
INSERT [dbo].[Absence] ([ID], [StudentSubjectID], [Semester], [Type]) VALUES (1048, 2060, 0, 3)
SET IDENTITY_INSERT [dbo].[Absence] OFF
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([ID], [SpecializationID], [Name], [Year]) VALUES (3, 1, N'12 A', N'2020-2021')
INSERT [dbo].[Class] ([ID], [SpecializationID], [Name], [Year]) VALUES (6, 4, N'12 B', N'2020-2021')
INSERT [dbo].[Class] ([ID], [SpecializationID], [Name], [Year]) VALUES (7, 7, N'12 C', N'2020-2021')
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[FinalGrade] ON 

INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1002, 2021, 0, 9.67)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1003, 2021, 1, 8.33)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1004, 2022, 0, 7.67)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1005, 2022, 1, 7.67)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1006, 2043, 0, 3)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1007, 2043, 1, 4)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1008, 2023, 0, 8)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1009, 2023, 1, 8.33)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1010, 2024, 1, 8.67)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1011, 2024, 0, 6.33)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1012, 2029, 0, 8.83)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1013, 2025, 0, 10)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1014, 2025, 1, 9)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1015, 2030, 0, 9.17)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1016, 2045, 0, 4.33)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1017, 2045, 1, 4.33)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1018, 2041, 0, 8)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1019, 2041, 1, 7.33)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1020, 2044, 1, 9.67)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1021, 2044, 0, 9.33)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1022, 2050, 0, 5)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1023, 2050, 1, 2.83)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1024, 2063, 1, 4)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1025, 2063, 0, 4.33)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1026, 2046, 0, 3.33)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1027, 2046, 1, 3.83)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1028, 2055, 0, 4.33)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1029, 2055, 1, 3.67)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1030, 2047, 1, 10)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1031, 2047, 0, 9.83)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1032, 2071, 0, 7.67)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1033, 2072, 0, 6.5)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1034, 2074, 0, 7.88)
INSERT [dbo].[FinalGrade] ([ID], [StudentSubjectID], [Semester], [Value]) VALUES (1035, 2075, 0, 8.67)
SET IDENTITY_INSERT [dbo].[FinalGrade] OFF
GO
SET IDENTITY_INSERT [dbo].[Grade] ON 

INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1004, 2021, 0, 9, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1005, 2021, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1006, 2021, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1007, 2021, 1, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1008, 2021, 1, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1009, 2021, 1, 7, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1010, 2022, 0, 6, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1011, 2022, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1012, 2022, 0, 9, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1013, 2022, 1, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1014, 2022, 1, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1015, 2022, 1, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1016, 2043, 0, 3, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1017, 2043, 0, 2, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1018, 2043, 0, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1019, 2043, 1, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1020, 2043, 1, 3, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1021, 2043, 1, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1022, 2023, 0, 7, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1023, 2023, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1024, 2023, 0, 9, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1025, 2023, 1, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1026, 2023, 1, 7, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1027, 2023, 1, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1028, 2024, 1, 7, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1029, 2024, 1, 9, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1030, 2024, 1, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1031, 2024, 0, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1032, 2024, 0, 7, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1033, 2024, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1034, 2029, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1035, 2029, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1036, 2029, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1037, 2029, 0, 9, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1038, 2025, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1039, 2025, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1040, 2025, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1041, 2025, 1, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1042, 2025, 1, 9, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1043, 2025, 1, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1044, 2030, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1045, 2030, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1046, 2030, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1047, 2030, 0, 9, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1048, 2045, 0, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1049, 2045, 0, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1050, 2045, 0, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1051, 2045, 1, 3, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1052, 2045, 1, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1053, 2045, 1, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1054, 2041, 0, 6, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1055, 2041, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1056, 2041, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1057, 2041, 1, 7, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1058, 2041, 1, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1059, 2041, 1, 7, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1060, 2044, 1, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1061, 2044, 1, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1062, 2044, 1, 9, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1063, 2044, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1064, 2044, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1065, 2044, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1066, 2050, 0, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1067, 2050, 0, 3, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1068, 2050, 0, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1069, 2050, 0, 6, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1070, 2050, 1, 2, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1071, 2050, 1, 3, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1072, 2050, 1, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1073, 2050, 1, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1074, 2063, 0, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1075, 2063, 0, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1076, 2063, 0, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1077, 2063, 0, 4, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1078, 2063, 1, 3, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1079, 2063, 1, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1080, 2063, 1, 6, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1081, 2063, 1, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1082, 2046, 0, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1083, 2046, 0, 3, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1084, 2046, 0, 3, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1085, 2046, 0, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1086, 2046, 1, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1087, 2046, 1, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1088, 2046, 1, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1089, 2046, 1, 3, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1090, 2055, 0, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1091, 2055, 0, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1092, 2055, 0, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1093, 2055, 1, 6, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1094, 2055, 1, 3, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1095, 2055, 1, 2, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1096, 2047, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1097, 2047, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1098, 2047, 0, 9, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1099, 2047, 0, 10, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1100, 2047, 1, 10, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1101, 2047, 1, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1102, 2047, 1, 10, 0)
GO
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1103, 2047, 1, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1104, 2071, 0, 10, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1105, 2071, 0, 7, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1106, 2071, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1107, 2071, 0, 7, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1108, 2072, 0, 6, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1109, 2072, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1110, 2072, 0, 4, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1111, 2072, 0, 9, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1112, 2074, 0, 6, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1113, 2074, 0, 9, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1114, 2074, 0, 5, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1115, 2074, 0, 3, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1116, 2074, 0, 10, 1)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1117, 2075, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1118, 2075, 0, 9, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1119, 2075, 0, 8, 0)
INSERT [dbo].[Grade] ([ID], [StudentSubjectID], [Semester], [Value], [Thesis]) VALUES (1120, 2075, 0, 9, 1)
SET IDENTITY_INSERT [dbo].[Grade] OFF
GO
SET IDENTITY_INSERT [dbo].[Specialization] ON 

INSERT [dbo].[Specialization] ([ID], [Name]) VALUES (1, N'Mate-Info')
INSERT [dbo].[Specialization] ([ID], [Name]) VALUES (4, N'Stiintele Naturii')
INSERT [dbo].[Specialization] ([ID], [Name]) VALUES (5, N'Filologie')
INSERT [dbo].[Specialization] ([ID], [Name]) VALUES (6, N'Protectia Mediului')
INSERT [dbo].[Specialization] ([ID], [Name]) VALUES (7, N'Stiinte Sociale')
INSERT [dbo].[Specialization] ([ID], [Name]) VALUES (8, N'Pedagogic')
INSERT [dbo].[Specialization] ([ID], [Name]) VALUES (9, N'Sportiv')
INSERT [dbo].[Specialization] ([ID], [Name]) VALUES (10, N'Arte')
SET IDENTITY_INSERT [dbo].[Specialization] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentSubject] ON 

INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2021, 15, 4)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2022, 1015, 4)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2023, 1016, 4)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2024, 1017, 4)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2025, 1018, 4)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2026, 15, 6)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2027, 1015, 6)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2028, 1016, 6)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2029, 1017, 6)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2030, 1018, 6)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2031, 15, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2032, 1015, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2033, 1016, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2034, 1017, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2035, 1018, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2036, 15, 10)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2037, 1015, 10)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2038, 1016, 10)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2039, 1017, 10)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2040, 1018, 10)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2041, 1011, 6)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2042, 1013, 6)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2043, 1019, 6)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2044, 1020, 6)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2045, 1021, 6)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2046, 1011, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2047, 1013, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2048, 1019, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2049, 1020, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2050, 1021, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2051, 1011, 11)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2052, 1013, 11)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2053, 1019, 11)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2054, 1020, 11)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2055, 1021, 11)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2056, 1011, 12)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2057, 1013, 12)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2058, 1019, 12)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2059, 1020, 12)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2060, 1021, 12)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2061, 1012, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2062, 1014, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2063, 1022, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2064, 1023, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2065, 1024, 3)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2066, 1012, 9)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2067, 1014, 9)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2068, 1022, 9)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2069, 1023, 9)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2070, 1024, 9)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2071, 1012, 13)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2072, 1014, 13)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2073, 1022, 13)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2074, 1023, 13)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2075, 1024, 13)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2076, 1012, 18)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2077, 1014, 18)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2078, 1022, 18)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2079, 1023, 18)
INSERT [dbo].[StudentSubject] ([ID], [StudentID], [SubjectID]) VALUES (2080, 1024, 18)
SET IDENTITY_INSERT [dbo].[StudentSubject] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([ID], [Name]) VALUES (3, N'Romana')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (4, N'Informatica')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (6, N'Matematica')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (9, N'Engleza')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (10, N'Fizica')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (11, N'Chimie')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (12, N'Biologie')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (13, N'Istorie')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (14, N'Geografie')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (15, N'Germana')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (16, N'Franceza')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (17, N'Sport')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (18, N'Filosofie')
INSERT [dbo].[Subject] ([ID], [Name]) VALUES (19, N'Religie')
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[SubjectSpecialization] ON 

INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2004, 4, 1, 0)
INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2005, 6, 1, 1)
INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2006, 3, 1, 1)
INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2007, 10, 1, 0)
INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2008, 6, 4, 0)
INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2009, 3, 4, 1)
INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2010, 11, 4, 0)
INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2011, 12, 4, 1)
INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2012, 3, 7, 1)
INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2013, 9, 7, 0)
INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2014, 13, 7, 1)
INSERT [dbo].[SubjectSpecialization] ([ID], [SubjectID], [SpecializationID], [Thesis]) VALUES (2015, 18, 7, 0)
SET IDENTITY_INSERT [dbo].[SubjectSpecialization] OFF
GO
SET IDENTITY_INSERT [dbo].[TeacherSubjectClass] ON 

INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2015, 14, 4, 3)
INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2016, 14, 6, 3)
INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2017, 14, 6, 6)
INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2018, 1010, 10, 3)
INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2019, 1010, 13, 7)
INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2021, 1010, 9, 7)
INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2022, 1025, 3, 3)
INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2023, 1025, 3, 6)
INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2024, 1025, 3, 7)
INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2025, 1025, 18, 7)
INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2026, 1026, 11, 6)
INSERT [dbo].[TeacherSubjectClass] ([ID], [TeacherID], [SubjectID], [ClassID]) VALUES (2027, 1026, 12, 6)
SET IDENTITY_INSERT [dbo].[TeacherSubjectClass] OFF
GO
SET IDENTITY_INSERT [dbo].[TeachingMaterial] ON 

INSERT [dbo].[TeachingMaterial] ([ID], [TeacherSubjectClassID], [Semester], [Name], [Path]) VALUES (1002, 2015, 0, N'Test', N'C:\Users\Alex\Documents\PamfileAlex.pdf')
INSERT [dbo].[TeachingMaterial] ([ID], [TeacherSubjectClassID], [Semester], [Name], [Path]) VALUES (1003, 2018, 0, N'Tema1', N'D:\School\Facultate\Anul II Sem 2\MVP\Teme\Tema1.p')
INSERT [dbo].[TeachingMaterial] ([ID], [TeacherSubjectClassID], [Semester], [Name], [Path]) VALUES (1004, 2018, 1, N'Tema2', N'D:\School\Facultate\Anul II Sem 2\MVP\Teme\Tema2.p')
SET IDENTITY_INSERT [dbo].[TeachingMaterial] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1, N'Admin', N'Admin', N'admin@admin', N'admin', 1, NULL)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (14, N'Marin', N'Marin', N'marin@professor.ro', N'professor', 2, NULL)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (15, N'Andrei', N'Ion', N'andrei@student.ro', N'student', 3, 3)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1010, N'Grigore', N'Vasile', N'grigore@professor.ro', N'professor', 2, 3)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1011, N'Gheorghe', N'Creanga', N'creanga@student.ro', N'student', 3, 6)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1012, N'Flavius', N'Jean', N'jean@student.ro', N'student', 3, 7)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1013, N'Delia', N'Campeanu', N'campeanu@student.ro', N'student', 3, 6)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1014, N'Andreea', N'Iliescu', N'iliescu@student.ro', N'student', 3, 7)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1015, N'Dan', N'Enache', N'enache@student.ro', N'student', 3, 3)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1016, N'Raul', N'Petre', N'petre@student.ro', N'student', 3, 3)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1017, N'Sebastian', N'Vulpe', N'vuple@student.ro', N'student', 3, 3)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1018, N'Alexandra', N'Stanciu', N'stanciu@student.ro', N'student', 3, 3)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1019, N'Tudor', N'Ghideanu', N'ghideanu@student.ro', N'student', 3, 6)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1020, N'Georgiana', N'Pavel', N'pavel@student.ro', N'student', 3, 6)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1021, N'Robert', N'Lacatus', N'lacatus@student.ro', N'student', 3, 6)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1022, N'Ionel', N'Necula', N'necula@student.ro', N'student', 3, 7)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1023, N'Teodora', N'Nistor', N'nistor@student.ro', N'student', 3, 7)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1024, N'Roxana', N'Petrescu', N'petrescu@student.ro', N'student', 3, 7)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1025, N'Darius', N'Plesan', N'plesan@professor.ro', N'professor', 2, 6)
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Email], [Password], [Role], [ClassID]) VALUES (1026, N'Emanuel', N'Paler', N'paler@professor.ro', N'professor', 2, 7)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Absence]  WITH CHECK ADD  CONSTRAINT [FK_Absence_StudentSubject] FOREIGN KEY([StudentSubjectID])
REFERENCES [dbo].[StudentSubject] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Absence] CHECK CONSTRAINT [FK_Absence_StudentSubject]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Specialization] FOREIGN KEY([SpecializationID])
REFERENCES [dbo].[Specialization] ([ID])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Specialization]
GO
ALTER TABLE [dbo].[FinalGrade]  WITH CHECK ADD  CONSTRAINT [FK_FinalGrade_StudentSubject] FOREIGN KEY([StudentSubjectID])
REFERENCES [dbo].[StudentSubject] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FinalGrade] CHECK CONSTRAINT [FK_FinalGrade_StudentSubject]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK_Grade_StudentSubject] FOREIGN KEY([StudentSubjectID])
REFERENCES [dbo].[StudentSubject] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK_Grade_StudentSubject]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_Subject]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_User] FOREIGN KEY([StudentID])
REFERENCES [dbo].[User] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_User]
GO
ALTER TABLE [dbo].[SubjectSpecialization]  WITH CHECK ADD  CONSTRAINT [FK_SubjectSpecialization_Specialization] FOREIGN KEY([SpecializationID])
REFERENCES [dbo].[Specialization] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectSpecialization] CHECK CONSTRAINT [FK_SubjectSpecialization_Specialization]
GO
ALTER TABLE [dbo].[SubjectSpecialization]  WITH CHECK ADD  CONSTRAINT [FK_SubjectSpecialization_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectSpecialization] CHECK CONSTRAINT [FK_SubjectSpecialization_Subject]
GO
ALTER TABLE [dbo].[TeacherSubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubjectClass_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherSubjectClass] CHECK CONSTRAINT [FK_TeacherSubjectClass_Class]
GO
ALTER TABLE [dbo].[TeacherSubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubjectClass_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherSubjectClass] CHECK CONSTRAINT [FK_TeacherSubjectClass_Subject]
GO
ALTER TABLE [dbo].[TeacherSubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubjectClass_User] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[User] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherSubjectClass] CHECK CONSTRAINT [FK_TeacherSubjectClass_User]
GO
ALTER TABLE [dbo].[TeachingMaterial]  WITH CHECK ADD  CONSTRAINT [FK_TeachingMaterial_TeacherSubjectClass] FOREIGN KEY([TeacherSubjectClassID])
REFERENCES [dbo].[TeacherSubjectClass] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeachingMaterial] CHECK CONSTRAINT [FK_TeachingMaterial_TeacherSubjectClass]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Class]
GO
/****** Object:  StoredProcedure [dbo].[AddAbsence]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddAbsence] 
	@studentSubjectID int,
	@semester bit,
	@type int
AS
BEGIN
	INSERT INTO Absence (StudentSubjectID, Semester, [Type]) VALUES (@studentSubjectID, @semester, @type)
END
GO
/****** Object:  StoredProcedure [dbo].[AddClass]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddClass]
	@specializationID int,
	@name varchar(20),
	@year varchar(10)
AS
BEGIN
	INSERT INTO Class (SpecializationID, [Name], [Year]) VALUES (@specializationID, @name, @year)
END
GO
/****** Object:  StoredProcedure [dbo].[AddFinalGrade]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddFinalGrade] 
	@studentSubjectID int,
	@semester bit,
	@value real
AS
BEGIN
	INSERT INTO FinalGrade (StudentSubjectID, Semester, [Value]) VALUES (@studentSubjectID, @semester, @value)
END
GO
/****** Object:  StoredProcedure [dbo].[AddGrade]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddGrade]
	@studentSubjectID int,
	@semester bit,
	@value float,
	@thesis bit
AS
BEGIN
	INSERT INTO Grade (StudentSubjectID, Semester, [Value], Thesis) VALUES (@studentSubjectID, @semester, @value, @thesis)
END
GO
/****** Object:  StoredProcedure [dbo].[AddSpecialization]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddSpecialization] 
	@name varchar(50)
AS
BEGIN
	INSERT INTO Specialization ([Name]) VALUES (@name)
END
GO
/****** Object:  StoredProcedure [dbo].[AddStudentSubject]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddStudentSubject]
	@studentID int,
	@subjectID int
AS
BEGIN
	INSERT INTO StudentSubject (StudentID, SubjectID) VALUES (@studentID, @subjectID)
END
GO
/****** Object:  StoredProcedure [dbo].[AddSubject]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddSubject]
	@name varchar(50)
AS
BEGIN
	INSERT INTO [Subject] ([Name]) VALUES (@name)
END
GO
/****** Object:  StoredProcedure [dbo].[AddSubjectSpecialization]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddSubjectSpecialization] 
	@subjectID int,
	@specializationID int,
	@thesis bit
AS
BEGIN
	INSERT INTO SubjectSpecialization (SubjectID, SpecializationID, Thesis) VALUES (@subjectID, @specializationID, @thesis)
END
GO
/****** Object:  StoredProcedure [dbo].[AddTeacherSubjectClass]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddTeacherSubjectClass] 
	@teacherID int,
	@subjectID int,
	@classID int
AS
BEGIN
	INSERT INTO TeacherSubjectClass (TeacherID, SubjectID, ClassID) VALUES (@teacherID, @subjectID, @classID)
END
GO
/****** Object:  StoredProcedure [dbo].[AddTeachingMaterial]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddTeachingMaterial] 
	@tscID int,
	@semester bit,
	@name varchar(30),
	@path varchar(50)
AS
BEGIN
	INSERT INTO TeachingMaterial (TeacherSubjectClassID, Semester, [Name], [Path]) VALUES (@tscID, @semester, @name, @path)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddUser]
	@firstName varchar(30),
	@lastName varchar(30),
	@email varchar(30),
	@password varchar(30),
	@role int,
	@classID int
AS
BEGIN
	INSERT INTO [User] (FirstName, [LastName], [Email], [Password], [Role], [ClassID]) VALUES (@firstName, @lastName, @email, @password, @role, @classID)
END
GO
/****** Object:  StoredProcedure [dbo].[CheckForEmailExistenceInUser]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CheckForEmailExistenceInUser]
	@email varchar(30)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 1 FROM [User] WHERE Email=@email
END
GO
/****** Object:  StoredProcedure [dbo].[CheckForSpecializationExistence]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CheckForSpecializationExistence] 
	@name varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 1 FROM Specialization WHERE [Name]=@name
END
GO
/****** Object:  StoredProcedure [dbo].[CheckForSubjectExistence]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CheckForSubjectExistence]
	@name varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 1 FROM [Subject] WHERE [Name]=@name
END
GO
/****** Object:  StoredProcedure [dbo].[GetAbsence]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAbsence] 
	@studentSubjectID int,
	@semester bit,
	@type int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Absence WHERE StudentSubjectID=@studentSubjectID AND Semester=@semester AND [Type]=@type
END
GO
/****** Object:  StoredProcedure [dbo].[GetAbsences]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAbsences] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Absence
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllUsers] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * from [User]
END
GO
/****** Object:  StoredProcedure [dbo].[GetClass]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetClass]
	@name varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Class WHERE [Name]=@name
END
GO
/****** Object:  StoredProcedure [dbo].[GetClasses]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetClasses]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Class
END
GO
/****** Object:  StoredProcedure [dbo].[GetFinalGrade]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFinalGrade] 
	@studentSubjectID int,
	@semester bit
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM FinalGrade WHERE StudentSubjectID=@studentSubjectID AND Semester=@semester
END
GO
/****** Object:  StoredProcedure [dbo].[GetFinalGrades]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFinalGrades] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM FinalGrade
END
GO
/****** Object:  StoredProcedure [dbo].[GetGrade]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetGrade]
	@studentSubjectID int,
	@semester bit,
	@value float,
	@thesis bit
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Grade WHERE StudentSubjectID=@studentSubjectID AND Semester=@semester AND [Value]=@value AND Thesis=@thesis
END
GO
/****** Object:  StoredProcedure [dbo].[GetGrades]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetGrades] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Grade
END
GO
/****** Object:  StoredProcedure [dbo].[GetSpecialization]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSpecialization] 
	@name varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Specialization WHERE [Name]=@name
END
GO
/****** Object:  StoredProcedure [dbo].[GetSpecializations]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSpecializations] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Specialization
END
GO
/****** Object:  StoredProcedure [dbo].[GetStudentSubject]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStudentSubject]
	@studentID int,
	@subjectID int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM StudentSubject WHERE StudentID=@studentID AND SubjectID=@subjectID
END
GO
/****** Object:  StoredProcedure [dbo].[GetStudentSubjectList]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStudentSubjectList] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM StudentSubject
END
GO
/****** Object:  StoredProcedure [dbo].[GetSubject]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSubject]
	@name varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [Subject] WHERE [Name]=@name
END
GO
/****** Object:  StoredProcedure [dbo].[GetSubjects]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSubjects]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [Subject]
END
GO
/****** Object:  StoredProcedure [dbo].[GetSubjectSpecialization]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSubjectSpecialization] 
	@subjectID int,
	@specializationID int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM SubjectSpecialization WHERE SubjectID=@subjectID AND SpecializationID=@specializationID
END
GO
/****** Object:  StoredProcedure [dbo].[GetSubjectSpecializations]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSubjectSpecializations] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM SubjectSpecialization
END
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherSubjectClass]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTeacherSubjectClass] 
	@teacherID int,
	@subjectID int,
	@classID int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM TeacherSubjectClass WHERE TeacherID=@teacherID AND SubjectID=@subjectID AND ClassID=@classID
END
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherSubjectClassList]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTeacherSubjectClassList] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM TeacherSubjectClass
END
GO
/****** Object:  StoredProcedure [dbo].[GetTeachingMaterial]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTeachingMaterial] 
	@tscID int,
	@name varchar(30)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM TeachingMaterial WHERE TeacherSubjectClassID=@tscID AND [Name]=@name
END
GO
/****** Object:  StoredProcedure [dbo].[GetTeachingMaterials]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTeachingMaterials] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM TeachingMaterial
END
GO
/****** Object:  StoredProcedure [dbo].[ModifyAbsence]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModifyAbsence] 
	@id int,
	@type int
AS
BEGIN
	UPDATE Absence SET [Type]=@type WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[ModifyClass]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModifyClass]
	@id int,
	@specializationID int,
	@name varchar(20),
	@year varchar(10)
AS
BEGIN
	UPDATE Class SET SpecializationID=@specializationID, [Name]=@name, [Year]=@year WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[ModifySpecialization]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModifySpecialization] 
	@id int,
	@name varchar(50)
AS
BEGIN
	UPDATE Specialization SET [Name]=@name WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[ModifySubject]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModifySubject]
	@id int,
	@name varchar(50)
AS
BEGIN
	UPDATE [Subject] SET [Name]=@name WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[ModifySubjectSpecialization]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModifySubjectSpecialization] 
	@id int,
	@thesis bit
AS
BEGIN
	UPDATE SubjectSpecialization SET Thesis=@thesis WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[ModifyUser]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModifyUser] 
	@id int,
	@firstName varchar(30),
	@lastName varchar(30),
	@email varchar(30),
	@password varchar(30),
	@role int,
	@classID int
AS
BEGIN
	UPDATE [User] SET FirstName=@firstName, LastName=@lastName, Email=@email, [Password]=@password, [Role]=@role, [ClassID]=@classID WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveAbsence]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveAbsence] 
	@id int
AS
BEGIN
	DELETE FROM Absence WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveClass]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveClass]
	@id int
AS
BEGIN
	DELETE FROM Class WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveGrade]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveGrade]
	@id int
AS
BEGIN
	DELETE FROM Grade WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveSpecialization]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveSpecialization] 
	@id int
AS
BEGIN
	DELETE FROM Specialization WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveStudentSubject]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveStudentSubject]
	@id int
AS
BEGIN
	DELETE FROM StudentSubject WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveSubject]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveSubject]
	@id int
AS
BEGIN
	DELETE FROM [Subject] WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveSubjectSpecialization]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveSubjectSpecialization] 
	@id int
AS
BEGIN
	DELETE FROM SubjectSpecialization WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveTeacherSubjectClass]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveTeacherSubjectClass] 
	@id int
AS
BEGIN
	DELETE FROM TeacherSubjectClass WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveTeachingMaterial]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveTeachingMaterial] 
	@id int
AS
BEGIN
	DELETE FROM TeachingMaterial WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveUser]
	@id int
AS
BEGIN
	DELETE FROM [User] WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 05/27/2021 10:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserLogin]
	@email varchar(30),
	@password varchar(30)
AS
BEGIN
	SELECT * FROM [User] WHERE [Email]=@email AND [Password]=@password
END
GO
USE [master]
GO
ALTER DATABASE [SchoolPlatform] SET  READ_WRITE 
GO
