CREATE PROCEDURE [dbo].[spProduct_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT Product.Id, Product.ProductName, Product.[Description], Product.RetailPrice, Product.QuantityInStock, Tax.TaxRate
	FROM Product, Tax
	WHERE Product.Id = @Id AND Product.TaxCategoryId=Tax.Id
END