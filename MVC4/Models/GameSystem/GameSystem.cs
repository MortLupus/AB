using System.Collections.Generic;

namespace MVC4.Models.GameSystem
{
    public class GameSystem
    {
        public ICollection<ProfileType> ProfileTypes { get; set; }
        //public ICollection<Category<<Item>> Categories { get; set; } 
    }
}