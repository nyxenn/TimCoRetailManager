CREATE PROCEDURE [dbo].[spSale_Lookup]
	@CashierId nvarchar(128),
	@SaleDate datetime2(7)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id
	FROM Sale
	WHERE CashierId = @CashierId AND SaleDate = @SaleDate;
END
