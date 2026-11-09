using System;
using System.Linq; 

namespace BinaryCalcp
{
    public class Calculator 
    {
        public const int bitCount = 16; 

        // --- Вспомогательные методы ---
        public static string ToBinary(long value) 
        {
           
            return Convert.ToString(value, 2).PadLeft(64, '0');
        }

        public static long BinaryToLong(string binary) 
        {
            return Convert.ToInt64(binary, 2);
        }

        
        public static string Add(long a, long b) 
        {
            long result = a + b;
            return ToBinary(result);
        }

        public static string Subtract(long a, long b)
        {
            long result = a - b;

          
            if (result < 0)
            {
                
                throw new ArgumentException("Результат вычитания не может быть отрицательным в данном калькуляторе.");
            }

       
            return ToBinary(result);
        }

        public static string Multiply(long a, long b) 
        {
            long result = a * b;
            return ToBinary(result);
        }

        public static string Divide(long a, long b) 
        {
            long result = a / b;
            return ToBinary(result);
        }

        // Ваша функция ToDirectCodeOutput
        public static string ToDirectCodeOutput(long value) 
        {
            string binary = ToBinary(value);
            
            return binary.Substring(binary.Length - bitCount); 
        }
    }
}