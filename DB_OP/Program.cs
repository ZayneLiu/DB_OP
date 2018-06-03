using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;

namespace DB_OP
{
    class Program
    {
        static void Main(string[] args)
        {
            //连接字符串
            string s = @"Data Source = (localdb)\MSSQLLocalDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            //用连接字符串实例化 Server对象
            Server SqlServer = new Server(s);
            SqlServer.Get_DBs();
            //Database[] dbs =  SqlServer.Get_DBs();  
            var a = SqlServer["test"]["department"].fields;


            Console.WriteLine();
        }
    }
}
