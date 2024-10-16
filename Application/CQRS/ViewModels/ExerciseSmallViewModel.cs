using Domain.Entity.Enum;

namespace Application.CQRS.ViewModels
{
    public record ExerciseSmallViewModel : GenericViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Muscle TargetedMuscle { get; set; }
        public Muscle SynergistMuscle { get; set; }
    }
}