using BankApplication.Models.PersonModel;
using System;

namespace BankApplication.Models.AccountModel
{
    public class Account
    {
        public int AccountID { get; private set; }
        public virtual Client Client { get; private set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; private set; }
        public Guid AccountCode { get; set; }
        public bool IsActive { get; set; }
        public string SecretWord { get; set; }

        /// <summary>
        /// For get Account from DB
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="interestRate"></param>
        /// <param name="client"></param>
        /// <param name="registrationDate"></param>
        /// <param name="accountCode"></param>
        public Account(int accountID, string login, string password, Client client, DateTime registrationDate, Guid accountCode, bool isActive, string secretWord)
        {
            AccountID = accountID;
            Login = login;
            Password = password;
            Client = client;
            RegistrationDate = registrationDate;
            AccountCode = accountCode;
            IsActive = isActive;
            SecretWord = secretWord;
        }

        /// <summary>
        /// For Create Account
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="interestRate"></param>
        /// <param name="client"></param>
        public Account(int accountID, string login, string password, Client client, string secretWord)
        {
            AccountID = accountID;
            Login = login;
            Password = password;
            Client = client;
            SecretWord = secretWord;
            RegistrationDate = DateTime.Now;
            AccountCode = Guid.NewGuid();
            IsActive = false; // admin check and confirm create acc 
        }
    }
}
