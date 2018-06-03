﻿CREATE TABLE [dbo].[USR01] (
    [USRNAME]   CHAR (24) NOT NULL,
    [USPASS]    CHAR (32) NOT NULL,
    [FNAME]     CHAR (50) NOT NULL,
    [LNAME]     CHAR (50) NOT NULL,
    [BDATE]     DATE      NOT NULL,
    [SEX]       CHAR (1)  NOT NULL,
    [USTRIES]   INT       NOT NULL,
    [ISBLOCKED] CHAR (1)  NOT NULL,
    [ISRECOV]   CHAR (1)  NOT NULL,
    [DVH]       INT       NOT NULL,
    PRIMARY KEY CLUSTERED ([USRNAME] ASC)
);
