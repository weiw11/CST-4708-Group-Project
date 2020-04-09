using System;

namespace Group_Project
{
    internal class Global
    {
        private readonly static String _CONN_STRING =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "" +
            "|DataDirectory|\\Comics.mdf" + 
            ";Integrated Security=True;Connect Timeout=30";

        public static String CONN_STRING
        {
            get { return _CONN_STRING; }
        }
    }
}