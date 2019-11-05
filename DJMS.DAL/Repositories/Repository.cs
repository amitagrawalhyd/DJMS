using DJMS.Common;
using DJMS.DAL.Helpers;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DJMS.DAL.Repositories
{
    public abstract class Repository : IDisposable
    {
        #region Private properties
        private bool _disposed;
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get; private set; }
        protected DBHelper DataContext { get; private set; }
        #endregion

        #region CTOR
        public Repository()
        {
            CreateConnection(null);
        }

        public Repository(IDbTransaction transaction)
        {
            CreateConnection(transaction);
        }
        #endregion

        #region Private Methods
        /// <summary>
        ///  Description : To Create Connection
        /// </summary>
        /// <param name="transaction"></param>
        private void CreateConnection(IDbTransaction transaction)
        {
            if (transaction == null)
            {
                var connectionFactory = new ConnectionFactory();
                this.Connection = connectionFactory.GetConnection;
                this.Transaction = null;
            }
            else
                this.Transaction = transaction;
            this.DataContext = new DBHelper(this.Connection, this.Transaction);
        }

        /// <summary>
        ///  Description : To Dispose the objects
        /// </summary>
        /// <param name="disposing"></param>
        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (this.Transaction != null)
                    {
                        this.Transaction.Dispose();
                        this.Transaction = null;
                    }
                    if (this.Connection != null)
                    {
                        this.Connection.Close();
                        this.Connection.Dispose();
                        this.Connection = null;
                    }
                }
                _disposed = true;
            }
        }

        #endregion


        #region Public Methods
        /// <summary>
        ///  Description : To create the Database Parameter based on DB type, flow direction.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string parameterName, object value, DbType? dbType = null, ParameterDirection? direction = null)
        {
            SqlParameter param = new SqlParameter(parameterName, value);
            if (direction.HasValue)
                param.Direction = direction.Value;
            if (dbType.HasValue)
                param.DbType = dbType.Value;
            return param;
        }

        /// <summary>
        ///  Description : To Save/Update the changes.
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                if (this.Transaction != null)
                    this.Transaction.Commit();
            }
            catch
            {
                if (this.Transaction != null)
                    this.Transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        ///  Description : To Rollback the Transaction.
        /// </summary>
        public void RollbackChanges()
        {
            try
            {
                if (this.Transaction != null)
                    this.Transaction.Rollback();
            }
            finally
            {
                if (this.Transaction != null)
                    this.Transaction.Dispose();
                this.Connection.Close();
            }
        }

        public void LogError(Exception ex, string storedProcedureName = "", string jsonData = "")
        {
            try
            {
                StringBuilder errorData = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(storedProcedureName))
                    errorData.AppendLine(storedProcedureName + "-");
                if (!string.IsNullOrWhiteSpace(jsonData))
                    errorData.AppendLine(jsonData);
                if (ex.InnerException != null)
                    errorData.AppendLine(string.Concat("innerException: ", ex.InnerException.Message, ex.InnerException.Source, ex.InnerException.StackTrace));
            }
            catch
            {
                //do nothing
            }
        }

        public DatabaseOperationResult GetOperationResult()
        {
            return new DatabaseOperationResult();
        }

        public DatabaseOperationResult GetOperationResult(int errorId, string errorMessage = "")
        {

            DatabaseOperationResult operationResult = new DatabaseOperationResult()
            {
                ErrorId = errorId,
                ErrorMessage = errorMessage,
                OperationStatus = DatabaseOperations.Failed,
                ErrorType = DatabaseErrorType.User
            };
            return operationResult;
        }

        public DatabaseOperationResult GetOperationResult(DatabaseOperations databaseOperations)
        {
            return new DatabaseOperationResult()
            {
                OperationStatus = databaseOperations,
                ErrorType = DatabaseErrorType.User
            };
        }

        public DatabaseOperationResult GetOperationResult(Exception ex, string storedProcedureName = "", string jsonData = "")
        {
            DatabaseOperationResult operationResult = new DatabaseOperationResult();
            try
            {
                operationResult.OperationStatus = DatabaseOperations.UnexpectedError;
                operationResult.ErrorType = DatabaseErrorType.System;
                operationResult.ErrorId = 0;
                StringBuilder errorData = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(storedProcedureName))
                    errorData.AppendLine(storedProcedureName + "-");
                if (!string.IsNullOrWhiteSpace(jsonData))
                    errorData.AppendLine(jsonData);
                if (ex.InnerException != null)
                    errorData.AppendLine(string.Concat("innerException: ", ex.InnerException.Message, ex.InnerException.Source, ex.InnerException.StackTrace));
            }
            catch
            {
                //do nothing
            }
            return operationResult;
        }

        /// <summary>
        ///  Description : To Dispose the objects.
        /// </summary>
        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Establishes Connection to Database
        /// </summary>
        public void Connect()
        {
            CreateConnection(null);
        }

        #endregion

        /// <summary>
        ///  Description : Destructor.
        /// </summary>
        ~Repository()
        {
            dispose(false);
        }
    }
}
