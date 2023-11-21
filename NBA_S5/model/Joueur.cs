using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.RegularExpressions;
using equipe;
using Npgsql;

namespace joueur
{
    public class Joueur
    {

        private string connectionString;

        public Joueur(string con) => this.connectionString = con ?? throw new ArgumentNullException(nameof(con));

        public List<Joueur> GetJoueurByIdEquipe(int idEquipe, string con)
        {
            List<Joueur> listeJoueur = new List<Joueur>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Joueur where id_equipe = " + idEquipe;
                Console.WriteLine(sql);
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Joueur e = new Joueur(con);
                            e.idJoueur = reader.GetInt32(0);
                            e.equipe = new Equipe(con).GetEquipeById(reader.GetInt32(4), con);
                            e.nom = reader.GetString(1);
                            e.prenom = reader.GetString(2);
                            e.dateNaissance = reader.GetDateTime(3).ToString();
                            e.numero = reader.GetInt32(5);
                            e.poste = reader.GetString(6);
                            listeJoueur.Add(e);
                        }
                    }
                }
            }
            return listeJoueur;
        }

        public Joueur GetJoueurById(int idJoueur, string con)
        {
            Joueur e = new Joueur(con);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Joueur where id_Joueur = " + idJoueur;
                Console.WriteLine(sql);
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            e.idJoueur = reader.GetInt32(0);
                            e.equipe = new Equipe(con).GetEquipeById(reader.GetInt32(4), con);
                            e.nom = reader.GetString(1);
                            e.prenom = reader.GetString(2);
                            e.dateNaissance = reader.GetDateTime(3).ToString();
                            e.numero = reader.GetInt32(5);
                            e.poste = reader.GetString(6);
                        }
                    }
                }
            }
            return e;
        }

        public List<Joueur> GetAllJoueur(string con)
        {
            List<Joueur> listeJoueur = new List<Joueur>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Joueur";
                Console.WriteLine(sql);
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Joueur j = new Joueur(con);
                            j.idJoueur = reader.GetInt32(0);
                            j.equipe = new Equipe(con).GetEquipeById(reader.GetInt32(4), con);
                            j.nom = reader.GetString(1);
                            j.prenom = reader.GetString(2);
                            j.dateNaissance = reader.GetDateTime(3).ToString();
                            j.numero = reader.GetInt32(5);
                            j.poste = reader.GetString(6);

                            listeJoueur.Add(j);
                        }
                    }
                }
                connection.Close();
            }
            return listeJoueur;
        }

        public int idJoueur { get; set; }
        public Equipe equipe { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string dateNaissance { get; set; }
        public int numero { get; set; }
        public string poste { get; set; }
    }
}