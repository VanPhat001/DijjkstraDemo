using ShortestPath.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath.ViewModels
{
    public class StartOptionViewModel : INotifyPropertyChanged
    {
        private CellEnums _status;
        private bool _isEmpty;
        private bool _isTrap;
        private bool _isStart;
        private bool _isEnd;

        private event EventHandler _findClick;
        private event EventHandler _clearPathClick;
        private event EventHandler _clearMapClick;


        public void OnFindClick(object sender)
        {
            _findClick?.Invoke(sender, new EventArgs());
        }
        public void OnClearPathClick(object sender)
        {
            _clearPathClick?.Invoke(sender, new EventArgs());
        }
        public void OnClearMapClick(object sender)
        {
            _clearMapClick?.Invoke(sender, new EventArgs());
        }

        public event EventHandler FindClick
        {
            add => _findClick += value;
            remove => _findClick -= value;
        }
        public event EventHandler ClearPathClick
        {
            add => _clearPathClick += value;
            remove => _clearPathClick -= value;
        }
        public event EventHandler ClearMapClick
        {
            add => _clearMapClick += value;
            remove => _clearMapClick -= value;
        }

        /// <summary>
        /// 
        /// </summary>
        public StartOptionViewModel()
        {
            IsEmpty = true;
            IsTrap = false;
            IsStart = false;
            IsEnd = false;
        }

        public bool IsEmpty
        {
            get => _isEmpty;
            set
            {
                _isEmpty = value;
                OnPropertyChanged(nameof(IsEmpty));
                if (value) Status = CellEnums.Empty;
            }
        }
        public bool IsTrap
        {
            get => _isTrap;
            set
            {
                _isTrap = value;
                OnPropertyChanged(nameof(IsTrap));
                if (value) Status = CellEnums.Trap;
            }
        }
        public bool IsStart
        {
            get => _isStart;
            set
            {
                _isStart = value;
                OnPropertyChanged(nameof(IsStart));
                if (value) Status = CellEnums.Start;
            }
        }
        public bool IsEnd
        {
            get => _isEnd;
            set
            {
                _isEnd = value;
                OnPropertyChanged(nameof(IsEnd));
                if (value) Status = CellEnums.End;
            }
        }

        public CellEnums Status
        {
            get => _status;
            private set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
