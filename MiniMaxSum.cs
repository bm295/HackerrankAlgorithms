using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        string[] line = Console.ReadLine().Split(' ');
        int[] inputs = Array.ConvertAll(line, Int32.Parse);
        long[] sums = new long[inputs.Length];
        for(int i = 0; i < inputs.Length; i++) {
            for(int j = 0; j < sums.Length; j++) {
                if (i != j)
                    sums[j] += inputs[i];
            }
        }
        long min = sums[0];
        long max = sums[0];
        for (int i = 1; i < sums.Length; i++) {
            if (sums[i] < min) min = sums[i];
            if (sums[i] > max) max = sums[i];
        }
        Console.WriteLine(string.Format("{0} {1}", min, max));
    }
}
