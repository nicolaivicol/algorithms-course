using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1_Week2
{
    public class QuickSort
    {
        public enum Pivot
        {
            First,
            Last,
            Median
        }

        public static void DoQuickSort(List<int> lst, Pivot piv)
        {
            DoQuickSort(ref lst, 0, lst.Count - 1, piv);
        }
        public static int DoQuickSortCnt(List<int> lst, Pivot piv)
        {
            int cnt = 0;
            DoQuickSort(ref lst, ref cnt, 0, lst.Count - 1, piv);
            return cnt;
        }

        private static void DoQuickSort(ref List<int> lst, int l, int r, Pivot piv)
        {
            if ((r - l) < 1)
                return;
            int p = ChoosePivot(lst, l, r, piv);
            int i = Partition(ref lst, l, r);
            DoQuickSort(ref lst, l, i - 1, piv);
            DoQuickSort(ref lst, i + 1, r, piv);
        }
        private static void DoQuickSort(ref List<int> lst, ref int cnt, int l, int r, Pivot piv)
        {
            if ((r - l) < 1)
                return;
            int p = ChoosePivot(lst, l, r, piv);
            int i = Partition(ref lst, l, r);
            cnt = cnt + (r - l);
            DoQuickSort(ref lst, ref cnt, l, i - 1, piv);
            DoQuickSort(ref lst, ref cnt, i + 1, r, piv);
        }

        private static int ChoosePivot(List<int> lst, int l, int r, Pivot piv)
        {
            int piv_i = l;
            if (piv == Pivot.First)
                piv_i = l;
            else if (piv == Pivot.Last)
                piv_i = r;
            else if (piv == Pivot.Median)
            {
                if ((lst[r] <= lst[l] && lst[l] <= lst[(l + r) / 2]) || (lst[r] >= lst[l] && lst[l] >= lst[(l + r) / 2]))
                    piv_i = l;
                else if ((lst[l] <= lst[r] && lst[r] <= lst[(l + r) / 2]) || (lst[l] >= lst[r] && lst[r] >= lst[(l + r) / 2]))
                    piv_i = r;
                else
                    piv_i = (l + r) / 2;
            }
            Swap(ref lst, l, piv_i);
            return lst[l];
        }
        private static int Partition(ref List<int> lst, int l, int r)
        {
            int p = lst[l];
            int i = l + 1;
            for (int j = l + 1; j <= r; j++)
            {
                if (lst[j] < p)
                {
                    Swap(ref lst, i, j);
                    i++;
                }
            }
            Swap(ref lst, l, i - 1);
            return i - 1;
        }
        private static void Swap(ref List<int> lst, int i1, int i2)
        {
            int misc = lst[i1];
            lst[i1] = lst[i2];
            lst[i2] = misc;
        }

    }
}
