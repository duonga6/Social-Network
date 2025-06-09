namespace SocialNetwork.Application.Wrappers.Responses
{
    public class DataResponse<T> : IDataResponse<T>
    {
        public T Data { get; }

        public bool IsSuccess { get; } = true;

        public DataResponse(T data)
        {
            Data = data;
        }
    }
}
