
USE SmraaAlYamanDb
GO


CREATE SCHEMA ProductData
GO



CREATE OR ALTER VIEW ProductData.ProductDetailsView
WITH SCHEMABINDING
AS
SELECT 
    P.Id                AS ProductId,
    P.Name              AS ProductName,
    P.EnglishName       AS ProductEnglishName,

    P.State,
    P.IsAllowedOnline,

    P.TransactionType,
    P.ReceiptType,

    C.Id                AS CatagoryId,
    C.Name              AS CatagoryName,

    B.Id                AS BrandId,
    B.Name              AS BrandName,

    G.Id                AS GroupId,
    G.Name              AS GroupName,

    CO.Id               AS CountryId,
    CO.Name             AS CountryName,

    P.MainTax           AS MainTax,
    P.SubTax            AS SubTax,

    P.TotalTaxAmount    AS TotalTaxes,

    p.IsDeleted         AS IsDeleted,

    P.CreatedAt,
    P.LastUpdate

FROM dbo.Products P

INNER JOIN dbo.Catagories C
ON P.CatagoryId = C.Id

INNER JOIN dbo.Brands B
ON P.BrandId = B.Id

INNER JOIN dbo.ProductGroups G
ON P.ProductGroupId = G.Id

INNER JOIN dbo.CountriesOfOrigin CO
ON P.CountryOfOriginId = CO.Id

GO


CREATE UNIQUE CLUSTERED INDEX PK_Products_Id
ON ProductData.ProductDetailsView(ProductId);


CREATE NONCLUSTERED INDEX IX_ProductDetails_State
ON ProductData.ProductDetailsView(State);

CREATE NONCLUSTERED INDEX IX_ProductDetails_ReceiptType
ON ProductData.ProductDetailsView(ReceiptType);

CREATE NONCLUSTERED INDEX IX_ProductDetails_TransactionType
ON ProductData.ProductDetailsView(TransactionType);


CREATE NONCLUSTERED INDEX IX_ProductDetails_Catagory
ON ProductData.ProductDetailsView(CatagoryId);

CREATE NONCLUSTERED INDEX IX_ProductDetails_BrandId
ON ProductData.ProductDetailsView(BrandId);

CREATE NONCLUSTERED INDEX IX_ProductDetails_GroupId
ON ProductData.ProductDetailsView(GroupId);

CREATE NONCLUSTERED INDEX IX_ProductDetails_CountryId
ON ProductData.ProductDetailsView(CountryId);


CREATE OR ALTER PROCEDURE ProductData.sp_GetProducts 
(
    @PageSize INT = 12,
    @PageNumber INT = 0,

    @GroupId INT = NULL,
    @BrandId INT = NULL,
    @CountryOfOriginId INT = NULL,
    @CategoryId INT = NULL,

    @ProductState NVARCHAR(30) = NULL,
    @ReceiptType NVARCHAR(30) = NULL,
    @TransactionType NVARCHAR(30) = NULL,

    @IsDeleted BIT = 0
)
AS
BEGIN

SET NOCOUNT ON;

DECLARE @sql NVARCHAR(MAX) = '
SELECT
    ProductId,
    ProductName,
    ProductEnglishName,
    State,
    IsAllowedOnline,
    TransactionType,
    ReceiptType,
    CatagoryId,
    CatagoryName,
    BrandId,
    BrandName,
    GroupId,
    GroupName,
    CountryId,
    CountryName,
    MainTax,
    SubTax,
    TotalTaxes,
    CreatedAt,
    LastUpdate
FROM ProductData.ProductDetailsView
WHERE 1 = 1
';

-- Soft Delete Filter
SET @sql += ' AND EXISTS (
    SELECT 1 
    FROM dbo.Products P 
    WHERE P.Id = ProductId
    AND P.IsDeleted = @IsDeleted
)';

-- Filters

IF @GroupId IS NOT NULL
    SET @sql += ' AND GroupId = @GroupId';

IF @BrandId IS NOT NULL
    SET @sql += ' AND BrandId = @BrandId';

IF @CountryOfOriginId IS NOT NULL
    SET @sql += ' AND CountryId = @CountryOfOriginId';

IF @CategoryId IS NOT NULL
    SET @sql += ' AND CatagoryId = @CategoryId';

IF @ProductState IS NOT NULL
    SET @sql += ' AND State = @ProductState';

IF @ReceiptType IS NOT NULL
    SET @sql += ' AND ReceiptType = @ReceiptType';

IF @TransactionType IS NOT NULL
    SET @sql += ' AND TransactionType = @TransactionType';

-- Pagination

SET @sql += '
ORDER BY ProductId
OFFSET (@PageSize * @PageNumber) ROWS
FETCH NEXT @PageSize ROWS ONLY
';

EXEC sp_executesql
    @sql,
    N'
    @PageSize INT,
    @PageNumber INT,
    @GroupId INT,
    @BrandId INT,
    @CountryOfOriginId INT,
    @CategoryId INT,
    @ProductState NVARCHAR(30),
    @ReceiptType NVARCHAR(30),
    @TransactionType NVARCHAR(30),
    @IsDeleted BIT
    ',
    @PageSize,
    @PageNumber,
    @GroupId,
    @BrandId,
    @CountryOfOriginId,
    @CategoryId,
    @ProductState,
    @ReceiptType,
    @TransactionType,
    @IsDeleted;

END




EXEC ProductData.sp_GetProducts
    @PageSize = 12,
    @PageNumber = 2,
    @CategoryId = 3,
    @BrandId = 2,
    @GroupId = 5,
    @CountryOfOriginId = 1,
    @ProductState = 'Active',
    @IsDeleted = 1;







    GO
    SELECT * FROM [dbo].[ProductPrices]


CREATE OR ALTER VIEW ProductData.ProductDetailsWithPriceView
AS
SELECT
    -- Product Columns
    P.ProductId,
    P.ProductName,
    P.ProductEnglishName,

    P.State,
    P.IsAllowedOnline,

    P.TransactionType,
    P.ReceiptType,

    P.CatagoryId,
    P.CatagoryName,

    P.BrandId,
    P.BrandName,

    P.GroupId,
    P.GroupName,

    P.CountryId,
    P.CountryName,

    P.MainTax,
    P.SubTax,
    P.TotalTaxes,

    P.IsDeleted,

    P.CreatedAt,
    P.LastUpdate,

    -- Price Columns (split starts here)
    PR.PricePerSmallistUnit,
    PR.WholesalePricePerSmallistUnit,
    PR.LowestPricePerSmallistUnit,
    PR.SmallistUnitCost,

    PR.ProductPriceUnits,
    PR.TransactionsSammary,
    PR.Notes,

    PR.IsWaghted,
    PR.IsNotSellable,

    PR.CreatedAt  AS PriceCreatedAt,
    PR.LastUpdate AS PriceLastUpdate

FROM ProductData.ProductDetailsView P
LEFT JOIN [dbo].[ProductPrices] PR
ON PR.Id = P.ProductId;




GO



CREATE OR ALTER PROCEDURE ProductData.sp_GetProductDetailsById
(
    @ProductId INT
)
AS
BEGIN

SET NOCOUNT ON;

SELECT
    V.ProductId,
    V.ProductName,
    V.ProductEnglishName,

    V.State,
    V.IsAllowedOnline,

    V.TransactionType,
    V.ReceiptType,

    V.CatagoryId,
    V.CatagoryName,

    V.BrandId,
    V.BrandName,

    V.GroupId,
    V.GroupName,

    V.CountryId,
    V.CountryName,

    V.MainTax,
    V.SubTax,
    V.TotalTaxes,

    V.IsDeleted,

    V.CreatedAt,
    V.LastUpdate,

    V.PricePerSmallistUnit,
    V.WholesalePricePerSmallistUnit,
    V.LowestPricePerSmallistUnit,
    V.SmallistUnitCost,
    V.ProductPriceUnits,
    V.TransactionsSammary,

    V.Notes,

    V.IsWaghted,
    V.IsNotSellable,

    V.PriceCreatedAt,
    V.PriceLastUpdate
FROM ProductData.ProductDetailsWithPriceView V
WHERE ProductId = @ProductId;

END
GO


ProductData.sp_GetProductDetailsById 5









CREATE OR ALTER PROCEDURE ProductData.sp_GetProductAuditHistories
(
    @PageSize INT = 12,
    @PageNumber INT = 0,

    @Id INT = NULL,
    @BrandId INT = NULL,
    @CategoryId INT = NULL,
    @CountryOfOriginId INT = NULL,
    @GroupId INT = NULL,
    @ProductState NVARCHAR(30) = NULL,
    @ReceiptType NVARCHAR(30) = NULL,
    @TransactionType NVARCHAR(30) = NULL,

    @IncludeDeleted BIT = 1,
    @IncludeActive BIT = 1
)
AS
BEGIN

SET NOCOUNT ON;

DECLARE @sql NVARCHAR(MAX) = '
SELECT
    AuditId,
    EntityId,
    Name,
    EnglishName,
    State,
    IsAllowedOnline,
    TransactionType,
    ReceiptType,
    CatagoryId,
    BrandId,
    ProductGroupId,
    CountryOfOriginId,
    MainTax,
    SubTax,
    TotalTaxAmount,
    IsDeleted,
    [From],
    [ChangedAt],
    IsRecovered
FROM dbo.ProductAudits
WHERE 1 = 1
';

-- Filters

IF @Id IS NOT NULL
    SET @sql += ' AND EntityId = @Id';

IF @BrandId IS NOT NULL
    SET @sql += ' AND BrandId = @BrandId';

IF @CategoryId IS NOT NULL
    SET @sql += ' AND CatagoryId = @CategoryId';

IF @CountryOfOriginId IS NOT NULL
    SET @sql += ' AND CountryOfOriginId = @CountryOfOriginId';

IF @GroupId IS NOT NULL
    SET @sql += ' AND ProductGroupId = @GroupId';

IF @ProductState IS NOT NULL
    SET @sql += ' AND State = @ProductState';

IF @ReceiptType IS NOT NULL
    SET @sql += ' AND ReceiptType = @ReceiptType';

IF @TransactionType IS NOT NULL
    SET @sql += ' AND TransactionType = @TransactionType';


-- Soft Delete filtering

IF @IncludeDeleted = 0
    SET @sql += ' AND IsDeleted = 0';

IF @IncludeActive = 0
    SET @sql += ' AND IsDeleted = 1';


-- Pagination

SET @sql += '
ORDER BY ChangedAt DESC
OFFSET (@PageSize * @PageNumber) ROWS
FETCH NEXT @PageSize ROWS ONLY
';

EXEC sp_executesql
    @sql,
    N'
    @PageSize INT,
    @PageNumber INT,
    @Id INT,
    @BrandId INT,
    @CategoryId INT,
    @CountryOfOriginId INT,
    @GroupId INT,
    @ProductState NVARCHAR(30),
    @ReceiptType NVARCHAR(30),
    @TransactionType NVARCHAR(30),
    @IncludeDeleted BIT,
    @IncludeActive BIT
    ',
    @PageSize,
    @PageNumber,
    @Id,
    @BrandId,
    @CategoryId,
    @CountryOfOriginId,
    @GroupId,
    @ProductState,
    @ReceiptType,
    @TransactionType,
    @IncludeDeleted,
    @IncludeActive;

END










