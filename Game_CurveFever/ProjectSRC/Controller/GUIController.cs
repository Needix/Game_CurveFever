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
        private GUIModel _model;
        public GUIModel Model {
            get { return _model; }
            set {
                if(value == null) return;
                _model = value;

            }
        }

        public GUIMain View { get; set; }

        public Serializer Serializer { get; private set; }

        public GUIController(GUIMain view) {
            Serializer = new Serializer(this);
            Model = Serializer.Deserialize();
            if(Model == null) Model = new GUIModel();

            View = view;
            View.UpdateView(Model);
        }
    }
}