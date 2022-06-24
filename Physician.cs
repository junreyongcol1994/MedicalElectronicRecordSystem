using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MedicalElectronicRecordSystem
{
   
    

    public class Physician
    {
        MySqlConnection con;
        public string PhysicianID { get; set; }
        public string PhysicianName { get; set; }
        public string License { get; set; }
        public string LicenseNum { get; set; }
        public bool InsertNewPhysician()
        {
            try
            {
                string sql = "insert into tbl_physician (physician_name, license_name, license_no) " +
                    "values (@physician_name, @license_name, @license_no)";
                con = Database.GetConnection();
                con.Open();
                MySqlDataAdapter myda = new MySqlDataAdapter();
                myda.InsertCommand = new MySqlCommand(sql, con);
                myda.InsertCommand.Parameters.Add("@physician_name", MySqlDbType.VarString).Value = this.PhysicianName;
                myda.InsertCommand.Parameters.Add("@license_name", MySqlDbType.VarString).Value = this.License;
                myda.InsertCommand.Parameters.Add("@license_no", MySqlDbType.VarString).Value = this.LicenseNum;
                int a = myda.InsertCommand.ExecuteNonQuery();
                return a >= 1;
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
    
}
