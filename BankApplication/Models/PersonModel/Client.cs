using BankApplication.Models.CardsModel;
using System;
using System.Collections.ObjectModel;

namespace BankApplication.Models.PersonModel
{
    public class Client
    {
        public int ClientID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string PassportNumber { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public Guid ClientUniqueNumber { get; private set; }

        public ObservableCollection<Card> Cards { get; private set; }

        /// <summary>
        /// For Get client From DB
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="passportNumber"></param>
        /// <param name="registrationDate"></param>
        /// <param name="clientUniqueNumber"></param>
        /// <param name="cards"></param>
        public Client(int clientID, string firstName, string lastName, string email, string phoneNumber, 
            string passportNumber, DateTime registrationDate, Guid clientUniqueNumber, ObservableCollection<Card> cards)
        {
            Cards = new ObservableCollection<Card>();

            ClientID = clientID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            PassportNumber = passportNumber;
            RegistrationDate = registrationDate;
            ClientUniqueNumber = clientUniqueNumber;
            Cards = cards;
        }

        /// <summary>
        /// For Create Client
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="passportNumber"></param>
        public Client(int clientID, string firstName, string lastName, string email, string phoneNumber, string passportNumber)
        {
            Cards = new ObservableCollection<Card>();

            ClientID = clientID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            PassportNumber = passportNumber;
            RegistrationDate = DateTime.Now;
            ClientUniqueNumber = new Guid();
        }
    }
}
