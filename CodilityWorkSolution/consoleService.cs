using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms
{
    class ConsoleService
    {
        private const string _readPrompt = "console> ";

        public static void Run(Func<int, int> methodName)
        {
            while (true)
            {
                var consoleInput =
                    ReadFromConsole("Enter string  parameter: ");

                if (string.IsNullOrWhiteSpace(consoleInput)) continue;

                try
                {
                    // Execute the command:
                    var result = Execute(methodName,Convert.ToInt16(consoleInput));

                    // Write out the result:
                    WriteToConsole(Convert.ToString(result));
                }
                catch (Exception ex)
                {
                    // OOPS! Something went wrong - Write out the problem:
                    WriteToConsole(ex.Message);
                }
            }
        }

        public static void Run(Func<long[], long> methodName)
        {
            while (true)
            {
                var consoleInput =
                    ReadFromConsole("Enter array parameter(e.g. 1,2,3,4,5): ");

                long[] intArray = Array.ConvertAll(consoleInput.Split(','), i => Convert.ToInt64(i));

                if (string.IsNullOrWhiteSpace(consoleInput)) continue;

                try
                {
                    // Execute the command:
                    var result = Execute(methodName, intArray);

                    // Write out the result:
                    WriteToConsole(Convert.ToString(result));
                }
                catch (Exception ex)
                {
                    // OOPS! Something went wrong - Write out the problem:
                    WriteToConsole(ex.Message);
                }
            }
        }


        public static void Run(Func<long[],long,long[]> methodName)
        {
            while (true)
            {
                var consoleInputArray =
                    ReadFromConsole("Enter 1st parameter array (1,2,3,4,5,6): ");
                var consoleInputInt =
                    ReadFromConsole("Enter 2nd parameter int: ");

                if (string.IsNullOrWhiteSpace(consoleInputArray)) continue;

                try
                {
                    // Execute the command:
                    long[] intArray = Array.ConvertAll(consoleInputArray.Split(','), i => Convert.ToInt64(i));
                    var result = Execute(methodName,intArray, Convert.ToInt64(consoleInputInt));

                    // Write out the result:
                    WriteToConsole(string.Join("=>",result.Select(x => x.ToString()).ToArray()));
                }
                catch (Exception ex)
                {
                    // OOPS! Something went wrong - Write out the problem:
                    WriteToConsole(ex.Message);
                }
            }
        }


        private static int Execute(Func<int, int> methodName,int parameter){
            return methodName(parameter);
        }

        private static long Execute(Func<long[], long> methodName, long[] parameter)
        {
            return methodName(parameter);
        }

        private static string Execute(Func<string, string> methodName, string parameter)
        {
            return methodName(parameter);
        }

        private static long[] Execute(Func<long[],long, long[]> methodName,long[] parameterArray, long parameterInt)
        {
            return methodName(parameterArray,parameterInt);
        }

        public static void WriteToConsole(string message = "")
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
        }

        public static string ReadFromConsole(string promptMessage = "")
        {
            Console.Write(_readPrompt + promptMessage);
            return Console.ReadLine();
        }

    }
}
