using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MVC4.Integration.BattleScribe
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.battlescribe.net/schema/rosterSchema")]
    [XmlRoot("roster", Namespace = "http://www.battlescribe.net/schema/rosterSchema", IsNullable = false)]
    public class Roster
    {
        public Roster()
        {
            Categories = new Categories();
            Selections = new Selections();
        }

        [XmlElement("categories")]
        public Categories Categories { get; set; }

        [XmlElement("selections")]
        public Selections Selections { get; set; }
        
        [XmlAttribute("catalogueName")]
        public string CatalogueName { get; set; }

        [XmlAttribute("gameType")]
        public string GameType { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("points")]
        public int Points { get; set; }

        [XmlAttribute("pointsLimit")]
        public int PointsLimit { get; set; }
    
    }
    
    [Serializable]
    public class Selections
    {
        public Selections()
        {
            SelectionList = new List<Selection>();
        }

        [XmlArray("selection")]
        public List<Selection> SelectionList { get; set; }
    }

    [Serializable]
    public class Selection
    {
        public Selection()
        {
            Selections = new Selections();
            Profiles = new Profiles();
            Rules = new Rules();
        }
        
        [XmlAttribute("category")]
        public string Category { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public int Type { get; set; }

        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlAttribute("points")]
        public int Points { get; set; }

        [XmlElement("selections")]
        public Selections Selections { get; set; }

        [XmlElement("profiles")]
        public Profiles Profiles { get; set; }

        [XmlElement("rules")]
        public Rules Rules { get; set; }

    }

    public class Profiles
    {
    }

    public class Rules
    {
    }


    [Serializable]
    public class Categories
    {
        public Categories()
        {
            CategoryList = new List<string>();
        }

        [XmlArray("category")]
        public List<String> CategoryList { get; set; }
    }

}