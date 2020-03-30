using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Fitness_Zone.DAL
{
    class SystemDAL
    {
        public Boolean executeNonQueryS(string quary)
        {
            Boolean flag = false;
            SqlConnection con = null;
            SqlCommand com = null;
            try
            {
                con = new SqlConnection(DBEstablish.makeConnection());
                con.Open();
                com = new SqlCommand(quary, con);
                com.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                flag = false;
            }
            finally
            {
                com.Dispose();
                con.Close();
            }
            return flag;
        }

        public SqlDataReader executeQueryS(string quary)
        {
            SqlConnection con = null;
            SqlCommand com = null;
            try
            {
                con = new SqlConnection(DBEstablish.makeConnection());
                con.Open();
                com = new SqlCommand(quary, con);
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                com.Dispose();
                con.Close();
                throw;
            }

        }
    }
}
