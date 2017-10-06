using System.Collections.Generic;
using ASPPatterns.Chap3.Layered.Model;
using ASPPatterns.Chap3.Layered.Service;

namespace ASPPatterns.Chap3.Layered.Presentation
{
    public interface IProductListView
    {
        void Display(IList<ProductViewModel> Products);
        CustomerType CustomerType { get; }
        string ErrorMessage { set; }
    }
}