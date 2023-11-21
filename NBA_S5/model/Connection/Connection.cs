using Npgsql;
using System;
using System.Data;

public class Connection
{
    private readonly string ConnectionString;

    public Connection(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public DataTable ExecuteQuery(string query)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }

    public int ExecuteNonQuery(string query)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                return command.ExecuteNonQuery();
            }
        }
    }
}
