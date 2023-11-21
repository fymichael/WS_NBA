using System;
using System.ComponentModel.DataAnnotations;
using equipe;
using Npgsql;

namespace match
{
    public class Match
    {

        private string connectionString;

        public Match(string con) => this.connectionString = con ?? throw new ArgumentNullException(nameof(con));

        //avoir la liste des matchs
        public List<Match> GetAllMatch(string con)
        {
            List<Match> listeMatch = new List<Match>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM match";
                Console.WriteLine(sql);
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Match m = new Match(con);
                            m.IdMatch = reader.GetInt32(0);
                            m.equipe1 = new Equipe(con).GetEquipeById(reader.GetInt32(1), con);
                            m.equipe2 = new Equipe(con).GetEquipeById(reader.GetInt32(2), con);
                            listeMatch.Add(m);
                        }
                    }
                }
                connection.Close();
            }
            return listeMatch;
        }

        //inserer un match
        public void insertMatch()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO match VALUES (DEFAULT," + this.equipe1.IdEquipe + ", " + this.equipe2.IdEquipe + ", " + this.dateDebut + ", '" + this.etatMatch + "')";
                Console.WriteLine(sql);
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public int IdMatch { get; set; }
        public Equipe equipe1 { get; set; }
        public Equipe equipe2 { get; set; }
        public string dateDebut { get; set; }
        public int etatMatch { get; set; }
    }
}