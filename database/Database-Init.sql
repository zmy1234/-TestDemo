
/****** Object:  Table [dbo].[RightTab]    Script Date: 02/23/2021 22:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RightTab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RepoTitle] [nvarchar](255) NOT NULL,
	[RepoDesp] [nvarchar](255) NULL,
	[RepoUrl] [nvarchar](255) NULL,
	[SendMail] [nvarchar](40) NULL,
	[SendTime] [datetime] NOT NULL,
 CONSTRAINT [PK_RightTab] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeftTab]    Script Date: 02/23/2021 22:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeftTab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RepoTitle] [nvarchar](255) NULL,
	[RepoDesp] [nvarchar](255) NULL,
	[RepoUrl] [nvarchar](255) NULL,
	[AddTime] [datetime] NULL,
 CONSTRAINT [PK_LeftTab] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_LeftTab_AddTime]    Script Date: 02/23/2021 22:24:12 ******/
ALTER TABLE [dbo].[LeftTab] ADD  CONSTRAINT [DF_LeftTab_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
