using System;
using System.Globalization;
using Xunit;

namespace MyBooks.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var ctrl1 = CultureInfo.InvariantCulture;
            var ctrl2 = CultureInfo.InstalledUICulture;
            Assert.NotEqual(ctrl1, ctrl2);
        }
    }
}