namespace LegacyApp.Interfaces;

public interface IUserValidatorService
{
    bool IsEmailValid(string email);
    bool IsNameValid(string firstName, string lastName);
    bool IsAgeValid(DateTime dateOfBirth);
}