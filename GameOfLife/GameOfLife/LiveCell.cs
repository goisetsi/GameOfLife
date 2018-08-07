namespace GameOfLife
{
    public class LiveCell : Cell, ICellMortality
    {
        public LiveCell(int neighorCount)
            : base(neighorCount)
        {
        }

        public bool WillThisCellSurvive()
        {
            return this.NeighorCount != 2 && this.NeighorCount != 3;
        }
    }
}