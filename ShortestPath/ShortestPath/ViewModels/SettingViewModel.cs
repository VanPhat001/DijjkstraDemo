using ShortestPath.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath.ViewModels
{
    public class SettingViewModel : INotifyPropertyChanged
    {
        private SettingModel _model;

        public int Rows
        {
            get => _model.Rows;
            set
            {
                _model.Rows = value;
                OnPropertyChanged(nameof(Rows));
            }
        }

        public int Cols
        {
            get => _model.Cols;
            set
            {
                _model.Cols = value;
                OnPropertyChanged(nameof(Cols));
            }
        }

        public SettingViewModel()
        {
            _model = new SettingModel();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
