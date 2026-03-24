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

CREATE OR ALTER TRIGGER dbo.tr_ProductPriceAudit
   ON  dbo.ProductPrices
   AFTER UPDATE
AS 
BEGIN
INSERT INTO PriceAudits(
	[AuditId],
	[EntityId],
	[PricePerSmallistUnit],
	[WholesalePricePerSmallistUnit],
	[LowestPricePerSmallistUnit],
	[SmallistUnitCost],
	[ProductPriceUnits],
	[TransactionsSammary], 
	[Notes],
	[IsWaghted],
	[IsNotSellable],
	[From],
	[ChangedAt],
	[IsRecovered]
	)
SELECT 
	NEWID(),
	Id,
	[PricePerSmallistUnit],
	[WholesalePricePerSmallistUnit],
	[LowestPricePerSmallistUnit],
	[SmallistUnitCost],
	[ProductPriceUnits],
	[TransactionsSammary], 
	[Notes],
	[IsWaghted],
	[IsNotSellable],
	ISNULL(LastUpdate,CreatedAt),
	GETDATE(),
	0 AS BIT
FROM deleted

END