using System;
using System.ComponentModel.DataAnnotations;
using Npgsql;

namespace equipe
{
    public class Equipe
    {
        private string connectionString;

        public Equipe(string con) => this.connectionString = con ?? throw new ArgumentNullException(nameof(con));

        public List<Equipe> GetAllEquipe(string con)
        {
            List<Equipe> listeEquipe = new List<Equipe>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM equipe";
                Console.WriteLine(sql);
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Equipe j = new Equipe(con);
                            j.IdEquipe = reader.GetInt32(0);
                            j.nomEquipe = reader.GetString(1);
                            j.localisation = reader.GetString(2);
                            j.abreviation = reader.GetString(3);

                            listeEquipe.Add(j);
                        }
                    }
                }
                connection.Close();
            }
            return listeEquipe;
        }

        public Equipe GetEquipeById(int idEquipe, string con)
        {
            Equipe e = new Equipe(con);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM equipe where id_equipe = " + idEquipe;
                Console.WriteLine(sql);
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            e.IdEquipe = reader.GetInt32(0);
                            e.nomEquipe = reader.GetString(1);
                            e.localisation = reader.GetString(2);
                            e.abreviation = reader.GetString(3);
                        }
                    }
                }
            }
            return e;
        }

        public int IdEquipe { get; set; }
        public string nomEquipe { get; set; }
        public string localisation { get; set; }
        public string abreviation { get; set; }
    }
}