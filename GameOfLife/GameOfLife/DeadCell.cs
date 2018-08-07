namespace GameOfLife
{
    public class DeadCell : Cell, ICellMortality
    {
        public DeadCell(int neighorCount)
            : base(neighorCount)
        {
        }

        public bool WillThisCellSurvive()
        {
            return this.NeighorCount != 3;
        }
    }
}