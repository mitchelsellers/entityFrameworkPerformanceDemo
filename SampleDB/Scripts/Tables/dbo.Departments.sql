CREATE TABLE [dbo].[Departments]
(
[DepartmentId] [int] NOT NULL IDENTITY(1, 1),
[DepartmentName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[Departments] ADD CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED  ([DepartmentId])
GO
