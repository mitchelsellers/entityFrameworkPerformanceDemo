CREATE TABLE [dbo].[FacultyMembers]
(
[FacultyMemberId] [int] NOT NULL IDENTITY(1, 1),
[FirstName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LastName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[EmailAddress] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[School_SchoolId] [int] NULL
)
GO
ALTER TABLE [dbo].[FacultyMembers] ADD CONSTRAINT [PK_dbo.FacultyMembers] PRIMARY KEY CLUSTERED  ([FacultyMemberId])
GO
CREATE NONCLUSTERED INDEX [IX_School_SchoolId] ON [dbo].[FacultyMembers] ([School_SchoolId])
GO
ALTER TABLE [dbo].[FacultyMembers] ADD CONSTRAINT [FK_dbo.FacultyMembers_dbo.Schools_School_SchoolId] FOREIGN KEY ([School_SchoolId]) REFERENCES [dbo].[Schools] ([SchoolId])
GO
