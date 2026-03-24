
CREATE OR ALTER TRIGGER dbo.tr_SupplayerAudits
   ON  dbo.Supplayers
   AFTER UPDATE
AS 
BEGIN
INSERT INTO SupplayerAudits ([AuditId], [EntityId], [Name], [ContactPhone], [Scope], [From], [ChangedAt], [IsRecovered], [IsDeleted])

SELECT 
	NEWID(),
    i.Id,
    i.Name,
    i.ContactPhone,
    i.Scope,
	ISNULL(i.LastUpdate,i.CreatedAt),
    GETDATE(),
    0 AS BIT,
    i.IsDeleted
FROM deleted i
END
GO
