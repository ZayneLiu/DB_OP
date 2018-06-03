using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DB_OP
{
    public class Operation
    {
        //检索所有数据库（系统数据库除外）
        public static Table Extract(string query, SqlConnection connection, out List<Database> dbs)
        {
            //初始化 out 参数
            dbs = new List<Database>();
            //查询结果
            Table result = Extraction(query, connection);
            
            foreach (Row row in result)
            {
                dbs.Add(new Database(row.row_name));
            }
            return result;
        }





        static Table Extraction(string query, SqlConnection connection)
        {
            connection.Open();//初始化连接
            Table result = new Table();//初始化返回结果
            result.table_name = "Result";
            //List<string> fields = new List<string>();
            var reader = new SqlCommand(query, connection).ExecuteReader();//执行SQL语句
            result.fields = new string[reader.FieldCount];
            while (reader.Read())                
            {
                //获取整行
                object[] d = new object[reader.FieldCount];
                reader.GetValues(d);
                Console.WriteLine();

                //将整行打散 初始化 Data 并重组为 Row
                Row row = new Row();
                row.row_name = d.First().ToString();
                for (int i = 0; i < d.Length; i++)
                {
                    row.datas.Add(new Data(reader.GetName(i), d[i]));
                    result.fields[i] = reader.GetName(i);
                }
                result.rows.Add(row);//每行添加进 Table
            }//读取
            //收尾工作
            reader.Close();
            connection.Close();
            return result;
        }

    }
}
