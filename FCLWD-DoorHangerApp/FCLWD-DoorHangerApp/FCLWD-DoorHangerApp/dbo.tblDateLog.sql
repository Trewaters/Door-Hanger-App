CREATE TABLE [dbo].[tblDateLog] (
    [dlPkey]   INT           NOT NULL,
    [dlNew]    DATETIME2 (7) NULL DEFAULT '1900-01-01',
    [dlUpdate] DATETIME2 (7) NULL DEFAULT '1900-01-01',
    [dlDH]     DATETIME2 (7) NULL DEFAULT '1900-01-01',
    [dlTerm]   DATETIME2 (7) NULL DEFAULT '1900-01-01',
    [dlCSweep] DATETIME2 (7) NULL DEFAULT '1900-01-01',
    PRIMARY KEY CLUSTERED ([dlPkey] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'primary Key equal to Cycle', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblDateLog', @level2type = N'COLUMN', @level2name = N'dlPkey';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Data Refreshed on this Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblDateLog', @level2type = N'COLUMN', @level2name = N'dlNew';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Data updated between Door Hanger and Terminations', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblDateLog', @level2type = N'COLUMN', @level2name = N'dlUpdate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'date the Door Hangers were printed', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblDateLog', @level2type = N'COLUMN', @level2name = N'dlDH';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'date teh Terminations were printed ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblDateLog', @level2type = N'COLUMN', @level2name = N'dlTerm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'date the Clean Sweep was run', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblDateLog', @level2type = N'COLUMN', @level2name = N'dlCSweep';

