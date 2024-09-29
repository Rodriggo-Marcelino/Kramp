namespace Application.CQRS.GenericsCQRS.User.Validators
{
    public class ValidatorHelper
    {
        public ValidatorHelper() { }

        public bool BeAtLeast18YearsOld(DateTime birthDate)
        {
            var currentDate = DateTime.Today;
            var age = currentDate.Year - birthDate.Year;
            if (birthDate.Date > currentDate.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}
