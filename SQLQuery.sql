Create database Currency
CREATE TABLE Currency(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CurrencyCode VARCHAR(10) NOT NULL, -- 幣別代碼
    CurrencyName VARCHAR(100) NULL, -- 幣別中文名稱
	CurrencyLang VARCHAR(10) NULL, -- 幣別語系代碼
	CurrencySymbol VARCHAR(10) NULL,
	CurrencyRate decimal(18, 0) NULL,
	CurrencyDescription VARCHAR(100) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(), -- 建立時間
    UpdatedAt DATETIME DEFAULT GETDATE() -- 更新時間
);

CREATE TABLE [dbo].[Card](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Attack] [int] NOT NULL,
	[Health] [int] NOT NULL,
	[Cost] [int] NOT NULL
) ON [PRIMARY]
GO