using System;
    using System.Collections.Generic;
    using System.Linq;
using BinaryCalcp;
// using BinaryArithmeticApp; // Этот using не нужен, если Calculator в том же namespace

namespace BinaryCalc // Тот же namespace
    {
        class Program
        {
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
                            resultBin = Calculator.Add(val1, val2); // Вызываем из Calculator
                            break;
                        case "-":
                            resultBin = Calculator.Subtract(val1, val2); // Вызываем из Calculator
                            break;
                        case "*":
                            resultBin = Calculator.Multiply(val1, val2); // Вызываем из Calculator
                            break;
                        case "/":
                            if (val2 == 0) throw new DivideByZeroException("Деление на ноль!");
                            resultBin = Calculator.Divide(val1, val2); // Вызываем из Calculator
                            break;
                        default:
                            Console.WriteLine("Неверная операция.");
                            return;
                    }

                    // 3. Вывод результатов
                    long finalDecimal = Calculator.BinaryToLong(resultBin); // Вызываем из Calculator

                    // Форматирование "прямого кода" для вывода
                    string displayBin = Calculator.ToDirectCodeOutput(finalDecimal); // Вызываем из Calculator

                    Console.WriteLine("\nРезультаты:");
                    Console.WriteLine($"прямой код: {displayBin}");
                    Console.WriteLine($"результат в исходной системе счисления: {Convert.ToString(finalDecimal, sourceBase).ToUpper()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }