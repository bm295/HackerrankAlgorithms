using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        int posCnt, nevCnt, zeroCnt;
        posCnt = 0;
        nevCnt = 0;
        zeroCnt = 0;
        for(int i = 0; i < n; i++) {
            if (arr[i] > 0)
                posCnt++;
            else if (arr[i] < 0)
                nevCnt++;
            else
                zeroCnt++;
        }
        Console.WriteLine((decimal)posCnt/n);
        Console.WriteLine((decimal)nevCnt/n);
        Console.WriteLine((decimal)zeroCnt/n);
    }
}
