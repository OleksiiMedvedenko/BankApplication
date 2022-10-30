using BankApplication.Models.PersonModel;
using System;

namespace BankApplication.Models.CardsModel
{
    public class Card
    {
        public int CardID { get; private set; }
        public virtual Client Client { get; private set; }

        public int CVC2Code { get; private set; }
        public string CardNumber { get; set; }
        public int CardPINCode { get; set; }
        public decimal AmountOfMoney { get; set; }
        public CurrencyType CardCurrencyType { get; private set; }
        public DateTime CreateCardDate { get; private set; }
        public DateTime ExpiryCardDate { get; private set; }
        public bool IsActive { get; set; } // card can be 


        /// <summary>
        /// For get Card From DB
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="cardNumber"></param>
        /// <param name="amountOfMoney"></param>
        /// <param name="client"></param>
        /// <param name="cardCurrencyType"></param>
        /// <param name="createCardDate"></param>
        public Card(int cardID, int securityCode, string cardNumber, int cardPINCode, decimal amountOfMoney, Client client, CurrencyType cardCurrencyType, DateTime createCardDate, bool isActive)
        {
            CardID = cardID;
            CVC2Code = securityCode;
            CardNumber = cardNumber;
            CardPINCode = cardPINCode;
            AmountOfMoney = amountOfMoney;
            Client = client;
            CardCurrencyType = cardCurrencyType;
            CreateCardDate = createCardDate;
            IsActive = isActive;
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
        public Card(int securityCode, string cardNumber, int cardPINCode, decimal amountOfMoney, Client client, CurrencyType cardCurrencyType)
        {
            CVC2Code = securityCode;
            CardNumber = cardNumber;
            CardPINCode = cardPINCode;
            AmountOfMoney = amountOfMoney;
            Client = client;
            CardCurrencyType = cardCurrencyType;
            CreateCardDate = DateTime.Now;
            IsActive = true;
        }
    }
}
