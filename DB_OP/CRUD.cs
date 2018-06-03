using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_OP
{
    interface CRUD
    {
        int Create(string name);
        Table Read(string SQL);
        int Update();
        int Delete();
    }
}
