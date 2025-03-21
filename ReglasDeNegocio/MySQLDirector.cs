using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class MySQLDirector
    {
        public string sError, sConnection;
        // Estos valores son temporales mientras se trabaja en el desarrollo
        // Serán modificados, profe no se enoje plis
        private string sServer = "LAPTOP-P73RDL1S";
        private string sUser = "escuela";
        private string sPass = "12345";

        public string GetUser()
        {
            string user = string.Empty;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand("SELECT Username FROM primariafim.director;", conMySQL)) // Query para obtener los nombres de las BDs
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = reader[0].ToString();
                        }
                    }
                }
            } catch(Exception ex)
            {
                sError = ex.Message;
            }
            return user;
        }

        public bool DireLogin(string user, string pass)
        {
            bool bOk = false;
            string direUser = string.Empty;
            string direPass = string.Empty;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand("SELECT Username, Pass from primariafim.director;", conMySQL)) // Query para obtener los nombres de las BDs
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            direUser = reader[0].ToString();
                            direPass = reader[1].ToString();
                        }
                    }
                }

                if(user == direUser && pass == direPass)
                {
                    bOk = true;
                }
            } catch(Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public string GetName()
        {
            string user = string.Empty;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand("SELECT Nombre, Apellidos FROM primariafim.director;", conMySQL)) // Query para obtener los nombres de las BDs
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader[0].ToString();
                            string apellido = reader[1].ToString();
                            user = nombre + " " + apellido;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return user;
        }
    }
}
