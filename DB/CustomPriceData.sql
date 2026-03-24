USE SmraaAlYamanDb
GO

CREATE SCHEMA CustomPriceData
GO



CREATE OR ALTER PROCEDURE CustomPriceData.GetCustomPriceAudits
(
    @BranchId INT = NULL,
    @Barcode NVARCHAR(100) = NULL,
    @PageSize INT = 12,
    @PageNumber INT = 0
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        AuditId,
        BranchId,
        Barcode,
        Price,
        LowestPriceForSale,
        [From],
        ChangedAt,
        IsRecovered
    FROM dbo.CustomPriceAudits
    WHERE (@BranchId IS NULL OR BranchId = @BranchId)
      AND (@Barcode IS NULL OR Barcode = @Barcode)
    ORDER BY ChangedAt DESC

END

CustomPriceData.GetCustomPriceAudits 5




CREATE OR ALTER PROCEDURE CustomPriceData.GetAllPrices
    @Code NVARCHAR(100) = NULL,
    @ProductId INT = NULL,
    @BranchId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT cp.*
    FROM CustomPrices cp
    INNER JOIN Barcodes b
        ON cp.BarcodeCode = b.Code
    WHERE (@Code IS NULL OR cp.BarcodeCode = @Code)
      AND (@BranchId IS NULL OR cp.BranchId = @BranchId)
      AND (@ProductId IS NULL OR b.ProductId = @ProductId)
END




