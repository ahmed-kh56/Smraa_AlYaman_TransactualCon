
CREATE OR ALTER TRIGGER dbo.tr_AvailabltyAudit
   ON  Availabilities 
   AFTER DELETE
AS 
BEGIN
INSERT INTO AvailabltyAudits ([AuditId], [ProductId], [BranchId], [From], [ChangedAt], [IsRecovered])
Select 
    NEWID(),
    i.ProductId,
    i.BrancheId,
    i.CreatedAt,
    GETDATE(),
    0 AS BIT
FROM deleted i
END
GO
