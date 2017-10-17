CREATE TABLE [dbo].[SchoolCourses]
(
[School_SchoolId] [int] NOT NULL,
[Course_CourseId] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[SchoolCourses] ADD CONSTRAINT [PK_dbo.SchoolCourses] PRIMARY KEY CLUSTERED  ([School_SchoolId], [Course_CourseId])
GO
CREATE NONCLUSTERED INDEX [IX_Course_CourseId] ON [dbo].[SchoolCourses] ([Course_CourseId])
GO
CREATE NONCLUSTERED INDEX [IX_School_SchoolId] ON [dbo].[SchoolCourses] ([School_SchoolId])
GO
ALTER TABLE [dbo].[SchoolCourses] ADD CONSTRAINT [FK_dbo.SchoolCourses_dbo.Courses_Course_CourseId] FOREIGN KEY ([Course_CourseId]) REFERENCES [dbo].[Courses] ([CourseId]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SchoolCourses] ADD CONSTRAINT [FK_dbo.SchoolCourses_dbo.Schools_School_SchoolId] FOREIGN KEY ([School_SchoolId]) REFERENCES [dbo].[Schools] ([SchoolId]) ON DELETE CASCADE
GO
