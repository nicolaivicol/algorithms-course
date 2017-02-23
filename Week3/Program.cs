using System;
using System.Diagnostics;

namespace Algo1_Week3
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"D:\courses\algorithms 1\kargerMinCut.txt";
            Graph graph = new Graph(filename);
            Console.WriteLine("Karger Min Cut");
            Console.Write("Give N of cut attempts: ");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int iterN = int.Parse(Console.ReadLine());
            int mincut = graph.FindMinCut(iterN);
            stopWatch.Stop();
            Console.WriteLine("min cut: {0}   |  sec/cut: {1:0.0000}", mincut, stopWatch.Elapsed.TotalSeconds/ iterN);
            Console.ReadLine();
        }
    }
}
