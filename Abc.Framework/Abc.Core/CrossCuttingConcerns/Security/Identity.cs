using System;
using System.Security.Principal;

namespace Abc.Core.CrossCuttingConcerns.Security
{
    public class Identity : IIdentity
    {
        public Guid Id { get; set; } //IIdentity base gelir
        public string Name { get; set; } //IIdentity base gelir
        public string AuthenticationType { get; set; } //IIdentity base gelir
        public bool IsAuthenticated { get; set; } //IIdentity base gelir

        //Aşağıdaki kısımlar ihtiyaç doğrultusunda eklenmiştir
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
