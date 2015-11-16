// PlayerState.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Game_CurveFever.ProjectSRC.Model.Game.Items;

namespace Game_CurveFever.ProjectSRC.Model.Game {
    public class PlayerState {
        public const int PLAYER_TURN_SPEED_NORMAL = 40; //Every X milliseconds player can change direction // Higher = bigger turn radius // TODO: Calculate turn speed base on player speed
        public const int PLAYER_TURN_SPEED_SQUARE = 150; //Every X mulliseconds player can change direction // Used if player is under effect of SQUARE effect
        public const int PLAYER_TURN_RADIUS = 10; //Turn Radius per turn //Lower = bigger turn radius //In degrees
        public const int PLAYER_DEFAULT_SPEED = 1;
        public const int MAX_HOLE_SIZE_IN_TICKS = 500;
        public const int MIN_HOLE_SIZE_IN_TICKS = 330;
        public const double PROBABILITY_DRAW_HOLES_START = 0.0105; //Probability to start a hole each tick

        public Player Owner { get; private set; }
        public HitPoint CurrentHitpoint { get; private set; }
        public int Direction { get; set; } //0 is right, 90 is up, 180 is left, 270 is down
        public List<HitPoint> HitBox { get; private set; }
        public List<Effect> ActiveEffects { get; private set; }
        public bool Died { get; set; }
        public int LastMoveTick { get; set; }

        public int DrawHoleStartTick { get; set; }
        public int DrawHoleStopTick { get; set; }
        public int CurrentSpeed { get; set; }
        public int CurrentSize { get; set; }
        public int CurrentTurnRadius { get; set; }
        public bool NoControl { get; set; }
        public bool ReverseControl { get; set; }

        public PlayerState(Player owner) {
            Owner = owner;
            HitBox = new List<HitPoint>();
            ActiveEffects = new List<Effect>();
        }

        public void SetStart(HitPoint startPosition, int startDirection) {
            if(CurrentHitpoint!=null) throw new InvalidOperationException("Initial position was already set!");
            CurrentHitpoint = startPosition;
            Direction = startDirection;
        }

        public HitPoint CalculateNextMove(Player player) {
            Position p = player.PlayerState.CurrentHitpoint.CalcRelativePoint(Direction, CurrentSpeed);
            return new HitPoint(p.X, p.Y, Owner, CurrentSize);
        }

        public void AddHitPoint(int x, int y, int size) {
            AddHitPoint(new HitPoint(x, y, Owner, size));
        }
        public void AddHitPoint(HitPoint p) {
            CurrentHitpoint = p;
            HitBox.Add(p);
        }

        public int CheckAmountActiveEffects(string name) {
            int active = 0;
            foreach (Effect effect in ActiveEffects) {
                if (effect.Name.Equals(name)) active++;
            }
            return active;
        }

        public void RemoveEffect(String name) {
            List<Effect> newEffectList = new List<Effect>();
            foreach(Effect effect in ActiveEffects) {
                if(effect.Name.Equals(name)) {
                    Debug.WriteLine("Force-Remove item from player (" + Owner.Name + "): " + effect.Name);
                    continue;
                }
                newEffectList.Add(effect);
            }
            ActiveEffects = newEffectList;
        }
        public void RemoveExpiredEffects() {
            List<Effect> newList = new List<Effect>();
            foreach(Effect effect in ActiveEffects) {
                if(effect.CheckExpired()) {
                    Debug.WriteLine("Removing expired item from player ("+Owner.Name+"): "+effect.Name);
                    continue;
                }
                newList.Add(effect);
            }
            ActiveEffects = newList;
        }

        public override string ToString() {
            return string.Format("CurrentHitpoint: {0}, Direction: {1}", CurrentHitpoint, Direction);
        }
    }
}