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
using Game_CurveFever.ProjectSRC.Controller.Game;
using Game_CurveFever.ProjectSRC.Model.Game;
using Game_CurveFever.ProjectSRC.Model.Game.Items;

namespace Game_CurveFever.ProjectSRC.Controller.GUI {
    public class MainPanel : Form {
        private readonly MainLoop _mainLoop;
        public static int GameWidth { get; private set; }
        public static int GameHeight { get; private set; }
        public static int GameScoreboardX { get; private set; }

        public MainPanel(int guiW, int guiH, MainLoop mainLoop) {
            _mainLoop = mainLoop;

            GameWidth = guiW;
            GameHeight = guiH;
            GameScoreboardX = GameWidth - GameWidth / 5;

            this.Size = new Size(GameWidth, GameHeight);
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.Manual;
            this.BringToFront();
            this.Location = new Point(5,5);
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
                _mainLoop.GameState = MainLoop.GameStates.End;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            //Draw won player
            int tick = Environment.TickCount;
            if (_mainLoop.GameState == MainLoop.GameStates.Won) {
                g.DrawString(_mainLoop.Winner.Name + " (Color \""+_mainLoop.Winner.Color.Name+"\") won!", new Font("Arial", 30), new SolidBrush(Color.White), 40, this.Height/2f); //TODO: Draw text in middle of screen
                return;
            }
            Debug.WriteLine("WonPlayer: "+(Environment.TickCount-tick));

            //Draw Items
            tick = Environment.TickCount;
            foreach (Item fieldItem in _mainLoop.FieldItems) {
                g.DrawImage(fieldItem.Image, fieldItem.X, fieldItem.Y);
            }
            Debug.WriteLine("Items: " + (Environment.TickCount - tick));

            //Draw Players
            tick = Environment.TickCount;
            List<Player> players = _mainLoop.Players;
            foreach (Player player in players) {
                List<HitPoint> points = player.PlayerState.HitBox;
                foreach (HitPoint point in points) {
                    Brush b = new SolidBrush(point.Color);
                    g.FillEllipse(b,point.X, point.Y, point.Size, point.Size);
                }
                //g.FillEllipse(new SolidBrush(player.Color), player.PlayerState.Position.X, player.PlayerState.Position.Y, HitPoint.DEFAULT_SIZE, HitPoint.DEFAULT_SIZE);
            }
            Debug.WriteLine("Players: " + (Environment.TickCount - tick));

            //Draw Scores
            tick = Environment.TickCount;
            Font scoreFont = new Font("Arial", 15);
            for (int i = 0; i < players.Count; i++) {
                Player curPlayer = players[i];
                String crashed = curPlayer.PlayerState.Died ? " (Crashed)" : "";
                String scoreString = curPlayer.Name + crashed + ": " + curPlayer.Score;
                g.DrawString(scoreString, scoreFont, new SolidBrush(curPlayer.Color), GameScoreboardX, 5 + i * 20);
            }
            g.DrawLine(new Pen(Color.White), GameScoreboardX, 0, GameScoreboardX, GameHeight);
            Debug.WriteLine("Scores: " + (Environment.TickCount - tick));

            //Draw paused
            tick = Environment.TickCount;
            if(_mainLoop.GameState == MainLoop.GameStates.Paused) {
                g.DrawString("Game paused!", new Font("Arial", 30), new SolidBrush(Color.White), this.Width/2-50, this.Height/2f); //TODO: Draw text in middle of screen
            }
            Debug.WriteLine("Paused: " + (Environment.TickCount - tick));
        }

        private void ClosingForm(object sender, CancelEventArgs e) {
            _mainLoop.Exit();
        }


        public void Repaint() {
            if (!this.IsHandleCreated) return;
            try {
                this.Invoke((MethodInvoker) delegate {
                    //this.Invalidate();
                    //this.Update();
                    this.Refresh();
                });
            } catch(ObjectDisposedException) { } //No way to solve this // best way to handle it
        }
    }
}