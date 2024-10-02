namespace Application.CQRS.GenericsCQRS.Generic.Validator
{
    public class ValidatorHelper
    {
        public string NAME_IS_REQUIRED_MSG = "O nome é obrigatório.";
        public string NAME_MIN_LENGTH_MSG = "O nome deve ter no mínimo 2 caracteres.";
        public string SURNAME_IS_REQUIRED_MSG = "O sobrenome é obrigatório.";
        public string SURNAME_MIN_LENGTH_MSG = "O sobrenome deve ter no mínimo 2 caracteres.";
        public string BIO_MIN_LENGTH_MSG = "A biografia deve ter no mínimo 10 caracteres.";
        public string BIRTHDATE_IS_REQUIRED_MSG = "A data de nascimento é obrigatória.";
        public string BIRTHDATE_MIN_AGE_MSG = "O usuário deve ter pelo menos 18 anos.";
        public string USERNAME_IS_REQUIRED_MSG = "O nome de usuário é obrigatório.";
        public string PASSWORD_IS_REQUIRED_MSG = "A senha é obrigatória.";
        public string PASSWORD_MIN_LENGTH_MSG = "A senha deve ter no mínimo 6 caracteres.";
        public string DOCUMENT_NUMBER_IS_REQUIRED_MSG = "O número do documento é obrigatório.";
        public string DOCUMENT_NUMBER_MIN_LENGTH_MSG = "O número do documento deve ter no mínimo 5 caracteres.";
        public string DESCRIPTION_MAX_LENGTH_MSG = "A descrição deve ter no máximo 244 caracteres.";
        public string JOB_IS_REQUIRED_MSG = "A profissão é obrigatória.";

        public int NAME_MIN_LENGTH_VALUE = 2;
        public int SURNAME_MIN_LENGTH_VALUE = 2;
        public int BIO_MIN_LENGTH_VALUE = 10;
        public int PASSWORD_MIN_LENGTH_VALUE = 6;
        public int DOCUMENT_NUMBER_MIN_LENGTH_VALUE = 5;
        public int DESCRIPTION_MAX_LENGTH_VALUE = 244;

        public ValidatorHelper()
        {
        }

        public bool BeAtLeast18YearsOld(DateTime birthDate)
        {
            var currentDate = DateTime.Today;
            var age = currentDate.Year - birthDate.Year;
            if (birthDate.Date > currentDate.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}