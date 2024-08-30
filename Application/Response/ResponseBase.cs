namespace Application.Response
{
    public record ResponseBase<T>
    {
        public ResponseInfo? ResponseInfo { get; init; }
        public T? Value { get; init; }
    }
}
