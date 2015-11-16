using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game_CurveFever.ProjectSRC.Controller;
using Game_CurveFever.ProjectSRC.Controller.Game;
using Game_CurveFever.ProjectSRC.Controller.GUI;
using Game_CurveFever.ProjectSRC.GUI;
using Game_CurveFever.ProjectSRC.Model.Game;

namespace Game_CurveFever {
    static class Program {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int guiW = 1500;
            int guiH = 900;
            Rectangle screenSize = Screen.PrimaryScreen.Bounds;
            if (screenSize.Width < guiW) guiW = screenSize.Width - 10;
            if(screenSize.Height < guiH) guiH = screenSize.Height - 50;
            int gameScoreboardX = guiW - guiH / 5;

            List<Player> players = new List<Player>();
            players.Add(new Player("Test1", 'a', 'd'));
            players.Add(new Player("Test2", 'q', 'e'));
            
            //FinalizePlayer(gameScoreboardX, guiH, start, players);
            GameOptions options = new GameOptions(true, true, 40, GameOptions.Host.Server, 5000, GameOptions.AllowedPause.Everyone, GameOptions.PlayerStartPositions.Random, true, null);
            MainLoop mainL = new MainLoop(guiW, guiH, options, players);

            //GUIMain view = new GUIMain();
            //GUIController controller = new GUIController(view); //Controller is saved in view as reference
            //view.RegisterController(controller);
        }
    }
}
