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

        public GUIMain() {
            InitializeComponent();
        }

        private void b_local_createNewGame_Click(object sender, System.EventArgs e) {
            this.Visible = false;
            new GUILocalNew().Visible = true;
        }

        private void b_local_loadSavedGame_Click(object sender, System.EventArgs e) {
            this.Visible = false;
            new GUILocalLoad().Visible = true;
        }

        private void b_internet_createNewServer_Click(object sender, System.EventArgs e) {
            this.Visible = false;
            new GUIInternetCreate().Visible = true;
        }

        private void b_internet_joinServer_Click(object sender, System.EventArgs e) {
            this.Visible = false;
            new GUIInternetJoin().Visible = true;
        }
    }
}
