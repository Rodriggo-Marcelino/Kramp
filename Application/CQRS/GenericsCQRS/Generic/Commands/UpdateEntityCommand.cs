using Application.Response;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record UpdateEntityCommand<TEntity, TViewModel> : IRequest<ResponseBase<TViewModel>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
