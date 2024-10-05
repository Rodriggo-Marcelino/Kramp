﻿using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record UpdateEntityCommand<TEntity, TDTO, TViewModel>
        : IRequest<ResponseBase<TViewModel>>
    {
        public Guid Id { get; set; }
        public TDTO? Data { get; set; }
        public List<TDTO>? DataList { get; set; }

        public UpdateEntityCommand(Guid id, TDTO data)
        {
            Id = id;
            Data = data;
        }

        public UpdateEntityCommand(Guid id, List<TDTO> dataList)
        {
            Id = id;
            DataList = dataList;
        }
    }
}