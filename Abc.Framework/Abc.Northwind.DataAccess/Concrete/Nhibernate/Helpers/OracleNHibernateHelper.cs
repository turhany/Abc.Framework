using System.Reflection;
using Abc.Core.DataAccess.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Abc.Northwind.DataAccess.Concrete.Nhibernate.Helpers
{
    public class OracleNHibernateHelper : NHibernateHelper
    {
        protected override ISessionFactory InitilizeFactory()
        {
            return Fluently.Configure().Database(OracleConfiguration.Oracle10
                    .ConnectionString(c => c.FromConnectionStringWithKey("NorthwindContext")))
                .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                //.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }
    }
}
