Create database Currency
CREATE TABLE Currency(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CurrencyCode VARCHAR(10) NOT NULL, -- ���O�N�X
    CurrencyName VARCHAR(100) NULL, -- ���O����W��
	CurrencyLang VARCHAR(10) NULL, -- ���O�y�t�N�X
	CurrencySymbol VARCHAR(10) NULL,
	CurrencyRate decimal(18, 0) NULL,
	CurrencyDescription VARCHAR(100) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(), -- �إ߮ɶ�
    UpdatedAt DATETIME DEFAULT GETDATE() -- ��s�ɶ�
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