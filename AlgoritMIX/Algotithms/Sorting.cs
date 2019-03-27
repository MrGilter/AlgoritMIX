using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritMIX.Algotithms
{
    class Sorting
    {
        // Сортировка пузырьком / Bubble sort
        public int[] Bubble_Sort(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas.Length - 1; j++)
                {
                    if (mas[j] > mas[j + 1])
                    {
                        swap(ref mas[j], ref mas[j + 1]);
                    }
                }
            }
            return mas;
        }

        // Шейкерная сортировка / Shaker sort
        public int[] Shaker_Sort(int[] mas)
        {
            int begin = 0;
            int end = mas.Length - 1;
            bool a = true;
            while (a)
            {
                a = false;
                begin++;
                for (int i = begin; i < end; i++)
                {
                    if (mas[i] > mas[i + 1])
                    {
                        swap(ref mas[i], ref mas[i + 1]);
                        a = true;
                    }
                }
                if (!a) { break; }
                end--;
                for (int i = end; i > begin; i--)
                {
                    if (mas[i] < mas[i - 1])
                    {
                        swap(ref mas[i], ref mas[i - 1]);
                        a = true;
                    }
                }


            }
            return mas;
        }

        //Сортировка расческой / Comb sort
        public int[] Comb_Sort(int[] mas)
        {
            int len = mas.Length;
            bool check = true;
            while (len > 1 || check)
            {
                check = false;
                if (len > 1)
                {
                    if (len == 2)
                    {
                        len = 1;
                    }
                    else
                    {
                        len = Convert.ToInt32(len / 1.24733);
                    }

                }

                for (int i = 0; i + len < mas.Length; i++)
                {
                    if (mas[i] > mas[i + len])
                    {
                        swap(ref mas[i], ref mas[i + len]);
                        check = true;
                    }
                }

            }
            return mas;
        }

        //Сортировка вставками / Insertion sort
        public int[] Insert_Sort(int[] mas)
        {
            int len = mas.Length;
            int buff = 0;
            for (int i = 1; i < len; i++)
            {
                int j = i - 1;
                buff = mas[i];
                while (j >= 0 && mas[j] > buff)
                {
                    mas[j + 1] = mas[j];
                    j -= 1;
                }
                mas[j + 1] = buff;
            }
            return mas;
        }

        //Сортировка Шелла / Shellsort
        public int[] Shell_Sort(int[] mas)
        {
            int D = mas.Length / 2;
            int j;
            while (D > 0)
            {
                for (int i = 0; i < mas.Length - D; i++)
                {
                    j = i;
                    while ((j >= 0) && mas[j] > mas[j + D])
                    {
                        swap(ref mas[j], ref mas[j + D]);
                        j = j - D;
                    }
                }
                D = D / 2;
            }
            return mas;
        }

        //Сортировка деревом / Tree sort
        public List<int> Tree_Sort(int[] mas)
        {
            int len = mas.Length;
            BinaryTree tree = new BinaryTree();
            foreach (int y in mas)
            {
                tree.Insert(y);
            }

            return tree.Return_sort();
        }
        class BinaryTree
        {
            public int? IntBox { get; set; }
            public int Kvo { get; set; }
            public BinaryTree Left_Node { get; set; }
            public BinaryTree Right_Node { get; set; }
            public BinaryTree Parent { get; set; }

            public List<int> Return_sort()
            {
                List<int> result = new List<int>();
                if (Left_Node != null)
                {
                    result.AddRange(Left_Node.Return_sort());
                }
                for (int i = 0; i < Kvo; i++)
                {
                    result.Add(Convert.ToInt32(IntBox));
                }
                if (Right_Node != null)
                {
                    result.AddRange(Right_Node.Return_sort());
                }
                return result;
            }

            public void Insert(int data)
            {
                if (IntBox == null || IntBox == data)
                {
                    IntBox = data;
                    Kvo++;
                    return;
                }

                if (this.IntBox > data)
                {
                    if (Left_Node == null)
                    {
                        Left_Node = new BinaryTree();

                    }
                    Insert(data, Left_Node, this);
                }
                else if (this.IntBox < data)
                {
                    if (Right_Node == null)
                    {
                        Right_Node = new BinaryTree();
                    }
                    Insert(data, Right_Node, this);
                }
            }

            public void Insert(int data, BinaryTree node, BinaryTree parent)
            {
                if (node.IntBox == null || node.IntBox == data)
                {
                    node.IntBox = data;
                    node.Kvo++;
                    node.Parent = parent;
                    return;
                }
                if (node.IntBox > data)
                {
                    if (node.Left_Node == null)
                    {
                        node.Left_Node = new BinaryTree();

                    }
                    Insert(data, node.Left_Node, node);
                }
                else
                {
                    if (node.Right_Node == null)
                    {
                        node.Right_Node = new BinaryTree();

                    }
                    Insert(data, node.Right_Node, node);
                }
            }
        }


        //Гномья сортировка / Gnome sort
        public int[] Gnome_Sort(int[] mas)
        {
            int len = mas.Length;

            int i = 0;
            while (i < len)
            {
                if (i == 0 || mas[i - 1] <= mas[i])
                {
                    i++;
                }
                else
                {
                    swap(ref mas[i], ref mas[i - 1]);
                    i--;
                }
            }
            return mas;
        }

        //Сортировка выбором / Selection sort
        public int[] Selection_Sort(int[] mas)
        {
            int len = mas.Length;

            for (int i = 0; i < len; i++)
            {
                int pos = i, min_z = mas[i];

                for (int j = i + 1; j < len; j++)
                {
                    if (mas[j] < min_z)
                    {
                        min_z = mas[j];
                        pos = j;
                    }
                }
                swap(ref mas[i], ref mas[pos]);
            }
            return mas;
        }

        //Пирамидальная сортировка / Heapsort
        public int[] Heap_Sort(int[] mas)
        {
            //Build virtual tree
            for (int i = mas.Length / 2 - 1; i >= 0; i--)
            {
                sortH(ref mas, i, mas.Length);
            }
            int b = mas.Length;
            for (int j = mas.Length - 1; j >= 0; j--)
            {
                swap(ref mas[0], ref mas[j]);
                b--;

                for (int i = mas.Length / 2; i >= 0; i--)
                {
                    sortH(ref mas, i, b);
                }
            }



            return mas;
        }
        private void sortH(ref int[] mas, int i, int len)
        {
            if ((2 * i + 2) < len)
            {
                if (mas[2 * i + 2] > mas[2 * i + 1])
                {
                    if (mas[i] < mas[2 * i + 2])
                    {
                        swap(ref mas[2 * i + 2], ref mas[i]);
                    }

                }
                else
                {
                    if (mas[i] < mas[2 * i + 1])
                    {
                        swap(ref mas[2 * i + 1], ref mas[i]);
                    }
                }

            }
            else if ((2 * i + 1) < len)
            {
                if (mas[i] < mas[2 * i + 1])
                {
                    swap(ref mas[2 * i + 1], ref mas[i]);
                }
            }
            else
            {
                return;
            }
        }

        //Быстрая сортировка / Quicksort
        public int[] Quick_Sort(int[] mas, int a0, int aN)
        {
            int center = mas[(a0 + aN) / 2];
            int left = a0, right = aN;
            while (left <= right)
            {
                while (mas[left] < center && left <= aN)
                {
                    left++;
                }
                while (mas[right] > center && right >= a0)
                {
                    right--;
                }
                if (left <= right)
                {
                    swap(ref mas[left], ref mas[right]);
                    left++; right--;
                }
            }
            if (right > a0)
            {
                mas = Quick_Sort(mas, a0, right);
            }
            if (left < aN)
            {
                mas = Quick_Sort(mas, left, aN);
            }




            return mas;
        }


        //Поразрядная сортировка / Radix sort
        // LSD
        private int maxZ(int[] mas)
        {
            int z = 0;
            int l = mas.Length;
            for (int i = 0; i < l; i++)
            {
                if (mas[i] > z)
                {
                    z = mas[i];
                }
            }
            return z;
        }
        private int width(int z)
        {
            //Количество разрядов
            int w = 0;
            while (z != 0)
            {
                z = z / 10;
                w++;
            }
            return w;
        }
        public int[] Radix_LSD_sort(int[] mas)
        {
            List<List<int>> radix_lists = new List<List<int>>();

            for (int ii = 0; ii <= 19; ii++)
            {
                radix_lists.Add(new List<int>());
            }

            int[] buff = new int[mas.Length - 1];

            int razrad = width(maxZ(mas));
            int l = mas.Length;
            int item, p = 0; ;

            for (int i = 0; i < razrad; i++)
            {
                for (int i_m = 0; i_m < l; i_m++)
                {
                    item = mas[i_m];
                    for (int j = 0; j < i; j++)
                    {
                        item = item / 10;
                    }
                    item = item % 10;
                    if (mas[i_m] >= 0)
                    {
                        radix_lists[item + 10].Add(mas[i_m]);
                    }
                    else
                    {
                        radix_lists[item + 10].Insert(0, mas[i_m]);
                    }
                }

                p = 0;
                for (int i1 = 0; i1 < 19; i1++)
                {
                    foreach (int t in radix_lists[i1])
                    {
                        mas[p] = t;
                        p++;
                    }
                }
                for (int o = 0; o < 19; o++)
                {
                    radix_lists[o].Clear();
                }
            }
            return mas;
        }

        private static void swap(ref int i, ref int j)
        {
            int mem = i;
            i = j;
            j = mem;
        }

    }
}
