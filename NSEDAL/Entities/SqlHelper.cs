using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Dapper;
using System.Reflection.Metadata.Ecma335;

namespace NSEDAL.Entities
{
    public static class SqlHelper
    {
        private static string _connectionString = string.Empty;
        //public static string ConnectionString
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(_connectionString))
        //        {
        //            throw new ApplicationException("Connection not defined.");
        //        }
        //        return _connectionString;
        //    }
        //    set => _connectionString = value;
        //}

        public static void ExecuteNonQuery(string ConnectionString, string sqlQuery)
        {
            _connectionString = ConnectionString;
            DapperContext db = new DapperContext(ConnectionString);
            using (var connection = db.CreateConnection())
            {
                connection.Query(sqlQuery);
            }
        }

        public static IEnumerable<T> ExecuteDataSet<T>(string ConnectionString, string sqlQuery) where T : class
        {
            _connectionString = ConnectionString;
            DapperContext db = new DapperContext(_connectionString);
            IEnumerable<T> result = null;
            using (var connection = db.CreateConnection())
            {
                result = connection.Query<T>(sqlQuery);
            }
            return result;
        }   
    }
}
