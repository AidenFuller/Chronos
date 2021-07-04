using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos
{
    public static class Utilities
    {
        public static void Swap<T>(IList<T> list, int index1, int index2)
        {
            T tmp = list[index1];
            list[index1] = list[index2];
            list[index2] = tmp;
        }

        public static void SwapValues<T>(List<List<T>> list, T item1, T item2)
        {
            List<T> list1 = list.First(l => l.Contains(item1));
            List<T> list2 = list.First(l => l.Contains(item2));

            int idx1 = list1.IndexOf(item1);
            int idx2 = list2.IndexOf(item2);

            list1[idx1] = item2;
            list2[idx2] = item1;
        }
    }
}
