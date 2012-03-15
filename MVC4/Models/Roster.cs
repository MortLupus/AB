using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MVC4.Models
{
    public class Roster : Entity
    {
        private IList<Unit> _units = new Collection<Unit>();

        public string Name { get; set; }
        public string CatalogueId { get; set; }
        public uint Points { get; set; }
        public uint PointsLimit { get; set; }

        public IList<Unit> Units
        {
            get { return _units; }
            set { _units = value; }
        }

        public class Unit
        {
            private IList<Upgrade> _upgrades = new Collection<Upgrade>();

            public string Category { get; set; }
            public string Name { get; set; }
            public uint Number { get; set; }
            public uint Points { get; set; }

            public IList<Upgrade> Upgrades
            {
                get { return _upgrades; }
                set { _upgrades = value; }
            }


            public class Upgrade
            {
                public string Category { get; set; }
                public string Name { get; set; }
                public uint Points { get; set; }
            }
        }
    }
}