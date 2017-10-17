CREATE TABLE [dbo].[Classrooms]
(
[ClassroomId] [int] NOT NULL IDENTITY(1, 1),
[SchoolId] [int] NOT NULL,
[Roomname] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MaxStudents] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[Classrooms] ADD CONSTRAINT [PK_dbo.Classrooms] PRIMARY KEY CLUSTERED  ([ClassroomId])
GO
CREATE NONCLUSTERED INDEX [IX_SchoolId] ON [dbo].[Classrooms] ([SchoolId])
GO
ALTER TABLE [dbo].[Classrooms] ADD CONSTRAINT [FK_dbo.Classrooms_dbo.Schools_SchoolId] FOREIGN KEY ([SchoolId]) REFERENCES [dbo].[Schools] ([SchoolId]) ON DELETE CASCADE
GO
