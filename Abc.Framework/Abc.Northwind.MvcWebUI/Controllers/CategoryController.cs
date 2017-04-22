using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.MvcWebUI.Models;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            var model = new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }
    }
}