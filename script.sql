USE [QLSV]
GO
/****** Object:  Table [dbo].[QLSV_TTSV]    Script Date: 11/11/2020 12:01:33 AM ******/
DROP TABLE [dbo].[QLSV_TTSV]
GO
/****** Object:  Table [dbo].[QLSV_LOP]    Script Date: 11/11/2020 12:01:33 AM ******/
DROP TABLE [dbo].[QLSV_LOP]
GO
/****** Object:  Table [dbo].[QLSV_KHOA]    Script Date: 11/11/2020 12:01:33 AM ******/
DROP TABLE [dbo].[QLSV_KHOA]
GO
/****** Object:  Table [dbo].[QLSV_KHOA]    Script Date: 11/11/2020 12:01:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLSV_KHOA](
	[makhoa] [nvarchar](10) NOT NULL,
	[khoa] [nvarchar](50) NULL,
 CONSTRAINT [PK_QLSV_KHOA] PRIMARY KEY CLUSTERED 
(
	[makhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLSV_LOP]    Script Date: 11/11/2020 12:01:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLSV_LOP](
	[malop] [nvarchar](10) NOT NULL,
	[lop] [nvarchar](50) NULL,
 CONSTRAINT [PK_QLSV_LOP] PRIMARY KEY CLUSTERED 
(
	[malop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLSV_TTSV]    Script Date: 11/11/2020 12:01:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLSV_TTSV](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mssv] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[lop] [nvarchar](10) NULL,
	[address] [nvarchar](50) NULL,
	[khoa] [nvarchar](50) NULL,
	[ngaysinh] [datetime] NULL,
	[gioitinh] [nvarchar](50) NULL,
	[toan] [float] NULL,
	[van] [float] NULL,
	[anh] [float] NULL,
	[diemtb] [float] NULL,
 CONSTRAINT [PK_QLSV_TTSV] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[QLSV_KHOA] ([makhoa], [khoa]) VALUES (N'CNTT', N'Công Nghệ Thông Tin')
INSERT [dbo].[QLSV_KHOA] ([makhoa], [khoa]) VALUES (N'NN', N'Ngoại Ngữ')
INSERT [dbo].[QLSV_KHOA] ([makhoa], [khoa]) VALUES (N'QHCC', N'Quan Hệ Công Chúng')
INSERT [dbo].[QLSV_LOP] ([malop], [lop]) VALUES (N'01', N'18TH01')
INSERT [dbo].[QLSV_LOP] ([malop], [lop]) VALUES (N'02', N'18TH02')
INSERT [dbo].[QLSV_LOP] ([malop], [lop]) VALUES (N'03', N'18QH03')
SET IDENTITY_INSERT [dbo].[QLSV_TTSV] ON 

INSERT [dbo].[QLSV_TTSV] ([id], [mssv], [name], [phone], [email], [lop], [address], [khoa], [ngaysinh], [gioitinh], [toan], [van], [anh], [diemtb]) VALUES (18, N'183030259', N'Nguyễn Thị Thảo', N'0983366166', N'thao@gmail.com', N'18TH01', N'37 buivanba', N'Ngoại Ngữ', CAST(N'2020-10-28T23:02:10.000' AS DateTime), N'Nữ', 8, 9, 8, 8.33333333333333)
INSERT [dbo].[QLSV_TTSV] ([id], [mssv], [name], [phone], [email], [lop], [address], [khoa], [ngaysinh], [gioitinh], [toan], [van], [anh], [diemtb]) VALUES (23, N'185050300', N'Nguyễn Văn Tài', N'090912345', N'tainguyen@gmail.com', N'18TH02', N'37 Điện Biên Phủ,Q.Bình Thạnh,TPHCM', N'Ngoại Ngữ', CAST(N'2020-11-11T10:19:40.000' AS DateTime), N'Nam', 3, 5.5, 8, 5.5)
INSERT [dbo].[QLSV_TTSV] ([id], [mssv], [name], [phone], [email], [lop], [address], [khoa], [ngaysinh], [gioitinh], [toan], [van], [anh], [diemtb]) VALUES (24, N'18501234', N'Nguyễn Văn Ba', N'0909343412', N'vanba@gmail.com', N'18TH01', N'37 văn cao,tphcm', N'Ngoại Ngữ', CAST(N'2020-11-10T10:26:05.000' AS DateTime), N'Nam', 7, 7, 7, 7)
INSERT [dbo].[QLSV_TTSV] ([id], [mssv], [name], [phone], [email], [lop], [address], [khoa], [ngaysinh], [gioitinh], [toan], [van], [anh], [diemtb]) VALUES (31, N'175858499', N'Nguyễn Hà', N'090912322', N'abc@gmail.com', N'18TH01', N'17 Trường Sơn,TPHCM', N'Quan Hệ Công Chúng', CAST(N'2020-12-01T10:47:03.000' AS DateTime), N'Nữ', 5, 5, 5, 5)
SET IDENTITY_INSERT [dbo].[QLSV_TTSV] OFF
