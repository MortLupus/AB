using System.Web.Mvc;
using Raven.Client;

namespace MVC4.Controllers
{
    [Authorize]
    public abstract class RavenController : Controller
    {
        public IDocumentSession RavenSession { get; set; }

    }
}
