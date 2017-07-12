SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ContextKey] [nvarchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Name] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ClaimType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClaimValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProviderKey] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RoleId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecurityStamp] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhoneNumber] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201706260848479_InitialCreate', N'Hablame.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5C5B6FE3B6127E2F70FE83A0A7738AD4CAE5EC624F606F913AC9D9A09B0BD6D9C5795BD012ED082B51AA44A5098AFEB23EF427F52F9CA144C9E24D175BB19D628145440EBF190E87E47038F45F7FFC39FEF1290CAC479CA47E4426F6D1E8D0B6307123CF27CB899DD1C50FEFEC1FDFFFE3BBF185173E595F4ABA1346072D493AB11F288D4F1D27751F7088D251E8BB4994460B3A72A3D0415EE41C1F1EFEC7393A723040D8806559E34F19A17E88F30FF89C46C4C531CD50701D7938487939D4CC7254EB0685388D918B27F607340FE06B5450DAD659E02390628683856D2142228A28C878FA39C5339A4464398BA10005F7CF3106BA050A52CC653F5D9177EDC6E131EB86B36A5842B9594AA3B027E0D109D78B23375F4BBB76A537D0DC0568983EB35EE7DA9BD8571ECE8B3E4501284066783A0D12463CB1AF2B1667697C83E9A86C382A202F1380FB354ABE8DEA880756E77607951D1D8F0ED9BF036B9A05344BF084E08C262838B0EEB279E0BB3FE3E7FBE81B269393A3F9E2E4DD9BB7C83B79FB6F7CF2A6DE53E82BD0090550749744314E4036BCA8FA6F5B8ED8CE911B56CD6A6D0AAD802DC194B0AD6BF4F41193257D80C972FCCEB62EFD27EC9525DCB83E131F661034A249069F37591080D1E2AADE69E4C9FE6FE07AFCE6ED205C6FD0A3BFCC875EE20F13278179F50907796DFAE0C7C5F412C6FB2B27BB4CA2907D8BF655D47E9D4559E2B2CE4446927B942C3115A51B3B2BE3ED64D20C6A78B32E51F7DFB499A4AA796B495987D69909258B6DCF8652DE97E5DBD9E2CEE218062F372DA69126831337AA91D4F2C0E2F52B9339EA6A3204BAF2775E012F42E407032C811DB880E7B1F0931057BDFC29028343A4B7CC77284D6105F03EA0F4A14174F87300D167D8CD1230CC194561FCE2DCEE1E22826FB270CEEC7D7BBC061B9AFB5FA34BE4D228B920ACD5C6781F23F75B94D10BE29D238A3F53B704649FF77ED81D601071CE5C17A7E9251833F6A61138D625E015A127C7BDE1D8E2B46B17641A203FD4FB20D232FAB5245DF9217A0AC5173190E9FC9126513F464B9F7413B524358B5A50B48ACAC9FA8ACAC0BA49CA29CD82E604AD721654837978F9080DEFE2E5B0FBEFE36DB6799BD6829A1A67B042E2FF62821358C6BC3B44294EC86A04BAAC1BBB7016F2E1634C5F7C6FCA397D41413634ABB56643BE080C3F1B72D8FD9F0DB99850FCE87BCC2BE970F0298901BE13BDFE4CD53EE724C9B63D1D846E6E9BF976D600D374394BD3C8F5F359A00979F18085283FF870567BF4A2E88D1C01818E81A1FB6CCB8312E89B2D1BD52D39C701A6D83A738B90E014A52EF254354287BC1E82953BAA46B055244414EE7B8527583A4E5823C40E4129CC549F50755AF8C4F56314B46A496AD9710B637DAF78C835E738C684316CD54417E6FAC00713A0E2230D4A9B86C64ECDE29A0DD1E0B59AC6BCCD855D8DBB128FD88A4DB6F8CE06BBE4FEDB8B1866B3C6B6609CCD2AE922803188B70B03E56795AE06201F5CF6CD40A51393C140B94BB515031535B603031555F2EA0CB438A2761D7FE9BCBA6FE6291E94B7BFAD37AA6B07B629E863CF4CB3F03DA10D85163851CDF37CCE2AF113D51CCE404E7E3E4BB9AB2B9B08039F612A866C56FEAED60F759A4164236A025C195A0B28BFFE53809409D543B83296D7281DF7227AC09671B74658BEF64BB0351B50B1EBD7A03542F365A96C9C9D4E1F55CF2A6B508CBCD361A186A3310879F1123BDE4129A6B8ACAA982EBE701F6FB8D6313E180D0A6AF15C0D4A2A3B33B8964AD36CD792CE21EBE3926DA425C97D3268A9ECCCE05AE236DAAE248D53D0C32DD84845E2163ED0642B231DD56E53D58D9D22338A178C1D430AD5F81AC5B14F96B5942A5E62CD8A7CAAE90FB3FEC9466181E1B8A926E7A892B6E244A3042DB1540BAC41D24B3F49E939A2688E589C67EA850A99766F352CFF25CBFAF6A90E62B90F94D4ECEFA28574692FECB3AA23C2DB5F42EF42E6CDE42174CDD8EB9B5B2CBD0D0528D144EDA7519085C4EC5C995B177777F5F645898A307624F915E749D194E2E28A6AEF3428EA841860802ABF65FD41324398545D7A9D75659B3C51334A1998AAA39882553B1B349303D379A064BFB0FF38B522BCCC7CE2C92875005ED413A396CFA080D5EABAA38A2927754CB1A63BA29457528794AA7A4859CF1E1184AC57AC8567D0A89EA23B07355FA48EAED67647D6648ED4A135D56B606B6496EBBAA36A924BEAC09AEAEED8AB4C137901DDE31DCB785A596BCB2A0EB39BED59068C97590D87D9F26A77F675A05A714F2C7E2BAF80F1F2BDB424E3896E2D4B2AE2179B599201C3BCE20837DDE282D3783D6FC614AEAF8545BDE9FADE8CD7CF5E5FD42A94C39C4C5271AF0E75D2E16DCC0F52ED8F6494935541625BA51A61437F4E290E478C6034FB2598063E66CB7749708D88BFC0292D5236ECE3C3A363E9ADCDFEBC7B71D2D40B340751D3E31771CCB6907D451E51E23EA044CD85D8E06DC80A5409335F110F3F4DECDFF256A779C482FD95171F5857E967E2FF9241C57D9261EB7735B773985CF9E683D59EBE6CE8AED5ABFF7D2D9A1E58B709CC9853EB50D2E53A232CBE77E8254DD1740369D67E05F17A2794F0D4408B2A4D88F55F16CC7D3AC8AB8252CA7F86E8E95F7D45D3BE1CD80851F33A6028BC415468CAFE5F07CB98F9EFC127CD33FFFB7556FF12601DD18CAF007CD21F4C7E03D07D192A5BEE70ABD19C87B6B124E57A6ECDA1DE28A172D77B93926ABDD14457D3A97BC06D9032BD8665BCB26CE3C176474D32F160D8BB34ED17CF20DE97A4E1553AC76E7385B7991EDC7015F4B7CA0ADE833C364D5ECEEE737FB76D6BA618EE9E2750F6CBF0DD3363E3D95ABBCFE3DDB6B199C2BC7B6E6CBDB275F7CCD676B57FEED8D23A6FA13BCFBD55D3880C7731BA58705B6E6D11388713FE3C0223283CCAE249A43E99AB2911B585E18AC4CCD49C45263356268EC257A16866DBAFAF7CC36FEC2CA769666BC8BD6CE2CDD7FF46DE9CA699B721A3711759C1DA9C425DA676CB3AD694F8F49AB280859EB4249DB7F9AC8D17EBAF29E97710A508B3C77047FC7A727C0751C99053A7474EAF7ADD0B7B67ED971361FF4EFDE50A82FD8E22C1AEB06B5634576411959BB7245149224568AE31451E6CA96709F517C8A550CD62CCF99BEE3C6EC76E3AE6D8BB22B7198D330A5DC6E13C10025ECC0968E29F272E8B328F6FE3FCE74986E80288E9B3D8FC2DF929F303AF92FB521313324030EF824774D9585216D95D3E57483711E908C4D5573945F7388C03004B6FC90C3DE2756403F3FB8897C87D5E45004D20ED0321AA7D7CEEA36582C29463ACDAC327D8B0173EBDFF3F5706C8D440540000, N'6.1.3-40302')
GO
SET ANSI_PADDING ON

GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
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
