
CREATE OR ALTER TRIGGER dbo.ProductAudit
   ON  dbo.Products 
   AFTER UPDATE
AS 
BEGIN
INSERT INTO ProductAudits (
	[AuditId],
	[EntityId],
	[Name],
	[EnglishName],
	[State],
	[IsAllowedOnline],
	[TransactionType],
	[ReceiptType],
	[CatagoryId],
	[BrandId],
	[ProductGroupId],
	[CountryOfOriginId],
	[MainTax],
	[SubTax],
	[TotalTaxAmount],
	[IsDeleted],
	[From],
	[ChangedAt],
	[IsRecovered]
	)
SELECT 
	NEWID(),
	[Id],
	[Name],
	[EnglishName],
	[State],
	[IsAllowedOnline],
	[TransactionType],
	[ReceiptType],
	[CatagoryId],
	[BrandId],
	[ProductGroupId],
	[CountryOfOriginId], 
	[MainTax], 
	[SubTax],
	[TotalTaxAmount], 
	[IsDeleted],
	ISNULL(LastUpdate,CreatedAt),
	GETDATE(),
	0 AS BIT
FROM deleted

END
GO
