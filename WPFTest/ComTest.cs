using DeviceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest
{
    class ComTest
    {
        public static ITransaction CreateTransaction(string _guid,string connectionStr)
        {
            Console.Write("begin creating transaction");
            ITransaction iTransaction = null;
            // COM 组件的创建与调用过程:
            //  4. 调用/使用 COM 组件
            try
            {
                // 调用注册表的CLSID, 并实例化
                Guid guid = new Guid(_guid);
                Type transactionType = Type.GetTypeFromCLSID(guid);
                object transaction = Activator.CreateInstance(transactionType);
                Console.WriteLine(transaction);
                iTransaction = transaction as ITransaction;
                iTransaction.Connect(connectionStr);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                Console.Write("教学提醒：试试将Platform target从Any CPU改为x64");
            }
            Console.Write("end creating transaction");
            return iTransaction;
        }

        public static string add(string guid,string connectionStr,int a, int b)
        {
            // COM 组件的创建与调用过程:
            //  4. 调用/使用 COM 组件
            ITransaction transaction = CreateTransaction(guid, connectionStr);
            return transaction.add(a, b);
        }

        public static string multi(string guid, string connectionStr, int a, int b)
        {
            // COM 组件的创建与调用过程:
            //  4. 调用/使用 COM 组件
            ITransaction transaction = CreateTransaction(guid, connectionStr);
            return transaction.multi(a, b);
        }

    }
}
