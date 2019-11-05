using DJMS.Common;
using DJMS.Models;
using DJMS.Repository.Security;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DJMS.DAL.Security
{
    public class SecurityService : Repositories.Repository, ISecurityService
    {
        public IEnumerable<SecurityUser> GetUsers()
        {
            try
            {                
                return DataContext.Execute<SecurityUser>("dbo.usp_Security_GetUserDetails", null);
            }
            catch (Exception ex)
            {
                base.LogError(ex, "usp_Security_GetUserDetails", string.Empty);
                return null;
            }
        }

        public DatabaseOperationResult SaveUser(SecurityUser user)
        {
            try
            {
                List<DbParameter> param = new List<DbParameter>()
                {
                    CreateParameter("@pID", user.ID),
                    CreateParameter("@pUserName", user.UserName),
                    CreateParameter("@pPassword", user.Password)
                };

                int? result = 0;
                DataContext.ExecuteNonQuery("dbo.usp_Security_ChangePassword", ref result, param);

                if (result == 1)
                    return GetOperationResult();
                else
                    return GetOperationResult(0, string.Empty);
            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(string.Format("ID: {0}", user.ID));
                builder.AppendLine(string.Format("UserName: {0}", user.UserName));
                builder.AppendLine(string.Format("Password: {0}", "************"));
                base.LogError(ex, "usp_Security_ChangePassword", builder.ToString());
                return null;
            }
        }
    }
}
