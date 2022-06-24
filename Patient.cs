using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalElectronicRecordSystem
{
    public class Patient
    {
        Controllers ctrl;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public Patient()
        {
            ctrl = new Controllers();
            
        }
        public String GetNewPatientID()
        {

            string id = "";
            string query = "select getNewPatientID()";
            MySqlConnection conn = Database.getConnection();
            try
            {

                conn.Open();
                cmd = new MySqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    id = dr.GetString(0);
                }
                return id;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
