using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest
{
    class DllTest
    {
        // 非托管动态链接库DLL的调用过程:
        // <1> 采用DllImport动态加载动态链接库文件中的函数
        // <2> 重新声明
        [DllImport(@"dll_cpp.dll", EntryPoint ="testAdd", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testAdd(int a, int b);

        // 非托管动态链接库DLL的调用过程:
        // <1> 采用DllImport动态加载动态链接库文件中的函数
        // <2> 重新声明
        [DllImport(@"dll_cpp.dll", EntryPoint = "testMulti", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testMulti(int a, int b);
    }
}
