using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryArithmeticApp
{
    class Program
    {
        // Разрядность для работы (16 бит: 1 бит знак, 15 бит значение)
        const int bitCount = 16;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Программа двоичных вычислений (через доп. код) ===");

                Console.Write("Введите исходную систему счисления (2-16): ");
                int sourceBase = int.Parse(Console.ReadLine());

                Console.Write("Введите первое число: ");
                string input1 = Console.ReadLine();

                Console.Write("Введите второе число: ");
                string input2 = Console.ReadLine();

                Console.Write("Выберите операцию (+, -, *, /): ");
                string operation = Console.ReadLine();

                // 1. Перевод из любой системы в десятичную (long)
                long val1 = Convert.ToInt64(input1, sourceBase);
                long val2 = Convert.ToInt64(input2, sourceBase);

                // 2. Выполнение операций в двоичной системе
                string resultBin = "";

                switch (operation)
                {
                    case "+":
                        resultBin = Add(val1, val2);
                        break;
                    case "-":
                        resultBin = Subtract(val1, val2);
                        break;
                    case "*":
                        resultBin = Multiply(val1, val2);
                        break;
                    case "/":
                        if (val2 == 0) throw new DivideByZeroException("Деление на ноль!");
                        resultBin = Divide(val1, val2);
                        break;
                    default:
                        Console.WriteLine("Неверная операция.");
                        return;
                }

                // 3. Вывод результатов
                long finalDecimal = BinaryToLong(resultBin);
                
                // Форматирование "прямого кода" для вывода (как просили в примере: 4 знака или больше)
                string displayBin = ToDirectCodeOutput(finalDecimal);

                Console.WriteLine("\nРезультаты:");
                Console.WriteLine($"прямой код: {displayBin}");
                Console.WriteLine($"результат в исходной системе счисления: {Convert.ToString(finalDecimal, sourceBase).ToUpper()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // --- ДВОИЧНАЯ АРИФМЕТИКА ---
        
        static string ToBinary(long value)
        {
            string binary = Convert.ToString(value, 2).PadLeft(bitCount - 1, '0'); // Оставляем место для знакового бита
            return binary;
        }

        static long BinaryToLong(string binary)
        {
            return Convert.ToInt64(binary, 2);
        }

        static string Add(long a, long b)
        {
            long result = a + b;
            return ToBinary(result);
        }

        static string Subtract(long a, long b)
        {
            long result = a - b;
            return ToBinary(result);
        }

        static string Multiply(long a, long b)
        {
            long result = a * b;
            return ToBinary(result);
        }

        static string Divide(long a, long b)
        {
            long result = a / b;
            return ToBinary(result);
        }

        static string ToDirectCodeOutput(long value)
        {
            string binary = ToBinary(value);
            return binary.Substring(binary.Length - bitCount); // Возвращаем последние 16 бит
        }
    }
}
