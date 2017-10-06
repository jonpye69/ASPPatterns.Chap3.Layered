using ASPPatterns.Chap3.Layered.Model;
using ASPPatterns.Chap3.Layered.Presentation;
using ASPPatterns.Chap3.Layered.Service;
using StructureMap;
using System;
using System.Collections.Generic;

namespace ASPPatterns.Chap3.Layered.WebUI
{
    public partial class _Default : System.Web.UI.Page, IProductListView
    {
        private ProductListPresenter _presenter;
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new ProductListPresenter(this,
            ObjectFactory.GetInstance<Service.ProductService>());
            ddlCustomerType.SelectedIndexChanged +=
            delegate { _presenter.Display(); };
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
                _presenter.Display();
        }
        public void Display(IList<ProductViewModel> products)
        {
            rptProducts.DataSource = products;
            rptProducts.DataBind();
        }
        public CustomerType CustomerType
        {
            get
            {
                return (CustomerType)Enum.ToObject(typeof(CustomerType), int.Parse(ddlCustomerType.SelectedValue));
            }
        }
        public string ErrorMessage
        {
            set
            {
                lblErrorMessage.Text = $"< p >< strong > Error </ strong >< br />{value}< p />";
            }
        }
    }
}