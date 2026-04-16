CREATE TABLE Products (
    Id BIGINT IDENTITY(1,1) NOT NULL 
        CONSTRAINT PK_Products PRIMARY KEY,

    Name NVARCHAR(150) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    Price DECIMAL(18,2) NOT NULL,
    StockQuantity INT NOT NULL,

    CategoryId BIGINT NOT NULL,

    CreatedBy NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME2 NOT NULL
        CONSTRAINT DF_Products_CreatedAt DEFAULT GETUTCDATE(),

    IsDeleted BIT NOT NULL
        CONSTRAINT DF_Products_IsDeleted DEFAULT 0,

    ModifiedBy NVARCHAR(50) NULL,
    ModifiedAt DATETIME2 NULL,

    CONSTRAINT FK_Products_Categories 
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);