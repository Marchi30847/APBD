namespace LegacyApp.Interfaces;

using System;

public interface IUserService
{
    bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId);
}