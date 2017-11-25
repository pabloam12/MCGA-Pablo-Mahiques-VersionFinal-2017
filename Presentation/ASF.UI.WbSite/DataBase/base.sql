/*==============================================================*/
/* Data Model: LeatherGoods 1.0                                 */
/*                                                              */
/* Leather goods							                    */
/* Marroquinería						                        */
/*==============================================================*/

USE [master]
GO
/****** Object:  Database [LeatherGoods]    Script Date: 7/30/2017 3:34:08 PM ******/
CREATE DATABASE [LeatherGoods]
GO
USE [LeatherGoods]
GO

/*==============================================================*/
/* Table: Comerciante                 	                        */
/*==============================================================*/
create table Dealer (
   Id                   int                  identity,
   FirstName            nvarchar(30)         not null,
   LastName             nvarchar(30)         not null,
   CategoryId           int                  not null,
   CountryId            int                  not null,
   Description          nvarchar(500)        null,
   TotalProducts        int                  not null default 0,
   Rowid				uniqueidentifier 	 default newsequentialid(),
   CreatedOn            datetime             not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime             not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_Dealer primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IndexDealerLastName                                   */
/*==============================================================*/
create index IndexDealerLastName on Dealer (
LastName ASC
)
go

/*==============================================================*/
/* Index: IndexDealerCountry                                    */
/*==============================================================*/
create index IndexDealerCountry on Dealer (
CountryId ASC
)
go

/*==============================================================*/
/* Table: Cart                                                  */
/*==============================================================*/
create table Cart (
   Id                   int                  identity,
   Cookie               nvarchar(40)         not null,
   CartDate             datetime             not null default getdate(),
   ItemCount            int                  not null default 0,
   Rowid				uniqueidentifier 	 default newsequentialid(),
   CreatedOn            datetime             not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime             not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_CART primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IndexCartCookie                                       */
/*==============================================================*/
create index IndexCartCookie on Cart (
Cookie ASC
)
go

/*==============================================================*/
/* Table: CartItem                                              */
/*==============================================================*/
create table CartItem (
   Id                   int                  identity,
   CartId               int                  not null,
   ProductId            int                  not null,
   Price                float                not null,
   Quantity             int                  not null default 1,
   CreatedOn            datetime             not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime             not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_CARTITEM primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IndexCartItemCartId                                   */
/*==============================================================*/
create index IndexCartItemCartId on CartItem (
CartId ASC
)
go

/*==============================================================*/
/* Table: Error                                                 */
/*==============================================================*/
create table Error (
   Id                   int                  identity,
   ClientId               int                  null,
   ErrorDate            datetime             null default getdate(),
   IpAddress            nvarchar(40)         null,
   ClientAgent            nvarchar(max)        null,
   Exception            nvarchar(max)        null,
   Message              nvarchar(max)        null,
   Everything           nvarchar(max)        null,
   HttpReferer          nvarchar(500)        null,
   PathAndQuery         nvarchar(500)        null,
   CreatedBy            int                  null,
   CreatedOn            datetime             not null default getdate(),
   ChangedBy            int                  null,
   ChangedOn            datetime             not null default getdate(),
   constraint PK_ERROR primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IndexErrorDate                                        */
/*==============================================================*/
create index IndexErrorDate on Error (
ErrorDate ASC
)
go

/*==============================================================*/
/* Table: "Order"                                               */
/*==============================================================*/
create table "Order" (
   Id                   int                  identity,
   ClientId             int                  not null,
   OrderDate            datetime             not null,
   TotalPrice           float                not null default 0,
   State               	int					 constraint CKC_GSTATE_ORDER check (State in ('Approved','Cancelled','Closed','Suspended','Reviewed')),
   OrderNumber          int                  not null default 0,
   ItemCount            int                  not null default 0,
   Rowid				uniqueidentifier 	 default newsequentialid(),
   CreatedOn            datetime             not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime             not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_ORDER primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IndexOrderDate                                        */
/*==============================================================*/
create index IndexOrderDate on "Order" (
OrderDate ASC
)
go

/*==============================================================*/
/* Index: IndexOrderClientId                                      */
/*==============================================================*/
create index IndexOrderClientId on "Order" (
ClientId ASC
)
go

/*==============================================================*/
/* Index: IndexOrderOrderNumber                                 */
/*==============================================================*/
create index IndexOrderOrderNumber on "Order" (
OrderNumber ASC
)
go

/*==============================================================*/
/* Table: OrderDetail                                           */
/*==============================================================*/
create table OrderDetail (
   Id                   int                  identity,
   OrderId              int                  not null,
   ProductId            int                  not null,
   Price                float                not null,
   Quantity             int                  not null default 1,
   CreatedOn            datetime             not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime             not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_ORDERDETAIL primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IndexOrderDetailOrderId                               */
/*==============================================================*/
create index IndexOrderDetailOrderId on OrderDetail (
OrderId ASC
)
go

/*==============================================================*/
/* Table: OrderNumber                                           */
/*==============================================================*/
create table OrderNumber (
   Id                   int                  identity,
   Number               int                  not null,
   CreatedOn            datetime             not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime             not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_ORDERNUMBER primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IndexOrderNumber                                      */
/*==============================================================*/
create index IndexOrderNumber on OrderNumber (
Number ASC
)
go

/*==============================================================*/
/* Table: Product                                               */
/*==============================================================*/
create table Product (
   Id                   int                  identity,
   Title                nvarchar(100)        not null,
   Description          nvarchar(250)        null,
   DealerId             int                  not null,
   Image                nvarchar(30)         not null,
   Price                float                not null,
   QuantitySold         int                  not null default 0,
   AvgStars             float                not null default 0,
   Rowid				uniqueidentifier 	 default newsequentialid(),
   CreatedOn            datetime             not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime             not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_PRODUCT primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IndexProductTitle                                     */
/*==============================================================*/
create index IndexProductTitle on Product (
Title ASC
)
go

/*==============================================================*/
/* Index: IndexProductDealerId                                  */
/*==============================================================*/
create index IndexProductDealerId on Product (
DealerId ASC
)
go

/*==============================================================*/
/* Index: IndexProductPrice                                     */
/*==============================================================*/
create index IndexProductPrice on Product (
Price ASC
)
go

/*==============================================================*/
/* Index: IndexProductAvgStars                                  */
/*==============================================================*/
create index IndexProductAvgStars on Product (
AvgStars ASC
)
go

/*==============================================================*/
/* Index: IndexProductQuantitySold                              */
/*==============================================================*/
create index IndexProductQuantitySold on Product (
QuantitySold ASC
)
go

/*==============================================================*/
/* Table: Rating                                                */
/*==============================================================*/
create table Rating (
   Id                   int                  identity,
   ClientId               int                  not null,
   ProductId            int                  not null,
   Stars                int                  not null,
   CreatedOn            datetime             not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime             not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_RATING primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IndexRatingClientId                                     */
/*==============================================================*/
create index IndexRatingClientId on Rating (
ClientId ASC
)
go

/*==============================================================*/
/* Index: IndexRatingProductId                                  */
/*==============================================================*/
create index IndexRatingProductId on Rating (
ProductId ASC
)
go

/*==============================================================*/
/* Table: "Client"                                                */
/*==============================================================*/
create table "Client" (
   Id                   int                  identity,
   FirstName            nvarchar(30)         not null,
   LastName             nvarchar(30)         not null,
   Email                nvarchar(100)        not null,
   CountryId            int                  not null,
   AspNetUsers			nvarchar(128) 	 	 not null,
   City                 nvarchar(30)         null,   
   SignupDate           datetime             not null default getdate(),
   Rowid				uniqueidentifier 	 default newsequentialid(),
   OrderCount           int                  not null default 0,
   CreatedOn            datetime             not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime             not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_Client primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IndexClientLastName                                     */
/*==============================================================*/
create index IndexClientLastName on "Client" (
LastName ASC
)
go

/*==============================================================*/
/* Index: IndexClientEmail                                        */
/*==============================================================*/
create unique index IndexClientEmail on "Client" (
Email ASC
)
go

/*==============================================================*/
/* Index: IndexOrderCount                                       */
/*==============================================================*/
create index IndexOrderCount on "Client" (
OrderCount ASC
)
go

alter table CartItem
   add constraint FK_CARTITEM_REFERENCE_CART foreign key (CartId)
      references Cart (Id)
go

alter table "Order"
   add constraint FK_ORDER_REFERENCE_Client foreign key (ClientId)
      references "Client" (Id)
go

alter table OrderDetail
   add constraint FK_ORDERDET_REFERENCE_ORDER foreign key (OrderId)
      references "Order" (Id)
go

alter table OrderDetail
   add constraint FK_ORDERDET_REFERENCE_PRODUCT foreign key (ProductId)
      references Product (Id)
go

alter table Product
   add constraint FK_PRODUCT_REFERENCE_Dealer foreign key (DealerId)
      references Dealer (Id)
go

alter table Rating
   add constraint FK_RATING_REFERENCE_Client foreign key (ClientId)
      references "Client" (Id)
go

alter table Rating
   add constraint FK_RATING_REFERENCE_PRODUCT foreign key (ProductId)
      references Product (Id)
go

/*==============================================================*/
/* Table: Setting                                               */
/*==============================================================*/
create table Setting (
	Id                  int                 identity,
	Name                nvarchar(30)        not null,
	Value               nvarchar(255)       not null,
	Description         nvarchar(max)       null,   
	LastChangeDate      datetime2           not null default getdate(),
	WebSiteName 		nvarchar(500) 		null,
	WebSiteUrl 			nvarchar(500) 		null,
	PageTitle 			nvarchar(80) 		null,
	AdminEmailAddress 	nvarchar(100) 		null,	
	SMTP 				varchar(100) 		null,
	SMTPUsername 		nvarchar(100) 		null,
	SMTPPassword 		nvarchar(100) 		null,
	SMTPPort 			nvarchar(10) 		null,
	SMTPEnableSSL 		bit 				null,
	Theme 				nvarchar(100) 		null,
	DefaultLanguageId 	int 				not null,
	CreatedOn           datetime2			not null default getdate(),
	CreatedBy           int					null,
	ChangedOn           datetime2			not null default getdate(),
	ChangedBy           int					null,
	constraint PK_SETTING primary key (Id)
)
go

/*==============================================================*/
/* Index: IndexSettingName                                      */
/*==============================================================*/
create index IndexSettingName on Setting (
Name ASC
)
go

/*==============================================================*/
/* Table: Category                                              */
/*==============================================================*/
create table Category (
   Id                   int                  identity,
   Name                 nvarchar(30)         not null,
   CreatedOn            datetime2            not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime2            not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_CATEGORY primary key (Id)
)
go

/*==============================================================*/
/* Index: IndexCategoryName                                     */
/*==============================================================*/
create index IndexCategoryName on Category (
Name ASC
)
go

/*==============================================================*/
/* Table: Country                                               */
/*==============================================================*/
create table Country (
   Id                   int                  identity,
   Name                 nvarchar(60)         not null,
   CreatedOn            datetime2            not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime2            not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_COUNTRY primary key (Id)
)
go

/*==============================================================*/
/* Index: IndexCountryName                                      */
/*==============================================================*/
create index IndexCountryName on Country (
Name ASC
)
go
/*==============================================================*/
/* LANGUAGE & LANGUAGE                                      */
/*==============================================================*/

/****** Object:  Table [dbo].[Language]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Id] int identity,
	[Name] [nvarchar](100) NOT NULL,
	[LanguageCulture] [nvarchar](20) NOT NULL,
	[FlagImageFileName] [nvarchar](50) NULL,
	[RightToLeft] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LocaleResourceKey]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocaleResourceKey](
	[Id] int identity,
	[Name] [nvarchar](200) NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[DateAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.LocaleResourceKey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LocaleStringResource]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocaleStringResource](
	[Id] int identity,
	[ResourceValue] [nvarchar](1000) NOT NULL,
	[LocaleResourceKey_Id] [int] NOT NULL,
	[Language_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LocaleStringResource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[LocaleStringResource]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LocaleStringResource_dbo.Language_Language_Id] FOREIGN KEY([Language_Id])
REFERENCES [dbo].[Language] ([Id])
GO
ALTER TABLE [dbo].[LocaleStringResource] CHECK CONSTRAINT [FK_dbo.LocaleStringResource_dbo.Language_Language_Id]
GO
ALTER TABLE [dbo].[LocaleStringResource]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LocaleStringResource_dbo.LocaleResourceKey_LocaleResourceKey_Id] FOREIGN KEY([LocaleResourceKey_Id])
REFERENCES [dbo].[LocaleResourceKey] ([Id])
GO
ALTER TABLE [dbo].[LocaleStringResource] CHECK CONSTRAINT [FK_dbo.LocaleStringResource_dbo.LocaleResourceKey_LocaleResourceKey_Id]
GO


/*==============================================================*/
/* ADD CONSTRAINT                                      */
/*==============================================================*/

alter table Dealer
   add constraint FK_DEALER_REFERENCE_CATEGORY foreign key (CategoryId)
      references Category (Id)
go

alter table Dealer
   add constraint FK_DEALER_REFERENCE_COUNTRY foreign key (CountryId)
      references Country (Id)
go

alter table Client
   add constraint FK_CLIENT_REFERENCE_COUNTRY foreign key (CountryId)
      references Country (Id)
go

/*==============================================================*/
/* ASP.NET MEMBERSHIP                                     */
/*==============================================================*/

/****** Object:  Table [dbo].[AspNetRoles]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bb205337-35c4-45cf-918a-3bad95d1f29b', N'admin@asf.com', 0, N'APIIq9WPfFOfNq0O7pweDgv/b4p91FY2QgKv0LHpl1sHlFfK3oWeg3z2Xfe7eLbCgw==', N'8253afe7-4f35-4e63-be52-4de57eca4363', NULL, 0, 0, NULL, 1, 0, N'admin@asf.com')
GO
USE [master]
GO
ALTER DATABASE [LeatherGoods] SET  READ_WRITE 
GO
