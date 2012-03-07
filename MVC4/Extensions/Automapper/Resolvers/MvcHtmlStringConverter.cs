using System.Web.Mvc;
using AutoMapper;

namespace MVC4.Extensions.Automapper.Resolvers
{
    public class MvcHtmlStringConverter : TypeConverter<string, MvcHtmlString>
    {
        protected override MvcHtmlString ConvertCore(string source)
        {
            return MvcHtmlString.Create(source);
        }
    }
}