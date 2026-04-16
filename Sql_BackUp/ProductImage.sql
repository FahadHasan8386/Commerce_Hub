CREATE TABLE ProductImages
(
    Id BIGINT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_ProductImages PRIMARY KEY,

    ProductId BIGINT NOT NULL,

    ImageUrl NVARCHAR(500) NOT NULL,
    IsPrimary BIT NOT NULL
        CONSTRAINT DF_ProductImages_IsPrimary DEFAULT 0,

    CreatedAt DATETIME2 NOT NULL
        CONSTRAINT DF_ProductImages_CreatedAt DEFAULT GETUTCDATE(),

    CONSTRAINT FK_ProductImages_Products
        FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
CREATE UNIQUE INDEX UX_ProductImages_OnePrimary
ON ProductImages(ProductId)
WHERE IsPrimary = 1;