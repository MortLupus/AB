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
            Categories = new List<string>();
            Selections = new List<Selection>();
        }

        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public List<string> Categories { get; set; }

        [XmlArray("selections")]
        [XmlArrayItem("selection")]
        public List<Selection> Selections { get; set; }

        [XmlAttribute("catalogueName")]
        public string CatalogueName { get; set; }

        [XmlAttribute("gameType")]
        public string GameType { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("points")]
        public decimal Points { get; set; }

        [XmlAttribute("pointsLimit")]
        public decimal PointsLimit { get; set; }

        [XmlAttribute("battleScribeVersion")]
        public string BattleScribeVersion { get; set; }

        [XmlAttribute("catalogueId")]
        public Guid CatalogueId { get; set; }

        [XmlAttribute("catalogueRevision")]
        public string CatalogueRevision { get; set; }

    }

    [Serializable]
    public class Selection
    {
        public Selection()
        {
            Selections = new List<Selection>();
            //Profiles = new Profiles();
            //Rules = new Rules();
        }
        
        [XmlAttribute("category")]
        public string Category { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("number")]
        public decimal Number { get; set; }

        [XmlAttribute("points")]
        public decimal Points { get; set; }

        [XmlArray("selections")]
        [XmlArrayItem("selection")]
        public List<Selection> Selections { get; set; }

        //[XmlElement("profiles")]
        //public Profiles Profiles { get; set; }

        //[XmlElement("rules")]
        //public Rules Rules { get; set; }

    }

    //public class Profiles
    //{
    //}

    //public class Rules
    //{
    //}

}