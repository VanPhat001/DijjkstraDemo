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
    /// Interaction logic for StartOptionWindow.xaml
    /// </summary>
    public partial class StartOptionWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startOptionViewModel"></param>
        public StartOptionWindow(StartOptionViewModel startOptionViewModel)
        {
            InitializeComponent();

            this.DataContext = startOptionViewModel;

            #region set binding controls
            // set bind radioEmpty.IsChecked
            var bind1 = new Binding()
            {
                Source = startOptionViewModel,
                Path = new PropertyPath(nameof(startOptionViewModel.IsEmpty)),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(radioEmpty, RadioButton.IsCheckedProperty, bind1);
            
            // set bind radioTrap.IsChecked
            var bind2 = new Binding()
            {
                Source = startOptionViewModel,
                Path = new PropertyPath(nameof(startOptionViewModel.IsTrap)),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(radioTrap, RadioButton.IsCheckedProperty, bind2);

            // set bind radioEmpty.IsChecked
            var bind3 = new Binding()
            {
                Source = startOptionViewModel,
                Path = new PropertyPath(nameof(startOptionViewModel.IsStart)),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(radioStart, RadioButton.IsCheckedProperty, bind3);

            // set bind radioEnd.IsChecked
            var bind4 = new Binding()
            {
                Source = startOptionViewModel,
                Path = new PropertyPath(nameof(startOptionViewModel.IsEnd)),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(radioEnd, RadioButton.IsCheckedProperty, bind4);
            #endregion

        }

        private void Button_Click_FindPath(object sender, RoutedEventArgs e)
        {
            (this.DataContext as StartOptionViewModel).OnFindClick(sender);
        }

        private void Button_Click_ClearPath(object sender, RoutedEventArgs e)
        {
            (this.DataContext as StartOptionViewModel).OnClearPathClick(sender);
        }

        private void Button_Click_ClearMap(object sender, RoutedEventArgs e)
        {
            (this.DataContext as StartOptionViewModel).OnClearMapClick(sender);
        }
    }
}
