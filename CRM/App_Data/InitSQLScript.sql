CREATE DATABASE [CRM];

USE [CRM]
GO
/****** Object:  Table [dbo].[客戶分類]    Script Date: 2017/12/23 上午 11:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[客戶分類](
	[Id] [int] NOT NULL,
	[分類名稱] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[客戶聯絡人]    Script Date: 2017/12/23 上午 11:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[客戶聯絡人](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[客戶Id] [int] NOT NULL,
	[職稱] [nvarchar](50) NOT NULL,
	[姓名] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[手機] [nvarchar](50) NULL,
	[電話] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[客戶資料]    Script Date: 2017/12/23 上午 11:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[客戶資料](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[客戶名稱] [nvarchar](50) NOT NULL,
	[統一編號] [char](8) NOT NULL,
	[電話] [nvarchar](50) NOT NULL,
	[傳真] [nvarchar](50) NULL,
	[地址] [nvarchar](100) NULL,
	[Email] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[客戶分類Id] [int] NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[客戶銀行資訊]    Script Date: 2017/12/23 上午 11:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[客戶銀行資訊](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[客戶Id] [int] NOT NULL,
	[銀行名稱] [nvarchar](50) NOT NULL,
	[銀行代碼] [int] NOT NULL,
	[分行代碼] [int] NULL,
	[帳戶名稱] [nvarchar](50) NOT NULL,
	[帳戶號碼] [nvarchar](20) NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_客戶銀行資訊] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[CRMSummary]    Script Date: 2017/12/23 上午 11:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[CRMSummary]
AS 
SELECT [t0].[客戶名稱],[t0].[IsDeleted], (
    SELECT COUNT(*)
    FROM [客戶聯絡人] AS [t1]
    WHERE [t1].[客戶Id] = [t0].[Id] and (IsDeleted is null or IsDeleted = '0')
    ) AS [客戶聯絡人數量], (
    SELECT COUNT(*)
    FROM [客戶銀行資訊] AS [t2]
    WHERE [t2].[客戶Id] = [t0].[Id] and (IsDeleted is null or IsDeleted = '0')
    ) AS [客戶銀行資訊數量]
FROM [客戶資料] AS [t0]




GO
INSERT [dbo].[客戶分類] ([Id], [分類名稱]) VALUES (1, N'資訊業')
INSERT [dbo].[客戶分類] ([Id], [分類名稱]) VALUES (2, N'金融業')
INSERT [dbo].[客戶分類] ([Id], [分類名稱]) VALUES (3, N'科技業')
INSERT [dbo].[客戶分類] ([Id], [分類名稱]) VALUES (4, N'零售業')
SET IDENTITY_INSERT [dbo].[客戶聯絡人] ON 

INSERT [dbo].[客戶聯絡人] ([Id], [客戶Id], [職稱], [姓名], [Email], [手機], [電話], [IsDeleted]) VALUES (4, 1, N'工程師', N'Gary', N'ggaarryy12340@gmail.com', N'0966-666638', NULL, 0)
INSERT [dbo].[客戶聯絡人] ([Id], [客戶Id], [職稱], [姓名], [Email], [手機], [電話], [IsDeleted]) VALUES (5, 4, N'老大', N'許哲軒', N'ggaarryy@gmail.com', NULL, NULL, 0)
INSERT [dbo].[客戶聯絡人] ([Id], [客戶Id], [職稱], [姓名], [Email], [手機], [電話], [IsDeleted]) VALUES (6, 1, N'123', N'235', N'ggaarryy12340@gmail.co', NULL, NULL, 1)
INSERT [dbo].[客戶聯絡人] ([Id], [客戶Id], [職稱], [姓名], [Email], [手機], [電話], [IsDeleted]) VALUES (7, 1, N'老闆', N'保哥', N'Will@miniasp.com', NULL, N'0225856519', NULL)
INSERT [dbo].[客戶聯絡人] ([Id], [客戶Id], [職稱], [姓名], [Email], [手機], [電話], [IsDeleted]) VALUES (8, 1, N'掃地的', N'666', N'ggaarryy12340@yahoo.com', NULL, NULL, NULL)
INSERT [dbo].[客戶聯絡人] ([Id], [客戶Id], [職稱], [姓名], [Email], [手機], [電話], [IsDeleted]) VALUES (9, 1, N'123', N'123', N'123@gmail.com', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[客戶聯絡人] OFF
SET IDENTITY_INSERT [dbo].[客戶資料] ON 

INSERT [dbo].[客戶資料] ([Id], [客戶名稱], [統一編號], [電話], [傳真], [地址], [Email], [IsDeleted], [客戶分類Id]) VALUES (1, N'多奇數位', N'12694272', N'0223222480', N'0223418318', N'台北市中正區杭州南路一段六巷五號三樓', N'service@miniasp.com', 0, 4)
INSERT [dbo].[客戶資料] ([Id], [客戶名稱], [統一編號], [電話], [傳真], [地址], [Email], [IsDeleted], [客戶分類Id]) VALUES (4, N'86小舖', N'88640312', N'3028392008', NULL, N'19 Lukens Dr.Ste300', NULL, 0, 4)
INSERT [dbo].[客戶資料] ([Id], [客戶名稱], [統一編號], [電話], [傳真], [地址], [Email], [IsDeleted], [客戶分類Id]) VALUES (5, N'中國信託', N'98565261', N'0937-015523', NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[客戶資料] ([Id], [客戶名稱], [統一編號], [電話], [傳真], [地址], [Email], [IsDeleted], [客戶分類Id]) VALUES (6, N'大立光', N'12347864', N'076011000', N'076011000', N'No.2, Zhuoyue Rd., Nanzi Dist., Kaohsiun, City 811, Taiwan (R.O.C.)', N'aaa@gmail.com', 1, 3)
SET IDENTITY_INSERT [dbo].[客戶資料] OFF
SET IDENTITY_INSERT [dbo].[客戶銀行資訊] ON 

INSERT [dbo].[客戶銀行資訊] ([Id], [客戶Id], [銀行名稱], [銀行代碼], [分行代碼], [帳戶名稱], [帳戶號碼], [IsDeleted]) VALUES (1, 1, N'合作金庫', 6, 431, N'123', N'456', 0)
INSERT [dbo].[客戶銀行資訊] ([Id], [客戶Id], [銀行名稱], [銀行代碼], [分行代碼], [帳戶名稱], [帳戶號碼], [IsDeleted]) VALUES (2, 4, N'玉山銀行', 808, 431, N'123', N'456', 1)
INSERT [dbo].[客戶銀行資訊] ([Id], [客戶Id], [銀行名稱], [銀行代碼], [分行代碼], [帳戶名稱], [帳戶號碼], [IsDeleted]) VALUES (3, 4, N'中國信託', 822, 430, N'123', N'223', NULL)
SET IDENTITY_INSERT [dbo].[客戶銀行資訊] OFF
ALTER TABLE [dbo].[客戶聯絡人] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[客戶資料] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[客戶銀行資訊] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[客戶聯絡人]  WITH CHECK ADD  CONSTRAINT [FK_客戶聯絡人_客戶資料] FOREIGN KEY([客戶Id])
REFERENCES [dbo].[客戶資料] ([Id])
GO
ALTER TABLE [dbo].[客戶聯絡人] CHECK CONSTRAINT [FK_客戶聯絡人_客戶資料]
GO
ALTER TABLE [dbo].[客戶資料]  WITH CHECK ADD FOREIGN KEY([客戶分類Id])
REFERENCES [dbo].[客戶分類] ([Id])
GO
ALTER TABLE [dbo].[客戶銀行資訊]  WITH CHECK ADD  CONSTRAINT [FK_客戶銀行資訊_客戶資料] FOREIGN KEY([客戶Id])
REFERENCES [dbo].[客戶資料] ([Id])
GO
ALTER TABLE [dbo].[客戶銀行資訊] CHECK CONSTRAINT [FK_客戶銀行資訊_客戶資料]
GO
