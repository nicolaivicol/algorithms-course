using System;
using System.Diagnostics;

namespace Algo1_Week3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Karger Min Cut");
            
            string filename = @"D:\courses\algorithms 1\kargerMinCut.txt";
            Graph graph = new Graph(filename);
            
            Console.Write("Give N of cut attempts: ");
            int iterN = int.Parse(Console.ReadLine());
            
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int mincut = graph.FindMinCut(iterN);
            stopWatch.Stop();
            
            Console.WriteLine("min cut: {0}   |  sec/cut: {1:0.0000}", mincut, stopWatch.Elapsed.TotalSeconds/ iterN);
            Console.ReadLine();
        }
    }
}
