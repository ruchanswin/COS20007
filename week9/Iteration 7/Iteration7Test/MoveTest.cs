using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration7
{
    public class MoveTest
    {
        Move? _moveCommand;
        Player? _testPlayer;
        Location? _testRoomA;
        Location? _testRoomB;
        Path? _testPath;

        [Test]
        public void TestPlayerCanMove()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("ruchan", "student");

            _testRoomA = new Location(["bedroom"], "bedroom", "Room for decoration");
            _testRoomB = new Location(["bathroom"], "bathroom", "Room for illustration");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(["north"], "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            _moveCommand.Execute(_testPlayer, ["move", "north"]);

            string _expected = _testRoomB.Name;
            string _actual = _testPlayer.Location.Name;
            Assert.That(_actual, Is.EqualTo(_expected), "Testing that player can move");
        }

        [Test]
        public void TestMoveDescription()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("ruchan", "student");

            _testRoomA = new Location(["bedroom"], "bedroom", "Room for decoration");
            _testRoomB = new Location(["bathroom"], "bathroom", "Room for illustration");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(["north"], "door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            string _expected = "You have moved north through a door from bedroom to bathroom, Room for illustration.\nItems available:\n\nThere are no exits.";
            string _actual = _moveCommand.Execute(_testPlayer, ["move", "north"]);
            Assert.That(_actual, Is.EqualTo(_expected), "Testing that move description is correct");
        }

        [Test]
        public void TestInvalidMoveNoDirection()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("ruchan", "student");

            _testRoomA = new Location(["bedroom"], "bedroom", "Room for decoration");
            _testRoomB = new Location(["bathroom"], "bathroom", "Room for illustration");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(["north"], "Door", "A test door", _testRoomA, _testRoomB);

            string _expected = "Where do you want to go?";
            string _actual = _moveCommand.Execute(_testPlayer, ["move"]); ;
            Assert.That(_actual, Is.EqualTo(_expected), "Testing invalid move: no path specified");
        }

        [Test]
        public void TestInvalidMoveNoPath()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("ruchan", "student");

            _testRoomA = new Location(["bedroom"], "bedroom", "Room for decoration");
            _testRoomB = new Location(["bathroom"], "bathroom", "Room for illustration");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(["north"], "Door", "A test door", _testRoomA, _testRoomB);

            string _expected = "The exit is not available.";
            string _actual = _moveCommand.Execute(_testPlayer, ["move", "east"]); ;
            Assert.That(_actual, Is.EqualTo(_expected), "Testing invalid move: non-existent path");
        }

        [Test]
        public void TestInvalidMoveNoLocation()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("ruchan", "student");

            _testRoomA = new Location(["bedroom"], "bedroom", "Room for decoration");
            _testPlayer.Location = _testRoomA;

            string _expected = "The exit is not available.";
            string _actual = _moveCommand.Execute(_testPlayer, ["move", "east"]); ;
            Assert.That(_actual, Is.EqualTo(_expected), "Testing invalid move: no destination location specified");
        }
    }
}