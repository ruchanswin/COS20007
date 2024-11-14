using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CounterTask2;

namespace CounterTask2
{
    public class TestCounter
    {
        Counter _testCounter;
        [SetUp]
        public void Setup()
        {
            _testCounter = new Counter("TEST COUNTER");
        }

        [Test]
        public void TestInitialiseCounterToZero()
        {
            Assert.That(_testCounter.Tick, Is.EqualTo(0));
        }

        [Test]
        public void TestCounterName()
        {
            Assert.That(_testCounter.Name, Is.EqualTo("TEST COUNTER"));
        }

        [TestCase(1, 1)]
        [TestCase(10, 10)]
        public void TestIncrementingCounter(int increments, int expectedResult)
        {
            for (int i = 0; i < increments; i++)
            {
                _testCounter.Increment();
            }
            Assert.That(_testCounter.Tick, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestCounterReset()
        {
            _testCounter.Increment();
            _testCounter.Reset();
            Assert.That(_testCounter.Tick, Is.EqualTo(0));
        }
    }
}
