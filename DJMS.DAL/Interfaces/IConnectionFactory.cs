using System;
using System.Data;

namespace DJMS.DAL.Interfaces
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
