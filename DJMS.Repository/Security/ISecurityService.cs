using DJMS.Common;
using DJMS.Models;
using System.Collections.Generic;

namespace DJMS.Repository.Security
{
    public interface ISecurityService
    {
        IEnumerable<SecurityUser> GetUsers();
        DatabaseOperationResult SaveUser(SecurityUser user);
    }
}
