using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_OP
{
    public class Table:CRUD,IEnumerable
    {
        public string table_name;
        public List<Row> rows = new List<Row>();
        public string[] fields;

        public Table() { }
        public Table(string name) { table_name = name; }

        public Row this[string row_name]
        {
            get { return rows.Find(row => row.row_name == row_name ); }
            //set { /* set the specified index to value here */ }
        }


        public int Create(string name)
        {
            throw new NotImplementedException();
        }
        public Table Read(string SQL)
        {
            throw new NotImplementedException();
        }
        public int Update()
        {
            throw new NotImplementedException();
        }
        public int Delete()
        {
            throw new NotImplementedException();
        }



        public override string ToString()
        {

            return GetType().ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return rows.GetEnumerator();
        }


        /// <summary>
        /// 当前表中所有列名并返回 string[]
        /// </summary>
        /// <param name="query"></param>
        /// <param name="connection">SQL Connection</param>
        /// <returns>字符串数组</returns>
        //public static string[] Get_Col_Names()
        //{
        //    using (SqlCommand command = new SqlCommand(query, connection))
        //    {
        //        return Get_Col_Names(command.ExecuteReader());
        //    }
        //}

    }
}