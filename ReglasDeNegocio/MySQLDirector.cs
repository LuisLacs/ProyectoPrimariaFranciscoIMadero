﻿using MySql.Data.MySqlClient;
using Mysqlx;
using System;
using System.Collections.Generic;
using System.Data;
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
        private string sUser = "Deisy";
        private string sPass = "12345";

        public string GetUser()
        {
            string user = string.Empty;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand("SELECT Username FROM primariafim.director;", conMySQL)) // Query para obtener el user de director
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = reader[0].ToString(); // Almacenar el resultado del query en la variable
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            } catch(Exception ex)
            {
                sError = ex.Message;
            }
            return user;
        }

        public bool PrincipalLogin(string user, string pass)
        {
            bool bOk = false;
            string prinUser = string.Empty;
            string prinPass = string.Empty;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand("SELECT Username, Pass from primariafim.director;", conMySQL)) // Query para obtener el user y password del director
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            prinUser = reader[0].ToString(); // Almacenar el nombre de usuario
                            prinPass = reader[1].ToString(); // Almacenar la contraseña
                        }
                        reader.Close();
                    }
                }

                // Verificar que los datos ingresados sean iguales a los datos en la base de datos
                if(user == prinUser && pass == prinPass)
                {
                    bOk = true;
                }
                conMySQL.Close();
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
                using (MySqlCommand cmd = new MySqlCommand("SELECT Nombre, Apellidos FROM primariafim.director;", conMySQL)) // Query para obtener el nombre completo del director
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader[0].ToString(); // Almacena el nombre
                            string apellido = reader[1].ToString(); // Almacena el apellido
                            user = nombre + " " + apellido; // Concatena en el mismo string
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return user;
        }

        public void GetTeachers(ref DataTable table)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = $"SELECT * FROM maestro;";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public void GetTeacher(ref DataTable table, int i)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = $"SELECT * FROM maestro WHERE idMaestro = {i};";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }

        public bool ModifyTeacher(int id, string name, string lname, int grade, string user, string pass)
        {
            bool bOk = false;
            try
            {
                string sQry = $"UPDATE maestro SET Nombre = '{name}', Apellidos = '{lname}', Grupo = {grade} WHERE idMaestro = {id};UPDATE registro_user SET Username = '{user}', Pass = '{pass}' WHERE idMaestro = {id};";
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public bool AddTeacher(int id, string name, string lname, int grade, string user, string pass)
        {
            bool bOk = false;
            try
            {
                string sQry = $"INSERT INTO maestro VALUES ({id}, '{name}', '{lname}', {grade}); INSERT INTO registro_user (Username, Pass, idMaestro) VALUES ('{user}', '{pass}', {id});"; // Query para agregar un maestro
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public bool DeleteTeacher(int id)
        {
            bool bOk = false;
            try
            {
                string sQry = $"DELETE FROM registro_user WHERE idMaestro = {id}; DELETE FROM maestro WHERE idMaestro = {id};"; // Query para eliminar un maestro
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public int LastID()
        {
            int id = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand("SELECT MAX(idMaestro) FROM maestro;", conMySQL)) // Query para obtener el último id de maestros
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public int GetIDName(string name)
        {
            int id = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand($"SELECT idMaestro FROM maestro WHERE Nombre = '{name}';", conMySQL)) // Query para obtener el id de maestro de acuerdo a su nombre
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public int GetIDLastName(string name)
        {
            int id = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand($"SELECT idMaestro from maestro WHERE Apellidos = '{name}';", conMySQL)) // Query para obtener el id de maestro de acuerdo a su apellido
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public int CountTeachers()
        {
            int id = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idMaestro) from maestro;", conMySQL)) // Query para obtener la cantidad de maestros que se encuentran en la bds
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt16(reader[0]);
                        }
                        reader.Close();
                    }
                }
                conMySQL.Close();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return id;
        }

        public bool ModifyPrincipal(string name, string lname, string user, string pass)
        {
            bool bOk = false;
            try
            {
                string sQry = $"UPDATE director SET Nombre = '{name}', Apellidos = '{lname}', Username = '{user}', Pass = '{pass}' WHERE idDirector = 1;"; // Query para actualizar los datos del director
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);

                if (conMySQL.State == ConnectionState.Closed)
                {
                    conMySQL.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                cmd.ExecuteNonQuery();
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public void GetClasses(ref DataTable table, int grade)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = $"SELECT * FROM maestro WHERE Grupo = {grade};";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
        }
    }
}
