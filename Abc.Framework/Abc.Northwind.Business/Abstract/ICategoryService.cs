using System.Collections.Generic;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);
        void Add(Category category);
        void Update(Category category);
        void DeleteById(int categoryId);
        List<Category> QueryableList();
    }
}
