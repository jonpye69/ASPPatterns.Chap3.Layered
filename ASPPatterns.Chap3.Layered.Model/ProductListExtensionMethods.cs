﻿using System.Collections.Generic;

namespace ASPPatterns.Chap3.Layered.Model
{
    public static class ProductListExtensionMethods
    {
        public static void Apply(this IList<Product> products,
        IDiscountStrategy discountStrategy)
        {
            foreach (Product p in products)
            {
                p.Price.SetDiscountStrategyTo(discountStrategy);
            }
        }
    }
}
