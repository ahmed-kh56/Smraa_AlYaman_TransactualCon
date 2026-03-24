USE SmraaAlYamanDbTran
GO

CREATE SCHEMA ProductPriceData
GO
CREATE OR ALTER PROC ProductPriceData.sp_GetProductPriceHistory
(
    @Id INT = NULL,
    @PageSize INT = 12,
    @PageNumber INT = 0
)
AS
BEGIN

    SET NOCOUNT ON;

    SELECT *
    FROM PriceAudits
    WHERE (@Id IS NULL OR EntityId = @Id)
    ORDER BY [From] DESC
    OFFSET (@PageNumber * @PageSize) ROWS
    FETCH NEXT @PageSize ROWS ONLY;

END
