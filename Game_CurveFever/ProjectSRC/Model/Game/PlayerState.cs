// PlayerState.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Drawing;
using Game_CurveFever.ProjectSRC.Model.Game.Items;

namespace Game_CurveFever.ProjectSRC.Model.Game {
    public class PlayerState {
        public const int PLAYER_CHANGE_DIRECTION_SPEED = 40; //Every X milliseconds player can change direction // Higher = bigger turn radius // TODO: Calculate turn speed base on player speed

        public Player Owner { get; private set; }
        public HitPoint Position { get; private set; }
        public int Direction { get; set; } //0 is right, 90 is up, 180 is left, 270 is down
        public List<HitPoint> HitBox { get; private set; }
        public List<Effect> Effects { get; private set; }
        public bool Died { get; set; }
        public int LastMoveTick { get; set; }

        public PlayerState(Player owner) {
            Owner = owner;
            HitBox = new List<HitPoint>();
            Effects = new List<Effect>();
        }

        public void SetStart(HitPoint startPosition, int startDirection) {
            if(Position!=null) throw new InvalidOperationException("Start position was already set!");
            Position = startPosition;
            Direction = startDirection;
        }

        public HitPoint CalculateNextMove(Player player, int size) {
            double radianDirection = Math.PI*Direction/180; //Degree to Radian
            float nextXDouble = (float)(Position.X + Math.Cos(radianDirection)); 
            float nextYDouble = (float)(Position.Y + Math.Sin(radianDirection));
            return new HitPoint(nextXDouble, nextYDouble, size, player);
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

        public void RemoveExpiredEffects() {
            List<Effect> newList = new List<Effect>();
            foreach(Effect effect in Effects) {
                if(!effect.CheckExpired()) newList.Add(effect);
            }
            Effects = newList;
        }

        public override string ToString() {
            return string.Format("Position: {0}, Direction: {1}", Position, Direction);
        }
    }
}