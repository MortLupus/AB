using Castle.Windsor;

namespace Infrastructure
{
    public class IoC
    {
        public static WindsorContainer Instance
        {
            get { return Nested.instance; }
        }

        #region Nested type: Nested

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit

            internal static readonly WindsorContainer instance = new WindsorContainer();
        }

        #endregion
    }
}