using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldDataPopulationTool
{
    class Program
    {
        private static SqlConnection _sqlConnection;

        private static string[] Tables = new string[] { "DBF01", "DBF02", "DBF03", "DBF04", "DBF05", "DBF06", "DBF07", "DBF08", "DBF09" };

        private static string AccessDataBaseConnectionString;
        private static string SQLDataBaseConnectionString;

        private static string TableName;

        static void Main(string[] args)
        {
            ReadConfiguration();

            foreach(string table in Tables)
            {
                using (OleDbConnection _accessConnection = new OleDbConnection(AccessDataBaseConnectionString))
                {
                    using (SqlConnection _sqlConnection = new SqlConnection(SQLDataBaseConnectionString))
                    {
                        try
                        {
                            var myDataTable = new DataTable();

                            _accessConnection.Open();

                            var query = "SELECT * FROM " + table + " WHERE B_NO > 0 ORDER BY B_NO";

                            var command = new OleDbCommand(query, _accessConnection);
                            var reader = command.ExecuteReader();

                            _sqlConnection.Open();

                            while (reader.Read())
                            {
                                Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5}", reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));

                                using (SqlCommand cmd = new SqlCommand("usp_InsertUpdateOldBillData", _sqlConnection))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.Add("@pBillNumber", SqlDbType.BigInt).Value = reader[5].ToString();
                                    cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = reader[0].ToString();
                                    cmd.Parameters.Add("@pAddress", SqlDbType.VarChar).Value = reader[1].ToString();
                                    cmd.Parameters.Add("@pDate", SqlDbType.Date).Value = reader[3].ToString();
                                    cmd.Parameters.Add("@pParticulars", SqlDbType.VarChar).Value = reader[2].ToString();
                                    cmd.Parameters.Add("@pWeight", SqlDbType.Real).Value = reader[4].ToString();

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        finally
                        {
                            _sqlConnection.Close();
                            _accessConnection.Close();
                        }
                    }
                }
            }
            
        }

        private static void ReadConfiguration()
        {
            AccessDataBaseConnectionString = ConfigurationManager.AppSettings["AccessFileConnection"];
            SQLDataBaseConnectionString = ConfigurationManager.AppSettings["SQLConnectionString"];
        }
    }
}
