using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;
using Abc.Core.CrossCuttingConcerns.Security;
using PostSharp.Aspects;
using Abc.Northwind.Business.DomainModels;
using System.Security.Principal;

namespace Abc.Northwind.Business.BusinessAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        private string _operation;

        public SecuredOperation(string operation)
        {
            _operation = operation;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            //identity'den al
            //System.Threading.Thread.CurrentPrincipal.Identity.Name > token ile set edilmiş bir identity almak
            //string currentUser = "engin";
            //Identity identity = (Identity)Thread.CurrentPrincipal.Identity;

            IIdentity identity = Thread.CurrentPrincipal.Identity;

            //db'den al
            List<OperationClaim> claims = new List<OperationClaim>
            {
                new OperationClaim { OperationName = "Product.Read", UserName = "engin" },
                new OperationClaim { OperationName = "Product.Write", UserName = "engin" },
                new OperationClaim { OperationName = "Category.Read", UserName = "engin" },
                new OperationClaim { OperationName = "Category.Write", UserName = "engin" },
                new OperationClaim { OperationName = "Customer.Read", UserName = "engin" }
            };

            if (!claims.Any(c => c.UserName == identity.Name && c.OperationName == _operation))
            {
                throw new SecurityException("You are not authorized.");
            }
        }
    }
}
