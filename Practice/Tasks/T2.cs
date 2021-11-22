using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice.Tasks
{
    public static class T2
    {
        //Написать код для разбиения на чанки
        //Задача с собеседования на стажировку Касперского
        public static IEnumerable<ICollection<T>> GetChunks<T>(this IEnumerable<T> source, int chunkSize)
        {
            List<List<T>> chunksList = new List<List<T>>();
            chunksList.Add(new List<T>());
            int indexRow = 0;
            int currentChunkElementIndex = 0;
            foreach (var i in source)
            {
                if (currentChunkElementIndex == chunkSize)
                {
                    yield return chunksList[indexRow];
                    indexRow++;
                    currentChunkElementIndex = 0;
                    chunksList.Add(new List<T>());
                }
                chunksList[indexRow].Add(i);
                currentChunkElementIndex++;
            }
            yield return chunksList[indexRow];
        }
        //Может более верное для yield
        public static IEnumerable<ICollection<T>> GetChunks2<T>(this IEnumerable<T> source, int chunkSize)
        {
            int currentChunkElementIndex = 0;
            LinkedList<T> list = new LinkedList<T>();
            foreach (var i in source)
            {
                if (currentChunkElementIndex == chunkSize)
                {
                    yield return list;
                    list.Clear();
                    currentChunkElementIndex = 0;
                }
                list.AddLast(i);
                currentChunkElementIndex++;
            }
            if (list.Count != 0) yield return list;
        }
        
        //Решение без yield с связанным списком
        public static IEnumerable<ICollection<T>> GetChunks3<T>(this IEnumerable<T> source, int chunkSize)
        {
            LinkedList<LinkedList<T>> chunkList = new LinkedList<LinkedList<T>>();
            int currentChunkElementIndex = 0;
            LinkedList<T> currentChunkList = chunkList.AddLast(new LinkedList<T>()).Value;
            foreach (var i in source)
            {
                if (currentChunkElementIndex >= chunkSize)
                {
                    currentChunkElementIndex = 0;
                    currentChunkList = chunkList.AddLast(new LinkedList<T>()).Value;
                }
                currentChunkList.AddLast(i);
                currentChunkElementIndex++;
            }
            return chunkList;
        }
        
        public static void Task()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            var chunks = GetChunks3(list, 4);
            foreach (var chunk in chunks)
            {
                foreach (var item in chunk)
                {
                    Console.Write("{0} ", item);
                }
                Console.WriteLine();
            }
// Expected output:
// 1 2 3 4
// 5 6 7 8
// 9 10 11
        }
    }
}