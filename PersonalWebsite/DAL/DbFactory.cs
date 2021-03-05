using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace PersonalWebsite.DAL
{
    public class DbFactory
    {
        public static DataBase db;
        public static string name = ConfigurationManager.ConnectionStrings["mysqlDbConnStr"].ProviderName;
        public static string connStr = ConfigurationManager.ConnectionStrings["mysqlDbConnStr"].ConnectionString;
        public  DbFactory()
        {
            //IDataBase db = null;
            switch (name)
            {
                case "System.Data.SqlClient":
                    db = new MSSqlDataBase();
                    db.ConnStr = connStr;
                    break;
                case "System.Data.Odbc":
                    db = new MysqlDataBase();
                    db.ConnStr = connStr;
                    break;
            }
            //return db;
        }
        //public static IDataBase CreateDb()
        //{
        //    IDataBase db = null;
        //    switch (name)
        //    {
        //        case "System.Data.SqlClient":
        //            db = new MSSqlDataBase();
        //            db.ConnStr = connStr;
        //            break;
        //        case "System.Data.Odbc":
        //            db = new MysqlDataBase();
        //            db.ConnStr = connStr;
        //            break;
        //    }
        //    return db;
        //}
        public static IDataReader ExcuteReader(CommandType cmdType, string cmdText, List<IDbDataParameter> cmdParams = null)
        {
          
            //IDataBase db = DbFactory.CreateDb();
            DbFactory dbFactory = new DbFactory();
            IDbConnection conn = db.CreateConnection(db.ConnStr);
            conn.Open();
            IDbCommand cmd = db.CreateCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            cmd.Connection = conn;
            if (cmdParams != null)
            {
                AttachParameters(cmd, cmdParams);
            }
            IDataReader sdr = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return sdr;
        }
        public static void AttachParameters(IDbCommand cmd, List<IDbDataParameter> cmdParams)
        {
            foreach (IDbDataParameter p in cmdParams)
            {
                if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input)
                    && p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
                cmd.Parameters.Add(p);
            }
        }
    }
    //public enum DbType
    //{
    //    MSSQLSERVER = 0,

    //    MySql = 1,

    //    OLEDB = 2
    //}
}