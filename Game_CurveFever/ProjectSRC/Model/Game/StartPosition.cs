namespace Game_CurveFever.ProjectSRC.Model.Game {
    public class StartPosition {
        public HitPoint StartPos { get; private set; }
        public int StartDirection { get; private set; }

        public StartPosition(HitPoint startPos, int startDirection) {
            StartPos = startPos;
            StartDirection = startDirection;
        }

        public override string ToString() {
            return string.Format("StartPos: {0}, StartDirection: {1}", StartPos, StartDirection);
        }
    }
}