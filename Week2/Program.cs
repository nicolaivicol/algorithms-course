using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1_Week2
{
    class Program
    {
        static void Main(string[] args)
        {
            // read file with integers
            string filename = @"E:\courses\algorithms I\week 2\QuickSort.txt";
            //string filename = @"E:\courses\algorithms I\week 1\hw\IntegerArrayCheck_15.txt";
            List<int> lst = new List<int>();
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    int x = Convert.ToInt32(sr.ReadLine());
                    lst.Add(x);
                }
            }
            //List<int> lst = 

            int cntFirst = QuickSort.DoQuickSortCnt(CopyOf(lst), QuickSort.Pivot.First);
            int cntLast = QuickSort.DoQuickSortCnt(CopyOf(lst), QuickSort.Pivot.Last);
            int cntMedian = QuickSort.DoQuickSortCnt(CopyOf(lst), QuickSort.Pivot.Median);

            Console.WriteLine("First: {0}", cntFirst);
            Console.WriteLine("Last: {0}", cntLast);
            Console.WriteLine("Median: {0}", cntMedian);
            Console.ReadLine();
        }

        public static List<int> CopyOf(List<int> lst)
        {
            List<int> lstcopy = new List<int>();
            for (int i = 0; i < lst.Count; i++)
            {
                lstcopy.Add(lst[i]);
            }
            return lstcopy;
        }
    }
}
