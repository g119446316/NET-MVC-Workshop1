﻿CREATE TABLE [dbo].[Table]
(
	[BOOK_CLASS_ID] NVARCHAR(8) NOT NULL PRIMARY KEY, 
    [BOOK_CLASS_NAME] NCHAR(120) NOT NULL, 
    [CREATE_DATE] NCHAR(8) NULL, 
    [CREATE_USER] NCHAR(24) NULL, 
    [MODIFY_DATE] DATETIME NULL, 
    [MODIFY_USER] NCHAR(24) NULL
)