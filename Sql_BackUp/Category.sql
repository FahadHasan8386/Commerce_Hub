CREATE TABLE Categories (
    Id BIGINT IDENTITY(1,1) NOT NULL 
        CONSTRAINT PK_Categories PRIMARY KEY,

    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NULL,

    CreatedBy NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME NOT NULL
        CONSTRAINT DF_Categories_CreatedAt DEFAULT GETUTCDATE(),

    IsDeleted BIT NOT NULL
        CONSTRAINT DF_Categories_IsDeleted DEFAULT 0,

    ModifiedBy NVARCHAR(50) NULL,
    ModifiedAt DATETIME NULL
);