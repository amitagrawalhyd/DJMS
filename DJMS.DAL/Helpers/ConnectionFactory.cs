using DJMS.Common;
using DJMS.DAL.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DJMS.DAL.Helpers
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection GetConnection
        {
            get
            {
                string connectionString = ApplicationContext.Instance.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing){ }

                disposedValue = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
