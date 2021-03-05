
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PersonalWebsite.Common
{
    public class SqlHelper
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["CodeFirstDbContext"].ConnectionString;
        public static SqlDataReader ExcuteReader(CommandType cmdType, string cmdText, List<SqlParameter> cmdParams = null)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = cmdType;
            if (cmdParams != null)
            {
                AttachParameters(cmd, cmdParams);
            }
            SqlDataReader sdr = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return sdr;
        }
        public static DataTable ExcuteTable(CommandType cmdType,string cmdText, List<SqlParameter> cmdParams = null)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText,conn);
            cmd.CommandType = cmdType;
            if (cmdParams != null)
            {
                AttachParameters(cmd,cmdParams);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Parameters.Clear();
            return dt;
        }
        public static object ExcuteScalar(CommandType cmdType, string cmdText, List<SqlParameter> cmdParams = null)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText,conn);
            cmd.CommandType = cmdType;
            if (cmdParams != null)
            {
                AttachParameters(cmd,cmdParams);
            }
            return cmd.ExecuteScalar();
        }
        public static T ExcuteScalar<T>( CommandType cmdType, string cmdText, List<SqlParameter> cmdParams = null)
        {
            try
            {
                Type type = typeof(T);
                object result = ExcuteScalar(cmdType, cmdText, cmdParams);
                if (result == null)
                {
                    return default(T);
                }
                else
                {
                    // return (T)Convert.ChangeType(result,typeof(T));
                    return (T)result;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("返回值不能转换成指定的类型！");
            }
           
           
        }
        public static int ExcuteNonQuery(CommandType cmdType, string cmdText, List<SqlParameter> cmdParams = null)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText,conn);
            cmd.CommandType = cmdType;
            if(cmdParams!=null)
            {
                AttachParameters(cmd,cmdParams);
            }
            return cmd.ExecuteNonQuery();
        }
        public static void AttachParameters(SqlCommand cmd, List<SqlParameter> cmdParams)
        {
            foreach (SqlParameter p in cmdParams)
            {
                if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input)
                    && p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
                cmd.Parameters.Add(p);
            }
        }
        public static List<SqlParameter> GetSqlParameters<T>(T queryModel)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            foreach (PropertyInfo p in queryModel.GetType().GetProperties())
            {
                var val = p.GetValue(queryModel);
                SqlParameter sqlParameter = new SqlParameter();
                if (p.PropertyType == typeof(string) && val != null)
                {
                    Attribute attr = p.GetCustomAttribute(typeof(MaxLengthAttribute));
                    MaxLengthAttribute maxLengthAttribute = attr as MaxLengthAttribute;
                    int size = maxLengthAttribute.Length;
                    sqlParameter = new SqlParameter("@" + p.Name, SqlDbType.VarChar, size);
                    sqlParameter.Value = val.ToString();
                }
                if (p.PropertyType == typeof(int) && Convert.ToInt32(val) != 0)
                {
                    sqlParameter = new SqlParameter("@" + p.Name, Convert.ToInt32(val));
                }
                if (p.PropertyType == typeof(DateTime) && val != null && Convert.ToDateTime(val) != DateTime.MinValue)
                {
                    sqlParameter = new SqlParameter("@" + p.Name, Convert.ToDateTime(val));

                }
                sqlParameters.Add(sqlParameter);
            }
            return sqlParameters;
        }
      
    }
}