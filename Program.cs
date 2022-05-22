using Robot_Navigation_2022;

Console.WriteLine("Please type in the filepath: ");
string filepath = Console.ReadLine();
Map Map = new Map(filepath);

Map.CleanInputs();
Map.GetInput();


Robot r = new Robot(Map.M, Map.N, Map.Goals, Map.start, Map.Walls);

Console.WriteLine("What algorithm do you want to use: ");

string read = Console.ReadLine();

if (read == "DFS")
{
    r.ProblemSolvingAgent(0);
}

if (read == "BFS")
{
    r.ProblemSolvingAgent(1);
}

if (read == "UNIFORM")
{
    r.ProblemSolvingAgent(2);
}

if (read == "BEST")
{
    r.ProblemSolvingAgent(3);
}

if (read == "GBFS")
{
    r.ProblemSolvingAgent(4);
}

if (read == "ASTAR")
{
    r.ProblemSolvingAgent(5);
}













