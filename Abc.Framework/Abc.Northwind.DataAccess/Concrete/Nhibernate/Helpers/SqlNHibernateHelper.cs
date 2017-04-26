using System.Configuration;
using System.Reflection;
using Abc.Core.DataAccess.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace Abc.Northwind.DataAccess.Concrete.Nhibernate.Helpers
{
    public class SqlNHibernateHelper : NHibernateHelper
    {
        protected override ISessionFactory InitilizeFactory()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NorthwindContext"].ToString();
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration()
                .DataBaseIntegration(db =>
                {
                    db.ConnectionString = connectionString;
                    db.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
                });

            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddMapping(mapping);

            ISessionFactory sessionFactory = cfg.BuildSessionFactory();

            return sessionFactory;
        }
    }
}
