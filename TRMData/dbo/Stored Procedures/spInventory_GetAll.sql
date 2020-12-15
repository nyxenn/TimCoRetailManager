CREATE PROCEDURE [dbo].[spInventory_GetAll]
AS
BEGIN
	SET nocount on;

	SELECT [ProductId], [Quantity], [PurchasePrice], [PurchaseDate]
	FROM Inventory
END
