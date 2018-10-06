using System;
using MySql.Data.MySqlClient;

namespace Pos2909.db
{
    public class AppDb : IDisposable
    {
        public MySqlConnection Connection;

        public AppDb(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
