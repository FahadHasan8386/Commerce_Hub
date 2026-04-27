CREATE TABLE CartItems (
    Id BIGINT IDENTITY(1,1) NOT NULL 
        CONSTRAINT PK_CartItems PRIMARY KEY,

    CartId BIGINT NOT NULL,
    ProductId BIGINT NOT NULL,

    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,

    CreatedBy NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME NOT NULL
        CONSTRAINT DF_CartItems_CreatedAt DEFAULT GETUTCDATE(),

    IsDeleted BIT NOT NULL
        CONSTRAINT DF_CartItems_IsDeleted DEFAULT 0,

    ModifiedBy NVARCHAR(50) NULL,
    ModifiedAt DATETIME NULL,

    CONSTRAINT FK_CartItems_Carts 
        FOREIGN KEY (CartId) REFERENCES Carts(Id),

    CONSTRAINT FK_CartItems_Products 
        FOREIGN KEY (ProductId) REFERENCES Products(Id)
);