using System;
using System.Collections;
using System.Text;

namespace DataStructures.Graph
{
    public class MyGraph
    {
        private BitMatrix data;
        private int numberNodes;
        private int numberEdges;
        private int[] numberNeighbors;

        public MyGraph(string graphFile, string fileFormat)
        {
            if (fileFormat.ToUpper() == "DIMACS")
                LoadDimacsFormatGraph(graphFile);
            else
                throw new Exception("Format " + fileFormat + " not supported");
        }

        private void LoadDimacsFormatGraph(string graphFile)
        {
            // Сюда помещается код  
        }

        public int NumberNodes
        {
            get { return this.numberNodes; }
        }

        public int NumberEdges
        {
            get { return this.numberEdges; }
        }

        public int NumberNeighbors(int node)
        {
            return this.numberNeighbors[node];
        }

        public bool AreAdjacent(int nodeA, int nodeB)
        {
            return data[nodeA, nodeB];
        }

        public override string ToString()
        {
            return "";
        }

        public static void ValidateGraphFile(string graphFile, string fileFormat)
        {
            if (fileFormat.ToUpper() == "DIMACS")
                ValidateDimacsGraphFile(graphFile);
            else
                throw new Exception("Format " + fileFormat + " not supported");
        }

        public static void ValidateDimacsGraphFile(string graphFile)
        {
            // Сюда помещается код  
        }

        public void ValidateGraph()
        {
            // Сюда помещается код   
        }

        // -------------------------------------------------------------------
        private class BitMatrix
        {
            private BitArray[] _data;
            public readonly int Dim;

            public bool this[int row, int col]
            {
                get => _data[row][col];
                set => _data[row][col] = value;
            }

            public BitMatrix(int n)
            {
                _data = new BitArray[n];
                for (int i = 0; i < _data.Length; ++i)
                {
                    _data[i] = new BitArray(n);
                }

                Dim = n;
            }

            public override string ToString()
            {
                StringBuilder s = new StringBuilder();
                for (int i = 0; i < _data.Length; ++i)
                {
                    for (int j = 0; j < _data[i].Length; ++j)
                    {
                        s.Append(_data[i][j] ? "1 " : "0 ");
                    }

                    s.Append(Environment.NewLine);
                }

                return s.ToString();
            }
        }
    }
}