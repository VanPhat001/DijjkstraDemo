using ShortestPath.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShortestPath.Algorithm
{
    public class ConvertBoardToGraph
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Graph Convert(Board board, out Point start, out Point end)
        {
            start = new Point(-1, -1);
            end = new Point(-1, -1);

            int rows = board.Rows;
            int cols = board.Cols;
            Graph graph = new Graph(rows * cols);

            int[] moveX = { 0, 1, 0, -1 };
            int[] moveY = { -1, 0, 1, 0 };

            CellEnums status1, status2;
            int r2, c2, index1, index2;

            #region build graph
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    index1 = board.GetIndex(y: r, x: c);
                    status1 = board.GetCellStatus(y: r, x: c);
                    if (status1 == CellEnums.Start)
                    {
                        if (start.X != -1) throw new Exception();
                        start.X = c;
                        start.Y = r;
                    }
                    else if (status1 == CellEnums.End)
                    {
                        if (end.X != -1) throw new Exception();
                        end.X = c;
                        end.Y = r;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        r2 = r + moveX[i];
                        c2 = c + moveY[i];
                        if (!board.CheckRange(y: r2, x: c2)) continue;

                        status2 = board.GetCellStatus(y: r2, x: c2);
                        index2 = board.GetIndex(y: r2, x: c2);

                        switch (status2)
                        {
                            case CellEnums.Start:
                            case CellEnums.End:
                            case CellEnums.Empty:
                                graph[index1, index2] = 1;
                                break;
                            case CellEnums.Trap:
                                graph[index1, index2] = -1;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            #endregion

            if (start.X == -1 || end.X == -1) throw new Exception();

            return graph;
        }


    }
}
