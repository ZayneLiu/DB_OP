using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DB_OP
{
    class Server:CRUD
    {
        SqlConnection connection;
        public string[] dbs;
        List<Database> databases;

        public Database this[string db_name]
        {
            get { return databases.Find(db => db.db_name == db_name); }
        }

        public Server(string ConnectionString)
        {
            connection = new SqlConnection(ConnectionString);

        }

        public void Get_DBs()
        {
            Table result = Read(@"select name from sys.databases where sys.databases.name not in ('master','tempdb','model','msdb')");
            //初始化返回结果
            //Database[] database = new Database[result.rows.Count];
            Console.WriteLine(result.table_name);
            string s =string.Empty;
            foreach (var item in result.fields)
            {
                s += item + "\t||\t";
            }
            Console.WriteLine("======\n" + s);
            foreach (Row row in result)
            {
                for (int i = 0; i < row.datas.Count; i++)
                {
                    Console.Write(row.datas[i].value + "\t||");
                    //database[i] = new Database(row.datas[i].value.ToString());
                }
                Console.WriteLine();
            }
            //return database;
        }

        //关闭连接
        public void Close()
        {
            connection.Close();
        }



        public int Create(string name)
        {
            throw new NotImplementedException();
        }
        public Table Read(string SQL)
        {
            return Operation.Extract(SQL, connection, out databases);
        }
        public int Update()
        {
            throw new NotImplementedException();
        }
        public int Delete()
        {
            throw new NotImplementedException();
        }
    }
}
