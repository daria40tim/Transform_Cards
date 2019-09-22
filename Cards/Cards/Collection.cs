using Cards.Model;
using Npgsql;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Collection
    {
        public static ObservableCollection<Card> Cards { get; set; }
        public static  ObservableCollection<Worker> Workers { get; set; }
        public static void FillData()
        {
            Workers = new ObservableCollection<Worker>();
            Cards = new ObservableCollection<Card>();
            Workers = ReadWorkers();
            Cards = ReadCards();
        }

        public static ObservableCollection<Card> ReadCards()
        {
            ObservableCollection<Card> Cards = new ObservableCollection<Card>();
            string queryString = "select card_id, tr_type, tr_power, pr_voltage, sec_voltage, is_shielded, bd_date, author, bid, is_not_tested, picture, card_file, addition, conn_type, coil_num, measure from tp_card";
            using (NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(queryString, connection);
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        string[] volt = reader[3].ToString().Split('-');
                        Voltage a = new Voltage(volt);
                        volt = reader[4].ToString().Split('/');
                        List<Voltage> b = new List<Voltage>();
                        foreach (var item in volt)
                        {
                            Voltage c = new Voltage(item.Split('-'));
                            b.Add(c);
                        }
                        Card new_Card = new Card
                        {
                            CardId = (int)reader[0],
                            Type = reader[1].ToString(),
                            Power = float.Parse(reader[2].ToString()),
                            Pr_Voltage = a,
                            Sec_Voltage = b,
                            IsShielded = (bool)reader[5],
                            DateofCreation = (DateTime)reader[6],
                            Bid = (bool)reader[8],
                            IsNotTested = (bool)reader[9],
                            Picture = reader[10].ToString(),
                            CardFile = reader[11].ToString(),
                            Addition = reader[12].ToString(),
                            ConnectionType = reader[13].ToString(),
                            NumberofCoils = int.Parse(reader[14].ToString()),
                            PowerMeasure = reader[15].ToString(),
                            Author = Workers.Where(o => o.WorkerId == (int)reader[7]).FirstOrDefault()
                        };
                        Cards.Add(new_Card);
                        new_Card = null;
                        a = null; b = null;
                    }
                }
                finally { reader.Close(); }
            }
            return Cards;
        }

        public static ObservableCollection<Worker> ReadWorkers()
        {
            ObservableCollection<Worker> Workers = new ObservableCollection<Worker>();
            string queryString = "select worker_id, name, login, password, job from worker";
            using (NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(queryString, connection);
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Worker new_Worker = new Worker
                        {
                            WorkerId = (int)reader[0],
                            Name = reader[1].ToString(),
                            LogIn = reader[2].ToString(),
                            Password = reader[3].ToString(),
                            Job = reader[4].ToString()
                        };
                        Workers.Add(new_Worker);
                        new_Worker = null;
                    }
                }
                finally { reader.Close(); }
            }
            return Workers;
        }
    }
}
