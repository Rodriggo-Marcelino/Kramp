using Application.Response;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record UpdateEntityCommand<TEntity, TViewModel> : IRequest<ResponseBase<TViewModel>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? UserBio { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Username { get; set; }
        public string? DocumentNumber { get; set; }

        public UpdateEntityCommand()
        {

        }
    }
}
