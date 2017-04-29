
using System.Collections.Generic;
using System.ServiceModel;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.Business.Abstract
{
    [ServiceContract] //Servis olduğunu ifade ediyoruz
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAll();

        [OperationContract]
        List<Product> GetByCategory(int catergoryId);

        [OperationContract]
        Product GetById(int productId);

        [OperationContract]
        void Add(Product product);

        [OperationContract]
        void Update(Product product);

        [OperationContract]
        void DeleteById(int productId);

        [OperationContract]
        List<Product> QueryableList();
    }
}
