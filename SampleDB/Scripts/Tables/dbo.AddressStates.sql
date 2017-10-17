CREATE TABLE [dbo].[AddressStates]
(
[StateId] [int] NOT NULL IDENTITY(1, 1),
[StateCode] [nvarchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[StateName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[AddressStates] ADD CONSTRAINT [PK_dbo.AddressStates] PRIMARY KEY CLUSTERED  ([StateId])
GO
