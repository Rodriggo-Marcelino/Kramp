namespace Application.CQRS.GenericsCQRS.Generic.Validator
{
    public class ValidatorHelper
    {
        public string NAME_IS_REQUIRED = "O nome é obrigatório.";
        public string NAME_MIN_LENGTH = "O nome deve ter no mínimo 2 caracteres.";
        public string SURNAME_IS_REQUIRED = "O sobrenome é obrigatório.";
        public string SURNAME_MIN_LENGTH = "O sobrenome deve ter no mínimo 2 caracteres.";
        public string BIO_MIN_LENGTH = "A biografia deve ter no mínimo 10 caracteres.";
        public string BIRTHDATE_IS_REQUIRED = "A data de nascimento é obrigatória.";
        public string BIRTHDATE_MIN_AGE = "O usuário deve ter pelo menos 18 anos.";
        public string USERNAME_IS_REQUIRED = "O nome de usuário é obrigatório.";
        public string PASSWORD_IS_REQUIRED = "A senha é obrigatória.";
        public string PASSWORD_MIN_LENGTH = "A senha deve ter no mínimo 6 caracteres.";
        public string DOCUMENT_NUMBER_IS_REQUIRED = "O número do documento é obrigatório.";
        public string DOCUMENT_NUMBER_MIN_LENGTH = "O número do documento deve ter no mínimo 5 caracteres.";

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
