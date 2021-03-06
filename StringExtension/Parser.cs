﻿using System;

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
            CheckInputData(source, @base);
                        
            ulong outputNumber = 0;
            source = source.ToUpperInvariant();

            for (int i = 0; i < source.Length; i++)
            {
                int index = SIGNS.IndexOf(source[i]);
                
                if (index > @base-1 || index < 0)
                {
                    throw new ArgumentException($"The {source[i]} is not used in this number system.");
                }

                try
                {
                    checked
                    {
                        outputNumber = outputNumber + (ulong)index * (ulong)Math.Pow(@base, (source.Length - 1 - i));
                    }
                }
                catch (OverflowException overflowEx)
                {
                    throw new ArgumentException($"The input {source} is big number.", overflowEx);
                }                
            }

            if (outputNumber >= int.MaxValue)
            {
                throw new ArgumentException($"Input {source} is more than int.MaxValue");
            }

            return (int)outputNumber;                       
        }

        private static void CheckInputData(string source, int @base)
        {
            if (ReferenceEquals(source, null))
            {
                throw new ArgumentNullException($"The {source} can not be null.");
            }

            if (source.Length <= 0)
            {
                throw new ArgumentException($"The {source} can not be empty.");
            }

            if (@base > MAXBASE || @base < MINBASE)
            {
                throw new ArgumentOutOfRangeException($"The {@base} can not be more than {MAXBASE} or less than {MINBASE}");
            }
        }
    }
}
