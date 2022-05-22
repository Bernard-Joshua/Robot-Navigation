namespace Robot_Navigation_2022
{
    internal class Point2D
    {
        public int X { get; set; }          // Gets and Sets the X coordinate of the state.
        public int Y { get; set; }          // Gets and Sets the Y coordinate of the state.

        //Override function to get the value of the state.
        public override string ToString()
        {
            return $"{X}:{Y}";
        }

    }
}
