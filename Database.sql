USE [DbNimapInfotech ]
GO
/****** Object:  Table [dbo].[MCategory]    Script Date: 10/5/2023 12:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[IsActiv] [bit] NULL,
 CONSTRAINT [PK_MCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MProduct]    Script Date: 10/5/2023 12:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MProduct](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_MProduct] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MCategory] ON 
GO
INSERT [dbo].[MCategory] ([CategoryId], [CategoryName], [IsActiv]) VALUES (1, N'Mobile phones', 1)
GO
INSERT [dbo].[MCategory] ([CategoryId], [CategoryName], [IsActiv]) VALUES (2, N'Game consoles', 1)
GO
SET IDENTITY_INSERT [dbo].[MCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[MProduct] ON 
GO
INSERT [dbo].[MProduct] ([ProductId], [ProductName], [CategoryId]) VALUES (2, N'Redmi Note 8', 1)
GO
INSERT [dbo].[MProduct] ([ProductId], [ProductName], [CategoryId]) VALUES (3, N'Vivo Y20G', 2)
GO
INSERT [dbo].[MProduct] ([ProductId], [ProductName], [CategoryId]) VALUES (4, N'Iphone15', 1)
GO
INSERT [dbo].[MProduct] ([ProductId], [ProductName], [CategoryId]) VALUES (5, N'Iphone15', 2)
GO
INSERT [dbo].[MProduct] ([ProductId], [ProductName], [CategoryId]) VALUES (6, N'Vivo Y20G', 2)
GO
INSERT [dbo].[MProduct] ([ProductId], [ProductName], [CategoryId]) VALUES (7, N'Iphone15', 1)
GO
INSERT [dbo].[MProduct] ([ProductId], [ProductName], [CategoryId]) VALUES (8, N'Vivo Y20G', 1)
GO
INSERT [dbo].[MProduct] ([ProductId], [ProductName], [CategoryId]) VALUES (9, N'Vivo Y20G', 1)
GO
INSERT [dbo].[MProduct] ([ProductId], [ProductName], [CategoryId]) VALUES (10, N'Game', 2)
GO
INSERT [dbo].[MProduct] ([ProductId], [ProductName], [CategoryId]) VALUES (11, N'Vivo Y20G', 1)
GO
SET IDENTITY_INSERT [dbo].[MProduct] OFF
GO
/****** Object:  StoredProcedure [dbo].[SpProduct]    Script Date: 10/5/2023 12:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[SpProduct] 
@ProductId int ,
@ProductName nvarchar(50),
@CategoryId int,
@Flag nvarchar(1)
As
Begin
if(@Flag='I')
Begin
Insert into MProduct values(@ProductName,@CategoryId)
End
If(@Flag='U')
Begin
Update MProduct Set 
ProductName=@ProductName,CategoryId=@CategoryId
Where ProductId=@ProductId
End
End
GO
