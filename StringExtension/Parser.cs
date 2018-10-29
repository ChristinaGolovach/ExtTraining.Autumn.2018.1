using System;

namespace StringExtension
{
    public static class Parser
    {
        private static readonly int MINBASE;
        private static readonly int MAXBASE;
        private static readonly string SIGNS;

        static Parser()
        {
            MINBASE = 2;
            MAXBASE = 16;
            SIGNS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        
        public static int ToDecimal(this string source, int @base)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException($"The {source} can not be null or empty");
            }

            if (@base > MAXBASE || @base < MINBASE)
            {
                throw new ArgumentOutOfRangeException($"The {@base} can not be more than {MAXBASE} or less than {MINBASE}");
            }
                        
            int outputNumber = 0;

            for (int i=0; i< source.Length; i++)
            {
                int index = SIGNS.IndexOf(source[i]);
                
                if (index > @base-1 || index < 0)
                {
                    throw new ArgumentException($"The {source[i]} is not used in this number system.");
                }              
                outputNumber = outputNumber + index * (int)Math.Pow(@base,(source.Length-1-i));
            }

            if (outputNumber >= int.MaxValue-1)
            {
                throw new ArgumentException($"Input {source} is more than int.MaxValue");
            }

            return outputNumber;
                       
        }
    }
}
