CREATE TABLE [dbo].[tblWorkingData] (
    [wdAccount]   NCHAR (11)    NOT NULL,
    [wdAge0]      SMALLMONEY    NULL,
    [wdAge1]      SMALLMONEY    NULL,
    [wdAge2]      SMALLMONEY    NULL,
    [wdAge3]      SMALLMONEY    NULL,
    [wdAge4]      SMALLMONEY    NULL,
    [wdAge5]      SMALLMONEY    NULL,
    [wdBal]       SMALLMONEY    NULL,
    [wdName]      VARCHAR (MAX) NULL,
    [wdAddr]      VARCHAR (MAX) NULL,
    [wdLoc]       VARCHAR (MAX) NULL,
    [wdCycle]     INT           NULL,
    [wdLstPayDte] DATETIME2 (7) NULL,
    [wdLstPayAmt] SMALLMONEY    NULL,
    [wdStCde]     INT           NULL,
    [wdStDesc]    VARCHAR (30)  NULL,
    [wdPnotes]    VARCHAR (MAX) NULL,
    [wdANotes]    VARCHAR (MAX) NULL,
    [wdMNotes]    VARCHAR (MAX) NULL,
    [wdTerm]      BIT           NULL,
    [wdHang]      BIT           NULL,
    [wdHangDte]   DATETIME2 (7) NULL,
    [wdCntDte]    DATETIME2 (7) NULL,
    [wdTermDte]   DATETIME2 (7) NULL,
    [wdAgreeDue]  DATETIME2 (7) NULL,
    [wdPmtAgreed] SMALLMONEY    NULL,
    [wdUnPmt]     SMALLMONEY    NULL,
    [wdPriRte]    VARCHAR (30)  NULL,
    [wdSecRte]    VARCHAR (30)  NULL,
    [wdStCdeDte]  DATETIME2 (7) NULL,
    [wdAgreeMade] DATETIME2 (7) NULL,
    [wdMinDue]    SMALLMONEY    NULL,
    PRIMARY KEY CLUSTERED ([wdAccount] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Premise-Tenant Account number. Primary Key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdAccount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'not sure what this amount is', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdAge0';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'0-30 days old amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdAge1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'30-60 days old amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdAge2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'60-90 days old amount [PTntvfAge2]', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdAge3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'90 plus days old amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdAge4';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'120 plus days old amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdAge5';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Current account balance', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdBal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Customer name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Customer Street Address', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdAddr';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Meter Location', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdLoc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Billing Cycle for the customer', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdCycle';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'last date a payment was made on account', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdLstPayDte';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Last amount they paid on that date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdLstPayAmt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Status Code on the meter', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdStCde';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Status Code description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdStDesc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Premise Notes from Billmaster', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdPnotes';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Account Notes from Billmaster', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdANotes';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Meter Notes from Billmaster', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdMNotes';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Print Termination Notice 33 (Final Notice)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdTerm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'print Door Hanger Notice (1st Notice)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdHang';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Door Hanger (1st Notice) date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdHangDte';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Contact Office by date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdCntDte';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Termination (Final Notice) date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdTermDte';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Payment Agreement Due Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdAgreeDue';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Amount of Payment Arrangement', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdPmtAgreed';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Amount of Unposted Payment for this customer', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdUnPmt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Type of Water Service by text description. Formerly "wdWater"', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdPriRte';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Type of Sewer Service by text description. Formerly "wdSewer"', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdSecRte';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Date the status code was changed', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdStCdeDte';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'date the Payment agreement was made', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblWorkingData', @level2type = N'COLUMN', @level2name = N'wdAgreeMade';

