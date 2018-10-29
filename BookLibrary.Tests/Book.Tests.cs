using System;
using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {
        Book book = new Book() { Title = "C# in Depth    ", Author = "   Jon Skeet   ", Year = "2019  ", PublishingHous = "Manning", Edition = "4", Pages = "900", Price = "40$" };

        [Test] 
        public void ToString_GeneralFormat_ReturnedStringViewOfBookInGeneralFormat()
        { 
            // Arrange
            string expectedResult = "C# in Depth, Jon Skeet, 2019, Manning, 4, 900, 40$";

            // Act
            string result = book.ToString();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ToString_ATYPFormat_ReturnedStringViewOfBookInGeneralFormat()
        {            
            // Arrange
            string expectedResult = "Jon Skeet, C# in Depth, 2019, Manning";

            // Act
            string result = String.Format("{0:ATYP}", book);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ToString_ATYFormat_ReturnedStringViewOfBookInGeneralFormat()
        {
            // Arrange
            string expectedResult = "Jon Skeet, C# in Depth, 2019";

            // Act
            string result = String.Format("{0:ATY}", book);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ToString_ATFormat_ReturnedStringViewOfBookInGeneralFormat()
        {
            // Arrange
            string expectedResult = "Jon Skeet, C# in Depth";

            // Act
            string result = String.Format("{0:AT}", book);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ToString_TYPFormat_ReturnedStringViewOfBookInGeneralFormat()
        {
            // Arrange
            string expectedResult = "C# in Depth, 2019, Manning";

            // Act
            string result = String.Format("{0:TYP}", book);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ToString_TFormat_ReturnedStringViewOfBookInGeneralFormat()
        {
            // Arrange
            string expectedResult = "C# in Depth";

            // Act
            string result = String.Format("{0:T}", book);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public void ToString_UnsupportedFormatFormat_ThrownException()
            => Assert.Throws<FormatException>(() => String.Format("{0:XYZ}", book));

    }
}
