using System.Data.SqlClient;

namespace QTechManagementSoftware
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            return DBConnection.GetDBConnection("SQL-Server\\QTSQLSERVER,1433", "QTech_Bookkeeping", "User01", "12345");
        }
    }
}
