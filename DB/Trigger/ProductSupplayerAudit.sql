
CREATE TRIGGER dbo.tr_ProductSupplayerAudit
   ON  dbo.ProductSupplayers
   AFTER UPDATE
AS 
BEGIN
INSERT INTO ProductSupplayerAudits(
	[AuditId],
	[ProductId],
	[SupplayerId],
	[IsDeleted],
	[From],
	[ChangedAt],
	[IsRecovered]
	)
SELECT 
	NEWID(),
	[ProductId],
	[SupplayerId],
	[IsDeleted],
	CreatedAt,
	GETDATE(),
	0 AS BIT
FROM deleted

END