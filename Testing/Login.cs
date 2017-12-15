using Npgsql;

namespace Testing
{
    class Login
    {
        
        public string ValidasiLogin(string username, string password)
        {
            string connString = "Host=127.0.0.1;Database=nutech;Password=postgres;Username=postgres";
            string statusLogin;

            try {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    // Retrieve row
                    var cmd = new NpgsqlCommand("SELECT id_user, nama_user, email FROM testing.users WHERE username='" + username + "' AND password='" + password + "'", conn);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        statusLogin = "1";
                    }
                    else
                    {
                        statusLogin = "0";
                    }

                    reader.Close();
                    conn.Close(); 
                }
            }
            catch(NpgsqlException ex)
            {
                statusLogin = "";
                ex.ErrorCode.Equals(ex);
            }
            
            return statusLogin;
        }
    }
}
