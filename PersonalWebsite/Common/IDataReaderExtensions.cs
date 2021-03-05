using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PersonalWebsite.Common
{
    public static class IDataReaderExtensions
    {
        public static List<T> ToList<T>(this IDataReader sdr) where T:class,new()
        {
            List<T> list = new List<T>();
            if (sdr == null) return list;
            int len = sdr.FieldCount;
            while (sdr.Read())
            {
                T info = new T();
                for (int j = 0;j<len;j++)
                {
                    if (sdr[j] == null || string.IsNullOrEmpty(sdr[j].ToString())) continue;
                    PropertyInfo pi = info.GetType().GetProperty(sdr.GetName(j).Trim());
                    pi.SetValue(info, sdr[j], null);
                }
                list.Add(info);
            }
            sdr.Close();
            sdr.Dispose();
            sdr = null;
            return list;
        }
        public static void Fetch<T>(this IDataReader sdr,T model)
        {
            
            if (sdr == null) return ;
            int len = sdr.FieldCount;
            for (int j = 0;j<len;j++)
            {
                if (sdr[j] == null || string.IsNullOrEmpty(sdr[j].ToString())) continue;
                PropertyInfo pi = model.GetType().GetProperty(sdr.GetName(j).Trim());
                pi.SetValue(model, sdr[j], null);
            }
           

        }
    }
}