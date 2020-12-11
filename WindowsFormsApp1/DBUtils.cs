using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-E139CL9\SQLEXPRESS";

            string database = "CourseDB";

            return DBSQLServerUtils.GetDBConnection(datasource, database);
        }
    }

}
