using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    public static class ConsecutiveVowelsInAString
    {
        public static int GetTheVowels(string word)
        {
            return word.Aggregate(0, (i, c) => i + (c == "aeiou"[i % 5] ? 1 : 0));
        }
    }

    [TestFixture]
    public class ConsecutiveVowelsInAStringTest
    {
        [Test]
        public void SampleTests()
        {
            Assertion(0, string.Empty);
            Assertion(6, "agrtertyfikfmroyrntbvsukldkfa");
            Assertion(4, "erfaiekjudhyfimngukduo");
            Assertion(7, "akfheujfkgiaaaofmmfkdfuaiiie");
            Assertion(0, "eiknfhjrytueiouesxdczbeuiuoimnmfhfiuou");
            Assertion(16, "desrehakkjfuteknvfiyrtfbehjdjrobchrunbcbbhdhehbvudjsnanbakkjndhfjenfndinmfnbfondndendnfudnfnanndhdemdmcnfdemnfjimdfofnmfnfjanmdnhdua");
            Assertion(11, "sudnfhrakekdhhfkakjdjdhvneidkvnudntomcnnamjemdmfudkfhjamvcjedkfdnridnmnbvfhbdjdidncbvchencchdjdodncvchfndnrnencncnffduncbhjdfja");
            Assertion(11, "jurjfdleiifjriisiouajjfyhekkfjvnnmsuimsnvyuhvcodnmfnsumvbjshhsadkvhfeixoua");
            Assertion(3, "jrknjffuolgtahamhaevbgeosreljtbhuiaamxpyxdmyb");
            Assertion(6, "sowqapfqbrjpygtmmulybwusgjijbrnchgkxiaazkcniaxllmupjcmkxwcsmzdaessgkkgzctmbchladughtkitcognxvjwiiiltkuebrwemopvxqpeurfsfgjmeuzgvhjnssbhwkfbejzygbytipjtdcyscwofrpwshiakbdnqfioxqulohdlnmmmfpfrriwpwbddpj");
        }

        private static void Assertion(int expected, string input) =>
          Assert.AreEqual(
            expected,
            ConsecutiveVowelsInAString.GetTheVowels(input),

            $"\n  Word: \"{input}\""
          );
    }
}