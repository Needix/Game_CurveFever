// Player.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Game_CurveFever.ProjectSRC.Model.Game {
    public class Player {
        public Color[] PlayerColors = { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Cyan, Color.DarkMagenta, Color.Lime, Color.Orange };

        public String Name { get; private set; }
        public char StearRight { get; private set; }
        public char StearLeft { get; private set; }

        public int ID { get; private set; }
        public Color Color { get; private set; }

        public PlayerState PlayerState { get; private set; }

        public Player(String name, char stearLeft, char stearRight) {
            Name = name;
            StearRight = stearRight;
            StearLeft = stearLeft;

            PlayerState = new PlayerState(this);
        }

        public void Finalize(int id, HitPoint startPos, int startDirection) {
            ID = id;
            Color = PlayerColors[id];
            PlayerState.SetStart(startPos, startDirection);
        }

        public override string ToString() {
            return string.Format("Name: {0}, StearRight: {1}, StearLeft: {2}, ID: {3}, Color: {4}, PlayerState: {5}", Name, StearRight, StearLeft, ID, Color, PlayerState);
        }
    }
}