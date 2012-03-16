using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MVC4.Models.Fantasy;
using MVC4.Extensions.AutoMapper;

namespace MVC4.Integration.BattleScribe
{
    public class FantasyArmy
    {
        private Dictionary<string, Action<Selection, Army>> _importActions;

        private Dictionary<string, Action<Selection, Army>> ImportActions
        {
            get
            {
                return _importActions ?? (_importActions = BuildActions());
            }
        }

        private Dictionary<string, Action<Selection, Army>> BuildActions()
        {
            var actions = new Dictionary<string, Action<Selection, Army>>();
            actions.Add("Lords", AddLord);
            actions.Add("Heroes", AddHero);
            actions.Add("Core", AddCore);
            actions.Add("Special", AddSpecial);
            actions.Add("Rare", AddRare);

            return actions;
        }

        public Army CreateArmy(Roster roster)
        {
            var army = roster.MapTo<Army>();

            roster.Selections.ForEach(x => ImportActions[x.Category](x, army));

            return army;
        }

        private void AddLord(Selection selection, Army army)
        {
            var lord = selection.MapTo<Character>();
            army.Lords.Add(lord);
        }

        private void AddHero(Selection selection, Army army)
        {
            var hero = selection.MapTo<Character>();
            army.Heroes.Add(hero);
        }

        private void AddCore(Selection selection, Army army)
        {
            var unit = CreateUnit(selection);
            army.Core.Add(unit);
        }

        private void AddSpecial(Selection selection, Army army)
        {
            var unit = CreateUnit(selection);
            army.Special.Add(unit);
        }

        private void AddRare(Selection selection, Army army)
        {
            var unit = CreateUnit(selection);
            army.Rare.Add(unit);
        }

        private static Unit CreateUnit(Selection selection)
        {
            if(selection.Selections.Count == 0)
                return selection.MapTo<Unit>();

            return new Unit
                           {
                               Name = selection.Name,
                               ModelCount =
                                   Convert.ToUInt32(selection.Selections.First(x => x.Number > 1).Number),
                               HasMusician = selection.Selections.Any(x => x.Name == "Musician"),
                               HasStandard = selection.Selections.Any(x => x.Name == "Standard Bearer"),
                               Points = Convert.ToUInt32(selection.Selections.First(x => x.Number > 1).Points / selection.Selections.First(x => x.Number > 1).Number)
                           };

        }
    }
}