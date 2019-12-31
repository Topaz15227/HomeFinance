 USE [HomeFinance]
 GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[ViewCardPays]
as
(SELECT 0 as Id, 'All' as CardName,
(select Count(Id) from StorePays where ClosingId is null)  as NumOfPays,
(select isnull(SUM(Amount),0) from StorePays where ClosingId is null) as Total,
(select isnull(SUM(Amount),0) from StorePays where ClosingId is null and Active=1) as ActiveTotal)
Union
(SELECT c.Id,c.CardName,
(select Count(sp.Id) from StorePays sp where sp.CardId=c.Id and sp.ClosingId is null)  as NumOfPays,
(select isnull(SUM(sp.Amount),0) from StorePays sp where sp.CardId=c.Id and sp.ClosingId is null) as Total,
(select isnull(SUM(sp.Amount),0) from StorePays sp where sp.CardId=c.Id and sp.ClosingId is null and sp.Active=1) as ActiveTotal
FROM Cards c
WHERE c.Active = 1)
GO
----------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewClosings]
as
SELECT cl.Id, c.CardName, cl.ClosingDate, cl.ClosingName, cl.ClosingAmount, cl.CardId
FROM Closings cl
	LEFT JOIN Cards c on cl.CardId = c.Id

GO
--------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewStorePays]
as
SELECT sp.Id, c.CardName,sp.PayDate, s.StoreName, sp.Amount, isnull(sp.Note, '') as Note,
	cl.ClosingDate, isnull(sp.Active, 0) as Active, sp.CardId, sp.StoreId, sp.ClosingId
FROM StorePays sp
	LEFT JOIN Cards c on sp.CardId = c.Id
	LEFT JOIN Stores s on sp.StoreId = s.Id
	LEFT JOIN Closings cl on sp.ClosingId = cl.Id
GO
-----------------------------------------------
