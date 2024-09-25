namespace Application.Response
{
    public record ResponseBase<T>
    {
        private object viewModel;

        public ResponseInfo? ResponseInfo { get; init; }
        public T? Value { get; init; }

        public ResponseBase(ResponseInfo responseInfo, object viewModel, T value)
        {
            this.ResponseInfo = null;
            this.viewModel = viewModel;
            this.Value = value;
        }

        public ResponseBase()
        {

        }
    }
}
