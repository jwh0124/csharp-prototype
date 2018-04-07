USE [tmpDB]
GO

/****** Object:  Table [dbo].[tbl_hrinfo]    Script Date: 04/08/2013 13:05:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_hrinfo](
	[seq] [int] IDENTITY(1,1) NOT NULL,
	[emp_no] [nvarchar](50) NOT NULL,
	[emp_nm] [nvarchar](50) NULL,
	[phone_no] [nvarchar](50) NULL,
	[sex] [char](1) NULL,
	[remarks] [nvarchar](500) NULL,
 CONSTRAINT [PK_tbl_hrinfo] PRIMARY KEY CLUSTERED 
(
	[seq] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


