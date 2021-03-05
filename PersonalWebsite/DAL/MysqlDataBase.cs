using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PersonalWebsite.DAL
{
    public class MysqlDataBase:DataBase
    {
        public string ConnStr { get; set; }
        public override IDbConnection CreateConnection()
        {
            return new MySqlConnection(ConnStr);
        }
        public override IDbConnection CreateConnection(string connStr)
        {
            return new MySqlConnection(connStr);
        }
        public override IDbCommand CreateCommand()
        {
            return new MySqlCommand();
        }
        public override IDbDataAdapter CreateDataAdapter()
        {
            return new MySqlDataAdapter();
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