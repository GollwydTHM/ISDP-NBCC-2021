using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ISDP_AlexanderK.db
{
    class DBConnection
    {
        public DBConnection(){}

        public const string Server = "localhost";
        public const string Port = "3306";
        public const string DatabaseName = "bullseye2021";
        public const string UserName = "kistner";
        public const string Password = "jklfgh104174";

        public MySqlConnection Connection { get; set; }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;
                string connstring = string.Format("Server={0}; port={1}; database={2}; UID={3}; password={4}", Server, Port, DatabaseName, UserName, Password);
                Connection = new MySqlConnection(connstring);
                Connection.Open();
            }

            return true;
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}

