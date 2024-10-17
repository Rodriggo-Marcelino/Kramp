using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.Training;
using Application.Response;
using AutoMapper;
using Domain.Entity.Training;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create.Training
{
    public class CreateCompletePlanHandler : CreateEntityTemplate<
            Plan,
            CreateEntityCommand<Plan, CreateCompletePlanDTO, CompletePlanViewModel>,
            CreateCompletePlanDTO,
            CompletePlanViewModel,
            PlanRepository>
    {
        private readonly PlanRepository _repository;
        private readonly IMapper _mapper;
        private readonly PlanWorkoutRepository _planWorkoutRepository;
        private readonly WorkoutRepository _workoutRepository;
        private readonly IMediator _mediator;

        public CreateCompletePlanHandler(
            PlanRepository repository,
            IMapper mapper,
            PlanWorkoutRepository planWorkoutRepository,
            WorkoutRepository workoutRepository,
            IMediator mediator
        ) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _planWorkoutRepository = planWorkoutRepository;
            _workoutRepository = workoutRepository;
            _mediator = mediator;
        }

        protected override void ManipulateEntityBeforeSave(IEnumerable<CreateCompletePlanDTO> request, IEnumerable<Plan> entities)
        {
            foreach (var entity in entities.ToList())
            {
                entity.CreatedAt = DateTime.UtcNow;
            }
        }

        protected override void ManipulateEntityAfterSave(IEnumerable<CreateCompletePlanDTO> request, IEnumerable<Plan> entities)
        {
            foreach (var plan in entities.ToList())
            {
                foreach (var dto in request.ToList())
                {
                    if (plan.Name == dto.Name)
                    {
                        foreach (var planWorkout in dto.Workouts.ToList())
                        {
                            planWorkout.PlanId = plan.Id;
                        }
                    }
                    var command = new CreateEntityCommand<PlanWorkout, AddWorkoutToPlanDTO, PlanWorkoutViewModel>(dto.Workouts);
                    _mediator.Send(command).Wait();
                }
            }


        }

        protected override ResponseBase<IEnumerable<CompletePlanViewModel>> CreateResponse(IEnumerable<Plan>? entityList)
        {
            var viewModels = _mapper.Map<IEnumerable<CompletePlanViewModel>?>(entityList);

            viewModels = InsertWorkoutsInViewModel(viewModels, entityList);

            return new ResponseBase<IEnumerable<CompletePlanViewModel>>(new ResponseInfo(), viewModels);
        }

        private IEnumerable<CompletePlanViewModel> InsertWorkoutsInViewModel(IEnumerable<CompletePlanViewModel> viewModels, IEnumerable<Plan>? entityList)
        {
            var updatedViewModels = new List<CompletePlanViewModel>();


            foreach (var plan in entityList.ToList())
            {
                var planWorkouts = _planWorkoutRepository
                    .FindAllAsync(planWorkouts =>
                        planWorkouts.PlanId == plan.Id)
                    .Result.ToDictionary(pw => pw.Id, pw => pw.WorkoutId);

                var workouts = _workoutRepository.FindAllByIdAsync(planWorkouts.Values).Result;

                foreach (var viewModel in viewModels.ToList())
                {
                    if (viewModel.Name == plan.Name)
                    {
                        viewModel.Workouts = _mapper.Map<List<SimpleWorkoutViewModel>>(workouts);
                        updatedViewModels.Add(viewModel);
                    }
                }
            }

            return updatedViewModels;
        }
    }
}
