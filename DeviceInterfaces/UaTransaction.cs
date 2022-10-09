using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DeviceInterfaces
{
    // COM 组件的创建与调用过程:
    //  1. 声明 COM 组件, 即定义接口
    //[Guid("A0FD122E-58B0-4BC8-9CB9-31673DCC7DB8")]
    [Guid("ADCD6417-325B-4FED-911F-BEC7B2F50295")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Description("UA事务记录器")]
    public class UaTransaction : ITransaction
    {
        private String connectionString = "";

        public void Connect(string connectString)
        {
            connectionString = connectString;
        }

        public void Disconnect()
        {
            connectionString = "";
        }

        public string GetVersion()
        {
            return "1.0";
        }

        // COM 组件的创建与调用过程:
        //  2. 实现 COM 组件, 即实现接口函数
        public string add(int a, int b)
        {
            return string.Concat(a,"-", b ,"=", a - b);
        }

        // COM 组件的创建与调用过程:
        //  2. 实现 COM 组件, 即实现接口函数
        public string multi(int a, int b)
        {
            return string.Concat(a, "*", b, "* 10 =", a * b * 10);
        }
    }
}
