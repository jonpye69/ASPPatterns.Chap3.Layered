using ASPPatterns.Chap3.Layered.Model;
using ASPPatterns.Chap3.Layered.Presentation;
using ASPPatterns.Chap3.Layered.Service;
using StructureMap;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ASPPatterns.Chap3.Layered.WebUI.Controllers
{
    public class HomeController : Controller, IProductListView
    {
        private ProductListPresenter _presenter;
        private IList<ProductViewModel> _products;

        public ActionResult Index()
        {
            _presenter = new ProductListPresenter(this,
           ObjectFactory.GetInstance<Service.ProductService>());

            _presenter.Display();

            return View(_products);
        }

        public void Display(IList<ProductViewModel> Products)
        {
            _products = Products;
        }

        public CustomerType CustomerType { get; }

        public string ErrorMessage { get; set; }
    }
}