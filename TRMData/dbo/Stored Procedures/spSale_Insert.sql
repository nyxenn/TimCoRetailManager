CREATE PROCEDURE [dbo].[spSale_Insert]
	@CashierId nvarchar(128),
	@SaleDate datetime2(7),
	@SubTotal money,
	@Tax money,
	@Total money
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO Sale (CashierId, SaleDate, SubTotal, Tax, Total)
	VALUES (@CashierId, @SaleDate, @SubTotal, @Tax, @Total)
END