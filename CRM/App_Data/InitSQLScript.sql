CREATE DATABASE [CRM];

USE [CRM]
GO
/****** Object:  Table [dbo].[�Ȥ����]    Script Date: 2017/12/23 �W�� 11:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[�Ȥ����](
	[Id] [int] NOT NULL,
	[�����W��] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[�Ȥ��p���H]    Script Date: 2017/12/23 �W�� 11:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[�Ȥ��p���H](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[�Ȥ�Id] [int] NOT NULL,
	[¾��] [nvarchar](50) NOT NULL,
	[�m�W] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[���] [nvarchar](50) NULL,
	[�q��] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[�Ȥ���]    Script Date: 2017/12/23 �W�� 11:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[�Ȥ���](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[�Ȥ�W��] [nvarchar](50) NOT NULL,
	[�Τ@�s��] [char](8) NOT NULL,
	[�q��] [nvarchar](50) NOT NULL,
	[�ǯu] [nvarchar](50) NULL,
	[�a�}] [nvarchar](100) NULL,
	[Email] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[�Ȥ����Id] [int] NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[�Ȥ�Ȧ��T]    Script Date: 2017/12/23 �W�� 11:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[�Ȥ�Ȧ��T](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[�Ȥ�Id] [int] NOT NULL,
	[�Ȧ�W��] [nvarchar](50) NOT NULL,
	[�Ȧ�N�X] [int] NOT NULL,
	[����N�X] [int] NULL,
	[�b��W��] [nvarchar](50) NOT NULL,
	[�b�ḹ�X] [nvarchar](20) NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_�Ȥ�Ȧ��T] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[CRMSummary]    Script Date: 2017/12/23 �W�� 11:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[CRMSummary]
AS 
SELECT [t0].[�Ȥ�W��],[t0].[IsDeleted], (
    SELECT COUNT(*)
    FROM [�Ȥ��p���H] AS [t1]
    WHERE [t1].[�Ȥ�Id] = [t0].[Id] and (IsDeleted is null or IsDeleted = '0')
    ) AS [�Ȥ��p���H�ƶq], (
    SELECT COUNT(*)
    FROM [�Ȥ�Ȧ��T] AS [t2]
    WHERE [t2].[�Ȥ�Id] = [t0].[Id] and (IsDeleted is null or IsDeleted = '0')
    ) AS [�Ȥ�Ȧ��T�ƶq]
FROM [�Ȥ���] AS [t0]




GO
INSERT [dbo].[�Ȥ����] ([Id], [�����W��]) VALUES (1, N'��T�~')
INSERT [dbo].[�Ȥ����] ([Id], [�����W��]) VALUES (2, N'���ķ~')
INSERT [dbo].[�Ȥ����] ([Id], [�����W��]) VALUES (3, N'��޷~')
INSERT [dbo].[�Ȥ����] ([Id], [�����W��]) VALUES (4, N'�s��~')
SET IDENTITY_INSERT [dbo].[�Ȥ��p���H] ON 

INSERT [dbo].[�Ȥ��p���H] ([Id], [�Ȥ�Id], [¾��], [�m�W], [Email], [���], [�q��], [IsDeleted]) VALUES (4, 1, N'�u�{�v', N'Gary', N'ggaarryy12340@gmail.com', N'0966-666638', NULL, 0)
INSERT [dbo].[�Ȥ��p���H] ([Id], [�Ȥ�Id], [¾��], [�m�W], [Email], [���], [�q��], [IsDeleted]) VALUES (5, 4, N'�Ѥj', N'�\���a', N'ggaarryy@gmail.com', NULL, NULL, 0)
INSERT [dbo].[�Ȥ��p���H] ([Id], [�Ȥ�Id], [¾��], [�m�W], [Email], [���], [�q��], [IsDeleted]) VALUES (6, 1, N'123', N'235', N'ggaarryy12340@gmail.co', NULL, NULL, 1)
INSERT [dbo].[�Ȥ��p���H] ([Id], [�Ȥ�Id], [¾��], [�m�W], [Email], [���], [�q��], [IsDeleted]) VALUES (7, 1, N'����', N'�O��', N'Will@miniasp.com', NULL, N'0225856519', NULL)
INSERT [dbo].[�Ȥ��p���H] ([Id], [�Ȥ�Id], [¾��], [�m�W], [Email], [���], [�q��], [IsDeleted]) VALUES (8, 1, N'���a��', N'666', N'ggaarryy12340@yahoo.com', NULL, NULL, NULL)
INSERT [dbo].[�Ȥ��p���H] ([Id], [�Ȥ�Id], [¾��], [�m�W], [Email], [���], [�q��], [IsDeleted]) VALUES (9, 1, N'123', N'123', N'123@gmail.com', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[�Ȥ��p���H] OFF
SET IDENTITY_INSERT [dbo].[�Ȥ���] ON 

INSERT [dbo].[�Ȥ���] ([Id], [�Ȥ�W��], [�Τ@�s��], [�q��], [�ǯu], [�a�}], [Email], [IsDeleted], [�Ȥ����Id]) VALUES (1, N'�h�_�Ʀ�', N'12694272', N'0223222480', N'0223418318', N'�x�_�������ϪC�{�n���@�q���Ѥ����T��', N'service@miniasp.com', 0, 4)
INSERT [dbo].[�Ȥ���] ([Id], [�Ȥ�W��], [�Τ@�s��], [�q��], [�ǯu], [�a�}], [Email], [IsDeleted], [�Ȥ����Id]) VALUES (4, N'86�p�E', N'88640312', N'3028392008', NULL, N'19 Lukens Dr.Ste300', NULL, 0, 4)
INSERT [dbo].[�Ȥ���] ([Id], [�Ȥ�W��], [�Τ@�s��], [�q��], [�ǯu], [�a�}], [Email], [IsDeleted], [�Ȥ����Id]) VALUES (5, N'����H�U', N'98565261', N'0937-015523', NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[�Ȥ���] ([Id], [�Ȥ�W��], [�Τ@�s��], [�q��], [�ǯu], [�a�}], [Email], [IsDeleted], [�Ȥ����Id]) VALUES (6, N'�j�ߥ�', N'12347864', N'076011000', N'076011000', N'No.2, Zhuoyue Rd., Nanzi Dist., Kaohsiun, City 811, Taiwan (R.O.C.)', N'aaa@gmail.com', 1, 3)
SET IDENTITY_INSERT [dbo].[�Ȥ���] OFF
SET IDENTITY_INSERT [dbo].[�Ȥ�Ȧ��T] ON 

INSERT [dbo].[�Ȥ�Ȧ��T] ([Id], [�Ȥ�Id], [�Ȧ�W��], [�Ȧ�N�X], [����N�X], [�b��W��], [�b�ḹ�X], [IsDeleted]) VALUES (1, 1, N'�X�@���w', 6, 431, N'123', N'456', 0)
INSERT [dbo].[�Ȥ�Ȧ��T] ([Id], [�Ȥ�Id], [�Ȧ�W��], [�Ȧ�N�X], [����N�X], [�b��W��], [�b�ḹ�X], [IsDeleted]) VALUES (2, 4, N'�ɤs�Ȧ�', 808, 431, N'123', N'456', 1)
INSERT [dbo].[�Ȥ�Ȧ��T] ([Id], [�Ȥ�Id], [�Ȧ�W��], [�Ȧ�N�X], [����N�X], [�b��W��], [�b�ḹ�X], [IsDeleted]) VALUES (3, 4, N'����H�U', 822, 430, N'123', N'223', NULL)
SET IDENTITY_INSERT [dbo].[�Ȥ�Ȧ��T] OFF
ALTER TABLE [dbo].[�Ȥ��p���H] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[�Ȥ���] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[�Ȥ�Ȧ��T] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[�Ȥ��p���H]  WITH CHECK ADD  CONSTRAINT [FK_�Ȥ��p���H_�Ȥ���] FOREIGN KEY([�Ȥ�Id])
REFERENCES [dbo].[�Ȥ���] ([Id])
GO
ALTER TABLE [dbo].[�Ȥ��p���H] CHECK CONSTRAINT [FK_�Ȥ��p���H_�Ȥ���]
GO
ALTER TABLE [dbo].[�Ȥ���]  WITH CHECK ADD FOREIGN KEY([�Ȥ����Id])
REFERENCES [dbo].[�Ȥ����] ([Id])
GO
ALTER TABLE [dbo].[�Ȥ�Ȧ��T]  WITH CHECK ADD  CONSTRAINT [FK_�Ȥ�Ȧ��T_�Ȥ���] FOREIGN KEY([�Ȥ�Id])
REFERENCES [dbo].[�Ȥ���] ([Id])
GO
ALTER TABLE [dbo].[�Ȥ�Ȧ��T] CHECK CONSTRAINT [FK_�Ȥ�Ȧ��T_�Ȥ���]
GO
