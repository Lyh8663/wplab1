
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

namespace WPFTest.UI.Chapter6
{
    /// <summary>
    /// C6_SY2.xaml 的交互逻辑
    /// </summary>
    public partial class C6_SY2 : ChildPage
    {
        public C6_SY2()
        {
            InitializeComponent();

        }

        private void btn1_Click_1(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox1.Text.Trim();
            string strText2 = textBox2.Text.Trim();
            // 非托管动态链接库DLL的调用过程:
            // <3> 在程序中调用重新声明的函数
            int ret = DllTest.testAdd(int.Parse(strText1), int.Parse(strText2));
            textBox3.Text = String.Concat(ret);
        }



        private void btn2_Click_1(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox5.Text.Trim();
            string strText2 = textBox6.Text.Trim();
            // 非托管动态链接库DLL的调用过程:
            // <3> 在程序中调用重新声明的函数
            int ret = DllTest.testMulti(int.Parse(strText1), int.Parse(strText2));
            textBox7.Text = String.Concat(ret);
        }
    }
}
