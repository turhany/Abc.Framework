using System.Web.Mvc;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entities.Concrete;
using Abc.Northwind.MvcWebUI.Models;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel()
            {
                Products = _productService.GetAll()
            };

            return View(model);
        }

        public ActionResult Add()
        {
            _productService.Add(new Product() {CategoryId = 1, ProductName = "Elma", UnitPrice = 15, UnitsInStock = 5});
            return Content("Added");
        }
    }
}