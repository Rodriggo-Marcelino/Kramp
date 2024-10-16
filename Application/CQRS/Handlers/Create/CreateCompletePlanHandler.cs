﻿using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create
{
    public class CreateCompletePlanHandler(PlanRepository repository, IMapper mapper) : CreateEntityTemplate<
            Plan,
            CreateEntityCommand<Plan, CreateCompletePlanDTO, CompletePlanViewModel>,
            CreateCompletePlanDTO,
            CompletePlanViewModel,
            PlanRepository>(repository, mapper)
    {
    }
}
