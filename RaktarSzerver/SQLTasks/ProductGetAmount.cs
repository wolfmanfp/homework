using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RaktarSzerver.SQLTasks
{
    class ProductGetAmount
    {
        DBConnection connection = DBConnection.Instance;
        SqlCommand command = new SqlCommand();
        string commandText = "SELECT Amount FROM Products WHERE NAME = &name";
        

        public ProductGetAmount(){
            this.command.CommandText = 
        }


    }
}
