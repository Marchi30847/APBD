using LegacyApp.Interfaces;

namespace LegacyApp.Services
{
    public class UserValidatorService : IUserValidatorService
    {
        public bool IsEmailValid(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            return true;
        }

        public bool IsNameValid(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            return true;
        }

        public bool IsAgeValid(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            var age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }
            return true;
        }
    }
}