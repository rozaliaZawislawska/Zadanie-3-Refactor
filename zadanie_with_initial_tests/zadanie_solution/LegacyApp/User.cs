using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        public User(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, int clientId)
        {
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            
            
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);
            
            if (client.Type == "VeryImportantClient")
            {
                HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                CreditLimit = getCreditLimitFromService() * 2;
            }
            else
            {
                HasCreditLimit = true;
                CreditLimit = getCreditLimitFromService();
            }
            
        }

        public bool IsCorrectLimit()
        {
            
            if (HasCreditLimit && CreditLimit < 500)
            {
                return false;
            }

            return true;
        }

        private int getCreditLimitFromService()
        {
            using (var userCreditService = new UserCreditService())
            {
                return userCreditService.GetCreditLimit(LastName, DateOfBirth);
            }
        }
    }
    
}