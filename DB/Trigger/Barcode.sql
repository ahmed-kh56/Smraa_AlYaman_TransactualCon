CREATE OR ALTER TRIGGER dbo.tr_BarcodeAudit
   ON  dbo.Barcodes 
   AFTER UPDATE
AS 
BEGIN
INSERT INTO
	BarcodeAudits([AuditId],
	[EntityId],
	[Notes],
	[Type],
	[Size],
	[Unit],
	[UnitsCountPerPackage],
	[ProductId],
	[IsActive],
	[IsAllowedOnline],
	[From],
	[ChangedAt],
	[IsRecovered]
	)
Select  
	NEWID(),
	i.Code,
	i.[Notes],
	i.[Type],
	i.[Size],
	i.[Unit],
	i.[UnitsCountPerPackage],
	i.[ProductId],
	i.[IsActive],
	i.[IsAllowedOnline],
	ISNULL(i.LastUpdate,i.CreatedAt),
	GETDATE(),
	0 AS BIT
FROM deleted i

END
GO


