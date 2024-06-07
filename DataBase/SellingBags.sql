USE [master]
GO
/****** Object:  Database [SellingBags]    Script Date: 06/07/2024 3:30:48 PM ******/
CREATE DATABASE [SellingBags]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SellingBags', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\SellingBags.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SellingBags_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\SellingBags_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SellingBags] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SellingBags].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SellingBags] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SellingBags] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SellingBags] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SellingBags] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SellingBags] SET ARITHABORT OFF 
GO
ALTER DATABASE [SellingBags] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SellingBags] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SellingBags] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SellingBags] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SellingBags] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SellingBags] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SellingBags] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SellingBags] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SellingBags] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SellingBags] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SellingBags] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SellingBags] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SellingBags] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SellingBags] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SellingBags] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SellingBags] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SellingBags] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SellingBags] SET RECOVERY FULL 
GO
ALTER DATABASE [SellingBags] SET  MULTI_USER 
GO
ALTER DATABASE [SellingBags] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SellingBags] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SellingBags] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SellingBags] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SellingBags] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SellingBags] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SellingBags', N'ON'
GO
ALTER DATABASE [SellingBags] SET QUERY_STORE = ON
GO
ALTER DATABASE [SellingBags] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SellingBags]
GO
/****** Object:  User [IIS APPPOOL\Sellings]    Script Date: 06/07/2024 3:30:49 PM ******/
CREATE USER [IIS APPPOOL\Sellings] FOR LOGIN [IIS APPPOOL\Sellings] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\DefaultAppPool]    Script Date: 06/07/2024 3:30:49 PM ******/
CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\Sellings]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\Sellings]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID_Account] [char](10) NOT NULL,
	[UserName] [nchar](50) NOT NULL,
	[Password] [nchar](50) NOT NULL,
	[ID_Role] [char](10) NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID_Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[ID_Address] [char](10) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[PhoneNumber] [char](10) NULL,
	[Ward] [nvarchar](50) NULL,
	[District] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[ID_Customer] [char](10) NULL,
	[SpecificAddress] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Address] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[ID_Brand] [char](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ImageURL] [nvarchar](max) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[ID_Brand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[ID_Cart] [char](10) NOT NULL,
	[Quantity] [int] NULL,
	[ID_Product] [char](10) NOT NULL,
	[ID_Account] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Cart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID_Category] [char](10) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[ImageURL] [nvarchar](20) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID_Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID_Customer] [char](10) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nchar](30) NULL,
	[PhoneNumber] [nchar](20) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](50) NULL,
	[ID_Account] [char](10) NOT NULL,
	[Ward] [nvarchar](50) NULL,
	[District] [nvarchar](50) NULL,
	[BirthDay] [date] NULL,
	[Gender] [nvarchar](5) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID_Customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[ID_Discount] [char](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Percents] [int] NULL,
	[ID_Product] [char](10) NOT NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[ID_Discount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID_OrderDetail] [char](10) NOT NULL,
	[ID_Order] [char](10) NOT NULL,
	[ID_Product] [char](10) NOT NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[ID_OrderDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID_Order] [char](10) NOT NULL,
	[Status] [int] NULL,
	[OrderDate] [datetime] NULL,
	[ID_Customer] [char](10) NOT NULL,
	[DeliDate] [date] NULL,
	[TotalMoney] [decimal](18, 0) NULL,
	[ShippingMethod] [nvarchar](50) NULL,
	[PaymentMethod] [nvarchar](50) NULL,
	[ID_Address] [char](10) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[ID_Payment] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ImageURL] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Payment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID_Product] [char](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Size] [nchar](10) NULL,
	[Color] [nchar](30) NULL,
	[Price] [decimal](18, 2) NULL,
	[Description] [nvarchar](max) NULL,
	[ID_Type] [char](10) NOT NULL,
	[ID_Brand] [char](10) NOT NULL,
	[ImageURL] [nvarchar](100) NULL,
	[Quantity] [int] NULL,
	[DateCreated] [date] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[ID_Type] [char](10) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[ImageURL] [nvarchar](100) NULL,
	[ID_Category] [char](10) NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[ID_Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID_Role] [char](10) NOT NULL,
	[Name] [nchar](20) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipping]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipping](
	[ID_Shipping] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[DeliTime] [nvarchar](50) NULL,
	[DeliDate] [int] NULL,
	[Cost] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Shipping] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WishList]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WishList](
	[ID_WishList] [char](10) NOT NULL,
	[ID_Product] [char](10) NOT NULL,
	[ID_Account] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_WishList] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([ID_Role])
REFERENCES [dbo].[Role] ([ID_Role])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Customer] FOREIGN KEY([ID_Customer])
REFERENCES [dbo].[Customer] ([ID_Customer])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Customer]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Account] FOREIGN KEY([ID_Account])
REFERENCES [dbo].[Account] ([ID_Account])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Account]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Product] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Product] ([ID_Product])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Product]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Account] FOREIGN KEY([ID_Account])
REFERENCES [dbo].[Account] ([ID_Account])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Account]
GO
ALTER TABLE [dbo].[Discount]  WITH CHECK ADD  CONSTRAINT [FK_Discount_Product] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Product] ([ID_Product])
GO
ALTER TABLE [dbo].[Discount] CHECK CONSTRAINT [FK_Discount_Product]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[Orders] ([ID_Order])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Product] ([ID_Product])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([ID_Customer])
REFERENCES [dbo].[Customer] ([ID_Customer])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Address] FOREIGN KEY([ID_Address])
REFERENCES [dbo].[Address] ([ID_Address])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Address]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([ID_Brand])
REFERENCES [dbo].[Brand] ([ID_Brand])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ID_Type])
REFERENCES [dbo].[ProductType] ([ID_Type])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
ALTER TABLE [dbo].[ProductType]  WITH CHECK ADD  CONSTRAINT [FK_ProductType_Category] FOREIGN KEY([ID_Category])
REFERENCES [dbo].[Category] ([ID_Category])
GO
ALTER TABLE [dbo].[ProductType] CHECK CONSTRAINT [FK_ProductType_Category]
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_Account] FOREIGN KEY([ID_Account])
REFERENCES [dbo].[Account] ([ID_Account])
GO
ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_Account]
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_Product] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Product] ([ID_Product])
GO
ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_Product]
GO
/****** Object:  StoredProcedure [dbo].[ReloadOrders]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ReloadOrders]
as
UPDATE Orders
SET status = CASE 
    WHEN DeliDate <= SYSDATETIME() AND status = 1 THEN 2
    WHEN DeliDate <= SYSDATETIME() AND status = 0 THEN -1
    ELSE status 
END
WHERE DeliDate <= SYSDATETIME() AND (status = 0 OR status = 1);
GO
/****** Object:  StoredProcedure [dbo].[spBestSeller]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spBestSeller] @month int
as
SELECT top 10 od.ID_Product, Sum(od.Quantity) AS TotalOrders
FROM OrderDetail od
inner JOIN Orders o ON o.ID_Order = od.ID_Order
where month(o.OrderDate) = @month 
GROUP BY od.ID_Product
ORDER BY TotalOrders DESC;
GO
/****** Object:  StoredProcedure [dbo].[spColor]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spColor]
as
select Color from Product
group by Color
GO
/****** Object:  StoredProcedure [dbo].[spDaylyRevenue]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spDaylyRevenue] @today date
as
select SUM(TotalMoney) as Tong from orders 
where Status = 2 and OrderDate = @today
GO
/****** Object:  StoredProcedure [dbo].[spLastCustomer]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spLastCustomer]
as
select top 1 ID_Customer  from Customer
order by ID_Customer desc
GO
/****** Object:  StoredProcedure [dbo].[spLoadAllBrand]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spLoadAllBrand] 
as
	select Name,ImageURL  from Brand 
GO
/****** Object:  StoredProcedure [dbo].[spMonthlyRevenue]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spMonthlyRevenue] @month int
as
select SUM(TotalMoney) as Tong from orders 
where Status = 2 and MONTH(OrderDate) = @month
GO
/****** Object:  StoredProcedure [dbo].[spNewProduct]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spNewProduct]
as
select top 12 * from Product
where DATEDIFF(DAY, DateCreated, SYSDATETIME()) < 30 
GO
/****** Object:  StoredProcedure [dbo].[spProductsByType]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spProductsByType] @ID_Category char(10) 
as 
	select * from Product p
	inner join ProductType t on p.ID_Type = t.ID_Type
	where t.ID_Category = @ID_Category
GO
/****** Object:  StoredProcedure [dbo].[spUpdateQuantityAfterOrder]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUpdateQuantityAfterOrder] @ID_Order char(10)
as
	with QuantityUpdate as (SELECT p.ID_Product ,AVG(p.Quantity) - SUM(od.Quantity) as Quantity
							FROM Product p
							INNER JOIN OrderDetail od ON p.ID_Product = od.ID_Product
							WHERE od.ID_Order = @ID_Order
							GROUP BY p.ID_Product)
	UPDATE Product
	SET Quantity = q.Quantity
	FROM Product p
	INNER JOIN QuantityUpdate q on p.ID_Product = q.ID_Product
GO
/****** Object:  StoredProcedure [dbo].[spYearlyRevenue]    Script Date: 06/07/2024 3:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spYearlyRevenue] @year int
as
select SUM(TotalMoney) as Tong from orders 
where Status = 2 and year(OrderDate) = @year
GO
USE [master]
GO
ALTER DATABASE [SellingBags] SET  READ_WRITE 
GO
