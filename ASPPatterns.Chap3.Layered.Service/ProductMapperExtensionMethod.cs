using ASPPatterns.Chap3.Layered.Model;
using System.Collections.Generic;

namespace ASPPatterns.Chap3.Layered.Service
{
    public static class ProductMapperExtensionMethods
    {
        public static IList<ProductViewModel> ConvertToProductListViewModel(
            this IList<Product> products)
        {
            IList<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (Product p in products)
            {
                productViewModels.Add(p.ConvertToProductViewModel());
            }
            return productViewModels;
        }

        public static ProductViewModel ConvertToProductViewModel(
        this Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.ProductId = product.Id;
            productViewModel.Name = product.Name;
            productViewModel.RRP = $"{ product.Price.RRP:C}";
            productViewModel.SellingPrice = $"{ product.Price.SellingPrice:C}";
            if (product.Price.Discount > 0)
                productViewModel.Discount = $"{ product.Price.Discount:C}";
            if (product.Price.Savings < 1 && product.Price.Savings > 0)
                productViewModel.Savings = product.Price.Savings.ToString("#%");

            return productViewModel;
        }

    }
}
