using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC4.Extensions.Automapper.Resolvers
{
    public class RavenIdResolver
    {
        [Pure]
        public static int Resolve(string ravenId)
        {
            //Contract.Requires(ravenId != null && ravenId.Trim() != string.Empty);
            //Contract.Ensures(Contract.Result<int>() > 0);

            var match = Regex.Match(ravenId, @"\d+");
            var idStr = match.Value;
            int id = int.Parse(idStr);

            if(id <= 0)
            {
                throw new Exception(string.Format("invalid id {0}", ravenId));
            }
            return id;
        }
    }
}