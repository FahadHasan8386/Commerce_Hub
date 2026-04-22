CREATE TABLE ProductImages (
    Id BIGINT IDENTITY(1,1) NOT NULL 
        CONSTRAINT PK_ProductImages PRIMARY KEY,

    ImageUrl NVARCHAR(MAX) NOT NULL,
    IsPrimary BIT NOT NULL 
        CONSTRAINT DF_ProductImages_IsPrimary DEFAULT 0, -- প্রধান ছবি কি না তা চেনার জন্য

    ProductId BIGINT NOT NULL, -- ফরেন কি (Foreign Key)

    -- Audit Fields
    CreatedBy NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME2 NOT NULL
        CONSTRAINT DF_ProductImages_CreatedAt DEFAULT GETUTCDATE(),

    IsDeleted BIT NOT NULL
        CONSTRAINT DF_ProductImages_IsDeleted DEFAULT 0,

    ModifiedBy NVARCHAR(50) NULL,
    ModifiedAt DATETIME2 NULL,

    -- Foreign Key Constraint
    CONSTRAINT FK_ProductImages_Products 
        FOREIGN KEY (ProductId) REFERENCES Products(Id) 
        ON DELETE CASCADE -- প্রোডাক্ট ডিলিট হলে ছবিও ডাটাবেজ থেকে মুছে যাবে
);