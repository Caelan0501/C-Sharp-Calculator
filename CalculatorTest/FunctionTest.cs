using Calculator;
namespace CalculatorTest
{
    [TestClass]
    public class FunctionTest
    {
        [TestMethod]
        public void IntAdd()
        {
            int result = Function.Add(1, 2);
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void IntAddNegA()
        {
            int result = Function.Add(-1, 2);
            Assert.AreEqual(1, result);
            result = Function.Add(5, -2);
            Assert.AreEqual(3, result);
        }
    }
}