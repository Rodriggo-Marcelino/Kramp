using Application.CQRS.GenericsCQRS.Generic.ViewModel;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels
{
    public record WorkoutExerciseViewModel : GenericViewModel
    {
        public Guid ExerciseId { get; set; }
        public ExerciseViewModel Exercise { get; set; }
        public int RestTimeInSeconds { get; set; }
        public int ExerciseTimeInSeconds { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
    }
}