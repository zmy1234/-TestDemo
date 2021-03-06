
/****** Object:  Table [dbo].[RightTabs]    Script Date: 02/25/2021 21:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RightTabs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RepoTitle] [nvarchar](255) NOT NULL,
	[RepoDesp] [nvarchar](255) NOT NULL,
	[RepoUrl] [nvarchar](255) NOT NULL,
	[SendMail] [nvarchar](max) NULL,
	[SendTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RightTabs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeftTabs]    Script Date: 02/25/2021 21:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeftTabs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RepoTitle] [nvarchar](255) NOT NULL,
	[RepoDesp] [nvarchar](255) NOT NULL,
	[RepoUrl] [nvarchar](255) NOT NULL,
	[AddTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_LeftTabs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02/25/2021 21:14:59 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
