USE SmraaAlYamanDb
GO

CREATE SCHEMA ProductSupplayerData
Go



CREATE OR ALTER VIEW ProductSupplayerData.ProductSupplayersWithPhones
WITH SCHEMABINDING
AS
SELECT
    p.Id AS ProductId,
    p.Name AS ProductName,
    s.Id AS SupplayerId,
    s.Name AS SupplayerName,
    s.Scope AS SupplayerScope,
    s.ContactPhone AS SupplayerPhone
FROM [dbo].[ProductSupplayers] AS ps
JOIN dbo.Products AS p ON p.Id = ps.ProductId
JOIN dbo.Supplayers AS s ON s.Id = ps.SupplayerId;

CREATE UNIQUE CLUSTERED INDEX UIX_ProductSupplayersWithPhones_Id 
ON ProductSupplayerData.ProductSupplayersWithPhones(ProductId,SupplayerId);


CREATE INDEX IX_ProductSupplayersWithPhones_ProductId
ON ProductSupplayerData.ProductSupplayersWithPhones(ProductId);

CREATE INDEX IX_ProductSupplayersWithPhones_SupplayerId
ON ProductSupplayerData.ProductSupplayersWithPhones(SupplayerId);
CREATE INDEX IX_ProductSupplayersWithPhones_SupplayerPhone
ON ProductSupplayerData.ProductSupplayersWithPhones(SupplayerPhone);



CREATE INDEX IX_ProductSupplayersWithPhones_SupplayerScope
ON ProductSupplayerData.ProductSupplayersWithPhones(SupplayerScope);

CREATE INDEX IX_ProductSupplayersWithPhones_Name
ON ProductSupplayerData.ProductSupplayersWithPhones(SupplayerName);




CREATE OR ALTER PROC ProductSupplayerData.sp_GetProductSupplayers
    @ProductId INT = NULL,
    @Phone NVARCHAR(16) = NULL,
    @Scope NVARCHAR(100) = NULL,
    @Name NVARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        s.Id AS SupplayerId,
        s.Name AS SupplayerName,
        s.Scope AS SupplayerScope,
        s.ContactPhone AS SupplayerPhone,
        pswp.ProductId,
        pswp.ProductName,
        CASE 
            WHEN @ProductId IS NOT NULL AND pswp.ProductId = @ProductId THEN 1
            ELSE 0
        END AS IsSupplyingProduct
    FROM dbo.Supplayers AS s
    LEFT JOIN ProductSupplayerData.ProductSupplayersWithPhones AS pswp
        ON pswp.SupplayerId = s.Id
        AND (@ProductId IS NULL OR pswp.ProductId = @ProductId)
    WHERE
        (@Phone IS NULL OR s.ContactPhone LIKE @Phone + '%')
        AND (@Scope IS NULL OR s.Scope = @Scope)
        AND (@Name IS NULL OR s.Name LIKE @Name + '%');
END
GO



ProductSupplayerData.sp_GetProductSupplayers @Phone='54313'

