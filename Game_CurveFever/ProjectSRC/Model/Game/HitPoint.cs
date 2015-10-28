// HitPoint.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Configuration;
using Game_CurveFever.ProjectSRC.Controller.Game;
using Game_CurveFever.ProjectSRC.Model.Game.Items;

namespace Game_CurveFever.ProjectSRC.Model.Game {
    public class HitPoint {
        public const int DEFAULT_SIZE = 5;

        public float X { get; set; }
        public float Y { get; set; }
        public Color Color { get; set; }
        public int Size { get; set; }
        public Player Owner { get; set; }
        public int Created { get; set; }

        public HitPoint(float x, float y, Player owner) : this(x, y, DEFAULT_SIZE, owner) { }
        public HitPoint(float x, float y, int size, Player owner) : this(x, y, size, owner, owner.Color) { }
        public HitPoint(float x, float y, int size, Player owner, Color color) {
            X = x;
            Y = y;
            Size = size;
            Owner = owner;
            Color = color;
            Created = Environment.TickCount;
        }

        public double Distance(HitPoint other) {
            return Math.Sqrt(Math.Pow(X - other.X,2) + Math.Pow(Y - other.Y,2));
        }

        public bool HitWall(int guiWidth, int guiHeight) {
            return X - Size <= 0 || X + Size >= guiWidth || Y - Size <= 0 || Y + Size >= guiHeight;
        }

        public bool Hit(Item e) {
            float minX2 = e.X;
            float minY2 = e.Y;
            float maxX2 = e.X + Item.IMAGE_HITBOX_SIZE;
            float maxY2 = e.Y + Item.IMAGE_HITBOX_SIZE;

            return Hit(minX2, minY2, maxX2, maxY2);
        }
        public bool Hit(HitPoint other) {
            float minX2 = other.X - other.Size / 2f;
            float minY2 = other.Y - other.Size / 2f;
            float maxX2 = other.X + other.Size / 2f;
            float maxY2 = other.Y + other.Size / 2f;

            return Hit(minX2, minY2, maxX2, maxY2);
        }
        public bool Hit(float minX2, float minY2, float maxX2, float maxY2) {
            float minX1 = X - Size / 2f;
            float minY1 = Y - Size / 2f;
            float maxX1 = X + Size / 2f;
            float maxY1 = Y + Size / 2f;

            bool xHit = true;
            bool yHit = true;

            if ((minX1 < minX2 && maxX1 < minX2) || (minX1 > maxX2 && maxX1 > maxX2)) {
                xHit = false;
            }
            if((minY1 < minY2 && maxY1 < minY2) || (minY1 > maxY2 && maxY1 > maxY2)) {
                yHit = false;
            }

            return xHit && yHit;
        }

        public static HitPoint CreateRandomHitPoint(int minX, int minY, int maxX, int maxY, Player owner) {
            return CreateRandomHitPoint(minX, minY, maxX, maxY, DEFAULT_SIZE, owner);
        }
        public static HitPoint CreateRandomHitPoint(int minX, int minY, int maxX, int maxY, int size, Player owner) {
            int x = MainLoop.Random.Next(minX, maxX);
            int y = MainLoop.Random.Next(minY, maxY);
            return new HitPoint(x, y, size, owner);
        }

        public override string ToString() {
            return string.Format("{0}/{1}", Math.Round(X), Math.Round(Y));
        }
    }
}