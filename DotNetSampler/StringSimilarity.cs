using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSampler
{
    internal class StringSimilarity
    {
        // this is from https://en.wikipedia.org/wiki/Levenshtein_distance
        public static int LevenshteinDistance(string s1, string s2)
        {
            int[,] d = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++) {
                d[i, 0] = i;
            }

            for (int j = 0; j <= s2.Length; j++) {
                d[0, j] = j;
            }

            for (int i = 1; i <= s1.Length; i++) {
                for (int j = 1; j <= s2.Length; j++) {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[s1.Length, s2.Length];
        }
    }
}
