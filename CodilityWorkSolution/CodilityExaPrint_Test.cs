using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataStructures_Algorithms
{
    static class CodilityExaprint_Task2
    {
        public static void Execute()
        {


            while (true)
            {
                Console.Write("Enter array parameters(e.g. 1,2,3,4,5):");

                short[] N = Array.ConvertAll(Console.ReadLine().Split(','), i => Convert.ToInt16(i));

                DateTime startTime = DateTime.Now;
                Console.WriteLine(solution(N));
                DateTime endTime = DateTime.Now;
                Console.WriteLine("Took:" + endTime.Subtract(startTime).TotalSeconds);
            }
        }

        public static int solution(short[] A)
        {
            return original(A);
            //return optimization1(A);
            //return optimization2(A);
        }

        private static int original(short[] A)
        {

            int N = A.Length;
            int result = 0;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (A[i] == A[j])
                        result = Math.Max(result, Math.Abs(i - j));
            return result;

            //Time:
        }

        private static int optimization1(short[] A)
        {
            int N = A.Length;
            int result = 0;
            Dictionary<int, int> maxDifference = new Dictionary<int, int>();
            for (int i = 0; i < N; i++)
            {
                if (maxDifference.ContainsKey(A[i]))
                {
                    result = Math.Max(result, Math.Abs(maxDifference[A[i]] - i));
                 }
                else
                {
                    maxDifference.Add(A[i], i);
                }
            }
            return result;

            //Time: 
        }

        // This is the fastest by multiples.
        private static int optimization2(short[] A)
        {
            int N = A.Length;
            int result = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = (N - 1); j > i; j--)
                {
                    if (A[i] == A[j])
                    {
                        result = Math.Max(result, Math.Abs(i - j));
                        break;
                    }
                }
            }

            return result;

            //Time: 
        }
    }
        static class CodilityExaprint_Task4
        {
            public static void Execute()
            {


                while (true)
                {
                    Console.Write("Enter string parameters:");

                    string N = Console.ReadLine();
                    Console.WriteLine(solution(N));
                }
            }

            public static int solution(string S)
            {
                Stack<int> items = new Stack<int>();
                string[] comands = S.Split(' ');

                int[] stack;
                int intVal;

                for (int i = 0; i < comands.Length; i++)
                {
                    if (comands[i] == "DUP")
                    {
                        dup(items);
                    }
                    else if (comands[i] == "POP")
                    {
                        pop(1, items);
                    }
                    else if (comands[i] == "+")
                    {
                        if (items.Count > 1)
                        {
                            popSum(items);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else if (comands[i] == "-")
                    {
                        if (items.Count > 1)
                        {
                            removeSum(items);
                        }
                        else {
                            return -1;
                        }
                    }
                    else if (int.TryParse(comands[i], out intVal))
                    {
                        pushInt(items, intVal);
                    }
                    else {
                        return -1;
                    }

             }



                return items.Peek();
            }

            private static void pushInt(Stack<int> items, int intVal)
            {
                items.Push(intVal);
            }

            // dup
            private static void dup(Stack<int> items)
            { //duplicate the top most
                int topMost = items.Peek();
                //get top most
                if (items.Any())
                {
                    topMost = items.First();

                    //duplicate
                    items.Push(topMost);

                }

            }

            // +
            private static void popSum(Stack<int> items)
            { // remove 2 top most sum and add back
                var top2Sum = items.Take(2).Sum();
                
               //pop twice
                pop(2, items);

                //add sum
                items.Push(top2Sum);

            }

            //-
            private static void removeSum(Stack<int> items)
            {// remove 2 top most and subtract and add back
                var top2 = items.Take(2).ToList();

                if (top2.Count > 1)
                {
                    //pop twice
                    pop(2, items);

                    //add subtracted
                    items.Push(top2.First() - top2.Last());
                }
            }

            private static void pop(int numberOfItems, Stack<int> items)
            {
                for (int i = 0; i < numberOfItems; i++)
                {
                    items.Pop();
                }
            }

        }        
    
}
