using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.DAL
{
    public abstract class DataBase
    {
        public string ConnStr { get; set; }

        public abstract IDbConnection CreateConnection();
        public abstract IDbConnection CreateConnection(string connStr);
        public abstract IDbCommand CreateCommand();
        public abstract IDbDataAdapter CreateDataAdapter();
        public IDbTransaction CreateTransaction(IDbConnection myConn)
        {
            return myConn.BeginTransaction();
        }
        public IDataReader CreateDataReader(IDbCommand myComm)
        {
            return myComm.ExecuteReader();
        }
    }
}
