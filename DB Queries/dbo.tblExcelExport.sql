CREATE TABLE [dbo].[tblExcelExport] (
    [exAccount] NCHAR (11)    NOT NULL,
    [exName]    VARCHAR (MAX) NOT NULL,
    [exAddr]    VARCHAR (MAX) NOT NULL,
    [exWtr]     SMALLMONEY    DEFAULT ((10)) NULL,
    [exSwr]     SMALLMONEY    DEFAULT ((10)) NULL,
    [exChgDte]  DATETIME2 (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([exAccount] ASC)
);

