using System;
using System.Globalization;


namespace BookLibrary
{
    /// <summary>
    /// This class implement interface IFormattable for the future expandability in formats.
    /// </summary>
    public class Book : IFormattable
    {       
        public string Title { get; set; }
        public string Year { get; set; }
        public string Author { get; set; }
        public string PublishingHous { get; set; }
        public string Edition { get; set; }
        public string Pages { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.InvariantCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format) == true)
            {
                format = "G";
            }

            if (ReferenceEquals(formatProvider, null) == true)
            {
                formatProvider = CultureInfo.InvariantCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return Title.ToString().Trim()+ ", " + Author.ToString().Trim() + ", " + Year.ToString().Trim() + ", " + PublishingHous.ToString().Trim() + ", " + Edition.ToString().Trim() + ", " + Pages.ToString().Trim() + ", " + String.Format("{0:C}",Price).Trim();
                case "ATYP":
                    return Author.ToString().Trim() + ", " + Title.ToString().Trim() + ", " + Year.ToString().Trim() + ", " + PublishingHous.ToString().Trim();
                case "ATY":
                   return Author.ToString().Trim() + ", " + Title.ToString().Trim() + ", " + Year.ToString().Trim();
                case "AT":
                    return Author.ToString().Trim() + ", " + Title.ToString().Trim();
                case "TYP":
                    return Title.ToString().Trim() + ", " + Year.ToString().Trim() + ", " + PublishingHous.ToString().Trim();
                case "T":
                    return Title.ToString().Trim();
                default:
                    throw new FormatException($"This {format} is  not supported");
            }
        }
    }
}
