USE [master]
GO
/****** Object:  Database [Homework3]    Script Date: 09.12.2019 20:49:27 ******/
CREATE DATABASE [Homework3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Homework3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.BARTKOWIAKSQL\MSSQL\DATA\Homework3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Homework3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.BARTKOWIAKSQL\MSSQL\DATA\Homework3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Homework3] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Homework3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Homework3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Homework3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Homework3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Homework3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Homework3] SET ARITHABORT OFF 
GO
ALTER DATABASE [Homework3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Homework3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Homework3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Homework3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Homework3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Homework3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Homework3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Homework3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Homework3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Homework3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Homework3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Homework3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Homework3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Homework3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Homework3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Homework3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Homework3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Homework3] SET RECOVERY FULL 
GO
ALTER DATABASE [Homework3] SET  MULTI_USER 
GO
ALTER DATABASE [Homework3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Homework3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Homework3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Homework3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Homework3] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Homework3', N'ON'
GO
ALTER DATABASE [Homework3] SET QUERY_STORE = OFF
GO
USE [Homework3]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 09.12.2019 20:49:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Surname] [nvarchar](30) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Film]    Script Date: 09.12.2019 20:49:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Film](
	[FilmId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Type] [nvarchar](30) NULL,
	[YearOfProduction] [int] NULL,
	[MinAge] [int] NULL,
	[3D] [bit] NULL,
 CONSTRAINT [PK_Film] PRIMARY KEY CLUSTERED 
(
	[FilmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderTicket]    Script Date: 09.12.2019 20:49:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderTicket](
	[OrderTicketId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[FilmId] [int] NULL,
	[TicketId] [int] NULL,
	[Day] [date] NULL,
	[Place] [int] NULL,
	[Vip] [bit] NULL,
	[Row] [nvarchar](10) NULL,
	[Time] [time](0) NULL,
 CONSTRAINT [PK_OrderTicket] PRIMARY KEY CLUSTERED 
(
	[OrderTicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 09.12.2019 20:49:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[Discount] [nvarchar](15) NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 09.12.2019 20:49:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](30) NULL,
	[Password] [nvarchar](30) NULL,
	[Age] [int] NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (5, N'Damian', N'Gaj')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (6, N'Damian', N'Jak')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (7, N'Mateusz', N'Polak')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (8, N'Bolek', N'Johnson')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (9, N'Kaja', N'Nowak')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1002, N'Zosia', N'Samosia')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1003, N'Ania', N'Kolo')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1004, N'Wiola', N'Nowa')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1005, N'Kuba', N'Wole')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1006, N'Janek', N'Ziele')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1007, N'Jola', N'Lojalna')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1008, N'Pawel', N'Byle')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1009, N'Mateusz', N'Bartkowia')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1010, N'Marek', N'Wczoraj')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1011, N'Ala', N'Makota')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1012, N'Ola', N'Nowak')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1013, N'Magda', N'Tak')
INSERT [dbo].[Client] ([ClientId], [Name], [Surname]) VALUES (1014, N'Joanna', N'Dart')
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Film] ON 

INSERT [dbo].[Film] ([FilmId], [Name], [Type], [YearOfProduction], [MinAge], [3D]) VALUES (1, N'Hugo', N'Family', 2017, 8, 1)
INSERT [dbo].[Film] ([FilmId], [Name], [Type], [YearOfProduction], [MinAge], [3D]) VALUES (2, N'Nemo', N'Animated', 2016, 6, 0)
INSERT [dbo].[Film] ([FilmId], [Name], [Type], [YearOfProduction], [MinAge], [3D]) VALUES (3, N'Saw', N'Horror', 2004, 18, 0)
INSERT [dbo].[Film] ([FilmId], [Name], [Type], [YearOfProduction], [MinAge], [3D]) VALUES (4, N'MammaMia', N'Musical', 1999, 10, 0)
INSERT [dbo].[Film] ([FilmId], [Name], [Type], [YearOfProduction], [MinAge], [3D]) VALUES (5, N'CowboyJack', N'Western', 2001, 9, 1)
INSERT [dbo].[Film] ([FilmId], [Name], [Type], [YearOfProduction], [MinAge], [3D]) VALUES (6, N'LoveIsEverywhere', N'Romantic', 2019, 16, 1)
INSERT [dbo].[Film] ([FilmId], [Name], [Type], [YearOfProduction], [MinAge], [3D]) VALUES (7, N'SherlockHolmes', N'Crime', 2004, 15, 0)
INSERT [dbo].[Film] ([FilmId], [Name], [Type], [YearOfProduction], [MinAge], [3D]) VALUES (8, N'StarWars', N'ScienceFiction', 2006, 6, 1)
INSERT [dbo].[Film] ([FilmId], [Name], [Type], [YearOfProduction], [MinAge], [3D]) VALUES (9, N'KacVegas', N'Comedy', 2001, 18, 1)
INSERT [dbo].[Film] ([FilmId], [Name], [Type], [YearOfProduction], [MinAge], [3D]) VALUES (10, N'Spartan', N'War', 2004, 8, 0)
SET IDENTITY_INSERT [dbo].[Film] OFF
SET IDENTITY_INSERT [dbo].[OrderTicket] ON 

INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (2, 5, 2, 2, CAST(N'2019-11-24' AS Date), 9, 1, N'B', CAST(N'11:12:00' AS Time))
INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (3, 6, 2, 1, CAST(N'2020-03-01' AS Date), 8, 1, N'C', CAST(N'23:11:00' AS Time))
INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (10, 8, 5, 2, CAST(N'2019-12-29' AS Date), 4, 0, N'A', CAST(N'15:17:00' AS Time))
INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (12, 8, 1, 2, CAST(N'2019-07-12' AS Date), 7, 0, N'B', CAST(N'19:20:00' AS Time))
INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (1003, 8, 2, 2, CAST(N'2019-12-29' AS Date), 3, 1, N'A', CAST(N'20:01:00' AS Time))
INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (1008, 1005, 1, 2, CAST(N'2019-12-21' AS Date), 7, 0, N'B', CAST(N'18:00:00' AS Time))
INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (1009, 1006, 2, 2, CAST(N'2019-12-27' AS Date), 1, 0, N'A', CAST(N'11:00:00' AS Time))
INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (1011, 1008, 3, 1, CAST(N'2020-01-01' AS Date), 2, 1, N'D', CAST(N'17:00:00' AS Time))
INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (1012, 1009, 2, 1, CAST(N'2020-01-14' AS Date), 7, 1, N'C', CAST(N'18:00:00' AS Time))
INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (1013, 1010, 1, 2, CAST(N'2019-12-28' AS Date), 7, 1, N'B', CAST(N'15:00:00' AS Time))
INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (1016, 1013, 2, 2, CAST(N'2019-12-03' AS Date), 7, 0, N'B', CAST(N'08:00:00' AS Time))
INSERT [dbo].[OrderTicket] ([OrderTicketId], [ClientId], [FilmId], [TicketId], [Day], [Place], [Vip], [Row], [Time]) VALUES (1017, 1014, 1, 2, CAST(N'2019-12-13' AS Date), 9, 1, N'D', CAST(N'09:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[OrderTicket] OFF
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([TicketId], [Discount], [Price]) VALUES (1, N'Student', 15)
INSERT [dbo].[Ticket] ([TicketId], [Discount], [Price]) VALUES (2, N'Normal', 30)
SET IDENTITY_INSERT [dbo].[Ticket] OFF
SET IDENTITY_INSERT [dbo].[UserLogin] ON 

INSERT [dbo].[UserLogin] ([UserId], [UserName], [Password], [Age]) VALUES (1, N'MateuszB', N'elo', 20)
INSERT [dbo].[UserLogin] ([UserId], [UserName], [Password], [Age]) VALUES (2, N'Bartek', N'xd', NULL)
INSERT [dbo].[UserLogin] ([UserId], [UserName], [Password], [Age]) VALUES (3, N'Bartek', N'xd', NULL)
INSERT [dbo].[UserLogin] ([UserId], [UserName], [Password], [Age]) VALUES (4, N'Kuba', N'buba', NULL)
INSERT [dbo].[UserLogin] ([UserId], [UserName], [Password], [Age]) VALUES (5, N'Madzia2', N'magda', NULL)
INSERT [dbo].[UserLogin] ([UserId], [UserName], [Password], [Age]) VALUES (1002, N'Kuba12', N'lol', NULL)
INSERT [dbo].[UserLogin] ([UserId], [UserName], [Password], [Age]) VALUES (1003, N'Ola', N'qwer', NULL)
INSERT [dbo].[UserLogin] ([UserId], [UserName], [Password], [Age]) VALUES (1004, N'Tomasz', N'program', NULL)
SET IDENTITY_INSERT [dbo].[UserLogin] OFF
ALTER TABLE [dbo].[OrderTicket]  WITH CHECK ADD  CONSTRAINT [FK_OrderTicket_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[OrderTicket] CHECK CONSTRAINT [FK_OrderTicket_Client]
GO
ALTER TABLE [dbo].[OrderTicket]  WITH CHECK ADD  CONSTRAINT [FK_OrderTicket_Film] FOREIGN KEY([FilmId])
REFERENCES [dbo].[Film] ([FilmId])
GO
ALTER TABLE [dbo].[OrderTicket] CHECK CONSTRAINT [FK_OrderTicket_Film]
GO
ALTER TABLE [dbo].[OrderTicket]  WITH CHECK ADD  CONSTRAINT [FK_OrderTicket_Ticket] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([TicketId])
GO
ALTER TABLE [dbo].[OrderTicket] CHECK CONSTRAINT [FK_OrderTicket_Ticket]
GO
USE [master]
GO
ALTER DATABASE [Homework3] SET  READ_WRITE 
GO
