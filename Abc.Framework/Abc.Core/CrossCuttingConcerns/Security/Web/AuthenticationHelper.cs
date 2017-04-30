using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Abc.Core.CrossCuttingConcerns.Security.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(
            Guid id, string userName, string email,
            DateTime expiration, string[] roles, bool rememberMe,
            string firstName, string lastName, string password)
        {
            var authTicket = new FormsAuthenticationTicket(1, //version
                userName, // user name
                DateTime.Now,
                expiration, //Expiration
                rememberMe, //Persistent
                CreateAuthTags(email, roles, firstName, lastName, password, id));

            string encTicket = FormsAuthentication.Encrypt(authTicket);

            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        public static string CreateAuthTags(string email, string[] roles, string firstName, string lastName, string password, Guid id)
        {
            var sb = new StringBuilder();
            sb.Append(email);
            sb.Append("|");
            for (int i = 0; i < roles.Length; i++)
            {
                sb.Append(roles[i]);
                if (i < roles.Length - 1)
                    sb.Append(",");
            }
            sb.Append("|");
            sb.Append(firstName);
            sb.Append("|");
            sb.Append(lastName);
            sb.Append("|");
            sb.Append(password);
            sb.Append("|");
            sb.Append(id);
            return sb.ToString();
        }
    }
}
