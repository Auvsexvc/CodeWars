using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class LengthOfMissingArrayTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(3, LengthOfMissingArray.GetLengthOfMissingArray(new object[][] { new object[] { 1, 2 }, new object[] { 4, 5, 1, 1 }, new object[] { 1 }, new object[] { 5, 6, 7, 8, 9 } }));
            Assert.AreEqual(2, LengthOfMissingArray.GetLengthOfMissingArray(new object[][] { new object[] { 5, 2, 9 }, new object[] { 4, 5, 1, 1 }, new object[] { 1 }, new object[] { 5, 6, 7, 8, 9 } }));
            Assert.AreEqual(2, LengthOfMissingArray.GetLengthOfMissingArray(new object[][] { new object[] { null }, new object[] { null, null, null } }));
            Assert.AreEqual(5, LengthOfMissingArray.GetLengthOfMissingArray(new object[][] { new object[] { 'a', 'a', 'a' }, new object[] { 'a', 'a' }, new object[] { 'a', 'a', 'a', 'a' }, new object[] { 'a' }, new object[] { 'a', 'a', 'a', 'a', 'a', 'a' } }));

            Assert.AreEqual(0, LengthOfMissingArray.GetLengthOfMissingArray(new object[][] { }));
            Assert.AreEqual(0, LengthOfMissingArray.GetLengthOfMissingArray(new object[][] { new object[] { }, new object[] { }, new object[] { } }));
        }
    }

    internal class LengthOfMissingArray
    {
        public static int GetLengthOfMissingArray(object[][] arrayOfArrays)
        {
            return arrayOfArrays != null && arrayOfArrays.Length > 1 && arrayOfArrays.All(x => x != null && x.Length > 0)
                      ? arrayOfArrays
                          .GroupBy(x => x.Length)
                          .OrderBy(x => x.Key)
                          .SkipWhile((v, i) => v.Key == i + arrayOfArrays.Min(x => x.Length))
                          .First()
                          .Key - 1
                      : 0;
        }
    }
}