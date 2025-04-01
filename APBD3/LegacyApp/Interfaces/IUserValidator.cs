namespace APBD3.LegacyApp.Interfaces;

public interface IUserValidator
{
    bool ValidateBasicUserInfo(string firstName, string lastName, string email, DateTime dateOfBirth);
}