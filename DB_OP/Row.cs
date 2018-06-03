using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_OP
{
    public class Row:CRUD,IEnumerable
    {

        public string row_name;
        public List<Data> datas = new List<Data>();



        public Row() { }
        public Row(string name) { row_name = name; }




        public override string ToString()
        {
            return this.GetType().ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return datas.GetEnumerator();
        }

        public int Create(string SQL)
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
    }
}