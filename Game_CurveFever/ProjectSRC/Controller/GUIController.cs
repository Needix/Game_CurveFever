// GUIController.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using Game_CurveFever.ProjectSRC.GUI;
using Game_CurveFever.ProjectSRC.Model;

namespace Game_CurveFever.ProjectSRC.Controller {
    public class GUIController {
        public GUIMain View { get; set; }

        public GUIController(GUIMain view) {
            View = view;
        }
    }
}