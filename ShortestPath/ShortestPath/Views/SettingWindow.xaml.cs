using ShortestPath.ViewModels;
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
using System.Windows.Shapes;

namespace ShortestPath.Views
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow(SettingViewModel settingViewModel)
        {
            InitializeComponent();

            DataContext = settingViewModel;

            var bind1 = new Binding()
            {
                Source = settingViewModel,
                Path = new PropertyPath( nameof(settingViewModel.Rows)),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(sliderRows, Slider.ValueProperty, bind1);


            var bind2 = new Binding()
            {
                Source = settingViewModel,
                Path = new PropertyPath(nameof(settingViewModel.Cols)),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(sliderCols, Slider.ValueProperty, bind2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
