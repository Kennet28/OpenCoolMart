namespace OpenCoolMart.Api.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; private set; }
        public ApiResponse(T data)
        {
            this.Data = data;
        }

    }
}
