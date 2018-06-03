using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB_OP
{
    class DB_OP
    {

        public static SqlDataReader Show_DBs(SqlConnection connection)
        {
            SqlCommand all_DBs = new SqlCommand("select name from sys.databases where sys.databases.name not in ('master','tempdb','model','msdb')", connection);
            return all_DBs.ExecuteReader();
        }

        string s = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DB_OP()
        {
            var conn = new SqlConnection(s);
            conn.Open();
            SqlCommand all_DBs = new SqlCommand("select name from sys.databases where sys.databases.name not in ('master','tempdb','model','msdb')",conn);
            var a = all_DBs.ExecuteReader();
        }
        enum Operation
        {
            Find,Update

        }
        Dictionary<Operation, SqlCommand> querylist ;

        public static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Workspace\C#\Csharp_DB\Csharp_DB\test.mdf;Integrated Security=True;Connect Timeout=30";
        public static List<object[]> Get_Data(SqlDataReader a)
        {
            //取每行数据----优雅^_^----无比优雅*_*
            List<object[]> objs = new List<object[]>();
            while (a.Read())
            {
                object[] d = new Object[a.FieldCount];
                a.GetValues(d);
                objs.Add(d);
            }
            //调试输出
            //foreach (var item in objs)
            //{
            //    foreach (var sub in item)
            //    {
            //        Console.WriteLine(sub + "\t===>\t" + sub.GetType());
            //    }
            //}
            return objs;
        }

        public static string[] Get_Col_Names(SqlDataReader a)
        {
            //列名
            string[] col_names = new string[a.FieldCount];
            for (int i = 0; i < a.FieldCount; i++)
            {
                col_names[i] = a.GetName(i);

            }
            ////调试输出
            //foreach (var item in col_names)
            //{
            //    Console.WriteLine(item);
            //}
            return col_names;
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="query">Select * From "somewhere"</param>
        /// <param name="connection">SQL Connection</param>
        /// <returns>字符串数组</returns>
        public static string[] Get_Col_Names(string query, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                return Get_Col_Names(command.ExecuteReader());
            }
        }

        #region 原型
        void Method()
        {
            //string dest = "department";
            //var a = new SqlCommand("select * from " + dest, connection).ExecuteReader();
            //var a = command.ExecuteReader();
            ////列名
            //string[] col_names = new string[a.FieldCount];
            //for (int i = 0; i < a.FieldCount; i++)
            //{
            //    col_names[i] = a.GetName(i);
            //}
            ////输出
            //foreach (var item in col_names)
            //{
            //    Console.WriteLine(item + "\t===>\t" + item.GetType());
            //}

            ////取每行数据----优雅^_^----无比优雅*_*
            //List<object[]> objs = new List<object[]>();
            //while (a.Read())
            //{
            //    object[] d = new Object[a.FieldCount];
            //    a.GetValues(d);
            //    objs.Add(d);
            //}
            ////输出
            //foreach (var item in objs)
            //{
            //    foreach (var sub in item)
            //    {
            //        Console.WriteLine(sub + "\t===>\t" + sub.GetType());
            //    }
            //} 
        }
        #endregion
    }
}
