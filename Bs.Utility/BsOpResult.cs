namespace Bs.Utility
{
    public class BsOpResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public BsOpError ErrorInfo { get; set; }
    }

    public class BsOpError
    {
        public string Class { get; set; }
        public string Method { get; set; }
        public string ErrorMessage { get; set; }
    }
}