using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_OP
{
    public class Data
    {
        public string name;
        public object value;
        public Type type;

        //public Data() { }

        public Data(string name, object value)
        {
            this.name = name;
            this.value = value;
            type = value.GetType();
        }
        //public Type Type { get => type;}
        //public string Name { get => name;}
        //public object Value { get => value; set => this.value = value; }

        public override string ToString()
        {
            return this.name;
        }
    }
}
