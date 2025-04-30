CREATE DATABASE QLDONHANG
USE QLDONHANG
-- Bảng Category (nhóm mặt hàng)
CREATE TABLE Category (
    MaCategory INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);
CREATE TABLE Product (
    MaProduct INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Price INT NOT NULL,
    Quantity INT DEFAULT 0,
    Description NVARCHAR(MAX) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    MaCategory INT NOT NULL,
    CONSTRAINT FK_Product_Category FOREIGN KEY (MaCategory) REFERENCES Category(MaCategory) ON DELETE CASCADE
);
drop table  Category
ALTER TABLE Category ALTER COLUMN Description NVARCHAR(255) NULL;
SELECT 
    p.MaProduct,
    p.Name AS ProductName,
    p.Price,
    p.Quantity,
    p.Description,
    p.CreatedAt,
    p.UpdatedAt,
    
    c.Name AS CategoryName  -- Lấy tên nhóm mặt hàng từ bảng Category
FROM 
    Product p
JOIN 
    Category c ON p.MaCategory = c.MaCategory;
