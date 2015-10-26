// Effect.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;

namespace Game_CurveFever.ProjectSRC.Model.Game.Items {
    public class Effect {
        public enum EffectedPlayer {
            Global = 0,
            Self = 1,
            Other = 2
        }

        public String Name { get; private set; }
        public EffectedPlayer EffectedPlayers { get; private set; }
        public int Power { get; private set; }

        public int TickStarted { get; private set; }
        public int Duration { get; private set; }

        public Effect(int duration, int power, EffectedPlayer players, string name) : this(duration, power, -1, players, name) { }
        public Effect(int duration, int power, int tickStarted, EffectedPlayer players, string name) {
            Duration = duration;
            TickStarted = tickStarted;
            Power = power;
            EffectedPlayers = players;
            Name = name;
        }

        public Boolean CheckExpired() {
            return TickStarted + Duration > Environment.TickCount;
        }

        public Effect Copy() {
            return new Effect(Duration, Power, Environment.TickCount, EffectedPlayers, Name);
        }

        public override string ToString() {
            return string.Format("{0}: EffectedPlayers: {1}, Power: {2}, TickStarted: {3}, Duration: {4}", Name, EffectedPlayers, Power, TickStarted, Duration);
        }
    }
}