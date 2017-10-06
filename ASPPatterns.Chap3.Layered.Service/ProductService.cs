﻿using System;
using System.Collections.Generic;

namespace ASPPatterns.Chap3.Layered.Service
{
    public class ProductService
    {
        private Model.ProductService _productService;
        public ProductService(Model.ProductService ProductService)
        {
            _productService = ProductService;
        }
        public ProductListResponse GetAllProductsFor(
        ProductListRequest productListRequest)
        {
            ProductListResponse productListResponse = new ProductListResponse();
            try
            {
                IList<Model.Product> productEntities =
                _productService.GetAllProductsFor(productListRequest.CustomerType);
                productListResponse.Products = productEntities.ConvertToProductListViewModel();
                productListResponse.Success = true;
            }
            catch (Exception)
            {
                // Log the exception…
                productListResponse.Success = false;
                // Return a friendly error message
                productListResponse.Message = "An error occurred";
            }

            return productListResponse;
        }
    }
}
