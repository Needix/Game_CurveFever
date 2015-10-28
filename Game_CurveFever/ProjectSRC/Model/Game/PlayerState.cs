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

        public Player Owner { get; private set; }
        public HitPoint Position { get; private set; }
        public int Direction { get; set; } //0 is right, 90 is up, 180 is left, 270 is down
        public List<HitPoint> HitBox { get; private set; }
        public List<Effect> ActiveEffects { get; private set; }
        public bool Died { get; set; }
        public int LastMoveTick { get; set; }

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
            if(Position!=null) throw new InvalidOperationException("Init position was already set!");
            Position = startPosition;
            Direction = startDirection;
        }

        public HitPoint CalculateNextMove(Player player) {
            double radianDirection = Math.PI*Direction/180; //Degree to Radian
            float nextXDouble = (float)(Position.X + Math.Cos(radianDirection)); 
            float nextYDouble = (float)(Position.Y + Math.Sin(radianDirection));
            return new HitPoint(nextXDouble, nextYDouble, CurrentSize, player);
        }

        public void AddHitPoint(int x, int y, int size) {
            AddHitPoint(x, y, size, Owner.Color);
        }
        public void AddHitPoint(int x, int y, int size, Color color) {
            AddHitPoint(new HitPoint(x, y, size, Owner, color));
        }
        public void AddHitPoint(HitPoint p) {
            Position = p;
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
                    Debug.WriteLine("Force-Remove item from player (" + this.Owner.Name + "): " + effect.Name);
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
                    Debug.WriteLine("Removing expired item from player ("+this.Owner.Name+"): "+effect.Name);
                    continue;
                }
                newList.Add(effect);
            }
            ActiveEffects = newList;
        }

        public override string ToString() {
            return string.Format("Position: {0}, Direction: {1}", Position, Direction);
        }
    }
}