CREATE TABLE [dbo].[tblShutOff] (
    [soAccount]   VARCHAR (11)  NOT NULL,
    [soAge0]      SMALLMONEY    NULL,
    [soAge1]      SMALLMONEY    NULL,
    [soAge2]      SMALLMONEY    NULL,
    [soAge3]      SMALLMONEY    NULL,
    [soAge4]      SMALLMONEY    NULL,
    [soAge5]      SMALLMONEY    NULL,
    [soBal]       SMALLMONEY    NULL,
    [soName]      VARCHAR (MAX) NULL,
    [soAddr]      VARCHAR (MAX) NULL,
    [soLoc]       VARCHAR (MAX) NULL,
    [soCycle]     INT           NULL,
    [soLstPayDte] DATETIME2 (7) NULL,
    [soLstPayAmt] SMALLMONEY    NULL,
    [soStCde]     INT           NULL,
    [soStCdeDte]  DATETIME2 (7) NULL,
    [soAgreeDue]  DATETIME2 (7) NULL,
    [soAgreeMade] DATETIME2 (7) NULL,
    [soPmtAgreed] SMALLMONEY    NULL,
    [soUnPmt]     SMALLMONEY    NULL,
    [soPriRte]    VARCHAR (MAX) NULL,
    [soSecRte]    VARCHAR (MAX) NULL,
    [soPnotes]    VARCHAR (MAX) NULL,
    [soANotes]    VARCHAR (MAX) NULL,
    [soMNotes]    VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([soAccount] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Premise-Tenant Account number and primary key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soAccount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'not sure what this amount is', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soAge0';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'0-30 days old amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soAge1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'30-60 days old amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soAge2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'60-90 days old amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soAge3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'90 days plus old amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soAge4';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'120 plus days old amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soAge5';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Current Account Balance', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soBal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Customer Name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Service Address', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soAddr';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Meter Location', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soLoc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Billing Cycle for the customer', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soCycle';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Last date a payment was made on account', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soLstPayDte';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Last amount they paid on that date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soLstPayAmt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Status code on the meter', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soStCde';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Date the status code was changed', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soStCdeDte';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Date the payment arrangement amount is due', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soAgreeDue';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Date the payment arrangement was made', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soAgreeMade';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Payment arrangement amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soPmtAgreed';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Uposted payment amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soUnPmt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primary Rate from Billmaster. Usually Water Service. Formerly "Primary Rate"', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soPriRte';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Secondary Rate from Billmaster. Usually Sewer Service. Formerly "Secondary Rate"', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soSecRte';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Premise Notes from Billmaster', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soPnotes';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Account Notes from Billmaster', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soANotes';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Meter Notes from Billmaster', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblShutOff', @level2type = N'COLUMN', @level2name = N'soMNotes';

