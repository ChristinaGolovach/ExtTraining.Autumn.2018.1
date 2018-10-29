using NUnit.Framework;
using BookLibrary;
using System.Globalization;
using System.Threading;

namespace BookExtension.Tests
{
    [TestFixture]
    public class BookFormatExtensionTests
    {
        Book book = new Book() { Title = "C# in Depth    ", Author = "   Jon Skeet   ", Year = 2019, PublishingHous = "Manning", Edition = 4, Pages = 900, Price = 40 };

        [Test]
        public void ToString_NEWFormat_ReturnedBookViewInNewStringFormat()
        {
            // Arange
            string expectedResult = "Author is Jon Skeet";

            // Act
            string result = string.Format(new BookFormatExtension(), "{0:NEW}", book);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ToString_NEWFormatWithLowerLetters_ReturnedBookViewInNewStringFormat()
        {
            // Arange
            string expectedResult = "Author is Jon Skeet";

            // Act
            string result = string.Format(new BookFormatExtension(), "{0:nEw}", book);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ToString_GFormat_ReturnedBookViewInGeneralStringFormat()
        {
            // Arange
            string expectedResult = "C# in Depth, Jon Skeet, 2019, Manning, 4, 900, $40.00";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            // Act
            string result = string.Format(new BookFormatExtension(), "{0:G}", book);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ToString_GFormatAndCurrentCulture_ReturnedBookViewInGeneralStringFormat()
        {
            // Arange
            string expectedResult = "C# in Depth, Jon Skeet, 2019, Manning, 4, 900, 40,00 Br";

            // Act            
            string result = book.ToString(null);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

    }
}
