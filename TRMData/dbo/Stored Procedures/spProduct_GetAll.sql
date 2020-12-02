CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
BEGIN
	SET nocount on;

	SELECT Product.Id, Product.ProductName, Product.[Description], Product.RetailPrice, Product.QuantityInStock, Tax.TaxRate
	FROM Product, Tax
	WHERE Product.TaxCategoryId=Tax.Id
	ORDER BY ProductName
END
