
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

using dll_csharp;

namespace WPFTest.UI.Chapter7
{
    /// <summary>
    /// C7_SY1.xaml 的交互逻辑
    /// </summary>
    public partial class C7_SY1 : ChildPage
    {
        public C7_SY1()
        {
            InitializeComponent();

        }

        private void btn1_Click_1(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox1.Text.Trim();
            string strText2 = textBox2.Text.Trim();
            string ret = ComTest.add("944CA448-AE53-47C8-84ED-80DBD799E3BD", "Simulation Transaction", int.Parse(strText1), int.Parse(strText2));
            textBox3.Text = String.Concat(ret);
        }

        private void btn2_Click_1(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox5.Text.Trim();
            string strText2 = textBox6.Text.Trim();
            string ret = ComTest.multi("ADCD6417-325B-4FED-911F-BEC7B2F50295", "User Transaction", int.Parse(strText1), int.Parse(strText2));
            textBox7.Text = String.Concat(ret);
        }
    }
}
