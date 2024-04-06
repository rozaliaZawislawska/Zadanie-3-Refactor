using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            CorrectDataFormat correctDataFormat = new CorrectDataFormat(firstName, lastName, email);
            if (!correctDataFormat.IsCorrectFormat())
            {
                return false;
            }

            if (!CorrectAge(dateOfBirth))
                return false;
            

            var user = new User(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)

            UserDataAccess.AddUser(user);
            return true;
        }

        private bool CorrectAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            return true;
        }
    }
    
}
