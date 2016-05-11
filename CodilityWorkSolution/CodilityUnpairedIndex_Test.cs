using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataStructures_Algorithms
{

    [TestFixture]
    class CodilityUnpairedIndex_Test
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


    static class CodilityUnpairedIndex
    {
        public static long solution(long[] A)
        {
        
            return FindPairs(A);

        }

        public static long FindPairs(long[] Alist){
        var dict = new Dictionary<int, int>();
            foreach(int d in Alist)
            {
                if (dict.ContainsKey(d))
                    dict[d]++;
                else
                    dict.Add(d, 1);
            }

            return (long)dict.First(x=>x.Value==1).Key;
        
        }

    }
}
