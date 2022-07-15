using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShortestPath.Algorithm
{
    public class DijkstraAlgorithm
    {
        private Graph _graph;
        private int[] _cost;
        private int[] _parent;
        private bool[] _mark;

        public static readonly int oo = 999999;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        public DijkstraAlgorithm(Graph graph)
        {
            _graph = graph;

            _cost = new int[graph.Vertices];
            _parent = new int[graph.Vertices];
            _mark = new bool[graph.Vertices];
        }

        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            for (int i = 0; i < _graph.Vertices; i++)
            {
                _cost[i] = oo;
                _parent[i] = -1;
                _mark[i] = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private void Process(int start, int end)
        {
            _cost[start] = 0;
            for (int i = 1; i < _graph.Vertices; i++)
            {
                int u = -1, min = oo;
                for (int k = 0; k < _graph.Vertices; k++)
                {
                    if (!_mark[k] && min > _cost[k])
                    {
                        min = _cost[k];
                        u = k;
                    }
                }

                if (u == -1) return;
                if (u == end) return;
                _mark[u] = true;

                for (int v = 0; v < _graph.Vertices; v++)
                {
                    if (!_mark[v] && _graph[u, v] == 1 && _cost[u] + _graph[u, v] < _cost[v])
                    {
                        _cost[v] = _cost[u] + _graph[u, v];
                        _parent[v] = u;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int[] Start(int start, int end)
        {
            Init();
            Process(start, end);
            return _parent;
        }
    }
}
