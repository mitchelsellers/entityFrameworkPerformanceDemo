CREATE TABLE [dbo].[CourseSessions]
(
[CourseSessionId] [int] NOT NULL IDENTITY(1, 1),
[CourseId] [int] NOT NULL,
[SchoolId] [int] NOT NULL,
[SessionIdentifier] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RegistrationOpens] [datetime] NOT NULL,
[RegistrationCloses] [datetime] NOT NULL,
[ClassStarts] [datetime] NOT NULL,
[ClassEnds] [datetime] NOT NULL,
[InstructorId] [int] NOT NULL,
[Instructor_FacultyMemberId] [int] NULL,
[Classroom_ClassroomId] [int] NULL
)
GO
ALTER TABLE [dbo].[CourseSessions] ADD CONSTRAINT [PK_dbo.CourseSessions] PRIMARY KEY CLUSTERED  ([CourseSessionId])
GO
CREATE NONCLUSTERED INDEX [IX_Classroom_ClassroomId] ON [dbo].[CourseSessions] ([Classroom_ClassroomId])
GO
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[CourseSessions] ([CourseId])
GO
CREATE NONCLUSTERED INDEX [IX_Instructor_FacultyMemberId] ON [dbo].[CourseSessions] ([Instructor_FacultyMemberId])
GO
CREATE NONCLUSTERED INDEX [IX_SchoolId] ON [dbo].[CourseSessions] ([SchoolId])
GO
ALTER TABLE [dbo].[CourseSessions] ADD CONSTRAINT [FK_dbo.CourseSessions_dbo.Classrooms_Classroom_ClassroomId] FOREIGN KEY ([Classroom_ClassroomId]) REFERENCES [dbo].[Classrooms] ([ClassroomId])
GO
ALTER TABLE [dbo].[CourseSessions] ADD CONSTRAINT [FK_dbo.CourseSessions_dbo.Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Courses] ([CourseId]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseSessions] ADD CONSTRAINT [FK_dbo.CourseSessions_dbo.FacultyMembers_Instructor_FacultyMemberId] FOREIGN KEY ([Instructor_FacultyMemberId]) REFERENCES [dbo].[FacultyMembers] ([FacultyMemberId])
GO
ALTER TABLE [dbo].[CourseSessions] ADD CONSTRAINT [FK_dbo.CourseSessions_dbo.Schools_SchoolId] FOREIGN KEY ([SchoolId]) REFERENCES [dbo].[Schools] ([SchoolId]) ON DELETE CASCADE
GO
