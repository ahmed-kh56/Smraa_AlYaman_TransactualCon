USE SmraaAlYamanDb
GO


CREATE SCHEMA BarcodeData
GO

CREATE OR ALTER PROCEDURE BarcodeData.sp_GetBarcodeAudits
(
    @PageSize INT = 12,
    @PageNumber INT = 0,

    @ProductId INT = NULL,
    @Barcode NVARCHAR(100) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @sql NVARCHAR(MAX) = '
    SELECT
        AuditId,
        EntityId,
        Notes,
        Type,
        Size,
        Unit,
        UnitsCountPerPackage,
        ProductId,
        IsActive,
        IsAllowedOnline,
        ActionType,
        [From],
        ChangedAt,
        IsRecovered
    FROM BarcodeData.BarcodeAudit
    WHERE 1 = 1
    ';

    -- Filters
    IF @ProductId IS NOT NULL
        SET @sql += ' AND ProductId = @ProductId';

    IF @Barcode IS NOT NULL
        SET @sql += ' AND EntityId = @Barcode';


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
        @ProductId INT,
        @Barcode NVARCHAR(100)
        ',
        @PageSize,
        @PageNumber,
        @ProductId,
        @Barcode;
END



CREATE OR ALTER PROCEDURE BarcodeData.sp_GetBarcodesData
(
    @ProductId INT = NULL
)
AS
BEGIN 
SELECT *
FROM dbo.Barcodes
WHERE ProductId = ISNULL(@ProductId, ProductId)
END