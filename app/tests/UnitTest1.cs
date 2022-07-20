using docker_test.Services;
using NUnit.Framework;

namespace tests
{
    public class Tests
    {
        private WeatherService _ws;

        [SetUp]
        public void Setup()
        {
            _ws = new WeatherService();
        }

        [Test]
        public void Test1()
        {
            var start = "123";
            var res = _ws.GetLooksLike(start);

            Assert.AreEqual("--321--", res);
        }
    }
}