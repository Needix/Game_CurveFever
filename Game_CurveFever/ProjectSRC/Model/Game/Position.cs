using System;

namespace Game_CurveFever.ProjectSRC.Model.Game {
    public class Position {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Position(float x, float y) {
            X = x;
            Y = y;
        }

        public Position CalcRelativePoint(int direction, int speed) {
            double radianDirection = Math.PI * direction / 180; //Degree to Radian
            float nextXDouble = (float)(X + Math.Cos(radianDirection) * speed);
            float nextYDouble = (float)(Y + Math.Sin(radianDirection) * speed);
            return new Position(nextXDouble, nextYDouble);
        }
    }
}