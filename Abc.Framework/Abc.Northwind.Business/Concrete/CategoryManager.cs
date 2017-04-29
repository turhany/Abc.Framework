using System.Collections.Generic;
using System.Linq;
using Abc.Core.DataAccess;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IQueryableRepository<Category> _categoryRepository;

        public CategoryManager(ICategoryDal categoryDal, IQueryableRepository<Category> categoryRepository)
        {
            _categoryDal = categoryDal;
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }

        public List<Category> GetByCategory(int catergoryId)
        {
            return _categoryDal.GetList(p => p.CategoryId == catergoryId);
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(p => p.CategoryId == categoryId);
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        public void DeleteById(int categoryId)
        {
            _categoryDal.Delete(new Category() { CategoryId = categoryId });
        }

        public List<Category> QueryableList()
        {
            var result = _categoryRepository.Table.Where(p => p.CategoryName.Contains("a"));//context açıldı

            //iş kurallarının kodları budara yer alır

            var result2 = result.Where(p => p.Description.Contains("a"));

            return result2.ToList();//tolist dediğimizde kapandı -> aynı transaction içinde oldu
        }
    }
}
