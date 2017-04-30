using System;
using System.Web.Security;

namespace Abc.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id = SetId(ticket),
                Name = SetName(ticket),
                Email = SetEmail(ticket),
                Roles = SetRoles(ticket),
                FirstName = SetFirstName(ticket),
                LastName = SetLastName(ticket),
                AuthenticationType = SetAuthType(ticket),
                Password = SetPassword(ticket),
                IsAuthenticated = SetIsAuthenticated()
            };

            return identity;
        }

        private bool SetIsAuthenticated()
        {
            return true;
        }

        private Guid SetId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split(new char[] { '|' });
            return new Guid(data[5]);
        }

        private string SetPassword(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split(new char[] { '|' });
            return data[4];
        }

        private string SetAuthType(FormsAuthenticationTicket ticket)
        {
            return "";
        }

        private string SetLastName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split(new char[] { '|' });
            return data[3];
        }

        private string SetFirstName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split(new char[] { '|' });
            return data[2];
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split(new char[] { '|' });
            string[] roles = data[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split(new char[] { '|' });
            return data[0];
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }
    }
}
