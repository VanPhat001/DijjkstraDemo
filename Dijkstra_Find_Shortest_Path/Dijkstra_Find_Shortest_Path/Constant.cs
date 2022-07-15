using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_Find_Shortest_Path
{
    public class Constant
    {
        #region Properties
        private const int btnHeight = 20;
        private const int btnWidth = 30;
        private const int rows = 21;
        private const int cols = 25;
        #endregion

        private Constant() { }

        private static Constant instance = null;
        public static Constant Instance
        {
            get
            {
                if (instance == null) instance = new Constant();
                return instance;
            }
            set { }
        }

        #region Getter
        public int BtnHeight => btnHeight;
        public int BtnWidth => btnWidth;
        public int Rows => rows;
        public int Cols => cols;
        #endregion

        public enum Status
        {
            Free,
            Trap,
            Start,
            End,
            Mark
        };

        public Color ConvertColor(Status status)
        {
            switch (status)
            {
                case Status.Free:  return Color.Gainsboro;
                case Status.Trap:  return Color.Red;
                case Status.Start: return Color.Green;
                case Status.End:   return Color.DarkSeaGreen;
                case Status.Mark:  return Color.Yellow;
            }

            return Color.Gray;
        }
    }
}