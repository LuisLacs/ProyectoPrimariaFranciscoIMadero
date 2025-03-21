using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class MainClass
    {
        public string sError, sConnection;
        // Estos valores son temporales mientras se trabaja en el desarrollo
        // Serán modificados, profe no se enoje plis
        private string sServer = "LAPTOP-P73RDL1S";
        private string sUser = "Deisy";
        private string sPass = "12345";

        public bool BDIniciarSesion()
        {
            bool bOk = false;
            try
            {
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                // Crear la conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                conMySQL.Open(); // Abrir y cerrar la conexión
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }
    }
}
