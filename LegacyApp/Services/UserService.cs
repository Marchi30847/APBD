using System;
using LegacyApp.Entities;
using LegacyApp.Interfaces;
using LegacyApp.Repositories;

namespace LegacyApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserValidatorService _userValidatorService;

        public UserService() : this(new UserValidatorService())
        {
        }

        public UserService(IUserValidatorService userValidatorService)
        {
            _userValidatorService = userValidatorService;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var validName = _userValidatorService.IsNameValid(firstName, lastName);
            var validEmail = _userValidatorService.IsEmailValid(email);
            var validAge = _userValidatorService.IsAgeValid(dateOfBirth);

            if (!(validName && validEmail && validAge))
            {
                return false;
            }

            IClientRepository clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                using (IUserCreditService userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (IUserCreditService userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}