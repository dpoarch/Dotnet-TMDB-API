namespace Assesment.Models.Shared
{
    public class TransactionResponse<T> : TransactionResponse where T : class
    {
        public T Response { get; set; }
    }


    public class TransactionResponse
    {
        public TransactionResponse()
        {
            IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
