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

        public Position Pos { get; private set; }
        public Color Color { get; set; }
        public int Size { get; set; }
        public Player Owner { get; set; }
        public int Created { get; set; }

        public HitPoint(float x, float y, Player owner) : this(x, y, owner, DEFAULT_SIZE) { }
        public HitPoint(float x, float y, Player owner, int size) {
            if(owner==null) throw new ArgumentException("HitPoint was created without owner!");
            Pos = new Position(x, y);
            Size = size;
            Owner = owner;
            Color = Owner.Color;
            Created = Environment.TickCount;
        }

        public Position CalcRelativePoint(int direction, int speed) {
            double radianDirection = Math.PI * direction / 180; //Degree to Radian
            float nextXDouble = (float)(Pos.X + Math.Cos(radianDirection)*speed);
            float nextYDouble = (float)(Pos.Y + Math.Sin(radianDirection)*speed);
            return new Position(nextXDouble, nextYDouble);
        }

        public double Distance(HitPoint other) {
            return Math.Sqrt(Math.Pow(Pos.X - other.Pos.X,2) + Math.Pow(Pos.Y - other.Pos.Y,2));
        }

        public bool HitWall(int guiWidth, int guiHeight) {
            return Pos.X - Size <= 0 || Pos.X + Size >= guiWidth || Pos.Y - Size <= 0 || Pos.Y + Size >= guiHeight;
        }

        public bool Hit(Item e) {
            float minX2 = e.X;
            float minY2 = e.Y;
            float maxX2 = e.X + Item.IMAGE_HITBOX_SIZE;
            float maxY2 = e.Y + Item.IMAGE_HITBOX_SIZE;

            return Hit(minX2, minY2, maxX2, maxY2);
        }
        public bool Hit(HitPoint other) {
            float minX2 = other.Pos.X - other.Size / 2f;
            float minY2 = other.Pos.Y - other.Size / 2f;
            float maxX2 = other.Pos.X + other.Size / 2f;
            float maxY2 = other.Pos.Y + other.Size / 2f;

            return Hit(minX2, minY2, maxX2, maxY2);
        }
        public bool Hit(float minX2, float minY2, float maxX2, float maxY2) {
            float minX1 = Pos.X - Size / 2f;
            float minY1 = Pos.Y - Size / 2f;
            float maxX1 = Pos.X + Size / 2f;
            float maxY1 = Pos.Y + Size / 2f;

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
            return new HitPoint(x, y, owner, size);
        }

        public override string ToString() {
            return string.Format("{0}/{1}", Math.Round(Pos.X), Math.Round(Pos.Y));
        }
    }
}