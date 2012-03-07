using System;

namespace MVC4.Extensions
{
    public static class TypeExtensions
    {
        public static bool CanBeCastTo<TCast>(this Type type)
        {
            return typeof(TCast).IsAssignableFrom(type);
        }
    }
}