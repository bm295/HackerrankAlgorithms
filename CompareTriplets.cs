using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_a0 = Console.ReadLine().Split(' ');
        int a0 = Convert.ToInt32(tokens_a0[0]);
        int a1 = Convert.ToInt32(tokens_a0[1]);
        int a2 = Convert.ToInt32(tokens_a0[2]);
        string[] tokens_b0 = Console.ReadLine().Split(' ');
        int b0 = Convert.ToInt32(tokens_b0[0]);
        int b1 = Convert.ToInt32(tokens_b0[1]);
        int b2 = Convert.ToInt32(tokens_b0[2]);
        var points = new int[] {GetScores(a0, b0), GetScores(a1, b1), GetScores(a2, b2)} ;
        var totalPoints = GetTotal(points);
        Console.WriteLine(string.Format("{0} {1}", totalPoints[0], totalPoints[1]));
    }
    
    static int GetScores(int x, int y) {
        if (x > y)
            return 1;
        if (x < y)
            return -1;
        return 0;
    }
    
    static int[] GetTotal(int[] points) {
        var scores = new int[] {0 , 0};
        for (var i = 0; i < points.Length; i++) {
            if (points[i] > 0)
                scores[0]++;
            else if (points[i] < 0)
                scores[1]++;
        }
        return scores;
    }
}
