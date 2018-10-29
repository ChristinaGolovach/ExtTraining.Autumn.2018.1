using System;
using System.Globalization;
using BookLibrary;

namespace BookExtension
{
    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        IFormatProvider parentformatProvider;

        public BookFormatExtension() : this(CultureInfo.CurrentCulture) { }

        public BookFormatExtension(IFormatProvider parentFormatProvoder)
        {
            parentformatProvider = parentFormatProvoder;   
        }

        public string Format(string format, object argument, IFormatProvider formatProvider)
        {
            string inputFormat = format.ToUpperInvariant();

            if (argument == null || inputFormat != "NEW" || argument.GetType() != typeof(Book))
            {
                return string.Format(parentformatProvider, "{0:" + format + "}", argument);
            }

            Book book = (Book)argument;             

            return $"Author is {book.Author}";
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}
