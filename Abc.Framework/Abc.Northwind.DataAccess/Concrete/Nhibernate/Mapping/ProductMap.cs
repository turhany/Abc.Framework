using Abc.Northwind.Entities.Concrete;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Abc.Northwind.DataAccess.Concrete.Nhibernate.Mapping
{
    public partial class ProductsMap : ClassMapping<Product>
    {

        public ProductsMap()
        {
            Lazy(true);
            Table("Products");
            Id(x => x.ProductId, map => map.Generator(Generators.Identity));
            Property(x => x.ProductName, map => map.NotNullable(true));
            Property(x => x.UnitPrice);
            Property(x => x.UnitsInStock);
            Property(x => x.CategoryId);
        }
    }
}