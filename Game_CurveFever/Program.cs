using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Game_CurveFever.ProjectSRC.Controller;
using Game_CurveFever.ProjectSRC.GUI;

namespace Game_CurveFever {
    static class Program {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GUIMain view = new GUIMain();
            GUIController controller = new GUIController(view); //Controller is saved in view as reference
            view.RegisterController(controller);

            Application.Run(view);
        }
    }
}
