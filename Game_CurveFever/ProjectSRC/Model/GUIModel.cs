// GUIModel.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game_CurveFever.ProjectSRC.Model {
    [XmlRoot("GUIModel")]
    //TODO: Add all classes that need to be included here
    //[XmlInclude(typeof(SomeModel)), XmlInclude(typeof(SomeClass))] // include classes, that are serialized here
    public class GUIModel {
        //TODO: Add fields that needs to be serialized
        //Add fields normally like so:
        //  public int SomeInt { get; set; }

        //Add Lists like so:
        //  [XmlArray("SomeUberName")]
        //  [XmlArrayItem("SomeSubName")]
        //  public List<SomeClass> AllSomething { get; set; } 

        public GUIModel() {
            //AllSomething = new List<SomeClass>();
        }
    }
}