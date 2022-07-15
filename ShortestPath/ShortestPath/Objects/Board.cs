using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ShortestPath.Objects
{
    public class Board
    {
        private Cell[,] _cells;
        private Grid _parent;

        #region cell click event
        private event EventHandler _cellClick;
        public event EventHandler CellClick
        {
            add => _cellClick += value;
            remove => _cellClick -= value;
        }
        private void OnCellClick(object sender)
        {
            this._cellClick?.Invoke(sender, new EventArgs());
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public Board(Grid parent, int rows, int cols)
        {
            _cells = new Cell[rows, cols];
            _parent = parent;

            _parent.Children.Clear();
            _parent.RowDefinitions.Clear();
            _parent.ColumnDefinitions.Clear();

            for (int i = 0; i < rows; i++)
            {
                _parent.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < cols; i++)
            {
                _parent.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task FillBoard()
        {
            Cell cell;
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    cell = new Cell(x: c, y: r, status: CellEnums.Empty);
                    _cells[r, c] = cell;
                    _parent.Children.Add(cell);
                    Grid.SetRow(cell, r);
                    Grid.SetColumn(cell, c);

                    cell.Click += Cell_Click;
                }
                await Task.Delay(1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cell_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnCellClick(sender);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task ResetBoard()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    _cells[r, c].Status = CellEnums.Empty;
                }
                await Task.Delay(1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearBoard()
        {
            _parent.Children.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task ClearPath()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (_cells[r, c].Status == CellEnums.Choose)
                    {
                        _cells[r, c].Status = CellEnums.Empty;
                    }
                }
                await Task.Delay(1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public CellEnums GetCellStatus(int x, int y)
        {
            return _cells[y, x].Status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="status"></param>
        public void SetCellStatus(int x, int y, CellEnums status)
        {
            _cells[y, x].Status = status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int GetIndex(int x, int y)
        {
            return y * Cols + x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetRow(int index)
        {
            return index / Cols;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetCol(int index)
        {
            return index % Cols;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool CheckRange(int x, int y)
        {
            return 0 <= x && x < Cols
                && 0 <= y && y < Rows;
        }

        public int Rows => _cells.GetLength(0);
        public int Cols => _cells.GetLength(1);
        public Grid Parent => _parent;
    }
}
