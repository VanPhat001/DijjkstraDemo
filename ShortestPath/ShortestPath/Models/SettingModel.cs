using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath.Models
{
    public class SettingModel
    {
        private int _rows;
        private int _cols;

        public int Rows
        {
            get => _rows;
            set
            {
                if (5 <= value && value <= 30) _rows = value;
            }
        }
        public int Cols
        {
            get => _cols;
            set
            {
                if (5 <= value && value <= 30) _cols = value;
            }
        }

        public SettingModel() 
        {
            Rows = 5;
            Cols = 5;
        }
    }
}
