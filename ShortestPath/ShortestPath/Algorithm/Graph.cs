using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath.Algorithm
{
    public class Graph
    {
        private int[,] _matrix;
        private int _vertices;

        public int this[int row, int col]
        {
            get => _matrix[row, col];
            set => _matrix[row, col] = value;
        }

        public Graph(int vertices)
        {
            Vertices = vertices;

            _matrix = new int[vertices, vertices];
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    _matrix[i, j] = 0;
                }
            }
        }

        public int Vertices { get => _vertices; set => _vertices = value; }
    }
}
