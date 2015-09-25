using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game_CurveFever.ProjectSRC.GUI {
    public partial class GUILocalNew :Form {
        private const int MAX_NEEDED_WINS = 50;
        private const int MAX_CONST = 100;
        private const int MAX_PLAYER_SPEED = 100;

        public GUILocalNew() {
            InitializeComponent();
            CustomInitComponents();
        }

        private void CustomInitComponents() {
            for(int i = 0; i < MAX_CONST; i++) {
                if(i<MAX_PLAYER_SPEED) comboBox_options_playerSpeed.Items.Add(i);
                if(i<MAX_NEEDED_WINS) comboBox_options_neededWins.Items.Add(i);
            }
        }
    }
}
