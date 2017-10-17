CREATE TABLE [dbo].[Schools]
(
[SchoolId] [int] NOT NULL IDENTITY(1, 1),
[SchoolTypeId] [int] NOT NULL,
[SchoolName] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Address] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Address2] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[City] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[StateId] [int] NOT NULL,
[PostalCode] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsActive] [bit] NOT NULL CONSTRAINT [DF__Schools__IsActiv__656C112C] DEFAULT ((0))
)
GO
ALTER TABLE [dbo].[Schools] ADD CONSTRAINT [PK_dbo.Schools] PRIMARY KEY CLUSTERED  ([SchoolId])
GO
CREATE NONCLUSTERED INDEX [IX_SchoolTypeId] ON [dbo].[Schools] ([SchoolTypeId])
GO
CREATE NONCLUSTERED INDEX [IX_StateId] ON [dbo].[Schools] ([StateId])
GO
ALTER TABLE [dbo].[Schools] ADD CONSTRAINT [FK_dbo.Schools_dbo.AddressStates_StateId] FOREIGN KEY ([StateId]) REFERENCES [dbo].[AddressStates] ([StateId]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Schools] ADD CONSTRAINT [FK_dbo.Schools_dbo.SchoolTypes_SchoolTypeId] FOREIGN KEY ([SchoolTypeId]) REFERENCES [dbo].[SchoolTypes] ([SchoolTypeId]) ON DELETE CASCADE
GO
