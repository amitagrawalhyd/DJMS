namespace DJMS.Common
{
    public class DatabaseOperationResult
    {
        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; }
        public DatabaseOperations OperationStatus { get; set; }
        public DatabaseErrorType ErrorType { get; set; }

        public DatabaseOperationResult()
        {
            ErrorId = 1;
            ErrorMessage = string.Empty;
            OperationStatus = DatabaseOperations.SavedSuccessfully;
            ErrorType = DatabaseErrorType.None;
        }
    }

    public enum DatabaseOperations : int
    {
        Failed = 0,
        SavedSuccessfully = 1,
        UnexpectedError = 2,
        AlreadyExists = 3,
        UnabletoConnectWebAPIService = 4
    }

    public enum DatabaseErrorType : int
    {
        None = 0,
        System = 1,
        User = 2
    }
}
