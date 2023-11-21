using System;
using System.ComponentModel.DataAnnotations;
using joueur;
using Npgsql;

namespace statistique
{
    public class Statistique
    {

        private string connectionString;

        public Statistique(string con) => this.connectionString = con ?? throw new ArgumentNullException(nameof(con));

        public List<Statistique> GetStatistiqueByIdEquipe(int idEquipe, string con)
        {
            List<Statistique> listeStatistique = new List<Statistique>();
            List<Joueur> idJoueur = new Joueur(con).GetJoueurByIdEquipe(idEquipe, con);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                for (int i = 0; i < idJoueur.Count(); i++)
                {

                    string sql = "SELECT * FROM v_statistique_personnel where id_joueur = " + idJoueur[i].idJoueur;
                    Console.WriteLine(sql);
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Statistique s = new Statistique(con);
                                s.joueur = new Joueur(con).GetJoueurById(reader.GetInt32(0), con);
                                s.passeDecisive = reader.GetInt32(1);
                                s.points = reader.GetInt32(2);
                                s.minute = reader.GetInt32(3);
                                s.rebonds = reader.GetInt32(4);
                                listeStatistique.Add(s);
                            }
                        }
                    }
                }
                connection.Close();
            }
            return listeStatistique;
        }

        public List<Statistique> GetAllStatistique(string con)
        {
            List<Statistique> listeStatistique = new List<Statistique>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM v_statistique_personnel";
                Console.WriteLine(sql);
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Statistique s = new Statistique(con);
                            s.joueur = new Joueur(con).GetJoueurById(reader.GetInt32(0), con);
                            s.passeDecisive = reader.GetInt32(1);
                            s.points = reader.GetInt32(2);
                            s.minute = reader.GetInt32(3);
                            s.rebonds = reader.GetInt32(4);
                            listeStatistique.Add(s);
                        }
                    }
                }
                connection.Close();
            }
            return listeStatistique;
        }

        public Joueur joueur { get; set; }
        public int passeDecisive { get; set; }
        public int points { get; set; }
        public int minute { get; set; }
        public int rebonds { get; set; }
    }
}