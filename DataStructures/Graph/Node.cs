using System.Collections.Generic;

namespace DataStructures.Graph
{
    public class Node<T>
    {
        public T Data { get; set; }
        public List<Edge<T>> Connections = new List<Edge<T>>();
    }
}