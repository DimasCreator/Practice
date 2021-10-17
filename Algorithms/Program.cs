using System;
using System.Threading.Channels;
using Algorithms.SimpleNumericAlgorithms;
using Algorithms.SortingAlgorithms;

Console.WriteLine("Hello from Algorithms");
int[] array1 = {1, 2, 3, 4, 5, 6, 7, 8, 9};
int[] array2 = {9, 8, 7, 6, 5, 4, 3, 2, 1};
int[] array3 = {1, 2, 3, 1, 2, 3, 1, 2, 3, 4, 5, 6, 7};
int[] array4 = {1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 7, 8, 9, 5, 6, 7};

Sorter.MergeSort(array1);
Sorter.MergeSort(array2);
Sorter.MergeSort(array3);
Sorter.MergeSort(array4);

////SortedTest
//Console.WriteLine("Insertion");
//int[] arrayInsertion1 = new[] { 2, 3, 4, 5, 3, 2, 32, 35, 234, 3234, 23452, 1, 2, 3, 4, 2, 4, 6, 7, 4, 3, 4, 5 };//Random sequence
//int[] arrayInsertion2 = new[] { 9, 9, 8, 8, 7, 7, 6, 6, 5, 5, 4, 4, 3, 3, 2, 2, 1, 1 };
//int[] arrayInsertion3 = new[] { 123, 421, 456, 32, 745, 3124, 856, 345, 865, 324, 12, 643, 865, 956, 235, 12, 547, 65, 432, 5347, 56 };//Random sequence
//int[] arrayInsertion4 = new[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5};//Only repeating elements
//int[] arrayInsertion5 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };//Sorted sequence
//int[] arrayInsertion6 = new[] { 1, 2, 3, 4, 5, 6, 6, 5, 4, 3, 2, 1, 1, 2, 3, 3, 2, 1 };
//int[] arrayInsertion7 = new[] { 1, 5, 4, 78, 4, 2, 5, 7, 4, 3, 2, 7, 5, 4, 3, 6, 4, 2, 6, 4, 3, 6, 7, 3, 2, 1, 6, 4, 6, 8, 4, 3, 1, 9, 7, 5 };//Random sequence
//int[] arrayInsertion8 = new[] { 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
//int[] arrayInsertion9 = new[] { 1, 4, 5, 3, 7, 8, 3, 5, 4, 2, 8, 5, 67, 321, 5432, 5374, 231, 754, 324, 11, 1, 11, 1, 1, 11, 1, 1111, 111, 1, 11, 10 };//Random sequence
//int[] arrayInsertion10 = new[] { 5, 2, 12, 634, 6548, 346, 4132, 5473, 3245, 457, 324, 4753, 124, 856, 34, 12, 745, 14, 745, 4132 };//Random sequence

//InsertionSort(arrayInsertion1);
//InsertionSort(arrayInsertion2);
//InsertionSort(arrayInsertion3);
//InsertionSort(arrayInsertion4);
//InsertionSort(arrayInsertion5);
//InsertionSort(arrayInsertion6);
//InsertionSort(arrayInsertion7);
//InsertionSort(arrayInsertion8);
//InsertionSort(arrayInsertion9);
//InsertionSort(arrayInsertion10);

//void InsertionSort(int[] array)
//{
//    Sorter.InsertionSort(array);
//    Print(array);
//}

//void Print(int[] array)
//{
//    foreach(var i in array)
//    {
//        Console.Write(i + " ");
//    }
//    Console.WriteLine();
//    Console.WriteLine();
//}