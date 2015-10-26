// MainLoop.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Game_CurveFever.ProjectSRC.Model.Game;
using Game_CurveFever.ProjectSRC.Model.Game.Items;

namespace Game_CurveFever.ProjectSRC.Controller.Game {
    public class MainLoop {
        private static Random _random;
        public static Random Random {
            get {
                if(_random == null) _random = new Random();
                return _random;
            }
            set { _random = value; }
        }

        public enum GameStates {
            Running = 0,
            Paused = 1,
            Won = 2,
        }

        private readonly MainPanel _panel; 
        public MainPanel Panel { get; private set; } //TODO: Remove on release
        private readonly GameOptions _gameOptions;

        public List<Player> Players { get; private set; }
        public List<Item> FieldItems { get; private set; }

        public GameStates GameState { get; set; }
        public bool End { get; set; }
        public bool Paused { get; set; }

        private int _lastItemAppearedTick = Environment.TickCount;
        private readonly int _tickTimeBetweenNewItemSpawns = 7*1000;
        private readonly double _itemAppearProbability = 0.005;

        public Player Winner { get; private set; }

        private readonly KeyMessageFilter _keyMessageFilter = new KeyMessageFilter();

        public MainLoop(GameOptions gameOptions, List<Player> players) {
            _gameOptions = gameOptions;
            Players = players;
            FieldItems = new List<Item>();
            GameState = GameStates.Running;

            Item.CreateItems();

            Application.AddMessageFilter(_keyMessageFilter);

            _panel = new MainPanel(this);
            _panel.Visible = true;

            var mainLoopThread = new Thread(Run);
            mainLoopThread.Name = "MainGameLoop";
            mainLoopThread.Start();
        }

        private void Run() {
            while(!End) {
                if(_gameOptions.PlayerSpeed < 100) Thread.Sleep(100 - (_gameOptions.PlayerSpeed)); //TEST: Max speed / Min speed
                if(_panel == null) continue;
                CalcNextRound();
                _panel.Repaint();
            }
            Application.Exit();
        }

        private void CalcNextRound() {
            if(GameState!=GameStates.Running) return;

            CreateNewFieldItems();

            CalculatePlayerLogic();

            RemoveExpiredItems();

            CheckWinner();
        }

        private void CalculatePlayerLogic() {
            foreach (Player player in Players) {
                if (player.PlayerState.Died) continue;

                CheckPlayerChangeDirection(player);
                CheckPlayerHitItem(player);

                PlayerState state = player.PlayerState;
                state.RemoveExpiredEffects();

                int pointSize = HitPoint.DEFAULT_SIZE;
                HitPoint nextMove = state.CalculateNextMove(player, pointSize);
                if (CheckPlayerHitWall(player, nextMove)) continue;
                if (CheckPlayerHitPlayer(player, nextMove)) continue;

                player.PlayerState.AddHitPoint(nextMove);
            }
        }

        private void CreateNewFieldItems() {
            if (Environment.TickCount - _lastItemAppearedTick > _tickTimeBetweenNewItemSpawns &&
                Random.NextDouble() < _itemAppearProbability) {
                Item newItem = Item.CreateRandomItem();
                FieldItems.Add(newItem);
                _lastItemAppearedTick = Environment.TickCount;
                Debug.WriteLine("Created new item: "+newItem);
            }
        }

        private void CheckWinner() {
            int alivePlayers = 0;
            Player possibleWinner = null;
            foreach (Player player in Players) {
                if(player.PlayerState.Died) continue;
                alivePlayers++;
                possibleWinner = player;
                if (alivePlayers > 1) break;
            }
            if (alivePlayers <= 1) {
                GameState = GameStates.Won;
                Winner = possibleWinner;
                Debug.WriteLine("Winner: " + Winner);
            }
        }

        private void RemoveExpiredItems() {
            List<Item> newItems = new List<Item>();
            foreach (Item fieldItem in FieldItems) {
                if (fieldItem.Collected || fieldItem.Expired()) {
                    Debug.WriteLine("Removing collected or expired item: " + fieldItem);
                    continue;
                }
                newItems.Add(fieldItem);
            }
            FieldItems = newItems;
        }

        private void CheckPlayerHitItem(Player player) {
            foreach (Item fieldItem in FieldItems) {
                if (player.PlayerState.Position.Hit(fieldItem)) {
                    player.PlayerState.Effects.Add(fieldItem.Effect);
                    fieldItem.Collected = true;
                    Debug.WriteLine(player.Name+" collected item: "+fieldItem.Effect);
                }
            }
        }

        private void CheckPlayerChangeDirection(Player p) {
            if (Environment.TickCount - p.PlayerState.LastMoveTick <= PlayerState.PLAYER_CHANGE_DIRECTION_SPEED) return;
            if(_keyMessageFilter.IsKeyPressed((p.StearLeft+"").ToUpper())) p.PlayerState.Direction -= 10;
            if(_keyMessageFilter.IsKeyPressed((p.StearRight+"").ToUpper())) p.PlayerState.Direction += 10;
            p.PlayerState.LastMoveTick = Environment.TickCount;
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
                    Debug.WriteLine(player.Name + " died! (PlayerHit " + colCheckPlayer.Name + " @ Positions: " + player.PlayerState.Position + "  ///  " + colCheckPlayer.PlayerState.Position + ")");
                    player.PlayerState.Died = true;
                    return true;
                }
            }
            return false;
        }

        private bool CheckPlayerHitWall(Player player, HitPoint nextMove) {
            if(nextMove.HitWall(MainPanel.GAME_SCOREBOARD_X, MainPanel.GAME_HEIGHT)) {
                player.PlayerState.Died = true;
                Debug.WriteLine(player.Name +" died! (WallHit @ "+nextMove+")");
                return true;
            }
            return false;
        }

        public void Exit() {
            End = true;
        }
    }
}