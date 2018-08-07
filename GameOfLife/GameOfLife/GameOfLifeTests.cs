namespace GameOfLife
{
    using NUnit.Framework;

    /// <summary>
    /// The test.
    /// </summary>
    /// Story
    /// As a Floor Boss
    /// I want to know whether or not a cell will live, die or be reborn
    /// So that I, can apply the action.
    [TestFixture]
    public class GameOfLifeTests
    {
        /// Scenario 1-2
        /// Title: Cell death From Underpopulation - less than 2 neighbors
        /// Given: I have a cell with less two neighbours neighbor.
        /// When: I check whether the cell will live or die.
        /// Then: I will indicate that this cell will die.
        [TestCase(0, TestName = "Cell with no neighbors dies")]
        [TestCase(1, TestName = "Cell with one neighbors dies")]
        public void UnderPopulationTest(int neighorCount)
        {
            // Given
            var cell = new LiveCell(neighorCount);

            // When
            var nextGenDeath = cell.WillThisCellSurvive();

            // Then
            Assert.IsTrue(nextGenDeath,"Cell should have died but it lived.");
        }

        // Title: Any Cell With 2 live neighbors will continue to live
        // Given: A cell with 2 live neighors
        // When: Checking the cell for whether it needs to live or die.
        // Then: The cell will continue to live.
        [TestCase(2,TestName = "Cell with 2 neighbor will live")]
        [TestCase(3,TestName = "Cell with 3 neighbor will live")]
        public void ContinueToLiveTest(int neighorCount)
        {
            // Given
            var cell = new LiveCell(neighorCount);

            // When
            var nextGenDeath = cell.WillThisCellSurvive();

            // Then
            Assert.IsFalse(nextGenDeath, "Cell should lived but it died");
        }

        // Title: Overpopulation
        // Given: A cell has more than 3 neighbors
        // When: Checking if cell will live or die
        // Then: Cell will be set to die
        [Test]
        public void OverpopulationTest([Values(4, 5, 6, 7, 8)] int neighborCount)
        {
            // Given
            var cell = new LiveCell(neighborCount);

            // When
            var nextGenDeath = cell.WillThisCellSurvive();

            // Then
            Assert.IsTrue(nextGenDeath, "Cell should have died, but lived");
        }

        // Title: A dead cell with anything other than 3 neighbors.
        // Given: A dead cell has 0,1,2,4,5,6,7,8 neighbors.
        // When: Checking if cell will live or die.
        // Then: Cell will stay dead.
        [Test]
        public void DeadCellStaysDeadTest([Values(0, 1, 2, 4, 5, 6, 7, 8)] int neighborCount)
        {
            // Given
            var cell = new DeadCell(neighborCount);

            // When
            var nextGenDeath = cell.WillThisCellSurvive();

            // Then
            Assert.IsTrue(nextGenDeath, "Cell should have died, but lived");
        }

        // Title: Cell Animation
        // Given: A dead cell has exactly 3 neighbors
        // When: Checking if cell will live or die
        // Then: Cell will be set to live.
        [Test]
        public void CellAnimationTest()
        {
            // Given
            var cell = new DeadCell(3);

            // When
            var nextGenDeath = cell.WillThisCellSurvive();

            // Then:
            Assert.IsFalse(nextGenDeath, "Cell should be set to live but is still dead");
        }
    }
}