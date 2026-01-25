using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] a = new int[n][];
        for(int a_i = 0; a_i < n; a_i++){
           string[] a_temp = Console.ReadLine().Split(' ');
           a[a_i] = Array.ConvertAll(a_temp,Int32.Parse);
        }
        var sumD1 = 0;
        var sumD2 = 0;
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < n; j++) {
                if (i == j)
                    sumD1 += a[i][j];
                if ((i + j) == (n - 1))
                    sumD2 += a[i][j];
            }
        }
        Console.WriteLine(Math.Abs(sumD1 - sumD2));
    }
}
