using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;
using CopaFilmes.Infrastructure.CrossCutting.Enums;

namespace CopaFilmes.Persistence.Connection
{
    public static class SqlMapperExtension
    {
        public static IEnumerable<TReturn> CommandQuery<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(this IDbConnection connection, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, DataBaseType dataBaseType, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null) =>
            connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(Treatment(sql, dataBaseType), map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public static IEnumerable<TReturn> CommandQuery<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(this IDbConnection connection, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, DataBaseType dataBaseType, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null) =>
            connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(Treatment(sql, dataBaseType), map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public static IEnumerable<TReturn> CommandQuery<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(this IDbConnection connection, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, DataBaseType dataBaseType, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null) =>
            connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(Treatment(sql, dataBaseType), map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public static IEnumerable<TReturn> CommandQuery<TFirst, TSecond, TThird, TFourth, TReturn>(this IDbConnection connection, string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, DataBaseType dataBaseType, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null) =>
            connection.Query<TFirst, TSecond, TThird, TFourth, TReturn>(Treatment(sql, dataBaseType), map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public static IEnumerable<TReturn> CommandQuery<TFirst, TSecond, TThird, TReturn>(this IDbConnection connection, string sql, Func<TFirst, TSecond, TThird, TReturn> map, DataBaseType dataBaseType, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null) =>
            connection.Query<TFirst, TSecond, TThird, TReturn>(Treatment(sql, dataBaseType), map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public static IEnumerable<TReturn> CommandQuery<TFirst, TSecond, TReturn>(this IDbConnection connection, string sql, Func<TFirst, TSecond, TReturn> map, DataBaseType dataBaseType, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null) =>
            connection.Query<TFirst, TSecond, TReturn>(Treatment(sql, dataBaseType), map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public static IEnumerable<T> CommandQuery<T>(this IDbConnection connection, string sql, DataBaseType dataBaseType, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null) =>
            connection.Query<T>(Treatment(sql, dataBaseType), param, transaction, buffered, commandTimeout, commandType);

        public static object CommandExecuteScalar(this IDbConnection connection, string sql, DataBaseType dataBaseType, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) =>
            connection.ExecuteScalar(Treatment(sql, dataBaseType), param, transaction, commandTimeout, commandType);

        public static object CommandInsert(this IDbConnection connection, string sql, DataBaseType dataBaseType, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string sequenceName = null)
        {
            object key = null;

            if (connection.Execute(Treatment(sql, dataBaseType), param, transaction, commandTimeout, commandType) > 0)
                key = connection.ExecuteScalar(GetPrimaryKey(sequenceName, dataBaseType));

            return key;
        }

        public static int CommandExecute(this IDbConnection connection, string sql, DataBaseType dataBaseType, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) =>
            connection.Execute(Treatment(sql, dataBaseType), param, transaction, commandTimeout, commandType);

        public static string Treatment(string sql, DataBaseType dataBaseType = DataBaseType.SqlServer)
        {
            switch (dataBaseType) {
                case DataBaseType.SqlServer:
                    sql = sql.Replace(":", "@");
                    break;
            }

            return sql;
        }

        public static string GetPrimaryKey(string sequence = null, DataBaseType dataBaseType = DataBaseType.SqlServer)
        {
            var sql = "";
            switch (dataBaseType) {
                case DataBaseType.SqlServer:
                    sql = " SELECT SCOPE_IDENTITY()";
                    break;
            }

            return sql;
        }
    }
}
