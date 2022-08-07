namespace BattleShipStateTrackerTest;
using BattleShipStateTracker;

[TestClass]
public class UnitTests
{
  
    [TestMethod]
    public void TestAddShip()
    {
        BattleShipStateTracker tracker = new();
        Boolean addValidShip = tracker.AddShip(1, 3, 9, 3);
        Assert.IsTrue(addValidShip);

        Boolean addInvalidShip = tracker.AddShip(-10, -10, 20, 20);
        Assert.IsFalse(addInvalidShip);

        Boolean addOverlapShip = tracker.AddShip(2, 3, 2, 5);
        Assert.IsFalse(addOverlapShip);

        Boolean addAdjacentShip = tracker.AddShip(1, 4, 1, 9);
        Assert.IsFalse(addOverlapShip);

    }

    [TestMethod]
    public void TestTakeHit()
    {
        BattleShipStateTracker tracker = new();
        tracker.AddShip(1, 3, 4, 3);

        Assert.AreEqual("Miss", tracker.TakeHit(-1, -1));
        Assert.AreEqual("Miss", tracker.TakeHit(11, 11));
        Assert.AreEqual("Miss", tracker.TakeHit(0, 3));

        Assert.AreEqual("Hit", tracker.TakeHit(1, 3));
        Assert.AreEqual("Hit", tracker.TakeHit(2, 3));
        Assert.AreEqual("Hit", tracker.TakeHit(3, 3));
        Assert.AreEqual("Hit", tracker.TakeHit(4, 3));
    }

    [TestMethod]
    public void TestIsLost()
    {
        BattleShipStateTracker tracker = new();
        tracker.AddShip(1, 3, 4, 3);

        Assert.IsFalse(tracker.IsLost());
        tracker.TakeHit(1, 3);
        tracker.TakeHit(4, 3);

        Assert.IsFalse(tracker.IsLost());
        tracker.TakeHit(3, 3);
        tracker.TakeHit(2, 3);
        Assert.IsTrue(tracker.IsLost());
    }
}
