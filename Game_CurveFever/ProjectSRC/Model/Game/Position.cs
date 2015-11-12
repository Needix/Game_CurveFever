namespace Game_CurveFever.ProjectSRC.Model.Game {
    public class Position {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Position(float x, float y) {
            X = x;
            Y = y;
        }
    }
}