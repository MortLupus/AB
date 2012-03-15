using System.Collections.Generic;
using System.Linq;

namespace MVC4.Models.GameSystem
{
    public abstract class Category<T> : List<T> where T : Item
    {
        public string Name { get; set; }
        public uint MinCount { get; set; }
        public uint MaxCount { get; set; }
        public uint MinPercent { get; set; }
        public uint MaxPercent { get; set; }
        
        public long TotalPoints()
        {
            return this.Sum(x => x.TotalPoints());
        }

    }

    public abstract class Item
    {
        public string Name { get; set; }
        public uint Points { get; set; }
        public uint ModelCount { get; set; }
        public abstract uint TotalPoints();
    }

    public class Upgrade
    {
        public string Name { get; set; }
        public uint Points { get; set; }
    }
}