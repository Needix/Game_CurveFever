// MainLoop.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Game_CurveFever.ProjectSRC.Model.Game;
using Game_CurveFever.ProjectSRC.Model.Game.Items;

namespace Game_CurveFever.ProjectSRC.Controller.Game {
    public class MainLoop {
        public enum GameStates {
            Running = 0,
            Paused = 1,
            Won = 2,
        }

        private readonly Thread _mainLoopThread;
        private readonly MainPanel _panel; 
        public MainPanel Panel { get; private set; } //TODO: Remove on release
        private readonly GameOptions _gameOptions;

        public List<Player> Players { get; private set; }
        public List<Item> FieldItems { get; private set; }

        public GameStates GameState { get; set; }
        public bool End { get; set; }
        public bool Paused { get; set; }

        public Player Winner { get; private set; }

        private readonly KeyMessageFilter _keyMessageFilter = new KeyMessageFilter();

        public MainLoop(GameOptions gameOptions, List<Player> players) {
            _gameOptions = gameOptions;
            Players = players;
            FieldItems = new List<Item>();
            GameState = GameStates.Running;

            Item.CreateItems();

            Application.AddMessageFilter(this._keyMessageFilter);

            _panel = new MainPanel(this);
            _panel.Visible = true;

            _mainLoopThread = new Thread(Run);
            _mainLoopThread.Name = "MainGameLoop";
            _mainLoopThread.Start();
        }

        private void Run() {
            while (!End) {
                CalcNextRound();
                _panel.Repaint();
                if(_gameOptions.PlayerSpeed!=0) Thread.Sleep(100-(_gameOptions.PlayerSpeed)); //TEST: Max speed / Min speed
            }
            Application.Exit();
        }

        private void CalcNextRound() {
            if(GameState!=GameStates.Running) return;

            Player possibleWinner = null;
            int alivePlayers = 0;
            foreach(Player player in Players) {
                if (player.PlayerState.Died) continue;

                CheckPlayerChangeDirection(player);

                PlayerState state = player.PlayerState;
                state.RemoveExpiredEffects();

                int pointSize = 3;
                HitPoint nextMove = state.CalculateNextMove(player, pointSize);
                if (CheckPlayerHitWall(player, nextMove)) continue;
                if (CheckPlayerHitPlayer(player, nextMove)) continue;

                player.PlayerState.AddHitPoint(nextMove);
                alivePlayers++;
                possibleWinner = player;
            }

            if (alivePlayers <= 1) {
                GameState = GameStates.Won;
                Winner = possibleWinner;
                Debug.WriteLine("Winner: "+Winner);
            }
        }

        private void CheckPlayerChangeDirection(Player p) {
            if(_keyMessageFilter.IsKeyPressed((p.StearLeft+"").ToUpper())) p.PlayerState.Direction -= 10;
            if(_keyMessageFilter.IsKeyPressed((p.StearRight+"").ToUpper())) p.PlayerState.Direction += 10;
        }

        private bool CheckPlayerHitPlayer(Player player, HitPoint nextMove) {
            bool hit = false;
            foreach (Player colCheckPlayer in Players) {
                PlayerState colPlayerState = colCheckPlayer.PlayerState;
                foreach (HitPoint colCheckHitpoint in colPlayerState.HitBox) {
                    if (colCheckPlayer != player && nextMove.Hit(colCheckHitpoint)) {
                        hit = true;
                        break;
                    }
                }
                if (hit) {
                    Debug.WriteLine(player.Name + " died! (PlayerHit " + colCheckPlayer.Name + " @Positions: " + player.PlayerState.Position + "  ///  " + colCheckPlayer.PlayerState.Position + ")");
                    player.PlayerState.Died = true;
                    return true;
                }
            }
            return false;
        }

        private bool CheckPlayerHitWall(Player player, HitPoint nextMove) {
            if (nextMove.HitWall(this._panel.Width, this._panel.Height)) {
                player.PlayerState.Died = true;
                Debug.WriteLine(player.Name +" died! (WallHit @"+nextMove+")");
                return true;
            }
            return false;
        }

        public void Exit() {
            End = true;
        }
    }
}