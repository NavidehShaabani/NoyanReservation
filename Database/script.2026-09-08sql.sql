USE [Tower]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[BuildingId] [bigint] IDENTITY(1,1) NOT NULL,
	[BuildingName] [nvarchar](150) NOT NULL,
	[BuildingAddress] [nvarchar](500) NULL,
	[BuildingDescription] [nvarchar](1000) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
	[OrgId] [bigint] NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAssignments]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAssignments](
	[EmployeeAssignmentId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [bigint] NOT NULL,
	[OrgId] [bigint] NOT NULL,
	[BuildingId] [bigint] NULL,
	[SpaceId] [bigint] NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[ShiftName] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[EmployeeAssignmentDesc] [nvarchar](1000) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_EmployeeAssignments] PRIMARY KEY CLUSTERED 
(
	[EmployeeAssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[OrgId] [bigint] NOT NULL,
	[EmployeeTypeId] [int] NOT NULL,
	[EmploymentType] [tinyint] NOT NULL,
	[HireDate] [date] NULL,
	[EndDate] [date] NULL,
	[BaseSalary] [decimal](18, 2) NULL,
	[HourlyRate] [decimal](18, 2) NULL,
	[BankName] [nvarchar](100) NULL,
	[BankCardNumber] [nvarchar](100) NULL,
	[BankAccountNumber] [nvarchar](100) NULL,
	[ShebaNumber] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[EmployeesDesc] [nvarchar](2000) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeTypes]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeTypes](
	[EmployeeTypeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeTypeName] [nvarchar](100) NOT NULL,
	[EmployeeTypeDesc] [nvarchar](500) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_EmployeeTypes] PRIMARY KEY CLUSTERED 
(
	[EmployeeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[MenuId] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentId] [bigint] NULL,
	[Title] [nvarchar](150) NOT NULL,
	[MenuUrl] [nvarchar](500) NULL,
	[Icon] [nvarchar](100) NULL,
	[SortOrder] [int] NOT NULL,
	[MenuDescription] [nvarchar](1000) NULL,
	[IsVisible] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[OrgId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrgName] [nvarchar](200) NOT NULL,
	[OrgType] [tinyint] NOT NULL,
	[OrgDesc] [nvarchar](1000) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Orgs] PRIMARY KEY CLUSTERED 
(
	[OrgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMenus]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenus](
	[RoleMenuId] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[MenuId] [bigint] NOT NULL,
	[PermissionLevel] [tinyint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_RoleMenus] PRIMARY KEY CLUSTERED 
(
	[RoleMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[RoleDescription] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spaces]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spaces](
	[SpaceId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrgId] [bigint] NOT NULL,
	[BuildingId] [bigint] NULL,
	[ParentSpaceId] [bigint] NULL,
	[SpaceName] [nvarchar](200) NOT NULL,
	[SpaceType] [tinyint] NOT NULL,
	[Capacity] [int] NULL,
	[Area] [decimal](10, 2) NULL,
	[SpaceDesc] [nvarchar](1000) NULL,
	[IsReservable] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Spaces] PRIMARY KEY CLUSTERED 
(
	[SpaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[UnitId] [bigint] IDENTITY(1,1) NOT NULL,
	[BuildingId] [bigint] NOT NULL,
	[UnitNumber] [nvarchar](50) NOT NULL,
	[FloorNumber] [int] NULL,
	[Area] [decimal](10, 2) NULL,
	[Bedrooms] [tinyint] NULL,
	[UnitDescription] [nvarchar](1000) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfiles]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfiles](
	[UserProfileId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[FatherName] [nvarchar](100) NULL,
	[BirthPlace] [nvarchar](150) NULL,
	[LandlinePhone] [nvarchar](30) NULL,
	[UserPostalCode] [nvarchar](20) NULL,
	[UserAddress] [nvarchar](500) NULL,
	[EmergencyContactName] [nvarchar](200) NULL,
	[EmergencyContactMobile] [nvarchar](30) NULL,
	[EmergencyContactRelation] [nvarchar](100) NULL,
	[Notes] [nvarchar](2000) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED 
(
	[UserProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserResidencies]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserResidencies](
	[UserResidencyId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[UnitId] [bigint] NOT NULL,
	[RelationshipType] [tinyint] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[Notes] [nvarchar](1000) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_UserResidencies] PRIMARY KEY CLUSTERED 
(
	[UserResidencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[AssignedAt] [datetime] NOT NULL,
	[ExpiresAt] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
	[Notes] [nvarchar](1000) NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NULL,
	[PasswordHash] [nvarchar](500) NULL,
	[Email] [nvarchar](150) NULL,
	[Mobile] [nvarchar](30) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[NationalId] [nvarchar](10) NULL,
	[Gender] [int] NOT NULL,
	[BirthDate] [datetime] NULL,
	[AvatarUrl] [nvarchar](500) NULL,
	[PhoneVerified] [bit] NOT NULL,
	[LastLoginAt] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Buildings] ON 
GO
INSERT [dbo].[Buildings] ([BuildingId], [BuildingName], [BuildingAddress], [BuildingDescription], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [OrgId]) VALUES (1, N'برج بوستان', N'تهران، منطقه ۱، خیابان نمونه، پلاک ۱۰۰', N'برج مسکونی بوستان با امکانات رفاهی و باشگاه ورزشی اختصاصی', 1, CAST(N'2026-09-01T17:22:05.297' AS DateTime), NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Buildings] OFF
GO
SET IDENTITY_INSERT [dbo].[Menus] ON 
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, NULL, N'داشبورد', N'/dashboard', N'dashboard', 1, N'صفحه اصلی سامانه', 1, 1, CAST(N'2026-09-01T17:22:05.383' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, NULL, N'مدیریت کاربران', N'/users', N'users', 2, N'مدیریت مالکین، ساکنین، مهمانان و اعضای خارجی', 1, 1, CAST(N'2026-09-01T17:22:05.387' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, NULL, N'مدیریت نقش‌ها', N'/roles', N'roles', 3, N'مدیریت نقش‌های سامانه', 1, 1, CAST(N'2026-09-01T17:22:05.390' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, NULL, N'مدیریت دسترسی‌ها', N'/permissions', N'lock', 4, N'مدیریت دسترسی نقش‌ها به منوهای سامانه', 1, 1, CAST(N'2026-09-01T17:22:05.390' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, NULL, N'ساختمان', N'/building', N'building', 5, N'مدیریت ساختمان برج', 1, 1, CAST(N'2026-09-01T17:22:05.393' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (6, NULL, N'واحدها', N'/units', N'home', 6, N'مدیریت واحدهای ساختمان', 1, 1, CAST(N'2026-09-01T17:22:05.397' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (7, NULL, N'باشگاه ورزشی', N'/club', N'fitness_center', 7, N'مدیریت باشگاه ورزشی برج', 1, 1, CAST(N'2026-09-01T17:22:05.397' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (8, NULL, N'رزروها', N'/reservations', N'calendar', 8, N'مدیریت رزروهای باشگاه', 1, 1, CAST(N'2026-09-01T17:22:05.400' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (9, NULL, N'شارژ ساختمان', N'/charges', N'account_balance_wallet', 9, N'مدیریت شارژ واحدها', 1, 1, CAST(N'2026-09-01T17:22:05.400' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (10, NULL, N'پرداخت‌ها', N'/payments', N'payment', 10, N'مدیریت پرداخت‌ها و تراکنش‌های مالی', 1, 1, CAST(N'2026-09-01T17:22:05.403' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (11, NULL, N'گزارش‌ها', N'/reports', N'report', 11, N'گزارش‌های مدیریتی و مالی', 1, 1, CAST(N'2026-09-01T17:22:05.403' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (12, NULL, N'تنظیمات', N'/settings', N'settings', 12, N'تنظیمات عمومی سامانه', 1, 1, CAST(N'2026-09-01T17:22:05.407' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleMenus] ON 
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, 1, 1, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, 1, 2, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, 1, 3, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, 1, 4, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, 1, 5, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (6, 1, 6, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (7, 1, 7, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (8, 1, 8, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (9, 1, 9, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (10, 1, 10, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (11, 1, 11, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (12, 1, 12, 3, 1, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (13, 2, 1, 0, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (14, 2, 2, 1, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (15, 2, 3, 0, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (16, 2, 4, 0, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (17, 2, 5, 0, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (18, 2, 6, 0, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (19, 2, 7, 3, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (20, 2, 8, 3, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (21, 2, 9, 0, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (22, 2, 10, 0, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (23, 2, 11, 1, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (24, 2, 12, 0, 1, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (25, 3, 1, 0, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (26, 3, 2, 1, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (27, 3, 3, 0, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (28, 3, 4, 0, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (29, 3, 5, 0, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (30, 3, 6, 0, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (31, 3, 7, 1, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (32, 3, 8, 2, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (33, 3, 9, 0, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (34, 3, 10, 0, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (35, 3, 11, 0, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (36, 3, 12, 0, 1, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (37, 4, 1, 0, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (38, 4, 2, 3, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (39, 4, 3, 0, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (40, 4, 4, 0, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (41, 4, 5, 3, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (42, 4, 6, 3, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (43, 4, 7, 0, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (44, 4, 8, 0, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (45, 4, 9, 0, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (46, 4, 10, 0, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (47, 4, 11, 1, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (48, 4, 12, 0, 1, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (49, 5, 1, 0, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (50, 5, 2, 0, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (51, 5, 3, 0, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (52, 5, 4, 0, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (53, 5, 5, 0, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (54, 5, 6, 0, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (55, 5, 7, 0, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (56, 5, 8, 0, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (57, 5, 9, 3, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (58, 5, 10, 3, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (59, 5, 11, 1, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (60, 5, 12, 0, 1, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (61, 6, 1, 1, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (62, 6, 2, 0, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (63, 6, 3, 0, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (64, 6, 4, 0, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (65, 6, 5, 0, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (66, 6, 6, 0, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (67, 6, 7, 1, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (68, 6, 8, 1, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (69, 6, 9, 1, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (70, 6, 10, 1, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (71, 6, 11, 0, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (72, 6, 12, 0, 1, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (73, 7, 1, 1, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (74, 7, 2, 0, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (75, 7, 3, 0, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (76, 7, 4, 0, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (77, 7, 5, 0, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (78, 7, 6, 0, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (79, 7, 7, 1, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (80, 7, 8, 1, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (81, 7, 9, 0, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (82, 7, 10, 1, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (83, 7, 11, 0, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (84, 7, 12, 0, 1, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[RoleMenus] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (1, N'مدیر سیستم', N'دسترسی کامل به تمام بخش‌های سامانه')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (2, N'مدیر باشگاه', N'مدیریت کامل باشگاه ورزشی، اعضا، سانس‌ها و رزروها')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (3, N'پذیرش باشگاه', N'مدیریت پذیرش، مشاهده اعضا و ثبت رزرو')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (4, N'مدیر ساختمان', N'مدیریت واحدها، مالکین و ساکنین برج')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (5, N'حسابدار', N'مدیریت شارژ، پرداخت‌ها و گزارش‌های مالی')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (6, N'ساکن', N'دسترسی عمومی ساکنین به خدمات ساختمان و باشگاه')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (7, N'عضو خارجی باشگاه', N'کاربر خارج از برج که عضو باشگاه ورزشی است')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Units] ON 
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, 1, N'101', 1, CAST(145.50 AS Decimal(10, 2)), 3, N'واحد مسکونی طبقه اول - سه خوابه', 1, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, 1, N'102', 1, CAST(120.00 AS Decimal(10, 2)), 2, N'واحد مسکونی طبقه اول - دو خوابه', 1, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, 1, N'201', 2, CAST(165.75 AS Decimal(10, 2)), 3, N'واحد مسکونی طبقه دوم - سه خوابه', 1, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, 1, N'202', 2, CAST(135.00 AS Decimal(10, 2)), 3, N'واحد مسکونی طبقه دوم - سه خوابه', 1, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, 1, N'301', 3, CAST(180.25 AS Decimal(10, 2)), 4, N'واحد مسکونی طبقه سوم - چهار خوابه', 1, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (6, 1, N'302', 3, CAST(150.00 AS Decimal(10, 2)), 3, N'واحد مسکونی طبقه سوم - سه خوابه', 1, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (7, 1, N'401', 4, CAST(210.00 AS Decimal(10, 2)), 4, N'واحد ویژه طبقه چهارم - چهار خوابه', 1, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (8, 1, N'402', 4, CAST(175.00 AS Decimal(10, 2)), 3, N'واحد مسکونی طبقه چهارم - سه خوابه', 1, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (9, 1, N'501', 5, CAST(250.00 AS Decimal(10, 2)), 4, N'پنت هاوس طبقه پنجم', 1, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (10, 1, N'502', 5, CAST(220.00 AS Decimal(10, 2)), 4, N'پنت هاوس طبقه پنجم', 1, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Units] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfiles] ON 
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, 1, N'حسین', N'تهران', N'02122000001', N'1111111111', N'تهران، خیابان ولیعصر', N'محمد محمدی', N'09121111111', N'برادر', N'کاربر مدیر سیستم', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, 2, N'اکبر', N'تهران', N'02122000002', N'1111111112', N'تهران، خیابان پاسداران', N'علی احمدی', N'09121111112', N'برادر', N'مدیر باشگاه', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, 3, N'کاظم', N'تهران', N'02122000003', N'1111111113', N'تهران، خیابان شریعتی', N'حسن کریمی', N'09121111113', N'برادر', N'مدیر ساختمان', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, 4, N'محمود', N'تهران', N'02122000004', N'1111111114', N'تهران، خیابان مطهری', N'مریم محمدی', N'09121111114', N'خواهر', N'حسابدار ساختمان', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, 5, N'رضا', N'تهران', N'02122000005', N'1111111115', N'تهران، خیابان انقلاب', N'سارا حسینی', N'09121111115', N'خواهر', N'پذیرش باشگاه', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (6, 6, N'حسن', N'تهران', N'02122000006', N'1111111116', N'تهران، برج بوستان، واحد ۱۰۱', N'مریم احمدی', N'09120000007', N'همسر', N'مالک واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (7, 7, N'علی', N'تهران', N'02122000007', N'1111111116', N'تهران، برج بوستان، واحد ۱۰۱', N'علی محمدی', N'09120000006', N'همسر', N'ساکن واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (8, 8, N'محمود', N'تهران', N'02122000008', N'1111111118', N'تهران، برج بوستان، واحد ۲۰۱', N'فاطمه رضایی', N'09120000009', N'همسر', N'مالک واحد ۲۰۱', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (9, 9, N'حسن', N'تهران', N'02122000008', N'1111111118', N'تهران، برج بوستان، واحد ۲۰۱', N'حسن رضایی', N'09120000008', N'همسر', N'ساکن واحد ۲۰۱', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (10, 10, N'احمد', N'تهران', N'02122000010', N'1111111120', N'تهران، خیابان آزادی', N'علی سلیمانی', N'09121111120', N'برادر', N'عضو خارجی باشگاه', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (11, 11, N'حسین', N'تهران', NULL, NULL, NULL, N'علی محمدی', N'09120000006', N'دوست', N'مهمان واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserProfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[UserResidencies] ON 
GO
INSERT [dbo].[UserResidencies] ([UserResidencyId], [UserId], [UnitId], [RelationshipType], [StartDate], [EndDate], [IsActive], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, 6, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime), NULL, 1, N'مالک اصلی واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.550' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserResidencies] ([UserResidencyId], [UserId], [UnitId], [RelationshipType], [StartDate], [EndDate], [IsActive], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, 7, 1, 2, CAST(N'2020-01-01T00:00:00.000' AS DateTime), NULL, 1, N'ساکن واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.560' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserResidencies] ([UserResidencyId], [UserId], [UnitId], [RelationshipType], [StartDate], [EndDate], [IsActive], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, 8, 3, 1, CAST(N'2019-05-01T00:00:00.000' AS DateTime), NULL, 1, N'مالک اصلی واحد ۲۰۱', CAST(N'2026-09-01T17:22:05.567' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserResidencies] ([UserResidencyId], [UserId], [UnitId], [RelationshipType], [StartDate], [EndDate], [IsActive], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, 9, 3, 2, CAST(N'2019-05-01T00:00:00.000' AS DateTime), NULL, 1, N'ساکن واحد ۲۰۱', CAST(N'2026-09-01T17:22:05.580' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserResidencies] ([UserResidencyId], [UserId], [UnitId], [RelationshipType], [StartDate], [EndDate], [IsActive], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, 11, 1, 4, CAST(N'2026-09-01T00:00:00.000' AS DateTime), CAST(N'2026-09-05T00:00:00.000' AS DateTime), 1, N'مهمان موقت واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.590' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserResidencies] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (1, 1, 1, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, 1, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (2, 2, 2, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, 1, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (3, 3, 4, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, 1, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (4, 4, 5, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, 1, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (5, 5, 3, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, 1, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (6, 6, 6, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, 1, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (7, 7, 6, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, 1, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (8, 8, 6, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, 1, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (9, 9, 6, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, 1, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (10, 10, 7, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, 1, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, N'admin', N'1234', N'admin@boosatan.ir', N'09120000001', N'مدیر', N'سیستم', N'0012345678', 1, CAST(N'1985-01-15T00:00:00.000' AS DateTime), NULL, 1, CAST(N'2026-09-08T15:48:16.347' AS DateTime), 1, CAST(N'2026-09-01T17:22:05.450' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, N'club.manager', N'1234', N'club.manager@boosatan.ir', N'09120000002', N'رضا', N'احمدی', N'0012345679', 1, CAST(N'1988-03-20T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, CAST(N'2026-09-01T17:22:05.453' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, N'building.manager', N'1234', N'building.manager@boosatan.ir', N'09120000003', N'مهدی', N'کریمی', N'0012345680', 1, CAST(N'1982-07-10T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, CAST(N'2026-09-01T17:22:05.457' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, N'accountant', N'1234', N'accountant@boosatan.ir', N'09120000004', N'سارا', N'محمدی', N'0012345681', 2, CAST(N'1990-11-05T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, CAST(N'2026-09-01T17:22:05.460' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, N'reception', N'1234', N'reception@boosatan.ir', N'09120000005', N'نگار', N'حسینی', N'0012345682', 2, CAST(N'1994-04-12T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, CAST(N'2026-09-01T17:22:05.460' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (6, N'ali.mohammadi', N'1234', N'ali.mohammadi@example.com', N'09120000006', N'علی', N'محمدی', N'0012345683', 1, CAST(N'1987-06-18T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, CAST(N'2026-09-01T17:22:05.460' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (7, N'maryam.ahmadi', N'1234', N'maryam.ahmadi@example.com', N'09120000007', N'مریم', N'احمدی', N'0012345684', 2, CAST(N'1991-02-25T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, CAST(N'2026-09-01T17:22:05.463' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (8, N'hassan.rezaei', N'1234', N'hassan.rezaei@example.com', N'09120000008', N'حسن', N'رضایی', N'0012345685', 1, CAST(N'1980-09-03T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, CAST(N'2026-09-01T17:22:05.463' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (9, N'fatemeh.rezaei', N'1234', N'fatemeh.rezaei@example.com', N'09120000009', N'فاطمه', N'رضایی', N'0012345686', 2, CAST(N'1985-12-14T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, CAST(N'2026-09-01T17:22:05.467' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (10, N'mohammad.soleimani', N'1234', N'mohammad.soleimani@example.com', N'09120000010', N'محمد', N'سلیمانی', N'0012345687', 1, CAST(N'1993-08-21T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, CAST(N'2026-09-01T17:22:05.467' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (11, N'guest.test', N'1234', N'guest@example.com', N'09120000011', N'رضا', N'کاظمی', N'0012345688', 1, CAST(N'1995-10-10T00:00:00.000' AS DateTime), NULL, 0, NULL, 1, CAST(N'2026-09-01T17:22:05.470' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [UQ_RoleMenus_Role_Menu]    Script Date: 9/8/2026 4:55:36 PM ******/
ALTER TABLE [dbo].[RoleMenus] ADD  CONSTRAINT [UQ_RoleMenus_Role_Menu] UNIQUE NONCLUSTERED 
(
	[RoleId] ASC,
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_UserProfiles_UserId]    Script Date: 9/8/2026 4:55:36 PM ******/
ALTER TABLE [dbo].[UserProfiles] ADD  CONSTRAINT [UQ_UserProfiles_UserId] UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_UserRoles_User_Role]    Script Date: 9/8/2026 4:55:36 PM ******/
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [UQ_UserRoles_User_Role] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Users_Email]    Script Date: 9/8/2026 4:55:36 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Users_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Users_NationalId]    Script Date: 9/8/2026 4:55:36 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Users_NationalId] UNIQUE NONCLUSTERED 
(
	[NationalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Users_Username]    Script Date: 9/8/2026 4:55:36 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Users_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Buildings] ADD  CONSTRAINT [DF_Buildings_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Buildings] ADD  CONSTRAINT [DF_Buildings_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[EmployeeAssignments] ADD  CONSTRAINT [DF_EmployeeAssignments_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeAssignments] ADD  CONSTRAINT [DF_EmployeeAssignments_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[EmployeeTypes] ADD  CONSTRAINT [DF_EmployeeTypes_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeTypes] ADD  CONSTRAINT [DF_EmployeeTypes_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_SortOrder]  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_IsVisible]  DEFAULT ((1)) FOR [IsVisible]
GO
ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Organizations] ADD  CONSTRAINT [DF_Orgs_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Organizations] ADD  CONSTRAINT [DF_Orgs_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[RoleMenus] ADD  CONSTRAINT [DF_RoleMenus_PermissionLevel]  DEFAULT ((0)) FOR [PermissionLevel]
GO
ALTER TABLE [dbo].[RoleMenus] ADD  CONSTRAINT [DF_RoleMenus_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[RoleMenus] ADD  CONSTRAINT [DF_RoleMenus_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Spaces] ADD  CONSTRAINT [DF_Spaces_IsReservable]  DEFAULT ((0)) FOR [IsReservable]
GO
ALTER TABLE [dbo].[Spaces] ADD  CONSTRAINT [DF_Spaces_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Spaces] ADD  CONSTRAINT [DF_Spaces_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Units] ADD  CONSTRAINT [DF_Units_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Units] ADD  CONSTRAINT [DF_Units_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[UserProfiles] ADD  CONSTRAINT [DF_UserProfiles_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[UserResidencies] ADD  CONSTRAINT [DF_UserResidencies_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserResidencies] ADD  CONSTRAINT [DF_UserResidencies_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [DF_UserRoles_AssignedAt]  DEFAULT (getdate()) FOR [AssignedAt]
GO
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [DF_UserRoles_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [DF_UserRoles_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_PhoneVerified]  DEFAULT ((0)) FOR [PhoneVerified]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_Orgs] FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organizations] ([OrgId])
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Buildings_Orgs]
GO
ALTER TABLE [dbo].[EmployeeAssignments]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAssignments_Buildings] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([BuildingId])
GO
ALTER TABLE [dbo].[EmployeeAssignments] CHECK CONSTRAINT [FK_EmployeeAssignments_Buildings]
GO
ALTER TABLE [dbo].[EmployeeAssignments]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAssignments_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployeeAssignments] CHECK CONSTRAINT [FK_EmployeeAssignments_Employees]
GO
ALTER TABLE [dbo].[EmployeeAssignments]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAssignments_Org] FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organizations] ([OrgId])
GO
ALTER TABLE [dbo].[EmployeeAssignments] CHECK CONSTRAINT [FK_EmployeeAssignments_Org]
GO
ALTER TABLE [dbo].[EmployeeAssignments]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAssignments_Spaces] FOREIGN KEY([SpaceId])
REFERENCES [dbo].[Spaces] ([SpaceId])
GO
ALTER TABLE [dbo].[EmployeeAssignments] CHECK CONSTRAINT [FK_EmployeeAssignments_Spaces]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Org] FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organizations] ([OrgId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Org]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Types] FOREIGN KEY([EmployeeTypeId])
REFERENCES [dbo].[EmployeeTypes] ([EmployeeTypeId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Types]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users]
GO
ALTER TABLE [dbo].[Menus]  WITH CHECK ADD  CONSTRAINT [FK_Menus_Parent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Menus] ([MenuId])
GO
ALTER TABLE [dbo].[Menus] CHECK CONSTRAINT [FK_Menus_Parent]
GO
ALTER TABLE [dbo].[RoleMenus]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenus_Menus] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menus] ([MenuId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleMenus] CHECK CONSTRAINT [FK_RoleMenus_Menus]
GO
ALTER TABLE [dbo].[RoleMenus]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenus_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleMenus] CHECK CONSTRAINT [FK_RoleMenus_Roles]
GO
ALTER TABLE [dbo].[Spaces]  WITH CHECK ADD  CONSTRAINT [FK_Spaces_Buildings] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([BuildingId])
GO
ALTER TABLE [dbo].[Spaces] CHECK CONSTRAINT [FK_Spaces_Buildings]
GO
ALTER TABLE [dbo].[Spaces]  WITH CHECK ADD  CONSTRAINT [FK_Spaces_Orgs] FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organizations] ([OrgId])
GO
ALTER TABLE [dbo].[Spaces] CHECK CONSTRAINT [FK_Spaces_Orgs]
GO
ALTER TABLE [dbo].[Spaces]  WITH CHECK ADD  CONSTRAINT [FK_Spaces_Parent] FOREIGN KEY([ParentSpaceId])
REFERENCES [dbo].[Spaces] ([SpaceId])
GO
ALTER TABLE [dbo].[Spaces] CHECK CONSTRAINT [FK_Spaces_Parent]
GO
ALTER TABLE [dbo].[Units]  WITH CHECK ADD  CONSTRAINT [FK_Units_Buildings] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([BuildingId])
GO
ALTER TABLE [dbo].[Units] CHECK CONSTRAINT [FK_Units_Buildings]
GO
ALTER TABLE [dbo].[UserProfiles]  WITH CHECK ADD  CONSTRAINT [FK_UserProfiles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserProfiles] CHECK CONSTRAINT [FK_UserProfiles_Users]
GO
ALTER TABLE [dbo].[UserResidencies]  WITH CHECK ADD  CONSTRAINT [FK_UserResidencies_Units] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Units] ([UnitId])
GO
ALTER TABLE [dbo].[UserResidencies] CHECK CONSTRAINT [FK_UserResidencies_Units]
GO
ALTER TABLE [dbo].[UserResidencies]  WITH CHECK ADD  CONSTRAINT [FK_UserResidencies_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserResidencies] CHECK CONSTRAINT [FK_UserResidencies_Users]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 9/8/2026 4:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserLogin]
(
    @pUsername       NVARCHAR(100),
    @pPasswordHash   NVARCHAR(500),

    @ResultCode     INT OUTPUT,
    @ResultMessage  NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    ---------------------------------------------------------
    -- مقداردهی اولیه Output
    ---------------------------------------------------------
    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در انجام عملیات.';


    DECLARE @UserId BIGINT = NULL;
    DECLARE @IsActive BIT = NULL;


    ---------------------------------------------------------
    -- 1. بررسی ورودی
    ---------------------------------------------------------
    IF NULLIF(LTRIM(RTRIM(@pUsername)), N'') IS NULL
       OR NULLIF(LTRIM(RTRIM(@pPasswordHash)), N'') IS NULL
    BEGIN
        SET @ResultCode = 400;
        SET @ResultMessage = N'نام کاربری و رمز عبور الزامی است.';
        RETURN;
    END;


    ---------------------------------------------------------
    -- 2. پیدا کردن کاربر
    ---------------------------------------------------------
    SELECT TOP (1)
        @UserId = U.UserId,
        @IsActive = U.IsActive
    FROM dbo.Users AS U
    WHERE U.Username = @pUsername;


    ---------------------------------------------------------
    -- 3. کاربر وجود ندارد
    ---------------------------------------------------------
    IF @UserId IS NULL
    BEGIN
        SET @ResultCode = 404;
        SET @ResultMessage = N'کاربری با این نام کاربری یافت نشد.';
        RETURN;
    END;


    ---------------------------------------------------------
    -- 4. کاربر غیرفعال است
    ---------------------------------------------------------
    IF @IsActive = 0
    BEGIN
        SET @ResultCode = 403;
        SET @ResultMessage =
            N'حساب کاربری شما غیرفعال است. لطفاً با مدیر سیستم تماس بگیرید.';
        RETURN;
    END;


    ---------------------------------------------------------
    -- 5. بررسی رمز عبور
    ---------------------------------------------------------
    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users AS U
        WHERE
            U.UserId = @UserId
            AND U.PasswordHash = @pPasswordHash
    )
    BEGIN
        SET @ResultCode = 401;
        SET @ResultMessage = N'رمز عبور وارد شده صحیح نیست.';
        RETURN;
    END;


    ---------------------------------------------------------
    -- 6. ورود موفق
    ---------------------------------------------------------
    UPDATE dbo.Users
    SET LastLoginAt = GETDATE()
    WHERE UserId = @UserId;


    SET @ResultCode = 200;
    SET @ResultMessage = N'ورود با موفقیت انجام شد.';


    ---------------------------------------------------------
    -- Result Set 1 : User
    ---------------------------------------------------------
    SELECT
        U.UserId,
        U.Username,
        U.FirstName,
        U.LastName,
        LTRIM(RTRIM(
            ISNULL(U.FirstName, N'') + N' ' +
            ISNULL(U.LastName, N'')
        )) AS FullName,
        U.Email,
        U.Mobile,
        U.NationalId,
        U.Gender,
        U.BirthDate,
        U.PhoneVerified,
        U.LastLoginAt,
        U.CreatedAt
    FROM dbo.Users AS U
    WHERE U.UserId = @UserId;


    ---------------------------------------------------------
    -- Result Set 2 : Roles
    ---------------------------------------------------------
    SELECT DISTINCT
        R.RoleId,
        R.RoleName,
        R.RoleDescription,
        UR.UserRoleId,
        UR.AssignedAt
    FROM dbo.UserRoles AS UR

    INNER JOIN dbo.Roles AS R
        ON R.RoleId = UR.RoleId

    WHERE
        UR.UserId = @UserId
        AND UR.IsActive = 1

    ORDER BY R.RoleName;


    ---------------------------------------------------------
    -- Result Set 3 : Menus + Permissions
    ---------------------------------------------------------
    SELECT
        M.MenuId,
        M.ParentId,
        M.Title,
        M.MenuUrl,
        M.Icon,
        M.SortOrder,
        M.MenuDescription,

        MAX(RM.PermissionLevel) AS PermissionLevel,

        CASE
            WHEN MAX(RM.PermissionLevel) >= 1
                THEN CAST(1 AS BIT)
            ELSE CAST(0 AS BIT)
        END AS CanRead,

        CASE
            WHEN MAX(RM.PermissionLevel) >= 2
                THEN CAST(1 AS BIT)
            ELSE CAST(0 AS BIT)
        END AS CanWrite,

        CASE
            WHEN MAX(RM.PermissionLevel) >= 3
                THEN CAST(1 AS BIT)
            ELSE CAST(0 AS BIT)
        END AS CanFullAccess

    FROM dbo.UserRoles AS UR

    INNER JOIN dbo.RoleMenus AS RM
        ON RM.RoleId = UR.RoleId

    INNER JOIN dbo.Menus AS M
        ON M.MenuId = RM.MenuId

    WHERE
        UR.UserId = @UserId
        AND UR.IsActive = 1
        AND RM.IsActive = 1
        AND M.IsActive = 1
        AND M.IsVisible = 1
        AND RM.PermissionLevel > 0

    GROUP BY
        M.MenuId,
        M.ParentId,
        M.Title,
        M.MenuUrl,
        M.Icon,
        M.SortOrder,
        M.MenuDescription

    ORDER BY M.SortOrder;

END;
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ادرس ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد محل خدمت پرسنل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EmployeeAssignmentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد استخدامی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EmployeeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد مکان ورزشی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'SpaceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ شروع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ خاتمه' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام شیفت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'ShiftName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات محل خدمت پرسنل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EmployeeAssignmentDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'محل خدمت پرسنل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد استخدامی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmployeeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع استخدامی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmployeeTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نحوه استخدامی (1: تمام وقت | 2: پاره وقت | 3: ساعتی | 4: قراردادی | 5: پروژه‌ای)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmploymentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ استخدام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'HireDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ پایان استخدام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حقوق پایه' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BaseSalary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نرخ کار ساعتی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'HourlyRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام بانک' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BankName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره کارت بانک' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BankCardNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره حساب بانک' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BankAccountNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره شبا بانک' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'ShebaNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات کارمند' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmployeesDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد نوع استخدام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'EmployeeTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام نوع استخدام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'EmployeeTypeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیح نوع استخدام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'EmployeeTypeDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد والد منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'لینک منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آیکون منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره ردیف' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'SortOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نمایش داده شود(1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'IsVisible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع سازمان (1: ساختمان | 2: آموزشگاه | 3: باشگاه | 4: موسسه آموزشی | 5: مجتمع چندمنظوره | 99: سایر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد نقش منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'RoleMenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی (1: بدون دسترسی 2: خواندن 3: نوشتن 4: کامل)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'PermissionLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد مکان ورزشی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'والد مکان ورزشی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'ParentSpaceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام مکان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع مکان (1: عمومی | 2: باشگاه | 3: سالن اجتماعات | 4: مغازه | 5: کلاس | 6: سالن ورزشی | 7: دفتر | 8: انبار | 9: پارکینگ | 10: سایر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ظرفیت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'Capacity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مساحت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'Area'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات مکان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'قابل رزور(1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'IsReservable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مکان ورزشی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد واحد ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UnitId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره واحد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UnitNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'طبقه واحد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'FloorNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مساحت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'Area'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تعداد خواب' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'Bedrooms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات واحد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UnitDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد پروفایل کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserProfileId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام پدر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'FatherName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'محل تولد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'BirthPlace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تلفن' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'LandlinePhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد پستی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserPostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ادرس' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تلفن مواقع اضطراری' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'EmergencyContactName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تلفن مواقع اضطراری' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'EmergencyContactMobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رابطه فرد مواقع اضطراری' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'EmergencyContactRelation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر واحد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserResidencyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد واحد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UnitId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع مالکیت (1: ساکن 2: مالک 3: خانواده مالک 4: نزدیکان مالک 5: خارج از ساختمان)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'RelationshipType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ شروع مالکیت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ پایان مالکیت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserRoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ تخصیص نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'AssignedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ انقضا' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'ExpiresAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال اسن (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربری' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Username'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کلمه عبور کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'PasswordHash'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایمیل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'موبایل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام خانوادگی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ملی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'NationalId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'جنسیت (1: مرد 2: زن)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ تولد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'BirthDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عکس' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'AvatarUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تایید موبایل (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'PhoneVerified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آخرین بازدید' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LastLoginAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
