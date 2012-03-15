using System;
using System.Collections.Generic;
using MVC4.Models.GameSystem;
using System.Linq;

namespace MVC4.Models.Fantasy
{
    public class Test
    {
        void A()
        {
            var a = new Army();

            var a1 = new Unit();
            a1.Name = "Archers";
            a1.ModelCount = 10;
            a1.Points = 11;
            a1.HasChampion = true;
            a1.HasMusician = true;
            a1.HasStandard = true;
            a1.Standard.MagicStandard = new Upgrade {Name = "Banner of Eternal Flame", Points = 20};

            a.Core.Add(a1);
        }
    }


    public class Army : Entity
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public Core Core { get; set; }
        public Special Special { get; set; }
        public Rare Rare { get; set; }
        public Heroes Heroes { get; set; }
        public Lords Lords { get; set; }
        public uint Points { get; set; }
       
    }

    public class Core : Category<Unit>
    {
        public Core()
        {
            Name = "Core";
            MinPercent = 25;
            MaxPercent = 100;
        }
    }

    public class Special : Category<Unit>
    {
        public Special()
        {
            Name = "Special";
            MinPercent = 0;
            MaxPercent = 50;
        }

    }

    public class Rare : Category<Unit>
    {
        public Rare()
        {
            Name = "Rare";
            MinPercent = 0;
            MaxPercent = 25;
        }

    }

    public class Heroes : Category<Character>
    {
        public Heroes()
        {
            Name = "Heroes";
            MinPercent = 0;
            MaxPercent = 50;
        }
    }

    public class Lords : Category<Character>
    {
        public Lords()
        {
            Name = "Lords";
            MinPercent = 0;
            MaxPercent = 50;
        }
    }

    public class Unit : Item
    {
        public Character Champion { get; set; }
        public Character Standard { get; set; }
        public Character Musician { get; set; }

        public bool HasChampion { get; set; }
        public bool HasStandard { get; set; }
        public bool HasMusician { get; set; }

        public override uint TotalPoints()
        {
            return ModelCount*Points +
                   (HasChampion ? Champion.Points : 0) +
                   (HasStandard ? Standard.Points : 0) +
                   (HasMusician ? Musician.Points : 0);

        }
    }

    public class Character : Model
    {
        public Upgrade MagicArmour { get; set; }
        public Upgrade MagicWeapon { get; set; }
        public Upgrade Talisman { get; set; }
        public Upgrade EnchantedItem { get; set; }
        public Upgrade MagicStandard { get; set; }

    }

    public class Model : Item
    {
        public Model()
        {
            ModelCount = 1;
        }

        public Characteristic Move { get; set; }
        public Characteristic WeaponSkill { get; set; }
        public Characteristic BallisticSkill { get; set; }
        public Characteristic Strength { get; set; }
        public Characteristic Toughness { get; set; }
        public Characteristic Wounds { get; set; }
        public Characteristic Initiative { get; set; }
        public Characteristic Attacks { get; set; }
        public Characteristic Leadership { get; set; }
        public ArmourSave ArmourSave { get; set; }
        public IList<Upgrade> Armour { get; set; }
        public IList<Upgrade> Weapons { get; set; }

        public override uint TotalPoints()
        {
            return Points +
                   Convert.ToUInt32(Armour.Sum(x => x.Points)) +
                   Convert.ToUInt32(Weapons.Sum(x => x.Points));
        }
    }

    public class ArmourSave
    {
    }

    public class Characteristic
    {
        public ushort Value { get; set; }
        public string SpecialValue { get; set; }
    }



}