
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

using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Utils;

namespace WPFTest.UI.Chapter2
{
    /// <summary>
    /// C2_SY1.xaml 的交互逻辑
    /// 知识点: 重定向实现进程同步通信
    ///     1. 设置重定向进程文件名称
    ///     2. 设置属性来重定向输入输出流
    ///     3. 进程向重定向的输入流中写入数据
    ///     4. 进程从输出流中获得数据
    /// </summary>
    public partial class C2_SY1 : ChildPage
    {

        public static Process cmdP;
        public static StreamWriter cmdStreamInput;
        private static StringBuilder cmdOutput = null;

        
        public C2_SY1()
        {
            InitializeComponent();

        }

        public C2_SY1(MainWindow parent)
        {
            InitializeComponent();
            this.parentWindow = parent;

        }

        private void ChildPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        

        private void clearComments()
        {
            //listBox1.Items.Clear();
            textBox2.Text = "";
        }

        private void showComment(String comment)
        {
            if (MyStringUtil.isEmpty(comment)) {
                //listBox1.Items.Add("");
                return;
            }

            //listBox1.Items.Add(comment);
            textBox2.Text = comment;
        }

        private void runCMD(object sender, RoutedEventArgs e)
        {
            clearComments();
            string strCmd = "ping www.sohu.com -n 20";
            if (!MyStringUtil.isEmpty(textBox1.Text))
                strCmd = "ping " + textBox1.Text.Trim() + " -n 20";

            cmdOutput = new StringBuilder("");
            
            cmdP = new Process();

            ///     1. 设置重定向进程文件名称
            cmdP.StartInfo.FileName = "cmd.exe";

            cmdP.StartInfo.CreateNoWindow = true;
            cmdP.StartInfo.UseShellExecute = false;

            ///     2. 设置属性来重定向输入输出流
            cmdP.StartInfo.RedirectStandardOutput = true;
            cmdP.StartInfo.RedirectStandardInput = true;
            
            /*异步调用
            cmdP.OutputDataReceived += new DataReceivedEventHandler(strOutputHandler);
            cmdP.Start();

            cmdStreamInput = cmdP.StandardInput;
            cmdStreamInput.WriteLine(strCmd);
            cmdStreamInput.WriteLine("exit");
            cmdP.BeginOutputReadLine();
            */

            //同步调用
            cmdP.Start();
            ///     3. 进程向重定向的输入流中写入数据
            cmdP.StandardInput.WriteLine(strCmd);
            cmdP.StandardInput.WriteLine("exit");

            ///     4. 进程从输出流中获得数据
            textBox2.Text = cmdP.StandardOutput.ReadToEnd();
            cmdP.WaitForExit();
            cmdP.Close();
        }

     

        private void closeCMD(object sender, RoutedEventArgs e)
        {
            cmdP.Close();
        }
    }
}
