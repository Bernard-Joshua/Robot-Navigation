using System.Text.RegularExpressions;

namespace Robot_Navigation_2022
{
    internal class Map
    {
        // Private variables
        private string readtext;
        private string filepath;
        private List<string> receiving = new List<string>();

        // Public Variables
        public int N;
        public int M;

        public Point2D start = new Point2D();
        public HashSet<string> Walls { get; set; } = new HashSet<string>();
        public List<Point2D> Goals { get; set; } = new List<Point2D>();


        // Retrieves the file path from the user.
        public Map(string file)
        {
            filepath = file;
        }

        // Cleans all the non digits and non commas.
        public void CleanInputs()
        {
            if (File.Exists(filepath))
            {
                readtext = File.ReadAllText(filepath);
                readtext = Regex.Replace(readtext, "([[\\]\\(\\)])", "");
                readtext = readtext.Replace(" | ", ",");
                File.WriteAllText(filepath, readtext);
                Console.WriteLine("File Has been Cleaned");
            }
            else
            {
                Console.WriteLine("File Path Could Not Be Found");
            }

        }

        //Converts the input to ints or point2D's
        public void GetInput()
        {
            receiving = File.ReadAllLines(filepath).ToList();

            string[] grid = receiving[0].Split(','); // Split by comma's that is why the commas were not parsed earlier.

            //Getting grid inputs
            N = int.Parse(grid[0]);
            M = int.Parse(grid[1]);

            string[] starting = receiving[1].Split(',');

            //Getting initial state
            start.X = int.Parse(starting[0]);
            start.Y = int.Parse(starting[1]);


            string[] target = receiving[2].Split(',');

            //Setting up the goals
            Goals.Add(new Point2D() { X = int.Parse(target[0]), Y = int.Parse(target[1]) });
            Goals.Add(new Point2D() { X = int.Parse(target[2]), Y = int.Parse(target[3]) });



            //Setting up walls.
            for (int i = 3; i < receiving.Count; i++)
            {
                string[] end = receiving[i].Split(',');

                int x = int.Parse(end[0]); // 2
                int y = int.Parse(end[1]); // 0
                int w = int.Parse(end[2]); // 2
                int h = int.Parse(end[3]); // 2

                Point2D wallOrigin = new Point2D() { X = x, Y = y };

                // Walls are added to a hashset to prevent duplicates
                Walls.Add(wallOrigin.ToString());

                // Transforming the width and height of the walls into coordinates.
                for (int nW = 1; nW < w; nW++)
                {
                    Point2D nextWall = new Point2D() { X = x + 1, Y = y };
                    Walls.Add(nextWall.ToString());
                }

                for (int nH = 1; nH < h; nH++)
                {
                    Point2D nextWall = new Point2D() { X = x, Y = y + 1 };
                    Walls.Add(nextWall.ToString());
                }



            }
            // Just incase the goals are inputed as walls.
            for (int i = 0; i < Goals.Count; i++)
            {
                if (Walls.Contains(Goals[i].ToString()) == true)
                {
                    Walls.Remove(Goals[i].ToString());
                }
            }


        }
    }
}

