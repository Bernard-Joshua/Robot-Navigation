namespace Robot_Navigation_2022
{

    internal class Problem
    {
        // Boundaries of the grid/map.
        private int N;
        private int M;

        // Initial and goal states
        public Point2D initial;
        public Point2D goal;

        // Reference to the walls set created in the Map class
        private HashSet<string> walls;

        // Actions available to the robot.
        public List<string> Action { get; } = new List<string> { "UP", "LEFT", "DOWN", "RIGHT" };

        // Constructor ( Problem Description ).
        public Problem(int n, int m, Point2D s, Point2D g, HashSet<string> walls)
        {
            this.N = n;
            this.M = m;
            this.walls = walls;
            this.initial = s;
            this.goal = g;
        }

        // Transition Model.
        public Point2D Result(Point2D state, string action)
        {
            Point2D next = null;

            if (action == "UP" && state.X - 1 >= 0
                            && (!walls.Contains($"{state.X - 1}:{state.Y}")))
            {
                next = new Point2D() { X = state.X - 1, Y = state.Y };
            }
            if ((action == "LEFT") && (state.Y - 1 >= 0)
                && (!walls.Contains($"{state.X}:{state.Y - 1}")))
            {
                next = new Point2D() { X = state.X, Y = state.Y - 1 };
            }
            if ((action == "DOWN") && (state.X + 1 < N)
                && (!walls.Contains($"{state.X + 1}:{state.Y}")))
            {
                next = new Point2D() { X = state.X + 1, Y = state.Y };
            }
            if ((action == "RIGHT") && (state.Y + 1 < M)
                && (!walls.Contains($"{state.X}:{state.Y + 1}")))
            {
                next = new Point2D() { X = state.X, Y = state.Y + 1 };
            }

            return next;
        }

        // Tests if the the state matches the goal.
        public bool GoalTest(Point2D state)
        {
            if (state.X == goal.X && state.Y == goal.Y)
            {
                return true;
            }
            return false;
        }

        // Function to calculate Manhattan Distance.
        public double Heuristics(Point2D s, Point2D g)
        {
            double x = Math.Abs(g.X - s.X);
            double y = Math.Abs(g.Y - s.Y);

            double eu = x + y;
            return eu;
        }

    }
}
