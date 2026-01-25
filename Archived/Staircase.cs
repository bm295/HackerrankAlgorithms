using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        for(int i = 1; i <= n; i++) {
            for(int j = 1; j <= n - i; j++) {
                Console.Write(' ');
            }
            for(int k = 1; k <= i; k++) {
                Console.Write("#");
            }
            Console.WriteLine();
        }
    }
}
