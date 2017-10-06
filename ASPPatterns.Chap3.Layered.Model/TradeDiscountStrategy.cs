namespace ASPPatterns.Chap3.Layered.Model
{
    public class TradeDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyExtraDiscountsTo(decimal originalSalePrice)
        {
            decimal price = originalSalePrice;
            price = price * 0.95M;
            return price;
        }
    }
}
