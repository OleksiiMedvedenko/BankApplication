﻿using BankApplication.Models.PersonModel;
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
        public bool IsActive { get; private set; }

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
        public Account(int accountID, string login, string password, float interestRate, Client client, DateTime registrationDate, Guid accountCode, bool isActive)
        {
            AccountID = accountID;
            Login = login;
            Password = password;
            Client = client;
            RegistrationDate = registrationDate;
            AccountCode = accountCode;
            IsActive = isActive;
        }

        /// <summary>
        /// For Create Account
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="interestRate"></param>
        /// <param name="client"></param>
        public Account(int accountID, string login, string password, float interestRate, Client client)
        {
            AccountID = accountID;
            Login = login;
            Password = password;
            Client = client;
            RegistrationDate = DateTime.Now;
            AccountCode = Guid.NewGuid();
            IsActive = true;
        }
    }
}
