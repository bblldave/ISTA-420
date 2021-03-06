USE [BaseballProject]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 6/22/2017 10:34:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[playerID] [int] NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[Position] [varchar](50) NULL,
	[Team] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[playerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 6/22/2017 10:34:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[Team1] [varchar](50) NULL,
	[Team2] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Time] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[gameId] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [pk_scheduleid] PRIMARY KEY CLUSTERED 
(
	[gameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[stats]    Script Date: 6/22/2017 10:34:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stats](
	[PlayerID] [int] NOT NULL,
	[G] [varchar](50) NULL,
	[AB] [varchar](50) NULL,
	[R] [varchar](50) NULL,
	[H] [varchar](50) NULL,
	[SecondBase] [varchar](50) NULL,
	[ThirdBase] [varchar](50) NULL,
	[HR] [varchar](50) NULL,
	[RBI] [varchar](50) NULL,
	[BB] [varchar](50) NULL,
	[K] [varchar](50) NULL,
	[SB] [varchar](50) NULL,
	[CS] [varchar](50) NULL,
	[AVG] [varchar](50) NULL,
	[SLG] [varchar](50) NULL,
	[OBP] [varchar](50) NULL,
	[OPS] [varchar](50) NULL,
 CONSTRAINT [PK_stats] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 6/22/2017 10:34:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 6/22/2017 10:34:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[Team] [varchar](50) NOT NULL,
	[TeamName] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[CoachId] [int] NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[Team] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/22/2017 10:34:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userName] [text] NULL,
	[firstName] [text] NULL,
	[lastName] [text] NULL,
	[email] [text] NULL,
	[role] [text] NULL,
	[phoneNumber] [text] NULL,
	[password] [text] NULL
)
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_stats] FOREIGN KEY([playerID])
REFERENCES [dbo].[stats] ([PlayerID])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_stats]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Teams] FOREIGN KEY([Team])
REFERENCES [dbo].[Teams] ([Team])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Teams]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Teams] FOREIGN KEY([Team1])
REFERENCES [dbo].[Teams] ([Team])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Teams]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Teams1] FOREIGN KEY([Team2])
REFERENCES [dbo].[Teams] ([Team])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Teams1]
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sysdiagrams'
GO
