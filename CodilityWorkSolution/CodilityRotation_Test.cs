using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataStructures_Algorithms
{

    [TestFixture]
    class CodilityRotation_Test
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

    static class CodilityRotation
    {
        public static long[] solution(long[] A, long K)
        {
        
                // write your code in C# 6.0 with .NET 4.5 (Mono)

            //Create 2 arrays, original and rotated
                long length = A.LongCount();
                long[] rotatedArray = new long[length];
                            

                if (K == length) { K = 0; }
                if (K > length) { K = K % length; }
            
            //iterate through original array 
                for (int i = 0; i < length; i++)
                {
                    var newIndex = (i + K);

                    if (newIndex > (length - 1))
                    {
                        rotatedArray[newIndex - (length)] = A[i];
                    }
                    else
                    {
                        rotatedArray[newIndex] = A[i];
                    }

                }

          return rotatedArray;
        }

    }
}
