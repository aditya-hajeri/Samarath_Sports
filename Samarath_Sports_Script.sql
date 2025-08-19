USE [master]
GO
/****** Object:  Database [Samarth_Sports]    Script Date: 19-08-2025 21:37:07 ******/
CREATE DATABASE [Samarth_Sports]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Samarth_Sports', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Samarth_Sports.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Samarth_Sports_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Samarth_Sports_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Samarth_Sports] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Samarth_Sports].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Samarth_Sports] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Samarth_Sports] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Samarth_Sports] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Samarth_Sports] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Samarth_Sports] SET ARITHABORT OFF 
GO
ALTER DATABASE [Samarth_Sports] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Samarth_Sports] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Samarth_Sports] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Samarth_Sports] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Samarth_Sports] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Samarth_Sports] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Samarth_Sports] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Samarth_Sports] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Samarth_Sports] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Samarth_Sports] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Samarth_Sports] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Samarth_Sports] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Samarth_Sports] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Samarth_Sports] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Samarth_Sports] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Samarth_Sports] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Samarth_Sports] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Samarth_Sports] SET RECOVERY FULL 
GO
ALTER DATABASE [Samarth_Sports] SET  MULTI_USER 
GO
ALTER DATABASE [Samarth_Sports] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Samarth_Sports] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Samarth_Sports] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Samarth_Sports] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Samarth_Sports] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Samarth_Sports] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Samarth_Sports] SET QUERY_STORE = ON
GO
ALTER DATABASE [Samarth_Sports] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Samarth_Sports]
GO
/****** Object:  Table [dbo].[Billing_Entry]    Script Date: 19-08-2025 21:37:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Billing_Entry](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[BillingNo] [varchar](50) NULL,
	[CompanyName] [varchar](50) NULL,
	[ProductName] [varchar](50) NULL,
	[ProductCode] [varchar](50) NULL,
	[ProductType] [varchar](50) NULL,
	[ProductCount] [varchar](50) NULL,
	[ProductMRP] [varchar](50) NULL,
	[ProductPrise] [varchar](50) NULL,
 CONSTRAINT [PK_Billing] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillingDetails]    Script Date: 19-08-2025 21:37:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillingDetails](
	[Billing_ID] [int] IDENTITY(1,1) NOT NULL,
	[BillingNo] [varchar](50) NULL,
	[CustomerName] [varchar](1000) NULL,
	[Total_Amount] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Month] [varchar](50) NULL,
	[Year] [varchar](50) NULL,
 CONSTRAINT [PK_BillingString] PRIMARY KEY CLUSTERED 
(
	[Billing_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company_Details]    Script Date: 19-08-2025 21:37:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_Details](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[Company_Name] [varchar](50) NULL,
 CONSTRAINT [PK_Add_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Main_Quotation]    Script Date: 19-08-2025 21:37:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_Quotation](
	[QuotationID] [int] IDENTITY(1,1) NOT NULL,
	[Quotation_No] [varchar](50) NULL,
	[Customer_Name] [varchar](500) NULL,
	[Total_Cost] [varchar](50) NULL,
	[Total_Cost_Text] [varchar](50) NULL,
	[Total_Tax] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Month] [varchar](50) NULL,
	[Year] [varchar](50) NULL,
 CONSTRAINT [PK_Main_Quotation] PRIMARY KEY CLUSTERED 
(
	[QuotationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Details]    Script Date: 19-08-2025 21:37:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Details](
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[Company_Name] [varchar](50) NULL,
	[Product_Name] [varchar](50) NULL,
	[Product_Code] [varchar](50) NULL,
	[Product_Type] [varchar](50) NULL,
	[Size] [varchar](50) NULL,
	[EACH] [varchar](50) NULL,
	[MRP] [varchar](50) NULL,
 CONSTRAINT [PK_Product_Details] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quotation]    Script Date: 19-08-2025 21:37:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotation](
	[QuotationID] [int] IDENTITY(1,1) NOT NULL,
	[MainQuotation_ID] [int] NULL,
	[Quotation_No] [varchar](50) NULL,
	[CompanyName] [varchar](50) NULL,
	[ProductName] [varchar](50) NULL,
	[ProductCode] [varchar](50) NULL,
	[ProductType] [varchar](50) NULL,
	[Rate] [varchar](50) NULL,
	[Discount] [varchar](50) NULL,
	[DiscountAmount] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[TotalAmount] [varchar](50) NULL,
	[Vat] [varchar](50) NULL,
	[GrantTotal] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Month] [varchar](15) NULL,
	[Year] [int] NULL,
 CONSTRAINT [PK_Quotation] PRIMARY KEY CLUSTERED 
(
	[QuotationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock_Management]    Script Date: 19-08-2025 21:37:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_Management](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NULL,
	[ProductType] [varchar](50) NULL,
	[ProductName] [varchar](50) NULL,
	[ProductCode] [varchar](50) NULL,
	[Stock] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
 CONSTRAINT [PK_Stock_Management] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Billing_Entry] ON 
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (1, N'SS/3/17/1', N'NIVEA', N'BAT', N'01323', N'Consumable', N'1', NULL, N'500')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (2, N'SS/3/17/1', N'SPARTAN', N'BALL', N'5624', N'Non Consumable', N'2', NULL, N'1200')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (3, N'SS/3/17/1', N'SPARTAN', N'BASKET BALL', N'1023', N'Consumable', N'2', NULL, N'2000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (4, N'SS/3/17/1', N'SPARTAN', N'BASKET BALL', N'1023', N'Consumable', N'2', NULL, N'2000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (5, N'SS/3/17/1', N'NIVEA', N'BAT', N'01323', N'Consumable', N'1', NULL, N'500')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (7, N'SS/3/17/1', N'NIVEA', N'BAT', N'01323', N'Consumable', N'2', NULL, N'1000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (8, N'SS/3/17/1', N'NIVEA', N'BAT', N'01323', N'Consumable', N'1', NULL, N'500')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (9, N'SS/3/17/1', N'NIVEA', N'BAT', N'01323', N'Consumable', N'1', NULL, N'500')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (10, N'SS/3/17/1', N'NIVEA', N'BAT', N'01323', N'Consumable', N'1', NULL, N'500')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (11, N'SS/3/17/2', N'ADIDAS', N'BAT', N'BAT01', N'Consumable', N'2', NULL, N'6000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (12, N'SS/3/17/2', N'NIVEA', N'BAT NIVEA', N'01323', N'Consumable', N'1', NULL, N'500')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (13, N'SS/3/17/2', N'NIVEA', N'BAT', N'N6874', N'Consumable', N'1', NULL, N'400')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (14, N'SS/3/17/2', N'ADIDAS', N'BAT ADIDAS', N'BAT01', N'Consumable', N'1', NULL, N'3000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (15, N'SS/3/17/2', N'SPARTAN', N'BASKET BALL', N'1023', N'Consumable', N'2', NULL, N'2000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (16, N'SS/3/17/3', N'NIVEA', N'BAT', N'N6874', N'Consumable', N'2', N'400', N'800')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (17, N'SS/3/17/3', N'ADIDAS', N'BAT ADIDAS', N'BAT01', N'Consumable', N'1', N'3000', N'3000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (18, N'SS/3/17/4', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'2', N'200', N'400')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (19, N'SS/3/17/4', N'ADIDAS', N'BAT ADIDAS', N'BAT01', N'Consumable', N'1', N'3000', N'3000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (20, N'SS/3/17/4', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'2', N'200', N'400')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (21, N'SS/3/17/5', N'ADIDAS', N'BAT ADIDAS', N'BAT01', N'Consumable', N'1', N'3000', N'3000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (22, N'SS/3/17/5', N'ADIDAS', N'BAT ADIDAS', N'BAT01', N'Consumable', N'1', N'3000', N'3000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (23, N'SS/3/17/5', N'SPARTAN', N'BALL', N'5624', N'Non Consumable', N'1', N'600', N'600')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (24, N'SS/3/17/6', N'SPARTAN', N'BASKET BALL', N'1023', N'Consumable', N'2', N'1000', N'2000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (25, N'SS/3/17/7', N'ADIDAS', N'BAT ADIDAS', N'BAT01', N'Consumable', N'0', N'3000', N'0')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (26, N'SS/3/17/8', N'ADIDAS', N'BAT ADIDAS', N'BAT01', N'Consumable', N'0', N'3000', N'0')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (27, N'SS/4/17/8', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'5', N'200', N'1000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (28, N'SS/4/17/8', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'6', N'200', N'1200')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (29, N'SS/4/17/9', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'15', N'200', N'3000')
GO
INSERT [dbo].[Billing_Entry] ([BillID], [BillingNo], [CompanyName], [ProductName], [ProductCode], [ProductType], [ProductCount], [ProductMRP], [ProductPrise]) VALUES (30, N'SS/8/25/10', N'ADIDAS', N'BAT ADIDAS', N'BAT01', N'Consumable', N'2', N'3000', N'6000')
GO
SET IDENTITY_INSERT [dbo].[Billing_Entry] OFF
GO
SET IDENTITY_INSERT [dbo].[BillingDetails] ON 
GO
INSERT [dbo].[BillingDetails] ([Billing_ID], [BillingNo], [CustomerName], [Total_Amount], [Date], [Month], [Year]) VALUES (1, N'SS/3/17/1', N'ihagad Institute', N'9200', N'13--03-2017', N'March', N'2017')
GO
INSERT [dbo].[BillingDetails] ([Billing_ID], [BillingNo], [CustomerName], [Total_Amount], [Date], [Month], [Year]) VALUES (2, N'SS/3/17/2', N'ABC Group', N'11900', N'13-03-2017', N'March', N'2017')
GO
INSERT [dbo].[BillingDetails] ([Billing_ID], [BillingNo], [CustomerName], [Total_Amount], [Date], [Month], [Year]) VALUES (3, N'SS/3/17/3', N'Kembrij School', N'3800', N'14-03-2017', N'March', N'2017')
GO
INSERT [dbo].[BillingDetails] ([Billing_ID], [BillingNo], [CustomerName], [Total_Amount], [Date], [Month], [Year]) VALUES (4, N'SS/3/17/4', N'ww', N'3800', N'31-03-2017', N'March', N'2017')
GO
INSERT [dbo].[BillingDetails] ([Billing_ID], [BillingNo], [CustomerName], [Total_Amount], [Date], [Month], [Year]) VALUES (5, N'SS/3/17/5', N'rrr', N'6600', N'31-03-2017', N'March', N'2017')
GO
INSERT [dbo].[BillingDetails] ([Billing_ID], [BillingNo], [CustomerName], [Total_Amount], [Date], [Month], [Year]) VALUES (6, N'SS/3/17/6', N'WW', N'2000', N'31-03-2017', N'March', N'2017')
GO
INSERT [dbo].[BillingDetails] ([Billing_ID], [BillingNo], [CustomerName], [Total_Amount], [Date], [Month], [Year]) VALUES (7, N'SS/3/17/7', N'TT', N'0', N'31-03-2017', N'March', N'2017')
GO
INSERT [dbo].[BillingDetails] ([Billing_ID], [BillingNo], [CustomerName], [Total_Amount], [Date], [Month], [Year]) VALUES (8, N'SS/4/17/8', N'www', N'2200', N'05-04-2017', N'April', N'2017')
GO
INSERT [dbo].[BillingDetails] ([Billing_ID], [BillingNo], [CustomerName], [Total_Amount], [Date], [Month], [Year]) VALUES (9, N'SS/4/17/9', N'aaaaa', N'3000', N'05-04-2017', N'April', N'2017')
GO
INSERT [dbo].[BillingDetails] ([Billing_ID], [BillingNo], [CustomerName], [Total_Amount], [Date], [Month], [Year]) VALUES (10, N'SS/8/25/10', N'Aditya', N'6000', N'19-08-2025', N'August', N'2025')
GO
SET IDENTITY_INSERT [dbo].[BillingDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Company_Details] ON 
GO
INSERT [dbo].[Company_Details] ([CompanyID], [Company_Name]) VALUES (1, N'adidas')
GO
INSERT [dbo].[Company_Details] ([CompanyID], [Company_Name]) VALUES (2, N'SPARTAN')
GO
INSERT [dbo].[Company_Details] ([CompanyID], [Company_Name]) VALUES (3, N'PUMA')
GO
INSERT [dbo].[Company_Details] ([CompanyID], [Company_Name]) VALUES (6, N'AAAA')
GO
INSERT [dbo].[Company_Details] ([CompanyID], [Company_Name]) VALUES (7, N'NIVEA')
GO
INSERT [dbo].[Company_Details] ([CompanyID], [Company_Name]) VALUES (8, N'SHIV-NARESH')
GO
INSERT [dbo].[Company_Details] ([CompanyID], [Company_Name]) VALUES (9, N'REEBOK')
GO
INSERT [dbo].[Company_Details] ([CompanyID], [Company_Name]) VALUES (10, N'XYZ')
GO
INSERT [dbo].[Company_Details] ([CompanyID], [Company_Name]) VALUES (11, N'WWW')
GO
INSERT [dbo].[Company_Details] ([CompanyID], [Company_Name]) VALUES (12, N'BHAGYODAY ENTERPRISES')
GO
SET IDENTITY_INSERT [dbo].[Company_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Main_Quotation] ON 
GO
INSERT [dbo].[Main_Quotation] ([QuotationID], [Quotation_No], [Customer_Name], [Total_Cost], [Total_Cost_Text], [Total_Tax], [Date], [Month], [Year]) VALUES (1, N'SS/03/17/01', N'W', N'13000', N'', N'100', N'30-03-2017', N'March', N'2017')
GO
INSERT [dbo].[Main_Quotation] ([QuotationID], [Quotation_No], [Customer_Name], [Total_Cost], [Total_Cost_Text], [Total_Tax], [Date], [Month], [Year]) VALUES (2, N'SS/04/17/02', N'Kembrij School,
Satara - Katarj Road,
Near Swarget', N'25386', N'', N'200', N'01-04-2017', N'April', N'2017')
GO
INSERT [dbo].[Main_Quotation] ([QuotationID], [Quotation_No], [Customer_Name], [Total_Cost], [Total_Cost_Text], [Total_Tax], [Date], [Month], [Year]) VALUES (3, N'SS/04/17/03', N'w', N'17786', N'', N'8', N'14/04/2017', N'April', N'2017')
GO
INSERT [dbo].[Main_Quotation] ([QuotationID], [Quotation_No], [Customer_Name], [Total_Cost], [Total_Cost_Text], [Total_Tax], [Date], [Month], [Year]) VALUES (4, N'SS/04/17/04', N'eeee', N'2302', N'', N'219', N'14/04/2017', N'April', N'2017')
GO
INSERT [dbo].[Main_Quotation] ([QuotationID], [Quotation_No], [Customer_Name], [Total_Cost], [Total_Cost_Text], [Total_Tax], [Date], [Month], [Year]) VALUES (5, N'SS/04/17/05', N'Tures', N'17988', N'', N'388', N'14/04/2017', N'April', N'2017')
GO
INSERT [dbo].[Main_Quotation] ([QuotationID], [Quotation_No], [Customer_Name], [Total_Cost], [Total_Cost_Text], [Total_Tax], [Date], [Month], [Year]) VALUES (6, N'SS/08/25/06', N'Aditya', N'2475', N'', N'225', N'19-08-2025', N'August', N'2025')
GO
SET IDENTITY_INSERT [dbo].[Main_Quotation] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Details] ON 
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (1, N'ADIDAS', N'BAT ADIDAS', N'BAT01', N'Consumable', N'SH', N'EACH', N'3000')
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (4, N'SPARTAN', N'PAD', N'PAD02', N'Non Consumable', N'PAIR', N'PAIR', N'2500')
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (5, N'ASSS', N'SFSDE', N'dfsdfsssss', N'Consumable', N'System.Windows.Forms.TextBox, Text: ds', N'System.Windows.Forms.TextBox, Text: ds', N'System.Windows.Forms.TextBox, Text: 2000')
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (6, N'SPARTAN', N'BASKET BALL', N'1023', N'Consumable', N'hs', N'Pre', N'1000')
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (7, N'NIVEA', N'BAT NIVEA', N'01323', N'Consumable', N'SH', N'PRE', N'500')
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (8, N'SPARTAN', N'FOOTBALL', N'4156', N'Consumable', N'hs', N'each', N'3000')
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (9, N'XYZ', N'BASE BALL', N'78965', N'Consumable', N'hs', N'pre', N'200')
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (10, N'SPARTAN', N'BALL', N'5624', N'Non Consumable', N'HS', N'PRE', N'600')
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (11, N'NIVEA', N'BAT', N'N6874', N'Consumable', N'HS', N'EACG', N'400')
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (12, N'NIVEA', N'FOOTBALL', N'7896', N'Consumable', N'sh', N'PCS', N'400')
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (13, N'WWW', N'W1BAT', N'wbat', N'Consumable', N'sh', N'PAIR', N'600')
GO
INSERT [dbo].[Product_Details] ([Product_ID], [Company_Name], [Product_Name], [Product_Code], [Product_Type], [Size], [EACH], [MRP]) VALUES (14, N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'sh', N'PCS', N'200')
GO
SET IDENTITY_INSERT [dbo].[Product_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Quotation] ON 
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (1, 1, N'SS/03/17/01', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'0', N'200', 2, N'400', N'0', N'400', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (2, 1, N'SS/03/17/01', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'0', N'200', 5, N'1000', N'0', N'1000', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (3, 1, N'SS/03/17/01', N'SPARTAN', N'FOOTBALL', N'4156', N'Consumable', N'3000', N'0', N'3000', 3, N'9000', N'0', N'9000', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (4, 1, N'SS/03/17/01', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'0', N'200', 3, N'600', N'0', N'600', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (5, 1, N'SS/03/17/01', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'0', N'200', 2, N'400', N'0', N'400', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (6, 1, N'SS/03/17/01', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'0', N'200', 2, N'400', N'0', N'400', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (7, 1, N'SS/03/17/01', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'0', N'200', 2, N'400', N'0', N'400', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (8, 1, N'SS/03/17/01', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'0', N'200', 1, N'200', N'0', N'200', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (9, 1, N'SS/03/17/01', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'0', N'200', 1, N'200', N'0', N'200', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (10, 1, N'SS/03/17/01', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'0', N'200', 1, N'200', N'0', N'200', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (11, 1, N'SS/03/17/01', N'WWW', N'WBALL2', N'W456', N'Non Consumable', N'200', N'0', N'200', 1, N'200', N'0', N'200', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (12, 1, N'SS/03/17/01', N'WWW', N'WBALL2', N'W456', N'Non Consumable', N'200', N'0', N'200', 0, N'0', N'0', N'0', N'30-03-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (13, 2, N'SS/04/17/02', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'10', N'180', 2, N'360', N'10', N'396', N'01-04-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (14, 2, N'SS/04/17/02', N'SPARTAN', N'PAD', N'PAD02', N'Non Consumable', N'2500', N'2', N'2450', 10, N'24500', N'2', N'24990', N'01-04-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (15, 3, N'SS/04/17/03', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'10', N'180', 5, N'900', N'6', N'954', N'05-04-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (16, 3, N'SS/04/17/03', N'WWW', N'WBALL2', N'w456', N'Non Consumable', N'200', N'10', N'180', 5, N'900', N'6', N'954', N'05-04-2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (17, 3, N'SS/04/17/03', N'NIVEA', N'BAT NIVEA', N'01323', N'Consumable', N'500', N'0', N'500', 5, N'2500', N'10', N'2750', N'14/04/2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (18, 3, N'SS/04/17/03', N'SPARTAN', N'FOOTBALL', N'4156', N'Consumable', N'3000', N'0', N'3000', 2, N'6000', N'6', N'6360', N'14/04/2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (19, 3, N'SS/04/17/03', N'SPARTAN', N'FOOTBALL', N'4156', N'Consumable', N'3000', N'0', N'3000', 2, N'6000', N'6', N'6360', N'14/04/2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (20, 3, N'SS/04/17/03', N'NIVEA', N'BAT', N'n6874', N'Consumable', N'400', N'0', N'400', 1, N'400', N'2', N'408', N'14/04/2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (21, 4, N'SS/04/17/04', N'NIVEA', N'BAT NIVEA', N'01323', N'Consumable', N'500', N'0', N'500', 2, N'1000', N'3', N'1030', N'14/04/2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (22, 4, N'SS/04/17/04', N'SPARTAN', N'BALL', N'5624', N'Non Consumable', N'600', N'0', N'600', 2, N'1200', N'6', N'1272', N'14/04/2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (23, 5, N'SS/04/17/05', N'NIVEA', N'BAT', N'n6874', N'Consumable', N'400', N'0', N'400', 2, N'800', N'2', N'816', N'14/04/2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (24, 5, N'SS/04/17/05', N'NIVEA', N'BAT NIVEA', N'01323', N'Consumable', N'500', N'0', N'500', 30, N'15000', N'2', N'15300', N'14/04/2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (25, 5, N'SS/04/17/05', N'SPARTAN', N'BALL', N'5624', N'Non Consumable', N'600', N'0', N'600', 3, N'1800', N'4', N'1872', N'14/04/2017', NULL, NULL)
GO
INSERT [dbo].[Quotation] ([QuotationID], [MainQuotation_ID], [Quotation_No], [CompanyName], [ProductName], [ProductCode], [ProductType], [Rate], [Discount], [DiscountAmount], [Quantity], [TotalAmount], [Vat], [GrantTotal], [Date], [Month], [Year]) VALUES (26, 6, N'SS/08/25/06', N'ADIDAS', N'BAT ADIDAS', N'bat01', N'Consumable', N'3000', N'0', N'45', 50, N'2250', N'10', N'2475', N'19-08-2025', N'August', 2025)
GO
SET IDENTITY_INSERT [dbo].[Quotation] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock_Management] ON 
GO
INSERT [dbo].[Stock_Management] ([StockID], [CompanyName], [ProductType], [ProductName], [ProductCode], [Stock], [Date]) VALUES (1, N'ADIDAS', N'Consumable', N'BAT ADIDAS', N'BAT01', N'3', NULL)
GO
INSERT [dbo].[Stock_Management] ([StockID], [CompanyName], [ProductType], [ProductName], [ProductCode], [Stock], [Date]) VALUES (2, N'NIVEA', N'Consumable', N'BAT', N'01323', N'5', NULL)
GO
INSERT [dbo].[Stock_Management] ([StockID], [CompanyName], [ProductType], [ProductName], [ProductCode], [Stock], [Date]) VALUES (3, N'SPARTAN', N'Non Consumable', N'BALL', N'5624', N'27', NULL)
GO
INSERT [dbo].[Stock_Management] ([StockID], [CompanyName], [ProductType], [ProductName], [ProductCode], [Stock], [Date]) VALUES (8, N'SPARTAN', N'Consumable', N'FOOTBALL', N'4156', N'40', N'25-03-2017')
GO
INSERT [dbo].[Stock_Management] ([StockID], [CompanyName], [ProductType], [ProductName], [ProductCode], [Stock], [Date]) VALUES (10, N'NIVEA', N'Consumable', N'BAT', N'N6874', N'3', NULL)
GO
INSERT [dbo].[Stock_Management] ([StockID], [CompanyName], [ProductType], [ProductName], [ProductCode], [Stock], [Date]) VALUES (11, N'XYZ', N'Consumable', N'BASE BALL', N'78965', N'30', N'09-03-2017')
GO
INSERT [dbo].[Stock_Management] ([StockID], [CompanyName], [ProductType], [ProductName], [ProductCode], [Stock], [Date]) VALUES (12, N'WWW', N'Consumable', N'W1BAT', N'wbat', N'30', N'30-03-2017')
GO
INSERT [dbo].[Stock_Management] ([StockID], [CompanyName], [ProductType], [ProductName], [ProductCode], [Stock], [Date]) VALUES (13, N'WWW', N'Consumable', N'FOOT BALL', N'w4568', N'20', N'30-03-2017')
GO
SET IDENTITY_INSERT [dbo].[Stock_Management] OFF
GO
USE [master]
GO
ALTER DATABASE [Samarth_Sports] SET  READ_WRITE 
GO
