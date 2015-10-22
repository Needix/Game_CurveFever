﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game_CurveFever.ProjectSRC.Controller;
using Game_CurveFever.ProjectSRC.Controller.Game;
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

            List<Player> players = new List<Player>();
            players.Add(new Player("Test1", 'a', 'd'));
            players.Add(new Player("Test2", 'q', 'e'));
            GameOptions.PlayerStartPositions start = GameOptions.PlayerStartPositions.Random;

            FinalizePlayer(start, players);
            GameOptions options = new GameOptions(true, 50, GameOptions.Host.Server, 5, GameOptions.AllowedPause.Everyone, start, true, null);
            MainLoop mainL = new MainLoop(options, players);
            //GUIMain view = new GUIMain();
            //GUIController controller = new GUIController(view); //Controller is saved in view as reference
            //view.RegisterController(controller);

            Application.Run(mainL.Panel);
        }

        private static void FinalizePlayer(GameOptions.PlayerStartPositions start, List<Player> players) {
            int guiWidth = MainPanel.GAME_START_WIDTH;
            int guiHeight = MainPanel.GAME_START_HEIGHT;


            for(int i = 0; i < players.Count; i++) {
                Player curPlayer = players[i];
                switch(start) {
                    case GameOptions.PlayerStartPositions.Circle:
                        //TODO: Calculate coords based on player count (e.g. 3 player: every 360/3 = 120 degree one player // 4 player: every 360/4 = 90 degree one player)
                        double angleBetweenPlayers = 360d/players.Count;
                        break;

                    case GameOptions.PlayerStartPositions.Line:
                        float xDistanceBetweenPlayers = (guiWidth - 40)/(float)players.Count;
                        int randomY = new Random().Next(20, guiHeight-20);
                        players[i].Finalize(i,
                            new HitPoint(20+i*xDistanceBetweenPlayers, randomY, curPlayer),
                            new Random().Next(360));
                        break;

                    case GameOptions.PlayerStartPositions.Random:
                        HitPoint newHitPoint = null;
                        while(newHitPoint == null) {
                            newHitPoint = HitPoint.CreateRandomHitPoint(20, 20, guiWidth-20, guiHeight-20, curPlayer);
                            Debug.WriteLine("Trying to create new random start position for player: "+curPlayer);
                            for(int j = 0; j < i; j++) {
                                Player checkPlayer = players[j];
                                double distance = newHitPoint.Distance(checkPlayer.PlayerState.Position);
                                if(distance < 20) {
                                    newHitPoint = null;
                                    Debug.WriteLine("Failed to create new random start position for player: "+curPlayer+"! Distance to "+checkPlayer+" was "+distance);
                                    break;
                                }
                            }
                        }
                        players[i].Finalize(i, newHitPoint, new Random().Next(360));
                        Debug.WriteLine("Finalized player "+curPlayer);
                        break;
                }
            }
        }
    }
}