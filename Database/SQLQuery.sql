USE [master]
GO
/****** Object:  Database [SocietyDB]    Script Date: 3/15/2022 5:03:39 PM ******/
CREATE DATABASE [SocietyDB]
 GO
USE [SocietyDB]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[GenderID] [int] NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[ResidentialAddress] [nvarchar](max) NOT NULL,
	[OfficeAddress] [nvarchar](max) NULL,
	[MobileNumber1] [nvarchar](50) NOT NULL,
	[WhatsappNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[MemberPhoto] [nvarchar](max) NULL,
	[CurrentPositionID] [int] NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberContributions]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberContributions](
	[ContributionID] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [bigint] NOT NULL,
	[ContributionDate] [datetime] NOT NULL,
	[AmountContributed] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_MemberContributions] PRIMARY KEY CLUSTERED 
(
	[ContributionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ContributionsView]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[ContributionsView]
AS
SELECT  TOP 100 PERCENT      MemberContributions.ContributionID, Members.FirstName, Members.Surname, MemberContributions.ContributionDate, MemberContributions.AmountContributed
FROM            Members RIGHT OUTER JOIN
                         MemberContributions ON Members.MemberID = MemberContributions.MemberID

						 ORDER BY MemberContributions.ContributionID
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[GenderID] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberPositions]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberPositions](
	[PositionID] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MemberPositions] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'6.0.0')
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'1f25b26f-198a-4a17-9417-a8d5c5df22ea', N'fc2214e3-ae8d-4731-b1e8-d5775bb7e71f', N'User', N'USER')
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'adf4b09d-01ac-4cbb-a372-d4b514db56c5', N'368f7d5f-0faf-4762-9425-e337964cc0ee', N'SuperAdmin', N'SUPERADMIN')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ce6f0820-215d-4382-bbbb-7f8cb6d470b8', N'adf4b09d-01ac-4cbb-a372-d4b514db56c5')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ed42f6eb-3aeb-4bbf-ac11-6d65efc9830f', N'1f25b26f-198a-4a17-9417-a8d5c5df22ea')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'ce6f0820-215d-4382-bbbb-7f8cb6d470b8', 0, N'841aba23-35b1-4d9c-b713-247cfb16a53f', N'benjaminsqlserver@gmail.com', 0, 1, NULL, N'BENJAMINSQLSERVER@GMAIL.COM', N'BENJAMINSQLSERVER@GMAIL.COM', N'AQAAAAEAACcQAAAAEHwsyO9oryYFE68obK9B/SDQOxoJHo75k/mgxZTwNg5PuQbisUVMUEv3YLAW/TN6HA==', NULL, 0, N'VRYLOZGHC7SMMKBQBEH2ANAQLQFNZN5Q', 0, N'benjaminsqlserver@gmail.com')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'ed42f6eb-3aeb-4bbf-ac11-6d65efc9830f', 0, N'a3b787cb-49d9-4c08-9713-deb05b11fe53', N'benmuyiwa@yahoo.com', 0, 1, NULL, N'BENMUYIWA@YAHOO.COM', N'BENMUYIWA@YAHOO.COM', N'AQAAAAEAACcQAAAAEAHQlYEdF6j8q835ZgB4nw4c3GNci1RnE2ifH/anhmqROIRsSwuLDkhXYxiYlmyOsg==', NULL, 0, N'FZ6EAUUOLJW5HQPWOKS5C5TU5CAFULPA', 0, N'benmuyiwa@yahoo.com')
GO
SET IDENTITY_INSERT [dbo].[Genders] ON 
GO
INSERT [dbo].[Genders] ([GenderID], [GenderName]) VALUES (2, N'Female')
GO
INSERT [dbo].[Genders] ([GenderID], [GenderName]) VALUES (1, N'Male')
GO
SET IDENTITY_INSERT [dbo].[Genders] OFF
GO
SET IDENTITY_INSERT [dbo].[MemberContributions] ON 
GO
INSERT [dbo].[MemberContributions] ([ContributionID], [MemberID], [ContributionDate], [AmountContributed]) VALUES (1, 1, CAST(N'2022-03-06T00:00:00.000' AS DateTime), CAST(23456.78 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[MemberContributions] OFF
GO
SET IDENTITY_INSERT [dbo].[MemberPositions] ON 
GO
INSERT [dbo].[MemberPositions] ([PositionID], [PositionName]) VALUES (4, N'Assistant General Secretary')
GO
INSERT [dbo].[MemberPositions] ([PositionID], [PositionName]) VALUES (5, N'Financial Secretary')
GO
INSERT [dbo].[MemberPositions] ([PositionID], [PositionName]) VALUES (3, N'General Secretary')
GO
INSERT [dbo].[MemberPositions] ([PositionID], [PositionName]) VALUES (6, N'Member')
GO
INSERT [dbo].[MemberPositions] ([PositionID], [PositionName]) VALUES (1, N'President')
GO
INSERT [dbo].[MemberPositions] ([PositionID], [PositionName]) VALUES (7, N'Treasurer')
GO
INSERT [dbo].[MemberPositions] ([PositionID], [PositionName]) VALUES (2, N'Vice President')
GO
SET IDENTITY_INSERT [dbo].[MemberPositions] OFF
GO
SET IDENTITY_INSERT [dbo].[Members] ON 
GO
INSERT [dbo].[Members] ([MemberID], [FirstName], [MiddleName], [Surname], [GenderID], [DateOfBirth], [ResidentialAddress], [OfficeAddress], [MobileNumber1], [WhatsappNumber], [Email], [MemberPhoto], [CurrentPositionID]) VALUES (1, N'John', N'Moses', N'Numble', 1, CAST(N'1978-03-07T00:00:00.000' AS DateTime), N'44 Markus street Asokoro Abuja', NULL, N'+12334566555', NULL, N'johnnumble@yahoo.com', N'data:image/jpeg;base64,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', 5)
GO
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 3/15/2022 5:03:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 3/15/2022 5:03:40 PM ******/
CREATE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 3/15/2022 5:03:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 3/15/2022 5:03:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 3/15/2022 5:03:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_UserId]    Script Date: 3/15/2022 5:03:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 3/15/2022 5:03:40 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 3/15/2022 5:03:40 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Genders]    Script Date: 3/15/2022 5:03:40 PM ******/
ALTER TABLE [dbo].[Genders] ADD  CONSTRAINT [IX_Genders] UNIQUE NONCLUSTERED 
(
	[GenderName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberPositions]    Script Date: 3/15/2022 5:03:40 PM ******/
ALTER TABLE [dbo].[MemberPositions] ADD  CONSTRAINT [IX_MemberPositions] UNIQUE NONCLUSTERED 
(
	[PositionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[MemberContributions]  WITH CHECK ADD  CONSTRAINT [FK_MemberContributions_Members] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([MemberID])
GO
ALTER TABLE [dbo].[MemberContributions] CHECK CONSTRAINT [FK_MemberContributions_Members]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [FK_Members_Genders] FOREIGN KEY([GenderID])
REFERENCES [dbo].[Genders] ([GenderID])
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [FK_Members_Genders]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [FK_Members_MemberPositions] FOREIGN KEY([CurrentPositionID])
REFERENCES [dbo].[MemberPositions] ([PositionID])
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [FK_Members_MemberPositions]
GO
/****** Object:  StoredProcedure [dbo].[MemberListProc]    Script Date: 3/15/2022 5:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MemberListProc]
AS
SELECT MemberID, FirstName+' '+Surname AS FullName FROM [dbo].[Members]
ORDER BY FirstName
GO
USE [master]
GO
ALTER DATABASE [SocietyDB] SET  READ_WRITE 
GO
