using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1_Week1_PA1
{
    class MergeSort
    {
        public static void DoMergeSort(List<int> lst)
        {
            List<int> lstbox = new List<int>();
            for (int i = 0; i < lst.Count; i++)
            {
                lstbox.Add(0);
            }
            DoMergeSort(ref lst, ref lstbox, 0, lst.Count - 1);
            return;
        }
        private static void DoMergeSort(ref List<int> lst, ref List<int> lstbox, int s, int e)
        {
            if ((e - s) == 0) // one element
                return;
            int s_l = s;
            int e_l = (s + e) / 2;
            int s_r = (s + e) / 2 + 1;
            int e_r = e;

            DoMergeSort(ref lst, ref lstbox, s_l, e_l);
            DoMergeSort(ref lst, ref lstbox, s_r, e_r);
            Merge(ref lst, ref lstbox, s_l, e_l, s_r, e_r);
        }
        private static void Merge(ref List<int> lst, ref List<int> lstbox, int s_l, int e_l, int s_r, int e_r)
        {
            int i_l = s_l;
            int i_r = s_r;
            for (int i = s_l; i <= e_r; i++)
            {

                if ((i_r > e_r) || ((lst[i_l] < lst[i_r]) && (i_l <= e_l)))
                {
                    lstbox[i] = lst[i_l];
                    i_l++;
                }
                else if ((i_l > e_l) || ((lst[i_l] >= lst[i_r]) && (i_r <= e_r)))
                {
                    lstbox[i] = lst[i_r];
                    i_r++;
                }
            }
            for (int i = s_l; i <= e_r; i++)
            {
                lst[i] = lstbox[i];
            }

        }
        public static int CheckIfSorted(List<int> lst)
        {
            int cnt = 0;
            for (int i = 0; i < (lst.Count - 1); i++)
            {
                if (lst[i] > lst[i + 1])
                    cnt++;
            }
            return cnt;
        }

        public static long DoMergeSortCountInv(List<int> lst)
        {
            List<int> lstbox = new List<int>();
            for (int i = 0; i < lst.Count; i++)
            {
                lstbox.Add(0);
            }
            long cntInv = 0;
            DoMergeSortCountInv(ref lst, ref lstbox, ref cntInv, 0, lst.Count - 1);
            return cntInv;
        }
        private static void DoMergeSortCountInv(ref List<int> lst, ref List<int> lstbox, ref long cntInv, int s, int e)
        {
            if ((e - s) == 0) // one element
                return;
            int s_l = s;
            int e_l = (s + e) / 2;
            int s_r = (s + e) / 2 + 1;
            int e_r = e;

            DoMergeSortCountInv(ref lst, ref lstbox, ref cntInv, s_l, e_l);
            DoMergeSortCountInv(ref lst, ref lstbox, ref cntInv, s_r, e_r);
            MergeCountInv(ref lst, ref lstbox, ref cntInv, s_l, e_l, s_r, e_r);
        }
        private static void MergeCountInv(ref List<int> lst, ref List<int> lstbox, ref long cntInv, int s_l, int e_l, int s_r, int e_r)
        {
            int i_l = s_l;
            int i_r = s_r;
            for (int i = s_l; i <= e_r; i++)
            {

                if ((i_r > e_r) || ((lst[i_l] < lst[i_r]) && (i_l <= e_l)))
                {
                    lstbox[i] = lst[i_l];
                    i_l++;
                }
                else if ((i_l > e_l) || ((lst[i_l] >= lst[i_r]) && (i_r <= e_r)))
                {
                    lstbox[i] = lst[i_r];
                    i_r++;
                    cntInv = cntInv + (e_l - i_l + 1);
                }
            }
            for (int i = s_l; i <= e_r; i++)
            {
                lst[i] = lstbox[i];
            }
        }


    }
}
