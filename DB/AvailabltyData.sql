USE SmraaAlYamanDbTran
GO


CREATE SCHEMA AvailabltyData

CREATE OR ALTER VIEW AvailabltyData.ProductAvailabiltyView
WITH SCHEMABINDING
AS 
SELECT 
	P.Id			AS ProductId,
	P.Name			AS ProductName,
	P.EnglishName	AS ProductEnglishName,
	A.BrancheId		AS BrancheId,
	A.CreatedAt		AS CreatedAt
FROM dbo.Availabilities A
INNER JOIN dbo.Products P
ON A.ProductId = P.Id



CREATE OR ALTER PROCEDURE AvailabltyData.sp_GetProductAvailablty
    @ProductId INT
AS
BEGIN
    SELECT 
        B.Id AS BranchId,
        B.BranchName,
        PA.ProductId,
        PA.ProductName,
        PA.ProductEnglishName,
        PA.CreatedAt,
        CASE 
            WHEN PA.ProductId IS NULL THEN 0
            ELSE 1
        END AS IsAvailable
    FROM Branches B
    LEFT JOIN AvailabltyData.ProductAvailabiltyView PA
        ON B.Id = PA.BrancheId
        AND PA.ProductId = @ProductId
END
