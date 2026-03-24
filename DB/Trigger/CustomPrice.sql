-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER dbo.tr_CustomPriceAudit
   ON  dbo.CustomPrices
   AFTER UPDATE
AS 
BEGIN
INSERT INTO CustomPriceAudits(
	[AuditId], 
	[Price],
	[LowestPriceForSale],
	[IsDeleted],
	[From],
	[ChangedAt],
	[IsRecovered],
	[BranchId],
	[Barcode]
	)
SELECT 
	NEWID(),
	[Price],
	[LowestPriceForSale],
	[IsDeleted],
	ISNULL(LastUpdate,CreatedAt),
	GETDATE(),
	0 AS BIT,
	[BranchId],
	[Code]
FROM deleted

END
GO

