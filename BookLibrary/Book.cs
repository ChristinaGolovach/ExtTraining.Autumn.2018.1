using System;
using System.Globalization;


namespace BookLibrary
{
    /// <summary>
    /// This class implement interface IFormattable for the future expandability in formats.
    /// </summary>
    public class Book : IFormattable
    {
        private string title;
        private int year;
        private string author;
        private string publishingHous;
        private int edition;
        private int pages;
        private decimal price;

        #region Properties
        public string Title
        {
            get => title;
            set => title = value.Trim();
        }

        public int Year
        {
            get => year;
            set
            {
                if (value < 1000)
                {
                    throw new ArgumentException($" {Year}  can not be less than 1000");
                }
                year = value;
            }
        }

        public string Author
        {
            get => author;
            set
            {
                CheckInputData(value);
                author = value.Trim();
            }
        }

        public string PublishingHous
        {
            get => publishingHous;
            set
            {
                CheckInputData(value);
                publishingHous = value.Trim();
            }
        }
        
        public int Edition
        {
            get => edition;
            set
            {
                CheckInputData(value);
                edition = value;
            }
        }

        public int Pages
        {
            get => pages;
            set
            {
                CheckInputData(value);
                pages = value;
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                CheckInputData(value);
                price = value;
            }
        }

        #endregion Properties

        public Book()
        {
            Title = "Default Title";
            Year = 2000;
            Author = "Default Author";
            PublishingHous = "Default Publishing House";
            Edition = 1;
            Pages = 1;
            Price = 1.0M;
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format) == true)
            {
                format = "G";
            }

            if (ReferenceEquals(formatProvider, null) == true)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return $"{Title}, {Author}, {Year}, {PublishingHous}, {Edition}, {Pages}, {Price:C}"; 
                case "ATYP":
                    return $"{Author}, {Title}, {Year}, {PublishingHous}";                  
                case "ATY":                 
                   return $"{Author}, {Title}, {Year}";
                case "AT":
                    return $"{Author}, {Title}";
                case "TYP":
                    return $"{Title}, {Year}, {PublishingHous}";
                case "T":
                    return $"{Title}";
                default:
                    throw new FormatException($"This {format} is  not supported");
            }
        }

        private void CheckInputData(int data)
        {
            if (data <= 0)
            {
                throw new ArgumentException($"Input {data} can not be negative.");
            }
        }

        private void CheckInputData(string data)
        {
            if (ReferenceEquals(data, null))
            {
                throw new ArgumentNullException($"Input {data} can not be null.");
            }

            if (data.Length < 1)
            {
                throw new ArgumentException($"Input {data} can not be empty.");
            }
        }

        private void CheckInputData(decimal data)
        {
            if (data <= 0)
            {
                throw new ArgumentException($"Input {data} can not be negative.");
            }
        }
    }
}
