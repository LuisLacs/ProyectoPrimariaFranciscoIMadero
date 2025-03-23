using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class MySQLMaestro
    {
        public string sError, sConnection;
        // Estos valores son temporales mientras se trabaja en el desarrollo
        // Serán modificados, profe no se enoje plis
        private string sServer = "LAPTOP-P73RDL1S";
        private string sUser = "Deisy";
        private string sPass = "12345";

        public bool TeacherLogin(ref DataTable table, string user, string pass)
        {
            bool bOk = false;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = "SELECT Username, Pass FROM registro_user;";

                    conMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(sQry, conMySQL);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }

                    conMySQL.Close();
                }
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }

        public int GetID(string user, string pass)
        {
            int id = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand($"SELECT idMaestro from registro_user WHERE Username = '{user}' AND Pass = '{pass}';", conMySQL)) // Query para obtener los nombres de las BDs
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

        public int GetID(int grade)
        {
            int id = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand($"SELECT maestro.idMaestro from maestro INNER JOIN grupo WHERE maestro.Grupo = grupo.idGrupo AND grupo.idGrupo = {grade};", conMySQL)) // Query para obtener los nombres de las BDs
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

        public string GetName(int id)
        {
            string user = string.Empty;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand($"SELECT maestro.Nombre, maestro.Apellidos FROM maestro INNER JOIN registro_user WHERE maestro.idMaestro = registro_user.idMaestro AND maestro.idMaestro = {id};", conMySQL)) // Query para obtener el nombre completo del maestro
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

        public void GetStudents(ref DataTable table)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = $"SELECT * FROM alumno;";

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

        public void GetStudent(ref DataTable table, int i)
        {
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                using (MySqlConnection conMySQL = new MySqlConnection(sConnection))
                {
                    string sQry = $"SELECT * FROM alumno where idAlumno = {i};";

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

        public bool AddStudent(string name, string lname, int grade)
        {
            bool bOk = false;
            try
            {
                int teacher = GetID(grade);
                string sQry = $"INSERT INTO alumno (Nombre, Apellidos, idMaestro, idGrupo) VALUES ('{name}', '{lname}', {teacher}, {grade});";
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

        public bool ModifyStudent(int id, string name, string lname, int grade)
        {
            bool bOk = false;
            try
            {
                int teacher = GetID(grade);
                string sQry = $"UPDATE alumno SET Nombre = '{name}', Apellidos = '{lname}', idMaestro = {teacher}, idGrupo = {grade} WHERE idAlumno = {id};";
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

        public bool DeleteStudent(int id)
        {
            bool bOk = false;
            try
            {
                string sQry = $"DELETE FROM alumno where idAlumno = {id};";
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

        public int GetIDName(string name)
        {
            int id = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand($"SELECT idAlumno FROM alumno WHERE Nombre = '{name}';", conMySQL)) // Query para obtener el id de alumno de acuerdo a su nombre
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
                using (MySqlCommand cmd = new MySqlCommand($"SELECT idAlumno FROM alumno WHERE Apellidos = '{name}';", conMySQL)) // Query para obtener el id de alumno de acuerdo a su apellido
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

        public bool UpdateGroup(int grade)
        {
            bool bOk = false;
            try
            {
                int students = CountStudents(grade);
                string sQry = $"UPDATE grupo SET CantidadAlumnos = {students};";
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

        private int CountStudents(int grade)
        {
            int students = 0;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(idAlumno) as Num from alumno INNER JOIN grupo WHERE alumno.idGrupo = grupo.idGrupo AND grupo.idGrupo = {grade};", conMySQL)) 
                {
                    conMySQL.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students = Convert.ToInt16(reader[0]);
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
            return students;
        }
    }
}
