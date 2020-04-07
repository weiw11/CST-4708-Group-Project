using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    class SQLConn
    {
        private readonly static String _CONN_STRING = 
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + 
            // REPLACE BELOW WITH DATABASE FILE LOCATION
            "F:\\Database.mdf" + 
            ";Integrated Security=True;Connect Timeout=30";

        public static String CONN_STRING
        {
            get { return _CONN_STRING; }
        }
    }
}
