namespace Application.Response
{
    public record ResponseBase<T>
    {

        public ResponseInfo? ResponseInfo { get; init; }
        public T? Value { get; init; }

        public ResponseBase(ResponseInfo responseInfo, T value)
        {
            this.ResponseInfo = null;
            this.Value = value;
        }

        public ResponseBase()
        {
        }
    }
}
