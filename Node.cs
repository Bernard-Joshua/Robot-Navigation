namespace Robot_Navigation_2022
{
    internal class Node<T>
    {
        public T Data { get; set; }                 // Point 2D as the data.
        public Node<T> Parent { get; set; }         // References the parent node.
        public int PathCost { get; set; }           // Gets and Sets the path-cost/step-cost.
        public double Heuristic { get; set; }       // Gets and Sets the heuristic functions values.

        // Override function to print the value of the 
        //node.
        public override string ToString()
        {
            return Data?.ToString();
        }



    }
}
