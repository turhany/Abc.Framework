using Abc.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;

namespace Abc.Northwind.DataAccess.Concrete.Nhibernate.Mapping
{
    public partial class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {

            Table(@"Products");

            LazyLoad();

            Id(x => x.ProductId)
                .Column("ProductID")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("int")
                .Not.Nullable()
                .Precision(10)
                .GeneratedBy.Identity();


            Map(x => x.ProductName)
                .Column("ProductName")
                .CustomType("String")
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("nvarchar")
                .Not.Nullable()
                .Length(40);

            Map(x => x.CategoryId)
                .Column("CategoryID")
                .CustomType("Int32")
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("int")
                .Precision(10);

            //Map(x => x.QuantityPerUnit)
            //    .Column("QuantityPerUnit")
            //    .CustomType("String")
            //    .Access.Property()
            //    .Generated.Never()
            //    .CustomSqlType("nvarchar")
            //    .Length(20);

            Map(x => x.UnitPrice)
                .Column("UnitPrice")
                .CustomType("Decimal")
                .Access.Property()
                .Generated.Never()
                .Default(@"0")
                .CustomSqlType("money")
                .Precision(19)
                .Scale(4);

            Map(x => x.UnitsInStock)
                .Column("UnitsInStock")
                .CustomType("Int16")
                .Access.Property()
                .Generated.Never()
                .Default(@"0")
                .CustomSqlType("smallint")
                .Precision(5);

            //Map(x => x.Picture).CustomType<BinaryBlobType>().Nullable();

            //Map(x => x.FileContent).CustomType<BinaryBlobType>().Nullable();

            //HasMany(x => x.OrderDetails)
            //  .Access.Property()
            //  .AsSet()
            //  .Cascade.None()
            //  .LazyLoad()
            //    // .OptimisticLock.Version() /*bug (or missing feature) in Fluent NHibernate*/
            //  .Inverse()
            //  .Generic()
            //  .KeyColumns.Add("ProductID", mapping => mapping.Name("ProductID")
            //                                                       .SqlType("int")
            //                                                       .Not.Nullable());

            //References(x => x.Category)
            //  .Class<Category>()
            //  .Access.Property()
            //  .Cascade.None()
            //  .Not.LazyLoad(Laziness.NoProxy)
            //  .Columns("CategoryID");
        }
    }
}
