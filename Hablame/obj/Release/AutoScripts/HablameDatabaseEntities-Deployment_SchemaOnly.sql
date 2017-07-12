SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conversation](
	[Id] [uniqueidentifier] NOT NULL,
	[TeacherId] [uniqueidentifier] NOT NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NULL,
	[DurationMinutes] [int] NOT NULL,
	[LanguageId] [uniqueidentifier] NOT NULL,
	[MistakeTypeOptionsConfigId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Conversation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LanguageFamilyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguageFamily](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_LanguageFamily] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mistake](
	[Id] [uniqueidentifier] NOT NULL,
	[ConversationId] [uniqueidentifier] NOT NULL,
	[SpokenValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CorrectValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsGrammar] [bit] NOT NULL,
	[IsVocab] [bit] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Rating] [int] NOT NULL,
	[IsPronunciation] [bit] NOT NULL,
	[IsPraise] [bit] NULL,
 CONSTRAINT [PK_Mistake] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MistakeAssignedMistakeType](
	[Id] [uniqueidentifier] NOT NULL,
	[MistakeId] [uniqueidentifier] NOT NULL,
	[MistakeTypeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_MistakeAssignedMistakeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MistakeMade](
	[Id] [uniqueidentifier] NOT NULL,
	[ConversationId] [uniqueidentifier] NOT NULL,
	[MistakeId] [uniqueidentifier] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Rating] [int] NOT NULL,
 CONSTRAINT [PK_MistakeMadeMistakeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MistakeType](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MinimumRatingLevelVisibility] [int] NOT NULL,
	[MaximumRatingLevelVisibility] [int] NOT NULL,
	[LanguageId] [uniqueidentifier] NOT NULL,
	[IsGrammar] [bit] NOT NULL,
	[IsPronunciation] [bit] NOT NULL,
	[IsVocab] [bit] NOT NULL,
	[IsPraise] [bit] NOT NULL,
 CONSTRAINT [PK_MistakeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MistakeTypeConfiguration](
	[Id] [uniqueidentifier] NOT NULL,
	[OwnerId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FirstMistakeTypeId] [uniqueidentifier] NOT NULL,
	[SecondMistakeTypeId] [uniqueidentifier] NOT NULL,
	[ThirdMistakeTypeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_MistakeTypeConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [uniqueidentifier] NOT NULL,
	[Forename] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Surname] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EmailAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PremiumAccount] [bit] NOT NULL,
	[PasswordHash] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW dbo.vw_ConversationSummary
AS
SELECT        c.StartDateTime, s.Forename AS 'StudentForename', s.Surname AS 'StudentSurname', t.Forename AS 'TeacherForename', t.Surname AS 'TeacherSurname', l.Name AS 'Language', 
                         config.Name AS ConfigurationName, c.DurationMinutes, c.Id AS 'ConversationId', c.LanguageId, c.MistakeTypeOptionsConfigId, c.StudentId, c.TeacherId
FROM            dbo.Conversation AS c INNER JOIN
                         dbo.Person AS t ON c.TeacherId = t.Id INNER JOIN
                         dbo.Person AS s ON c.StudentId = s.Id LEFT OUTER JOIN
                         dbo.MistakeTypeConfiguration AS config ON c.MistakeTypeOptionsConfigId = config.Id LEFT OUTER JOIN
                         dbo.Language AS l ON c.LanguageId = l.Id

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW dbo.vw_MistakeMadeSummary
AS
SELECT        mm.MistakeId, mm.ConversationId, m.SpokenValue, m.CorrectValue, mm.DateTime, m.IsGrammar, m.IsVocab, m.IsPronunciation, m.IsPraise
FROM            dbo.MistakeMade AS mm INNER JOIN
                         dbo.Mistake AS m ON mm.MistakeId = m.Id

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW dbo.vw_Mistakes
AS
SELECT        m.Id, m.SpokenValue, m.CorrectValue, COUNT(*) AS Count
FROM            dbo.MistakeMade AS mm INNER JOIN
                         dbo.Mistake AS m ON mm.MistakeId = m.Id
GROUP BY m.SpokenValue, m.CorrectValue, m.Id

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW dbo.vw_MistakesByConversation
AS
SELECT        m.Id, m.SpokenValue, m.CorrectValue, mm.ConversationId, m.IsPraise, COUNT(*) AS Count
FROM            dbo.MistakeMade AS mm INNER JOIN
                         dbo.Mistake AS m ON mm.MistakeId = m.Id
GROUP BY m.SpokenValue, m.CorrectValue, mm.ConversationId, m.Id, m.IsPraise

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW dbo.vw_MistakesByLanguage
AS
SELECT        m.Id, m.SpokenValue, m.CorrectValue, c.LanguageId, m.IsPraise, COUNT(*) AS Count
FROM            dbo.MistakeMade AS mm INNER JOIN
                         dbo.Mistake AS m ON mm.MistakeId = m.Id INNER JOIN
                         dbo.Conversation AS c ON mm.ConversationId = c.Id
GROUP BY m.SpokenValue, m.CorrectValue, c.LanguageId, m.Id, m.IsPraise

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW dbo.vw_MistakesByStudent
AS
SELECT        m.Id, m.SpokenValue, m.CorrectValue, c.StudentId, m.IsPraise, COUNT(*) AS Count
FROM            dbo.MistakeMade AS mm INNER JOIN
                         dbo.Mistake AS m ON mm.MistakeId = m.Id INNER JOIN
                         dbo.Conversation AS c ON m.ConversationId = c.Id
GROUP BY m.SpokenValue, m.CorrectValue, c.StudentId, m.Id, m.IsPraise

GO
ALTER TABLE [dbo].[Language]  WITH CHECK ADD  CONSTRAINT [FK_Language_Family] FOREIGN KEY([LanguageFamilyId])
REFERENCES [dbo].[LanguageFamily] ([Id])
GO
ALTER TABLE [dbo].[Language] CHECK CONSTRAINT [FK_Language_Family]
GO
ALTER TABLE [dbo].[Mistake]  WITH CHECK ADD  CONSTRAINT [FK_Mistake_Conversation] FOREIGN KEY([ConversationId])
REFERENCES [dbo].[Conversation] ([Id])
GO
ALTER TABLE [dbo].[Mistake] CHECK CONSTRAINT [FK_Mistake_Conversation]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Barry Rimell
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[getTopMistakesByConversationId] 
	@conversationId uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT
TOP 10
Mistake.ConversationId,
Mistake.SpokenValue,
Mistake.CorrectValue, 
Mistake.Id,
Mistake.IsMissingAuxVerb,
Mistake.IsSuperfluousAuxVerb
FROM Mistake
WHERE Mistake.ConversationId = @conversationId;
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Barry Rimell
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[getTopMistakesByLanguageId] 
	@languageId uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT
TOP 10
Mistake.ConversationId,
Mistake.SpokenValue,
Mistake.CorrectValue, 
Mistake.Id,
Mistake.IsMissingAuxVerb,
Mistake.IsSuperfluousAuxVerb
FROM Mistake
INNER JOIN Conversation
ON Mistake.ConversationId = Conversation.Id
WHERE Conversation.LanguageId = @languageId;
END

GO
