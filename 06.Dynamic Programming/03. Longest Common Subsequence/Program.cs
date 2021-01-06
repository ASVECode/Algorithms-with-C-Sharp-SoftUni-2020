using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Longest_Common_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> B = Console.ReadLine().Split().ToList();
            List<string> A = Console.ReadLine().Split().ToList();

            //find LCS in A,B starting from index 0 of each
            int longestCommonSubsequence = LCS(A, B, 0, 0);
            Console.WriteLine(longestCommonSubsequence);
            Console.Read();

        }

        //Find the longest common subsequnce starting from index1 in A and index2 in B
        //Pass A as shorter string
        public static int LCS(List<string> A, List<string>B, int index1, int index2)
        {
            int max = 0;
            if (index1 == A.Count)
            {
                //You have reached beyond A and thus no subsequence
                return 0;
            }
            if (index2 == B.Count)
            {   //you may reach end of 2nd string. LCS from that end is 0
                return 0;
            }
            for (int i = index1; i < A.Count; i++)
            {
                int exist = B.IndexOf(A[i], index2);
                if (exist != -1)
                {
                    //   found = true;
                    int temp = 1 + LCS(A, B, i + 1, exist + 1);
                    if (max < temp)
                    {
                        max = temp;
                    }
                }
            }
            return max;
        }
    }

}

