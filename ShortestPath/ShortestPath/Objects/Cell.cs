using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ShortestPath.Objects
{
    public enum CellEnums
    {
        Empty,
        Choose,
        Trap,
        Start,
        End
    }


    public class Cell : Button
    {
        private Point _locate;
        private CellEnums _status;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="status"></param>
        public Cell(int x, int y, CellEnums status = CellEnums.Empty)
        {
            Locate = new Point(x, y);
            Status = status;
        }



        public Point Locate { get => _locate; private set => _locate = value; }
        public CellEnums Status
        {
            get => _status;
            set
            {
                switch (value)
                {
                    case CellEnums.Empty:
                        Background = Brushes.White;
                        break;

                    case CellEnums.Choose: 
                        Background = Brushes.Blue;
                        break;

                    case CellEnums.Trap:
                        Background = Brushes.Red;
                        break;

                    case CellEnums.Start:
                        Background = Brushes.LightGreen;
                        break;

                    case CellEnums.End:
                        Background = Brushes.DarkGreen;
                        break;

                    default:
                        throw new Exception();
                }
                _status = value;
            }
        }

        public new object Content { get => base.Content; private set => base.Content = value; }

    }

}
