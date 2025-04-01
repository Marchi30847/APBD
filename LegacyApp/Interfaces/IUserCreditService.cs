namespace LegacyApp.Interfaces;

using System;

public interface IUserCreditService : IDisposable
{
    int GetCreditLimit(string lastName,  DateTime dateOfBirth);

}