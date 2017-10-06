using ASPPatterns.Chap3.Layered.Service;

namespace ASPPatterns.Chap3.Layered.Presentation
{
    public class ProductListPresenter
    {
        private IProductListView _productListView;
        private ProductService _productService;
        public ProductListPresenter(IProductListView ProductListView,
        ProductService ProductService)
        {
            _productService = ProductService;
            _productListView = ProductListView;
        }
        public void Display()
        {
            ProductListRequest productListRequest = new ProductListRequest
            {
                CustomerType = _productListView.CustomerType
            };

            ProductListResponse productResponse = _productService.GetAllProductsFor(productListRequest);

            if (productResponse.Success)
            {
                _productListView.Display(productResponse.Products);
            }
            else
            {
                _productListView.ErrorMessage = productResponse.Message;
            }
        }
    }
}