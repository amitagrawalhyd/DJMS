using DJMS.Common.Interfaces;

namespace DJMS.Common
{
    public sealed class SessionContext
    {
        #region Properties
        public static ISessionData Instance { get; set; }
        #endregion
    }

    public class SessionData : ISessionData
    {
        public int UserTypeId { get; set; }
    }
}
