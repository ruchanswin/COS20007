using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration7
{
    public class PathTest
    {
        Player? _testPlayer;
        Location? _testRoomA;
        Location? _testRoomB;
        Path? _testPath;

        [Test]
        public void TestLocatePathDestination()
        {
            _testPlayer = new Player("ruchan", "student");

            _testRoomA = new Location(["bedroom"], "bedroom", "Room for decoration");
            _testRoomB = new Location(["bathroom"], "bathroom", "Room for illustration");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(["north"], "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            Location _expected = _testRoomB;
            Location _actual = _testPath.Destination;

            Assert.That(_actual, Is.EqualTo(_expected));
        }

        [Test]
        public void TestLocatePathName()
        {
            _testPlayer = new Player("ruchan", "student");

            _testRoomA = new Location(["bedroom"], "bedroom", "Room for decoration");
            _testRoomB = new Location(["bathroom"], "bathroom", "Room for illustration");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(["north"], "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            string _expected = "A test door";
            string _actual = _testPath.FullDescription;

            Assert.That(_actual, Is.EqualTo(_expected));
        }

        [Test]
        public void TestLocatePath()
        {
            _testPlayer = new Player("ruchan", "student");

            _testRoomA = new Location(["bedroom"], "bedroom", "Room for decoration");
            _testRoomB = new Location(["bathroom"], "bathroom", "Room for illustration");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(["north"], "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            GameObject _expected = _testRoomA.Locate("north");
            GameObject _actual = _testPath;

            Assert.That(_actual, Is.EqualTo(_expected));
        }
    }
}