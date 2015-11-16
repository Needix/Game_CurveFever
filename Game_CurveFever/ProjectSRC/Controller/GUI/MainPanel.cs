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
            this.BackColor = Color.Black;
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

        protected override void OnPaint(PaintEventArgs e) { //BUG: Sometimes shows strange "red X"
            base.OnPaint(e);
            List<Player> players = _mainLoop.Players;
            Graphics g = e.Graphics;

            if (Item.ItemActive("Global:ColorChange", players)) {
                g.Clear(GetNextColorChangeColor());
            } else {
                g.Clear(Color.Black);   
            }

            if(_mainLoop.GameState == MainLoop.GameStates.ShowStart) {
                foreach (Player player in players) {
                    Pen p = new Pen(player.Color, 2);
                    Brush b = new SolidBrush(player.Color);

                    int direction = player.PlayerState.Direction;
                    Position arrowLineStart = player.PlayerState.CurrentHitpoint.CalcRelativePoint(direction, 15); //Relative location to player
                    Position arrowLineEnd = arrowLineStart.CalcRelativePoint(direction, 20); //Line Direction + Length
                    Position arrowHeadFront = arrowLineEnd.CalcRelativePoint(direction, 5); //Front of ArrowHead
                    Position arrowHeadLeft = arrowHeadFront.CalcRelativePoint(direction - 45, -10); //
                    Position arrowHeadRight = arrowHeadFront.CalcRelativePoint(direction + 45, -10);
                    Point[] triangle = new Point[3];
                    triangle[0] = new Point((int)arrowHeadFront.X, (int)arrowHeadFront.Y);
                    triangle[1] = new Point((int)arrowHeadLeft.X, (int)arrowHeadLeft.Y);
                    triangle[2] = new Point((int)arrowHeadRight.X, (int)arrowHeadRight.Y);

                    g.DrawLine(p, arrowLineStart.X, arrowLineStart.Y, arrowLineEnd.X, arrowLineEnd.Y);
                    g.FillPolygon(b, triangle);

                    string countDownString = "Get ready...";
                    int timeLeft = Environment.TickCount - _mainLoop.TickGameStateToStartChanged;
                    if(timeLeft > 4700) countDownString = "GO!";
                    else if(timeLeft > 3700) countDownString = "1!";
                    else if(timeLeft > 2700) countDownString = "2!";
                    else if(timeLeft > 1700) countDownString = "3!";

                    Font f = new Font("Arial", 30);
                    SizeF stringSize = g.MeasureString(countDownString, f);
                    g.DrawString(countDownString, f, new SolidBrush(Color.White), GameWidth / 2f - stringSize.Width / 2, GameHeight / 2f - stringSize.Height / 2); 
                }
            }

            //Score
            if(_mainLoop.GameState == MainLoop.GameStates.Score) {
                Font f = new Font("Arial", 30);
                String drawString = "Draw!";
                if(_mainLoop.Winner != null) drawString = _mainLoop.Winner.Name + " (Color \"" + _mainLoop.Winner.Color.Name + "\") scored!";

                SizeF stringSize = g.MeasureString(drawString, f);
                g.DrawString(drawString, f, new SolidBrush(Color.White), GameWidth / 2f - stringSize.Width / 2, GameHeight / 2f - stringSize.Height / 2); 
            }

            //Draw won player
            if (_mainLoop.GameState == MainLoop.GameStates.Won) {
                Font f = new Font("Arial", 30);
                String drawString = "Draw!";
                if (_mainLoop.Winner != null) drawString = _mainLoop.Winner.Name + " (Color \"" + _mainLoop.Winner.Color.Name + "\") won!";

                SizeF stringSize = g.MeasureString(drawString, f);
                g.DrawString(drawString, f, new SolidBrush(Color.White), GameWidth/2f-stringSize.Width/2, GameHeight/2f-stringSize.Height/2);
            }

            //Draw Items
            foreach (Item fieldItem in _mainLoop.FieldItems) {
                g.DrawImage(fieldItem.Image, fieldItem.X, fieldItem.Y);
            }

            //Draw Players
            bool darknessActive = Item.ItemActive("Global:Darkness", players);
            foreach(Player player in players) {
                HitPoint last = player.PlayerState.CurrentHitpoint;
                if(last != null) {
                    g.FillEllipse(new SolidBrush(last.Color), last.Pos.X, last.Pos.Y, last.Size, last.Size);
                }

                if(!darknessActive) { //TODO: Add "flickering" // FogOfWar
                    List<HitPoint> points = player.PlayerState.HitBox;
                    foreach(HitPoint point in points) {
                        if(!point.Enabled) continue;
                        Brush b = new SolidBrush(point.Color);
                        g.FillEllipse(b, point.Pos.X, point.Pos.Y, point.Size, point.Size);
                    }   
                }
            }

            //Draw Scores
            Font scoreFont = new Font("Arial", 15);
            for (int i = 0; i < players.Count; i++) {
                Player curPlayer = players[i];
                String crashed = curPlayer.PlayerState.Died ? " (Crashed)" : "";
                String scoreString = curPlayer.Name + crashed + ": " + curPlayer.Score;
                g.DrawString(scoreString, scoreFont, new SolidBrush(curPlayer.Color), GameScoreboardX, 5 + i * 20);
            }
            g.DrawLine(new Pen(Color.White), GameScoreboardX, 0, GameScoreboardX, GameHeight);

            //Draw paused
            if(_mainLoop.GameState == MainLoop.GameStates.Paused) {
                g.DrawString("Game paused!", new Font("Arial", 30), new SolidBrush(Color.White), this.Width/2-50, this.Height/2f);
            }
        }

        private void ClosingForm(object sender, CancelEventArgs e) {
            _mainLoop.Exit();
        }

        public void Repaint() {
            if (!this.IsHandleCreated) return;
            try {
                this.Invoke((MethodInvoker) this.Refresh);
            } catch(ObjectDisposedException) { } //No way to solve this // best way to handle it
        }

        private int _colorChangeIndex;
        private Color GetNextColorChangeColor() {
            int r = 0;
            int g = 0;
            int b = 0;
            int div = _colorChangeIndex/255;
            int rest = _colorChangeIndex%255;
            switch(div) {
                case 0:
                    r = rest;
                    break;
                case 1:
                    r = 255;
                    g = rest;
                    break;
                case 2:
                    r = 255 - rest;
                    g = 255;
                    break;
                case 3:
                    g = 255;
                    b = rest;
                    break;
                case 4:
                    g = 255 - rest;
                    b = 255;
                    break;
                case 5:
                    r = rest;
                    b = 255;
                    break;
                case 6:
                    r = 255;
                    b = 255 - rest;
                    break;
                case 7:
                    r = 255 - rest;
                    break;
                case 8:
                    _mainLoop.RemoveEffect("Global:ColorChange");
                    _colorChangeIndex = 0;
                    return Color.Black;
            }
            _colorChangeIndex+=10;
            return Color.FromArgb(r, g, b);
        }
    }
}