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
using Game_CurveFever.ProjectSRC.Controller.GUI;
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
            Init = 0,
            ShowStart = 1,
            Running = 2,
            Paused = 3,
            Score = 4,
            Won = 5,
            End = 6,
        }

        public const int PAUSE_BETWEEN_SCORES = 7*1000;
        public const int PAUSE_BETWEEN_START_RUNNING = 5*1000;

        public const int TICK_SELF_IMMUNITY = 500;

        private readonly MainPanel _panel; 
        private readonly GameOptions _gameOptions;

        public List<Player> Players { get; private set; }
        public List<Item> FieldItems { get; private set; }

        public GameStates GameState { get; set; }

        private int _lastItemSpawnTick = Environment.TickCount;
        private readonly int _tickTimeBetweenNewItemSpawns = 7*1000;
        private readonly double _itemSpawnProbability = 0.005;

        public int TickPlayerScored { get; set; }
        public int TickGameStateToStartChanged { get; set; }

        public Player Winner { get; private set; }

        public static int LastRunSpeed { get; private set; }

        private readonly KeyMessageFilter _keyMessageFilter = new KeyMessageFilter();

        public MainLoop(int guiW, int guiH, GameOptions gameOptions, List<Player> players) {
            _gameOptions = gameOptions;
            Players = players;
            FieldItems = new List<Item>();
            GameState = GameStates.Init;
            TickGameStateToStartChanged = Environment.TickCount;

            Item.CreateItems();

            Application.AddMessageFilter(_keyMessageFilter);

            _panel = new MainPanel(guiW, guiH, this);
            _panel.Visible = true;

            Thread mainLoopThread = new Thread(Run);
            mainLoopThread.Name = "MainGameLoop";
            mainLoopThread.Start();

            Application.Run(_panel);
        }

        private void Run() {
            while(GameState!=GameStates.End) {
                int sleep = _gameOptions.PlayerSpeed + LastRunSpeed;
                if (sleep < 100) Thread.Sleep(100 - sleep);

                if(_panel == null) continue;

                CalcNextRound();

                _panel.Repaint();
            }
            //TODO: Send network message on exit (or just use timeouts)
            Application.Exit();
        }

        private void CalcNextRound() {
            if(GameState == GameStates.Score && Environment.TickCount - TickPlayerScored > PAUSE_BETWEEN_SCORES) {
                TickGameStateToStartChanged = Environment.TickCount;
                GameState = GameStates.Init;
            }
            if(GameState == GameStates.Init) {
                List<StartPosition> pStartPos = CreateStartPositions(Players);
                for(int i = 0; i < Players.Count; i++) {
                    Players[i].ResetPlayer(i, pStartPos[i]);
                }

                GameState = GameStates.ShowStart;
            }
            if(GameState == GameStates.ShowStart && Environment.TickCount - TickGameStateToStartChanged > PAUSE_BETWEEN_START_RUNNING) {
                GameState = GameStates.Running;
            }
            if(GameState!=GameStates.Running) return;

            CreateNewFieldItems();

            CalculatePlayerLogic();

            CheckWinner();
        }

        /// <summary>
        /// Calculates all the player logic
        /// </summary>
        private void CalculatePlayerLogic() {
            ActivatePlayerEffects();

            if (Item.ItemActive("Global:Eraser", Players)) {
                RemoveEffect("Global:Eraser");
                foreach (Player player in Players) {
                    player.PlayerState.HitBox.Clear();
                }
            }

            foreach (Player player in Players) {
                for (int i = 0; i < 5; i++) { //Add multiple HitPoints at same time to speed up game
                    if (player.PlayerState.Died) continue;

                    CheckPlayerChangeDirection(player);
                    CheckPlayerHitItem(player);

                    player.PlayerState.RemoveExpiredEffects();

                    HitPoint nextMove = player.PlayerState.CalculateNextMove(player);
                    if (CheckPlayerHitWall(player, nextMove)) continue;
                    if (CheckPlayerHitPlayer(player, nextMove)) continue;

                    CalculateHoleChance(player, nextMove);

                    RemoveExpiredItems();
                }
            }
        }

        private void CalculateHoleChance(Player player, HitPoint nextMove) {
            PlayerState state = player.PlayerState;
            if(_gameOptions.Holes && (state.DrawHoleStartTick != 0 || Random.NextDouble() < PlayerState.PROBABILITY_DRAW_HOLES_START)) {
                if(state.DrawHoleStartTick == 0) {
                    state.DrawHoleStartTick = Environment.TickCount;
                    state.DrawHoleStopTick = Environment.TickCount +
                                             Random.Next(PlayerState.MIN_HOLE_SIZE_IN_TICKS, PlayerState.MAX_HOLE_SIZE_IN_TICKS);
                } else if(Environment.TickCount > state.DrawHoleStopTick) {
                    state.DrawHoleStartTick = 0;
                    state.DrawHoleStopTick = 0;
                }
                nextMove.Enabled = false;
            }
            player.PlayerState.AddHitPoint(nextMove);
        }

        /// <summary>
        /// Randomly creates new field items
        /// </summary>
        private void CreateNewFieldItems() {
            if (Environment.TickCount - _lastItemSpawnTick > _tickTimeBetweenNewItemSpawns && Random.NextDouble() < _itemSpawnProbability) {
                Item newItem = Item.CreateRandomItem();
                FieldItems.Add(newItem);
                _lastItemSpawnTick = Environment.TickCount;
                Debug.WriteLine("Created new item: "+newItem);
            }
        }

        /// <summary>
        /// Checks if there is only one player 
        /// </summary>
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
                Winner = possibleWinner;

                GameState = GameStates.Score;
                TickPlayerScored = Environment.TickCount;

                if(Winner != null) {
                    Winner.AddScore();
                    if(Winner.Score == _gameOptions.NeededWins) {
                        GameState = GameStates.Won;
                    }
                }
            }
        }

        /// <summary>
        /// Activates effects that are saved in PlayerState (like big/thin, speed/slow, square/turn-speed ...)
        /// </summary>
        private void ActivatePlayerEffects() {
            foreach(Player player in Players) {
                player.PlayerState.CurrentSize = HitPoint.DEFAULT_SIZE;
                player.PlayerState.CurrentSize += 6 * player.PlayerState.CheckAmountActiveEffects("Self:Big");
                player.PlayerState.CurrentSize -= 3 * player.PlayerState.CheckAmountActiveEffects("Self:Thin");

                player.PlayerState.CurrentTurnRadius = PlayerState.PLAYER_TURN_RADIUS;
                if(player.PlayerState.CheckAmountActiveEffects("Self:Square") > 0) player.PlayerState.CurrentTurnRadius = 90;

                player.PlayerState.NoControl = false;
                if(player.PlayerState.CheckAmountActiveEffects("Self:NoControl") > 0) player.PlayerState.NoControl = true;

                player.PlayerState.ReverseControl = false;
                if(player.PlayerState.CheckAmountActiveEffects("Self:ReverseControl") > 0) player.PlayerState.ReverseControl = true;

                player.PlayerState.CurrentSpeed = PlayerState.PLAYER_DEFAULT_SPEED;
                player.PlayerState.CurrentSpeed += 2 * player.PlayerState.CheckAmountActiveEffects("Self:Speed");
                player.PlayerState.CurrentSpeed -= 2 * player.PlayerState.CheckAmountActiveEffects("Self:Slow");

                foreach(Player player1 in Players) {
                    //Add/Subtract "Other" effects from other players
                    if(player == player1) continue;
                    if(player1.PlayerState.CheckAmountActiveEffects("Other:Square") > 0) player.PlayerState.CurrentTurnRadius = 90;
                    if(player1.PlayerState.CheckAmountActiveEffects("Other:NoControl") > 0) player.PlayerState.NoControl = true;
                    if(player1.PlayerState.CheckAmountActiveEffects("Other:ReverseControl") > 0) player.PlayerState.ReverseControl = true;

                    player.PlayerState.CurrentSpeed += 2 * player1.PlayerState.CheckAmountActiveEffects("Other:Speed");
                    player.PlayerState.CurrentSpeed -= 2 * player1.PlayerState.CheckAmountActiveEffects("Other:Slow");
                }
            }
        }
        /// <summary>
        /// Removes all expired/collected effects from field items
        /// </summary>
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
        /// <summary>
        /// Removed the specific effect from all players
        /// </summary>
        /// <param name="name">The effect name to remove</param>
        public void RemoveEffect(String name) {
            foreach(Player player in Players) {
                player.PlayerState.RemoveEffect(name);
            }
        }

        /// <summary>
        /// Changes the direction of the player
        /// </summary>
        /// <param name="p">The player that wants to change their direction</param>
        private void CheckPlayerChangeDirection(Player p) {
            if(p.PlayerState.CurrentTurnRadius == PlayerState.PLAYER_TURN_RADIUS && Environment.TickCount - p.PlayerState.LastMoveTick <= PlayerState.PLAYER_TURN_SPEED_NORMAL) return;
            if(p.PlayerState.CurrentTurnRadius != PlayerState.PLAYER_TURN_RADIUS && Environment.TickCount - p.PlayerState.LastMoveTick <= PlayerState.PLAYER_TURN_SPEED_SQUARE) return;
            if (p.PlayerState.NoControl) return;

            int turnRadius = p.PlayerState.CurrentTurnRadius;
            if(p.PlayerState.ReverseControl) turnRadius *= -1;
            if(_keyMessageFilter.IsKeyPressed((p.StearLeft + "").ToUpper())) p.PlayerState.Direction -= turnRadius;
            if(_keyMessageFilter.IsKeyPressed((p.StearRight + "").ToUpper())) p.PlayerState.Direction += turnRadius;
            p.PlayerState.LastMoveTick = Environment.TickCount;
        }

        /// <summary>
        /// Checks if the player hits an field item
        /// </summary>
        /// <param name="player">The player to check</param>
        private void CheckPlayerHitItem(Player player) {
            foreach(Item fieldItem in FieldItems) {
                if(player.PlayerState.CurrentHitpoint.Hit(fieldItem)) {
                    player.PlayerState.ActiveEffects.Add(fieldItem.Activate());
                    fieldItem.Collected = true;
                    Debug.WriteLine(player.Name + " collected item: " + fieldItem.Effect);
                }
            }
        }
        /// <summary>
        /// Checks if the next move of the player collides with another player
        /// </summary>
        /// <param name="player">The player to check</param>
        /// <param name="nextMove">The next move of this player</param>
        /// <returns>true, if the player will collide with another player, else false</returns>
        private bool CheckPlayerHitPlayer(Player player, HitPoint nextMove) {
            bool hit = false;
            foreach (Player colCheckPlayer in Players) {
                PlayerState colPlayerState = colCheckPlayer.PlayerState;
                foreach (HitPoint colCheckHitpoint in colPlayerState.HitBox) {
                    if(nextMove.Hit(colCheckHitpoint)) {
                        if(colCheckPlayer != player || (colCheckPlayer == player && Environment.TickCount - colCheckHitpoint.Created > TICK_SELF_IMMUNITY)) {
                            hit = true;
                            break;
                        }
                    }
                }
                if (hit) {
                    Debug.WriteLine(player.Name + " died! (PlayerHit " + colCheckPlayer.Name + " @ Positions: " + player.PlayerState.CurrentHitpoint + "  ///  " + colCheckPlayer.PlayerState.CurrentHitpoint + ")");
                    player.PlayerState.Died = true;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the player will hit a wall in the next move
        /// </summary>
        /// <param name="player">The player to check</param>
        /// <param name="nextMove">The next move of the player</param>
        /// <returns>true, if the player hits a wall in the next move, else false</returns>
        private bool CheckPlayerHitWall(Player player, HitPoint nextMove) {
            if(nextMove.HitWall(MainPanel.GameScoreboardX, MainPanel.GameHeight)) {
                player.PlayerState.Died = true;
                Debug.WriteLine(player.Name +" died! (WallHit @ "+nextMove+")");
                return true;
            }
            return false;
        }

        public List<StartPosition> CreateStartPositions(List<Player> player) {
            int guiWidth = MainPanel.GameScoreboardX;
            int guiHeight = MainPanel.GameHeight;
            List<StartPosition> starts = new List<StartPosition>();

            for(int i = 0; i < player.Count; i++) {
                Player curPlayer = player[i];
                switch(_gameOptions.PlayerStartPosition) {
                    case GameOptions.PlayerStartPositions.Circle:
                        //TODO: Calculate coords based on player count (e.g. 3 player: every 360/3 = 120 degree one player // 4 player: every 360/4 = 90 degree one player)
                        double angleBetweenPlayers = 360d / player.Count;
                        break;

                    case GameOptions.PlayerStartPositions.Line:
                        float xDistanceBetweenPlayers = (guiWidth - 40) / (float)player.Count;
                        int randomY = new Random().Next(20, guiHeight - 20);
                        starts.Add(new StartPosition(new HitPoint(20 + i * xDistanceBetweenPlayers, randomY, curPlayer), new Random().Next(360)));
                        break;

                    case GameOptions.PlayerStartPositions.Random:
                        HitPoint newHitPoint = null;
                        while(newHitPoint == null) {
                            newHitPoint = HitPoint.CreateRandomHitPoint(20, 20, guiWidth - 20, guiHeight - 20, curPlayer);
                            Debug.WriteLine("Trying to create new random start position for player: \"" + curPlayer + "\"");
                            for(int j = 0; j < i; j++) {
                                StartPosition sp = starts[j];
                                double distance = newHitPoint.Distance(sp.StartPos);
                                if(distance < 20) {
                                    newHitPoint = null;
                                    Debug.WriteLine("Failed to create new random start position for player: \"" + curPlayer + "\"!");
                                    Debug.WriteLine("Distance (" + distance + ") to \"" + sp + "\"");
                                    break;
                                }
                            }
                        }
                        starts.Add(new StartPosition(newHitPoint, Random.Next(360)));
                        Debug.WriteLine("Finalized player " + curPlayer);
                        Debug.WriteLine("");
                        break;
                }
            }
            return starts;
        }

        /// <summary>
        /// Requests the end the game and sets the GameState to end
        /// </summary>
        public void Exit() {
            GameState = GameStates.End;
        }
    }
}