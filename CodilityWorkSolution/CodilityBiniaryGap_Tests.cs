using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataStructures_Algorithms
{

    [TestFixture]
    class CodilityExaprint_Test
    {
        [SetUp]
        public void Init()
        {

        }

        [Test]
        public void FindGap()
        {

        }
    }

    static class CodilityBinaryGap
    {
        public static int solution(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            //convert to binary and char array
            string binaryString = Convert.ToString(N, 2);
            char[] binaryArray = binaryString.ToCharArray();
            Console.WriteLine("Binary:" + binaryString);

            //iterate through and count 
            int zeroCount = 0;
            int highestCount = 0;
            foreach (char b in binaryArray)
            {
                if (b == '0')
                {
                    zeroCount++;
                }
                else
                {
                    // check if max count
                    if (zeroCount > highestCount)
                    {
                        highestCount = zeroCount;
                    }

                    //reset zeroCount
                    zeroCount = 0;
                }

            }

            return highestCount;
        }

    }
}
