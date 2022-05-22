namespace Robot_Navigation_2022
{
    internal class Robot
    {
        private int N;
        private int M;

        private Point2D current;
        private List<Point2D> goals;
        private HashSet<string> wall;
        public List<Node<Point2D>> ActionSeq { get; private set; } = new List<Node<Point2D>>();

        public Point2D Current { get { return current; } set { current = value; } }

        // Constructor acts like the sensor
        public Robot(int n, int m, List<Point2D> g, Point2D initial, HashSet<string> walls)
        {
            N = n;
            M = m;
            current = initial;
            goals = g;
            wall = walls;
        }

        // Formulates the goal by generating a random number.
        public Point2D FormulateGoal(List<Point2D> goals)
        {
            Random rand = new Random();
            int goalInt = rand.Next(0, goals.Count);

            return goals[goalInt];
        }

        // Formulating the problem.
        public Problem FormulateProblem(Point2D state, Point2D goal)
        {
            return new Problem(N, M, state, goal, wall);
        }

        //Calls the search call to search the problem.
        public List<Node<Point2D>> SearchProblem(Problem p, int i)
        {
            Search s = new Search();
            List<Node<Point2D>> result = new List<Node<Point2D>>();
            switch (i)
            {
                case 0:
                    result = s.DFS(p);
                    break;
                case 1:
                    result = s.BFS(p);
                    break;
                case 2:
                    result = s.UniformCost(p);
                    break;
                case 3:
                    result = s.BFS(p);
                    break;
                case 4:
                    result = s.GBFS(p);
                    break;
                case 5:
                    result = s.AStar(p);
                    break;
            }

            return result;
        }
        public void ProblemSolvingAgent(int algo)
        {
            Point2D goal = null;     // Initially set to null.
            Problem problem = null;  // Initially set to null.

            if (ActionSeq.Count == 0)  // If 0 then only do.
            {
                goal = FormulateGoal(goals);    // Formulating goal.
                problem = FormulateProblem(current, goal);   //Formulating problem.
                ActionSeq = SearchProblem(problem, algo); // return action sequence.
            }


            Actuators(ActionSeq); // Feed action sequence to actuators.
        }


        public void Actuators(List<Node<Point2D>> actions)
        {
            // Checking if solution exists.
            if (actions == null || actions.Count == 0)
            {
                Console.WriteLine("Path: No Solution Found");
            }
            else
            {
                Console.WriteLine("Solution Found!");
                Console.WriteLine("Number of Nodes: " + actions.Count);
                Console.WriteLine("Path : ");
                actions.Reverse();    // Reverse the list because the order was the last node first.
                for (int i = 0; i < actions.Count - 1; i++)
                {
                    Current = actions[i].Data;
                    Console.Write(" -> " + Current.ToString());
                }
                Current = actions[actions.Count - 1].Data;
                Console.WriteLine(" -> Goal Reached: " + Current.ToString());
                ActionSeq.Clear();
            }
        }
    }
}
