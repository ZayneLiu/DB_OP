using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_OP
{
    public class Database:CRUD
    {
        public string db_name;
        List<Table> tables = new List<Table>();

        public Database(string name)
        {
            db_name = name;
        }
        public Table this[string table_name]
        {
            get
            {

                return tables.Find(table => table.table_name == table_name);
            }
            set { /* set the specified index to value here */ }
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
            return this.GetType().ToString();
        }
    }
}
