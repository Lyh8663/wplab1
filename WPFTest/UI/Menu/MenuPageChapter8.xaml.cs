using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTest.UI.Menu
{
    /// <summary>
    /// MenuPageChapter1.xaml 的交互逻辑
    /// </summary>
    public partial class MenuPageChapter8 : ChildPage
    {
        public MenuPageChapter8()
        {
            InitializeComponent();
        }

        private void ChildPage_Loaded(object sender, RoutedEventArgs e)
        {
            FireNextEvent("chapter8_sy1");
        }

        private void sy1_Click(object sender, RoutedEventArgs e)
        {
            FireNextEvent("chapter8_sy1");
        }

        private void sy2_Click(object sender, RoutedEventArgs e)
        {
            FireNextEvent("chapter8_sy2");
        }

      
    }
}
