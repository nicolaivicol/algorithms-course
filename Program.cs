using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1_Week1_PA1
{
    class Program
    {
        static void Main(string[] args)
        {
            // read file with integers
            string filename = @"E:\courses\algorithms I\week 1\hw\IntegerArray.txt";
            //string filename = @"E:\courses\algorithms I\week 1\hw\IntegerArrayCheck_15.txt";
            List<int> lst = new List<int>();
            List<int> lst_copy1 = new List<int>();
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    int x = Convert.ToInt32(sr.ReadLine());
                    lst.Add(x);
                    lst_copy1.Add(x);
                }
            }
            MergeSort.DoMergeSort(lst);
            Console.WriteLine("errors in sorting: {0}", MergeSort.CheckIfSorted(lst));

            long cntInv = MergeSort.DoMergeSortCountInv(lst_copy1);
            Console.WriteLine("inversions: {0}", cntInv);

            Console.ReadLine();

        }
    }
}
