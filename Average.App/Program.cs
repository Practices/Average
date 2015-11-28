using System;
using System.Collections.Generic;
using System.Linq;

namespace Average.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    Command command = GetCommand(args[0]);

                    if (command != Command.No)
                    {
                        IEnumerable<string> paramList = args.Skip(1);

                        if (IsNumbers(paramList))
                        {
                            IEnumerable<int> numbers = GetNumbers(paramList);

                            Calculation calculation = new Calculation();

                            double result = 0;

                            switch (command)
                            {
                                case Command.Arith:
                                    result = calculation.GetAverageArithmetric(numbers.ToArray());
                                    break;
                                case Command.Geo:
                                    result = calculation.GetAverageGeometric(numbers.ToArray());
                                    break;
                            }

                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine(BuildMessage(Message.ErrorArgs));
                            Console.WriteLine(BuildMessage(Message.Help));
                        }
                    }
                }
                else
                {
                    Console.WriteLine(BuildMessage(Message.Help));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Неизвестная ошибка. Программа завершается работу.");
            }
        }

        public static string BuildMessage(Message msg)
        {
            var text = "";

            switch (msg)
            {
                case Message.Help:
                    text += "Пожалуйста, вызовите программу с одним из следующих аргументов \n";
                    text +=
                        "-am <список чисел> - вычисляет среднее арифметические для списка чисел. Разрешаются только положительные числа. Например, -am 1 2 3 4 5 \n";
                    text +=
                        "-gm <список чисел> - вычисляет среднее геометрическое для списка чисел. Разрешаются только положительные числа. Например, -gm 3 3 3";
                    break;
                case Message.ErrorArgs:
                    text += "Вы ввели неправильные аргументы.";
                    break;
            }
            return text;
        }

        public static bool IsNumbers(IEnumerable<string> args)
        {
            if (!args.Any())
            {
                return false;
            }

            string strConcat = string.Concat(args);

            return strConcat.All(char.IsDigit);
        }

        public static Command GetCommand(string cmd)
        {
            Command command;

            switch (cmd)
            {
                case "-am":
                    command = Command.Arith;
                    break;
                case "-gm":
                    command = Command.Geo;
                    break;
                default:
                    command = Command.No;
                    break;
            }

            return command;
        }

        public static IEnumerable<int> GetNumbers(IEnumerable<string> args)
        {
            return args.Select(int.Parse);
        }
    }
}