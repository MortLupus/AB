using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Raven.Client;

namespace MVC4.Extensions.Raven
{
    public static class DocumentSessionExtensions
    {
        //public static User GetCurrentUser(this IDocumentSession session)
        //{
        //    if (HttpContext.Current.Request.IsAuthenticated == false)
        //        return null;

        //    var email = HttpContext.Current.User.Identity.Name;
        //    var user = session.GetUserByEmail(email);
        //    return user;
        //}

        //public static User GetUserByEmail(this IDocumentSession session, string email)
        //{
        //    return session.Query<User>().FirstOrDefault(u => u.EmailAddress == email);
        //}
    }
}