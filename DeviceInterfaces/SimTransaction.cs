using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// COM 组件的创建与调用过程:
//  1. 声明 COM 组件, 即定义接口
//  2. 实现 COM 组件, 即实现接口函数
//  3. 注册 COM 组件, 可调用 .net 环境中的 Regasm 程序将 COM 组件注册到系统中
//  4. 调用/使用 COM 组件

namespace DeviceInterfaces
{

    // COM 组件的创建与调用过程:
    //  1. 声明 COM 组件, 即定义接口
    //[Guid("9F6E38B0-2657-443D-BCC1-1C3246221828")]
    [Guid("944CA448-AE53-47C8-84ED-80DBD799E3BD")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Description("模拟事务记录")]
    public class SimTransaction : ITransaction
    {
        public void Connect(string connectString)
        {
        }

        public void Disconnect()
        {

        }

        public string GetVersion()
        {
            return "1.0";
        }

        // COM 组件的创建与调用过程:
        //  2. 实现 COM 组件, 即实现接口函数
        public string add(int a, int b)
        {
            return string.Concat(a, "+", b, "=", a + b);
        }

        // COM 组件的创建与调用过程:
        //  2. 实现 COM 组件, 即实现接口函数
        public string multi(int a, int b)
        {
            return string.Concat(a, "*", b, "=", a * b);
        }
    }
}
