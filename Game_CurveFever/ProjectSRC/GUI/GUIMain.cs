// GUIView.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System.Windows.Forms;
using Game_CurveFever.ProjectSRC.Controller;
using Game_CurveFever.ProjectSRC.Model;

namespace Game_CurveFever.ProjectSRC.GUI {
    public partial class GUIMain :Form {
        private GUIController _controller;

        public GUIMain() {
            InitializeComponent();
            RegisterCustomEvents();
        }

        private void RegisterCustomEvents() {
            //TODO: Add custom events here
        }

        public void RegisterController(GUIController controller) { _controller = controller; }

        public void UpdateView(GUIModel model) {
            //TODO: Add update code here (update gui components from model data)
        }
    }
}
