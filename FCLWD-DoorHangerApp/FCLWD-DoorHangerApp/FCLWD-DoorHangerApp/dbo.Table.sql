﻿CREATE TABLE [dbo].[tblCodes]
(
	[CodeValue] INT NOT NULL PRIMARY KEY, 
    [CodeDescription] VARCHAR(MAX) NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Billmaster Code value',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'tblCodes',
    @level2type = N'COLUMN',
    @level2name = N'CodeValue'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Description of equivalent Billmaster Code Value',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'tblCodes',
    @level2type = N'COLUMN',
    @level2name = N'CodeDescription'
	GO
