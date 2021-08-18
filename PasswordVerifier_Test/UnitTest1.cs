using System;
using Xunit;
using PasswordVerifier;

namespace PasswordVerifier_Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData("\t", true)]
        [InlineData("\n", true)]
        [InlineData("string with\twhite\nspace", true)]
        [InlineData("str", false)]
        public void TestContainsNullOrWhiteSpace(string str, bool expected) => Assert.Equal(PasswordVerifier.PasswordVerifier.ContainsNullOrWhiteSpace(str), expected);

        [Theory]
        [InlineData("aStrOf_09", true)]
        [InlineData("aStrOf__10", true)]
        [InlineData("aStrof7", false)]
        [InlineData("aStrOf_8", false)]
        public void TestIsMinLength(string str, bool expected) => Assert.Equal(PasswordVerifier.PasswordVerifier.IsMinLength(str), expected);

        [Theory]
        [InlineData("oneUppercase", true)]
        [InlineData("TwoUppercase", true)]
        [InlineData("ABC123", true)]
        [InlineData("123ABC", true)]
        [InlineData("lowercase", false)]
        [InlineData("abc123", false)]
        [InlineData("123abc", false)]
        public void TestIsMinUppercase(string str, bool expected) => Assert.Equal(PasswordVerifier.PasswordVerifier.IsMinUppercase(str), expected);

        [Theory]
        [InlineData("oNELOWERCASE", true)]
        [InlineData("tWOlOWERCASE", true)]
        [InlineData("abc123", true)]
        [InlineData("123abc", true)]
        public void TestIsMinLowercase(string str, bool expected) => Assert.Equal(PasswordVerifier.PasswordVerifier.IsMinLowercase(str), expected);

        [Theory]
        [InlineData("digits_1", true)]
        [InlineData("digits_12", true)]
        [InlineData("noDigits", false)]
        [InlineData("also_noDigits", false)]
        public void TestIsMinDigits(string str, bool expected) => Assert.Equal(PasswordVerifier.PasswordVerifier.IsMinDigits(str), expected);
    }
}
