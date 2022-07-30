using BankApplication.Models.PersonModel;
using System;

namespace BankApplication.Models.CardsModel
{
    public class Card
    {
        public int CardID { get; private set; }
        public string CardNumber { get; set; }
        public decimal AmountOfMoney { get; set; }
        public Client Client { get; private set; }
        public CurrencyType CardCurrencyType { get; private set; }
        public DateTime CreateCardDate { get; private set; }


        /// <summary>
        /// For get Card From DB
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="cardNumber"></param>
        /// <param name="amountOfMoney"></param>
        /// <param name="client"></param>
        /// <param name="cardCurrencyType"></param>
        /// <param name="createCardDate"></param>
        public Card(int cardID, string cardNumber, decimal amountOfMoney, Client client, CurrencyType cardCurrencyType, DateTime createCardDate)
        {
            CardID = cardID;
            CardNumber = cardNumber;
            AmountOfMoney = amountOfMoney;
            Client = client;
            CardCurrencyType = cardCurrencyType;
            CreateCardDate = createCardDate;
        }


        /// <summary>
        /// For Create Card
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="cardNumber"></param>
        /// <param name="amountOfMoney"></param>
        /// <param name="client"></param>
        /// <param name="cardCurrencyType"></param>
        /// <param name="createCardDate"></param>
        public Card(int cardID, string cardNumber, decimal amountOfMoney, Client client, CurrencyType cardCurrencyType)
        {
            CardID = cardID;
            CardNumber = cardNumber;
            AmountOfMoney = amountOfMoney;
            Client = client;
            CardCurrencyType = cardCurrencyType;
            CreateCardDate = DateTime.Now;
        }
    }
}
