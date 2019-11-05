using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DJMS.DAL.Helpers
{
    public class DBHelper
    {
        #region Private Members
        private IDbTransaction Transaction;
        private IDbConnection Connection;
        #endregion

        public DBHelper(IDbConnection connection, IDbTransaction transaction)
        {
            this.Connection = connection;
            this.Transaction = transaction;
        }

        private IDbCommand GetCommand(string procedureName, IList<DbParameter> parameters = null, int? connectionTimeout = null)
        {
            if (this.Connection.State != ConnectionState.Open)
                this.Connection.Open();
            IDbCommand command = this.Connection.CreateCommand();
            command.CommandText = procedureName;
            command.CommandType = CommandType.StoredProcedure;
            if (connectionTimeout.HasValue)
                command.CommandTimeout = connectionTimeout.Value;
            if (parameters != null && parameters.Count > 0)
                parameters.ToList().ForEach(p => command.Parameters.Add(p));
            if (this.Transaction != null)
                command.Transaction = this.Transaction;
            return command;
        }

        #region Public Methods
        /// <summary>
        /// Description: To Execute Insert/Update/Delete Queries
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionTimeout"></param>
        public void ExecuteNonQuery(string procedureName, IList<DbParameter> parameters = null, int? connectionTimeout = null)
        {
            try
            {
                this.GetCommand(procedureName, parameters, connectionTimeout).ExecuteNonQuery();
            }
            finally
            {
                if (this.Connection != null)
                    this.Connection.Close();
            }
        }
        /// <summary>
        /// Description: To Execute Insert/Update/Delete Queries with return value
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="returnValue"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionTimeout"></param>

        public void ExecuteNonQuery(string procedureName, ref int? returnValue, IList<DbParameter> parameters = null, int? connectionTimeout = null)
        {
            try
            {
                var returnParam = new SqlParameter("@pReturnValue", 0);
                if (returnValue != null && returnValue.HasValue)
                {
                    returnParam.Direction = ParameterDirection.ReturnValue;
                    if (parameters != null)
                        parameters.Add(returnParam);
                    else
                    {
                        parameters = new List<DbParameter>();
                        parameters.Add(returnParam);
                    }
                }

                this.GetCommand(procedureName, parameters, connectionTimeout).ExecuteNonQuery();
                if (returnValue != null && returnParam.Value != null)
                {
                    returnValue = (int)returnParam.Value;
                }
            }
            finally
            {
                if (this.Connection != null)
                    this.Connection.Close();
            }
        }

        /// <summary>
        /// Description: To get single Value
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionTimeout"></param>
        /// <returns></returns>
        public object ExecuteScalar(string procedureName, IList<DbParameter> parameters = null, int? connectionTimeout = null)
        {
            try
            {
                return this.GetCommand(procedureName, parameters, connectionTimeout).ExecuteScalar();
            }
            finally
            {
                if (this.Connection != null)
                    this.Connection.Close();
            }
        }

        /// <summary>
        /// Description: To get resule set
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionTimeout"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string procedureName, IList<DbParameter> parameters = null, int? connectionTimeout = null)
        {
            return this.GetCommand(procedureName, parameters, connectionTimeout).ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// Description: To Execute command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionTimeout"></param>
        /// <returns></returns>
        public IEnumerable<T> Execute<T>(string procedureName, IList<DbParameter> parameters = null, int? connectionTimeout = null) where T : class
        {
            DbDataReader reader = this.GetCommand(procedureName, parameters, connectionTimeout).ExecuteReader(CommandBehavior.Default) as DbDataReader;
            if (reader != null)
                return DataContractHelper<T>.CreateList(reader);
            else
                return new List<T>();
        }
        #endregion
    }
}
