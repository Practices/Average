using System;
using System.Collections.Generic;
using System.Linq;

namespace Average.App
{
    internal class Program
    {
        private const string averageArithmetricCommand = "-am";
        private const string averageGeometricCommand = "-gm";

        private static void Main(string[] args)
        {
            try
            {
                Command command = GetCommand(args);

                if (command != Command.Help)
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
                        averageArithmetricCommand
                        + " <список чисел> - вычисляет среднее арифметические для списка чисел. Разрешаются только положительные числа. Например, "
                        + averageArithmetricCommand + " 1 2 3 4 5 \n";
                    text +=
                        averageGeometricCommand
                        + " <список чисел> - вычисляет среднее геометрическое для списка чисел. Разрешаются только положительные числа. Например, "
                        + averageGeometricCommand + " 3 3 3";
                    break;
                case Message.ErrorArgs:
                    text += "Вы ввели неправильные аргументы.";
                    break;
            }
            return text;
        }

        public static bool IsNumbers(IEnumerable<string> args)
        {
            if (args.Any())
            {
                return false;
            }

            string strConcat = string.Concat(args);

            return strConcat.All(char.IsDigit);
        }

        public static Command GetCommand(string[] args)
        {
            Command command = Command.Help;

            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case averageArithmetricCommand:
                        command = Command.Arith;
                        break;
                    case averageGeometricCommand:
                        command = Command.Geo;
                        break;
                }
            }

            return command;
        }

        public static IEnumerable<int> GetNumbers(IEnumerable<string> args)
        {
            return args.Select(int.Parse);
        }
    }
}