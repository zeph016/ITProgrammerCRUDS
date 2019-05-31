using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CRUDS_EXER.DataAccess
{
    public class ConnectionManager
    {
        public static IDbConnection FGCICRUDSConnection
        {
            get
            {
                IDbConnection con = new SqlConnection(CRUDS_EXER.DataAccess.Properties.Settings.Default.FGCIConnectionString);
                return con;
            }
        }
        
    }
}
