using DiceLaunch;
namespace TestDice
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Constructor_Correct()
        {
            Player player1 = new Player(10);
            Assert.AreEqual(new int[10].Length, player1.Points.Length);
        }
        [TestMethod]
        public void Constructor_ShouldThrowError()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Player(0));
        }

    }
}