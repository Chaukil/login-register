/****** Script for SelectTopNRows command from SSMS  ******/
create database login
use login

CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
    [PassWord] [nvarchar](50) NOT NULL,
    [Type] [varchar](2) NOT NULL,
	)

INSERT INTO Account([UserName],[DisplayName],[PassWord],[Type]) VALUES ('kil', 'kil','123','1')
INSERT INTO Account([UserName],[DisplayName],[PassWord],[Type]) VALUES ('nhi', 'nhi','123','0')
INSERT INTO Account([UserName],[DisplayName],[PassWord],[Type]) VALUES ('bo', 'bo','123','1')