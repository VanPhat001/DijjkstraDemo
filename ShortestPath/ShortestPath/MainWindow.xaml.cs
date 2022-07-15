using ShortestPath.Algorithm;
using ShortestPath.Objects;
using ShortestPath.ViewModels;
using ShortestPath.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShortestPath
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board _board;
        private SettingViewModel _settingViewModel;
        private StartOptionViewModel _startOptionViewModel;

        

        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _settingViewModel = new SettingViewModel() { Rows = 5, Cols = 5 };
            _startOptionViewModel = new StartOptionViewModel();
            _board = new Board(mainboard, _settingViewModel.Rows, _settingViewModel.Cols);

            await _board.FillBoard();
            _board.CellClick += _board_CellClick;
            _startOptionViewModel.FindClick += _startOptionViewModel_FindClick;
            _startOptionViewModel.ClearPathClick += _startOptionViewModel_ClearPathClick;
            _startOptionViewModel.ClearMapClick += _startOptionViewModel_ClearMapClick;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void _startOptionViewModel_ClearMapClick(object sender, EventArgs e)
        {
            await _board.ResetBoard();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void _startOptionViewModel_ClearPathClick(object sender, EventArgs e)
        {
            await _board.ClearPath();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void _startOptionViewModel_FindClick(object sender, EventArgs e)
        {
            await _board?.ClearPath();

            Point start, end;
            Graph graph;

            #region convert data
            try
            {
                graph = ConvertBoardToGraph.Convert(_board, out start, out end);
            }
            catch
            {
                MessageBox.Show("Graph is not valid");
                return;
            }
            #endregion 

            int startIndex = _board.GetIndex((int)start.X, (int)start.Y);
            int endIndex = _board.GetIndex((int)end.X, (int)end.Y);

            #region find shortest path
            DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(graph);
            int[] parents = dijkstra.Start(startIndex, endIndex);
            if (parents[endIndex] == -1)
            {
                MessageBox.Show("can't solve");
            }
            #endregion

            #region trace path
            int index = endIndex, row, col;
            Stack<Point> stack = new Stack<Point>();
            while (true)
            {
                index = parents[index];
                if (index == -1 || index == startIndex) break;

                row = _board.GetRow(index);
                col = _board.GetCol(index);
                stack.Push(new Point(col, row));
            }
            #endregion

            #region show animation
            while (stack.Count > 0)
            {
                Point point = stack.Pop();
                _board.SetCellStatus((int)point.X, (int)point.Y, CellEnums.Choose);
                await Task.Delay(10);
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void _board_CellClick(object sender, EventArgs e)
        {
            //MessageBox.Show(_startOptionViewModel.Status.ToString());
            Cell cell = sender as Cell;
            cell.Status = _startOptionViewModel.Status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void ShowMessage(string message)
        {
            Task.Run(() =>
            {
                MessageBox.Show(message);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_Start(object sender, RoutedEventArgs e)
        {
            StartOptionWindow startWindow = new StartOptionWindow(_startOptionViewModel);
            startWindow.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MenuItem_Click_Setting(object sender, RoutedEventArgs e)
        {
            SettingWindow settingWindow = new SettingWindow(_settingViewModel);

            settingWindow.ShowDialog();

            _board?.ClearBoard();
            _board = new Board(mainboard, _settingViewModel.Rows, _settingViewModel.Cols);
            await _board.FillBoard();
            _board.CellClick += _board_CellClick;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
