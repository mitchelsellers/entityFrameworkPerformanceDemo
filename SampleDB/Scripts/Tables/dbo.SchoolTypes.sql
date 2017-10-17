CREATE TABLE [dbo].[SchoolTypes]
(
[SchoolTypeId] [int] NOT NULL IDENTITY(1, 1),
[SchoolTypeName] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[SchoolTypes] ADD CONSTRAINT [PK_dbo.SchoolTypes] PRIMARY KEY CLUSTERED  ([SchoolTypeId])
GO
