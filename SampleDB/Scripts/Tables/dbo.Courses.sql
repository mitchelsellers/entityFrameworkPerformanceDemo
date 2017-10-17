CREATE TABLE [dbo].[Courses]
(
[CourseId] [int] NOT NULL IDENTITY(1, 1),
[DepartmentId] [int] NOT NULL,
[CourseName] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CourseAcronym] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CourseDescription] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsActive] [bit] NOT NULL
)
GO
ALTER TABLE [dbo].[Courses] ADD CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED  ([CourseId])
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CourseAcronym] ON [dbo].[Courses] ([CourseAcronym])
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CourseName] ON [dbo].[Courses] ([CourseName])
GO
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Courses] ([DepartmentId])
GO
ALTER TABLE [dbo].[Courses] ADD CONSTRAINT [FK_dbo.Courses_dbo.Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentId]) ON DELETE CASCADE
GO
