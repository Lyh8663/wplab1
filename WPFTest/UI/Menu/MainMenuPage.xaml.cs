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
    /// TopMenuPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainMenuPage : ChildPage
    {
        public MainMenuPage()
        {
            m_iChapter  = 0;

            m_objectCur = null;

            InitializeComponent();
        }

        int     m_iChapter;

        private object m_objectCur;
        public object ObjectCur { get { return m_objectCur; } set { m_objectCur = value; } }

        private void set_label_foreground ()
        {
////            label2.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
//            label3.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
//            label4.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
//            label5.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
//            label6.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
//            label7.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
//            label8.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
//            label9.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
//            label10.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));

//            switch (m_iChapter)
//            {
//                case 0:
//                    break;

//                case 1:
//                    break;

//                case 2:
////                    label2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
//                    break;

//                case 3:
//                    label3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
//                    break;

//                case 4:
//                    label4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
//                    break;

//                case 5:
//                    label5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
//                    break;

//                case 6:
//                    label6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
//                    break;

//                case 7:
//                    label7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
//                    break;

//                case 8:
//                    label8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
//                    break;

//                case 9:
//                    label9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
//                    break;

//                case 10:
//                    label10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
//                    break;

//                default:
//                    break;
//            }
        }

        private void label1_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            parentWindow.createLeftMenuPage("chapter0");

            m_iChapter  = 1;
            set_label_foreground();
        }

        private void label2_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            parentWindow.createLeftMenuPage("chapter1");

            m_iChapter  = 2;
            set_label_foreground();
       }

        private void label3_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            parentWindow.createLeftMenuPage("chapter2");

            m_iChapter  = 3;
            set_label_foreground();
        }

        private void label4_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            parentWindow.createLeftMenuPage("chapter3");

            m_iChapter  = 4;
            set_label_foreground();
        }

        private void label5_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            parentWindow.createLeftMenuPage("chapter4");

            m_iChapter  = 5;
            set_label_foreground();
        }

        private void label6_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            parentWindow.createLeftMenuPage("chapter5");

            m_iChapter  = 6;
            set_label_foreground();
        }

        private void label7_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            parentWindow.createLeftMenuPage("chapter6");
 
            m_iChapter  = 7;
            set_label_foreground();
       }

        private void label8_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            parentWindow.createLeftMenuPage("chapter7");
 
            m_iChapter  = 8;
            set_label_foreground();
        }

        private void label9_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            parentWindow.createLeftMenuPage("chapter8");
 
            m_iChapter  = 9;
            set_label_foreground();
        }

        private void label10_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            parentWindow.createLeftMenuPage("chapter9");
 
            m_iChapter  = 10;
            set_label_foreground();
        }

        private void ChildPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            parentWindow.createLeftMenuPage("chapter1");
        }

        private void element_MouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = new SolidColorBrush(Colors.Aqua);
        }

        private void element_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = null;
        }

        private void element_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            if ( m_objectCur != null )
            {
                ((TextBlock)m_objectCur).Foreground = (SolidColorBrush)this.Resources["menu_foreground"];
            }
//            ((TextBlock)sender).Foreground = new SolidColorBrush(Colors.Red);
            ((TextBlock)sender).Foreground = (SolidColorBrush)this.Resources["menu_foreground_hot"];

            m_objectCur = (TextBlock)sender;
        }
    }
}
