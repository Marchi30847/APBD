namespace APBD3.LegacyApp.Interfaces;

public interface IUserCreditService
{
    int GetCreditLimit(string lastName, DateTime dateOfBirth);

}