using CounterTask2;
using NUnit.Framework;

namespace CounterTask2
{
    public class TestClock
    {
        Clock _clock;
        [SetUp]
        public void Setup()
        {
            _clock = new Clock();
        }

        [Test]
        public void TestClockTimeFormat()
        {
            Assert.That(_clock.Time(), Is.EqualTo("00:00:00"));
        }

        [TestCase(0, "00:00:00")]
        [TestCase(3700, "01:01:40")]
        [TestCase(86465, "00:01:05")]
        public void TestClockTick(int ticks, string expectedResult)
        {
            for (int i = 0; i < ticks; i++)
            {
                _clock.Tick();
            }
            Assert.That(_clock.Time(), Is.EqualTo(expectedResult), "Clock didn't tick correctly");
        }

        [Test]
        public void TestClockReset()
        {
            for (int i = 0; i < 3650; i++)
            {
                _clock.Tick();
            }
            _clock.Reset();
            Assert.That(_clock.Time(), Is.EqualTo("00:00:00"), "Clock reset didn't reset to 0");
        }
    }
}