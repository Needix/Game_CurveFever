// MainPanel.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Game_CurveFever.ProjectSRC.Model.Game;
using Game_CurveFever.ProjectSRC.Model.Game.Items;

namespace Game_CurveFever.ProjectSRC.Controller.Game {
    public class MainPanel : Form {
        private readonly MainLoop _mainLoop;
        public const int GAME_START_WIDTH = 800;
        public const int GAME_START_HEIGHT = 800;

        public MainPanel(MainLoop mainLoop) {
            _mainLoop = mainLoop;

            this.Size = new Size(GAME_START_WIDTH, GAME_START_HEIGHT);
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.Closing += ClosingForm;
            this.KeyPress += KeyPressed;
        }

        private void KeyPressed(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char) Keys.Space) {
                if(_mainLoop.GameState==MainLoop.GameStates.Running) //TODO: Add check if player is allowed to change pause
                    _mainLoop.GameState = MainLoop.GameStates.Paused;
                else if(_mainLoop.GameState == MainLoop.GameStates.Paused)
                    _mainLoop.GameState = MainLoop.GameStates.Running;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            //Draw won player
            if (_mainLoop.GameState == MainLoop.GameStates.Won) {
                g.DrawString(_mainLoop.Winner.Name + " won!", new Font("Arial", 30), new SolidBrush(Color.White), 40, this.Height/2f); //TODO: Draw text in middle of screen
                return;
            }

            //Draw Items
            foreach (Item fieldItem in _mainLoop.FieldItems) {
                g.DrawImage(fieldItem.Image, fieldItem.PosX, fieldItem.PosY);
            }

            //Draw Players
            List<Player> players = _mainLoop.Players;
            foreach (Player player in players) {
                List<HitPoint> points = player.PlayerState.HitBox;
                foreach (HitPoint point in points) {
                    Pen p = new Pen(point.Color, point.Size);
                    g.DrawLine(p, point.X, point.Y, point.X+1, point.Y+1);
                }
            }

            //Draw paused
            if(_mainLoop.GameState == MainLoop.GameStates.Paused) {
                g.DrawString("Game paused!", new Font("Arial", 30), new SolidBrush(Color.White), this.Width/2-50, this.Height/2f); //TODO: Draw text in middle of screen
            }
        }

        private void ClosingForm(object sender, CancelEventArgs e) {
            _mainLoop.Exit();
        }


        public void Repaint() {
            this.Invalidate();
        }
    }
}