using DDD.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDTest.Tests
{
    [TestClass]
    public class TemperatureTest
    {
        [TestMethod]
        public void 小数点以下2桁でまるめて表示できる()
        {
            var t = new Temperature(12.3f);
            Assert.AreEqual(12.3f, t.Value);
            Assert.AreEqual("12.30", t.DisplayValue);
            Assert.AreEqual("12.30 ℃", t.DisplayValueWithUnitSpace);
        }

        [TestMethod]
        public void Equals()
        {
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);
            Assert.AreEqual(true, t1.Equals(t2));
            Assert.AreEqual(true, t1 == t2);
        }
    }
}
