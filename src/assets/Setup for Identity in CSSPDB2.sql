USE [CSSPDB2]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* ------------------ Alter AspNetUsers --------------------------*/
ALTER TABLE [dbo].[AspNetUsers]
	ALTER COLUMN [Id] [nvarchar](450) NOT NULL;
GO

IF COL_LENGTH('AspNetUsers', 'NormalizedUserName') IS NULL
BEGIN
    ALTER TABLE [dbo].[AspNetUsers]
	ADD [NormalizedUserName] [nvarchar](256) NULL;
END 
GO	

IF COL_LENGTH('AspNetUsers', 'NormalizedEmail') IS NULL
BEGIN
	ALTER TABLE [dbo].[AspNetUsers]
	ADD	[NormalizedEmail] [nvarchar](256) NULL;
END 
GO	

IF COL_LENGTH('AspNetUsers', 'ConcurrencyStamp') IS NULL
BEGIN
	ALTER TABLE [dbo].[AspNetUsers]
	ADD	[ConcurrencyStamp] [nvarchar](max) NULL;
END 
GO	

IF COL_LENGTH('AspNetUsers', 'LockoutEnd') IS NULL
BEGIN
	ALTER TABLE [dbo].[AspNetUsers]
	ADD	[LockoutEnd] [datetimeoffset](7) NULL;
END 
GO	

/* ---------------------- Deleting AspNetUserRoles -----------------------------*/
DROP TABLE [dbo].[AspNetUserRoles]
GO

/* ---------------------- Deleting AspNetUserLogins -----------------------------*/
DROP TABLE [dbo].[AspNetUserLogins]
GO

/* ---------------------- Deleting AspNetUserTokens -----------------------------*/
DROP TABLE [dbo].[AspNetUserTokens]
GO

/* ---------------------- Deleting AspNetRoleClaims -----------------------------*/
DROP TABLE [dbo].[AspNetRoleClaims]
GO

/* ---------------------- Deleting AspNetUserClaims -----------------------------*/
DROP TABLE [dbo].[AspNetUserClaims]
GO

/* ---------------------- Deleting AspNetRoles -----------------------------*/
DROP TABLE [dbo].[AspNetRoles]
GO



/* --------------------- Creating AspNetRoles ----------------------------*/
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/* --------------------- Creating AspNetUserTokens ----------------------------*/
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO


/* --------------------- Creating AspNetRoleClaims ----------------------------*/
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO


/* --------------------- Creating AspNetUserClaims ----------------------------*/
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO


/* ------------------ Creating AspNetUserLogins --------------------------*/
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO


/* ------------------ Creating AspNetUserRoles --------------------------*/
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
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


UPDATE  AspNetUsers
SET    PasswordHash = [PN].PasswordHash, SecurityStamp = [PN].SecurityStamp
FROM   CSSPDB.dbo.AspNetUsers AS PN INNER JOIN
       AspNetUsers ON [PN].Id = AspNetUsers.Id
GO

UPDATE AspNetUsers
SET  NormalizedUserName = UPPER(UserName), NormalizedEmail = UPPER(Email)
GO

UPDATE       AspNetUsers
SET                EmailConfirmed = 1
WHERE        (Email LIKE 'paul.jiapizian@canada.ca') 
or (Email LIKE 'Patrice.Godin@Canada.ca')
or (Email LIKE 'David.Macarthur@Canada.ca')
or (Email LIKE 'Paul.Klaamas@Canada.ca')
or (Email LIKE 'sarah.sanche@canada.ca')
or (Email LIKE 'Christopher.Roberts@Canada.ca')
or (Email LIKE 'karyne.martell2@canada.ca')
or (Email LIKE 'Martin.Rodrigue@Canada.ca')
or (Email LIKE 'Joanne.volk@canada.ca')
or (Email LIKE 'Ryan.Alexander@Canada.ca')
or (Email LIKE 'paul.moccia@canada.ca')
or (Email LIKE 'megan.glavine@canada.ca')
or (Email LIKE 'Greg.Perchard@Canada.ca')
or (Email LIKE 'Yves.Lamontagne@Canada.ca')
or (Email LIKE 'Joe.Pomeroy@Canada.ca')
or (Email LIKE 'katherine.charland@canada.ca')
or (Email LIKE 'patti.densmore@canada.ca')
or (Email LIKE 'bernard.richard@canada.ca')
or (Email LIKE 'Dave.Curtis@Canada.ca')
or (Email LIKE 'Charles.Leblanc2@Canada.ca')
or (Email LIKE 'jeffrey.stobo@canada.ca')
or (Email LIKE 'david.duchesne@canada.ca')
or (Email LIKE 'james.arnott@canada.ca')
or (Email LIKE 'martin.deschenes@canada.ca')
or (Email LIKE 'Julieanne.Richard@Canada.ca')
or (Email LIKE 'cody.bannister2@canada.ca')
or (Email LIKE 'julie.savaria@canada.ca')
GO