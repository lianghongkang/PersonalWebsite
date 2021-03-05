using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonalWebsite.DAL
{
    public class MSSqlDataBase:DataBase
    {
        public string ConnStr { get; set; }
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnStr);
        }
        public override IDbConnection CreateConnection(string connStr)
        {
            return new SqlConnection(connStr);
        }
        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }
        public override IDbDataAdapter CreateDataAdapter()
        {
            return  new SqlDataAdapter();
        }
  
        //public IDbTransaction CreateTransaction(IDbConnection myConn)
        //{
        //    return myConn.BeginTransaction();
        //}
        //public IDataReader CreateDataReader(IDbCommand myComm)
        //{
        //    return myComm.ExecuteReader();
        //}

    }
}