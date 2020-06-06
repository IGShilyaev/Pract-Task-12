using System;

namespace PractTask12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Быстрая сортировка:");
            SortWithQuickSort();
            Console.WriteLine();
            Console.WriteLine("Сортировка с помощью двоичного дерева:");
            SortWithTree();
        }

        static void QuickSort(ref int[] arr, int left, int right, ref int rc, ref int cc)
        {
            if (left<right)
            {
                int mark = PartMark(arr, left, right, ref rc, ref cc);
                QuickSort(ref arr, left, mark, ref rc, ref cc);
                QuickSort(ref arr, mark + 1, right, ref rc, ref cc);
            }
        }

        static int PartMark(int[] arr, int left, int right, ref int rc, ref int cc)
        {
            int mid = arr[(left + right) / 2];
            int i = left;
            int j = right;
            while (i < j)
            {
                while (arr[i] < mid)
                { i++; cc++; }
                while (arr[j] > mid)
                { j--; cc++; }
                if (i >= j) break;
                SwapItems(ref arr, i, j);
                rc++;
                cc += 2;
                i++;
                j--;
            }
            return j;
        }
        
        static void SwapItems(ref int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
            return;
        }

        static void SortWithQuickSort()
        {
            int[] arr1 = { 7, 5, -5, 14, 3, 0, 0, -7, 8, -5 };
            int replaceCounter = 0;
            int compareCounter = 0;
            QuickSort(ref arr1, 0, arr1.Length - 1, ref replaceCounter, ref compareCounter);
            Console.WriteLine("Неупорядоченный массив (10 элементов)");
            foreach (int x in arr1) Console.Write(x + " ");
            Console.WriteLine();
            Console.WriteLine($"Количество перестановок: {replaceCounter}");
            Console.WriteLine($"Количество сравнений: {compareCounter}");

            replaceCounter = 0;
            compareCounter = 0;
            int[] arr2 = { -10, -9, -9, -3, 0, 0, 2, 2, 5, 10 };
            QuickSort(ref arr2, 0, arr2.Length - 1, ref replaceCounter, ref compareCounter);
            Console.WriteLine("Упорядоченный по возрастанию массив (10 элементов)");
            foreach (int x in arr2) Console.Write(x + " ");
            Console.WriteLine();
            Console.WriteLine($"Количество перестановок: {replaceCounter}");
            Console.WriteLine($"Количество сравнений: {compareCounter}");

            replaceCounter = 0;
            compareCounter = 0;
            int[] arr3 = { 10, 5, 2, 2, 0, -1, -1, -1, -5, -10 };
            QuickSort(ref arr3, 0, arr3.Length - 1, ref replaceCounter, ref compareCounter);
            Console.WriteLine("Упорядоченный по убыванию массив (10 элементов)");
            foreach (int x in arr3) Console.Write(x + " ");
            Console.WriteLine();
            Console.WriteLine($"Количество перестановок: {replaceCounter}");
            Console.WriteLine($"Количество сравнений: {compareCounter}");
        }

        static void SortWithTree()
        {
            int replaceCounter = 0;
            int compareCounter = 0;
            int[] arr1 = { 7, 5, -5, 14, 3, 0, 0, -7, 8, -5 };
            MyFindTree<int> dTree = new MyFindTree<int>(ref compareCounter, arr1);
            int index = 0;
            foreach (int x in dTree) { arr1[index] = x; replaceCounter++; index++; }
            foreach (int x in arr1) Console.Write(x + " ");
            Console.WriteLine();
            Console.WriteLine($"Количество перестановок: {replaceCounter}");
            Console.WriteLine($"Количество сравнений: {compareCounter}");

            replaceCounter = 0;
            compareCounter = 0;
            int[] arr2 = { -10, -9, -9, -3, 0, 0, 2, 2, 5, 10 };
            dTree = new MyFindTree<int>(ref compareCounter, arr2);
            Console.WriteLine("Упорядоченный по возрастанию массив (10 элементов)");
            index = 0;
            foreach (int x in dTree) { arr2[index] = x; replaceCounter++; index++; }
            foreach (int x in arr2) Console.Write(x + " ");
            Console.WriteLine();
            Console.WriteLine($"Количество перестановок: {replaceCounter}");
            Console.WriteLine($"Количество сравнений: {compareCounter}");

            replaceCounter = 0;
            compareCounter = 0;
            int[] arr3 = { 10, 5, 2, 2, 0, -1, -1, -1, -5, -10 };
            dTree = new MyFindTree<int>(ref compareCounter, arr3);
            Console.WriteLine("Упорядоченный по убыванию массив (10 элементов)");
            index = 0;
            foreach (int x in dTree) { arr3[index] = x; replaceCounter++; index++; }
            foreach (int x in arr3) Console.Write(x + " ");
            Console.WriteLine();
            Console.WriteLine($"Количество перестановок: {replaceCounter}");
            Console.WriteLine($"Количество сравнений: {compareCounter}");
        }
    }
}
