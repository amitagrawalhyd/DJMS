using DJMS.Common.Interfaces;

namespace DJMS.Common
{
    public sealed class ApplicationContext
    {
        #region Properties
        public static IApplicationData Instance { get; set; }
        #endregion
    }

    public class ApplicationData : IApplicationData
    {
        public string ConnectionString { get; set; }
    }
}
