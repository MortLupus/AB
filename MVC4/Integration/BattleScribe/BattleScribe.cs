using System.Collections.Generic;
using MVC4.Models.Fantasy;

namespace MVC4.Integration.BattleScribe
{
    public class BattleScribe
    {
        public Army Import(Roster roster)
        {
            var fantasy = new FantasyArmy();
            var army = fantasy.CreateArmy(roster);

            return army;


        }


    }
}