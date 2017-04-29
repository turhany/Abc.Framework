using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public HttpResponseMessage Get()
        {
            var result = _productService.GetAll()
                .Select(p => new Product()
                 {
                     CategoryId = p.CategoryId,
                     ProductId = p.ProductId,
                     ProductName = p.ProductName,
                     UnitPrice = p.UnitPrice,
                     UnitsInStock = p.UnitsInStock
                 }).ToList();

            HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.OK, result);
            return message;
        }
    }
}
