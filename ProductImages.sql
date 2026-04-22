CREATE TABLE ProductImages (
    Id BIGINT IDENTITY(1,1) NOT NULL 
        CONSTRAINT PK_ProductImages PRIMARY KEY,

    ProductId BIGINT NOT NULL,

    ImageUrl NVARCHAR(MAX) NOT NULL,

    CreatedBy NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME2 NOT NULL
        CONSTRAINT DF_ProductImages_CreatedAt DEFAULT GETUTCDATE(),

    IsDeleted BIT NOT NULL
        CONSTRAINT DF_ProductImages_IsDeleted DEFAULT 0,

    ModifiedBy NVARCHAR(100) NULL,
    ModifiedAt DATETIME2 NULL
);