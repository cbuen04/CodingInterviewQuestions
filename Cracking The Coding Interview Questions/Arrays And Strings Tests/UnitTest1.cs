using Arrays_And_Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arrays_And_Strings_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsUnique()
        {
            string s = "asdf";
            Assert.IsTrue(Arrays.IsUnique(s));
        }

        [TestMethod]
        public void TestIsNotUnique()
        {
            string s = "asdfkhroawb";
            Assert.IsFalse(Arrays.IsUnique(s));
        }

        [TestMethod]
        public void TestIsUniqueAtoZ()
        {
            string s = "abcdefghijklmnopqrstuvwxyz";
            Assert.IsTrue(Arrays.IsUnique(s));
        }

        [TestMethod]
        public void TestIsNotUniqueAtoZ()
        {
            string s = "abcdefghijklmnopqrstuvwxyza";
            Assert.IsFalse(Arrays.IsUnique(s));
        }

        [TestMethod]
        public void TestIsUniqueNumbers()
        {
            string s = "0123";
            Assert.IsTrue(Arrays.IsUnique(s));
        }

        [TestMethod]
        public void TestIsUniqueNull()
        {
            string s = "";
            Assert.IsTrue(Arrays.IsUnique(s));
        }

        [TestMethod]
        public void TestIsUniqueOneChar()
        {
            string s = "a";
            Assert.IsTrue(Arrays.IsUnique(s));
        }

        [TestMethod]
        public void TestIsPermutation()
        {
            string s1 = "ebe";
            string s2 = "bee";

            Assert.IsTrue(Arrays.IsPermutation(s1, s2));
        }

        [TestMethod]
        public void TestIsPermutationOneNull()
        {
            string s1 = "";
            string s2 = "bee";
            Arrays.IsPermutation(s1, s2);

            Assert.IsFalse(Arrays.IsPermutation(s1, s2));
        }

        [TestMethod]
        public void TestIsPermutationLonger()
        {
            string s1 = "cracking";
            string s2 = "ngicckra";

            Assert.IsTrue(Arrays.IsPermutation(s1, s2));
        }

        [TestMethod]
        public void TestIsPermutationLongerFalse()
        {
            string s1 = "cracking";
            string s2 = "ngicckza";

            Assert.IsFalse(Arrays.IsPermutation(s1, s2));
        }

        [TestMethod]
        public void TestIsPermutationComplex()
        {
            string s1 = "cracking the coding interview";
            string s2 = "ngicckza vieintewr che tingod";

            Assert.IsTrue(Arrays.IsPermutation(s1, s2));
        }

        [TestMethod]
        public void TestURLify()
        {
            string s = "cracking the coding interview";
            string expected = "cracking%20the%20coding%20interview";
            Arrays.URLify(s);

            Assert.AreEqual(expected, Arrays.URLify(s));
        }

        [TestMethod]
        public void TestURLifySeveralSpaces()
        {
            string s = "   ";
            string expected = "%20%20%20";

            Assert.AreEqual(expected, Arrays.URLify(s));
        }

        [TestMethod]
        public void TestStringCompression()
        {
            string s = "aabcccccaaa";
            string expected = "a2b1c5a3";

            Arrays.StringCompression(s);

            Assert.AreEqual(expected, Arrays.StringCompression(s));
        }

        [TestMethod]
        public void TestStringCompression2()
        {
            string s = "aaab";
            string expected = "a3b1";

            Arrays.StringCompression(s);

            Assert.AreEqual(expected, Arrays.StringCompression(s));
        }

        [TestMethod]
        public void TestStringCompressionReturnOriginalString()
        {
            string s = "aab";
            string expected = "aab";

            Arrays.StringCompression(s);

            Assert.AreEqual(expected, Arrays.StringCompression(s));
        }

        [TestMethod]
        public void TestStringCompressionReturnOriginalString2()
        {
            string s = "a";
            string expected = "a";

            Arrays.StringCompression(s);

            Assert.AreEqual(expected, Arrays.StringCompression(s));
        }

        [TestMethod]
        public void TestIsPallendromer()
        {
            string s = "taco cat";

            Arrays.IsPalendrome(s);

            Assert.IsTrue(Arrays.IsPalendrome(s));
        }
    }
}
