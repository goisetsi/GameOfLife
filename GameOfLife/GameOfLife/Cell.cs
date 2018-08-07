namespace GameOfLife
{
    public abstract class Cell
    {
        public Cell(int neighorCount)
        {
            this.NeighorCount = neighorCount;
        }

        public int NeighorCount { get; set; }

    }
}