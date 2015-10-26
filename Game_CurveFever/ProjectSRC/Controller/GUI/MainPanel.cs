// MainPanel.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
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
        public const int GAME_WIDTH = 1500;
        public const int GAME_HEIGHT = 900;
        public const int GAME_SCOREBOARD_X = GAME_WIDTH - GAME_WIDTH / 5;

        public MainPanel(MainLoop mainLoop) {
            _mainLoop = mainLoop;

            this.Size = new Size(GAME_WIDTH, GAME_HEIGHT);
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.Manual;
            this.BringToFront();
            this.Location = new Point(25,25);
            this.FormBorderStyle = FormBorderStyle.None;
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
            if (e.KeyChar == (char) Keys.Escape) {
                _mainLoop.End = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            //Draw won player
            if (_mainLoop.GameState == MainLoop.GameStates.Won) {
                g.DrawString(_mainLoop.Winner.Name + " (Color \""+_mainLoop.Winner.Color.Name+"\") won!", new Font("Arial", 30), new SolidBrush(Color.White), 40, this.Height/2f); //TODO: Draw text in middle of screen
                return;
            }

            //Draw Items
            foreach (Item fieldItem in _mainLoop.FieldItems) {
                g.DrawImage(fieldItem.Image, fieldItem.X, fieldItem.Y);
            }

            //Draw Players
            List<Player> players = _mainLoop.Players;
            foreach (Player player in players) {
                List<HitPoint> points = player.PlayerState.HitBox;
                foreach (HitPoint point in points) {
                    Brush b = new SolidBrush(point.Color);
                    g.FillEllipse(b,point.X, point.Y, point.Size, point.Size);
                }
            }

            //Draw Scores
            Font scoreFont = new Font("Arial", 15);
            for (int i = 0; i < players.Count; i++) {
                Player curPlayer = players[i];
                String crashed = curPlayer.PlayerState.Died ? " (Crashed)" : "";
                String scoreString = curPlayer.Name + crashed + ": " + curPlayer.Score;
                g.DrawString(scoreString, scoreFont, new SolidBrush(curPlayer.Color), GAME_SCOREBOARD_X, 5 + i * 20);
            }
            g.DrawLine(new Pen(Color.White), GAME_SCOREBOARD_X, 0, GAME_SCOREBOARD_X, GAME_HEIGHT);

            //Draw paused
            if(_mainLoop.GameState == MainLoop.GameStates.Paused) {
                g.DrawString("Game paused!", new Font("Arial", 30), new SolidBrush(Color.White), this.Width/2-50, this.Height/2f); //TODO: Draw text in middle of screen
            }
        }

        private void ClosingForm(object sender, CancelEventArgs e) {
            _mainLoop.Exit();
        }


        public void Repaint() {
            if (!this.IsHandleCreated) return;
            try {
                this.Invoke((MethodInvoker) delegate {
                    this.Invalidate();
                    this.Update();
                });
            } catch(ObjectDisposedException) { } //No way to solve this // best way to handle it
        }
    }
}