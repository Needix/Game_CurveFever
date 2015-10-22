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

namespace Game_CurveFever.ProjectSRC.Model.Game {
    public class HitPoint {
        public const int DEFAULT_SIZE = 3;

        public float X { get; set; }
        public float Y { get; set; }
        public Color Color { get; set; }
        public int Size { get; set; }
        public Player Owner { get; set; }

        public HitPoint(float x, float y, Player owner) : this(x, y, DEFAULT_SIZE, owner) { }
        public HitPoint(float x, float y, int size, Player owner) : this(x, y, size, owner, owner.Color) { }
        public HitPoint(float x, float y, int size, Player owner, Color color) {
            X = x;
            Y = y;
            Size = size;
            Owner = owner;
            Color = color;
        }

        public double Distance(HitPoint other) {
            return Math.Sqrt(Math.Pow(X - other.X,2) + Math.Pow(Y - other.Y,2));
        }

        public Boolean HitWall(int guiWidth, int guiHeight) {
            return X - Size <= 0 || X + Size >= guiWidth || Y - Size <= 0 || Y + Size >= guiHeight;
        }

        public Boolean Hit(HitPoint other) {
            float minX1 = X - Size;
            float minY1 = Y - Size;
            float maxX1 = X + Size;
            float maxY1 = Y + Size;

            float minX2 = other.X - other.Size;
            float minY2 = other.Y - other.Size;
            float maxX2 = other.X + other.Size;
            float maxY2 = other.Y + other.Size;

            bool xHit = false;
            bool yHit = false;

            if ( (minX2 > minX1 && minX2 < maxX1) ||
                 (maxX2 > minX1 && maxX2 < maxX1)) {
                xHit = true;
            }
            if(  (minY2 > minY1 && minY2 < maxY1) ||
                 (maxY2 > minY1 && maxY2 < maxY1)) {
                yHit = true;
            }

            return xHit && yHit;
        }

        public static HitPoint CreateRandomHitPoint(int minX, int minY, int maxX, int maxY, Player owner) {
            return CreateRandomHitPoint(minX, minY, maxX, maxY, DEFAULT_SIZE, owner);
        }
        public static HitPoint CreateRandomHitPoint(int minX, int minY, int maxX, int maxY, int size, Player owner) {
            int x = new Random().Next(minX, maxX);
            int y = new Random().Next(minY, maxY);
            return new HitPoint(x, y, size, owner);
        }

        public override string ToString() {
            return string.Format("{0}/{1}", X, Y);
        }
    }
}