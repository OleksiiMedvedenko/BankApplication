﻿using BankApplication.Models.AccountModel;
using BankApplication.Models.CardsModel;
using BankApplication.Models.PersonModel;
using DatabaseTools.DatabaseProviderController;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository.Interfaces
{
    public interface ICardsControllerDatabase
    {
        DatabaseQueryResult<bool> CreateCard(Card card); // check on UNIQUE card number 
        DatabaseQueryResult<bool> ChangeCardPINCode(Card card, int PINCode);
        DatabaseQueryResult<bool> BlockingCard(Card card);

        /// <summary>
        /// if CVC2Code set null => random value
        /// </summary>
        /// <param name="CVC2Code"></param>
        /// <returns></returns>
        DatabaseQueryResult<bool> SetNewCVC2CardCode(Card card, string CVC2Code = null);

        /// <summary>
        /// By CardNumber or phoneNuber client
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        DatabaseQueryResult<Card> GetCientCard(string parametr); // Select Name and last name client 

        DatabaseQueryResult<ObservableCollection<Card>> GetClientCards(Account account);
    }
}
