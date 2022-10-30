using BankApplication.Models.AccountModel;
using BankApplication.Models.CardsModel;
using BankApplication.Models.PersonModel;
using BankApplication.Repository.DatabaseContext;
using BankApplication.Repository.Interfaces;
using DatabaseTools.DatabaseProviderController;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository
{
    public class CardsControllerDatabase : ICardsControllerDatabase
    {
        public DatabaseQueryResult<bool> BlockingCard(Card card)
        {
            bool resultQuery = false;

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    var blockingCard = database.Cards.SingleOrDefault(x => x.CardNumber == card.CardNumber);

                    resultQuery = true;
                    blockingCard.IsActive = false;

                    database.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return new DatabaseQueryResult<bool>(resultQuery, ex.Message, ex);
            }

            return new DatabaseQueryResult<bool>(resultQuery);
        }

        public DatabaseQueryResult<bool> ChangeCardPINCode(Card card, int PINCode)
        {
            bool resultQuery = false;

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    var getCard = database.Cards.SingleOrDefault(x => x.CardNumber == card.CardNumber);

                    getCard.CardPINCode = PINCode;
                    resultQuery = true;
                    database.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return new DatabaseQueryResult<bool>(resultQuery, ex.Message, ex);
            }

            return new DatabaseQueryResult<bool>(resultQuery);
        }

        public DatabaseQueryResult<bool> CreateCard(Card card)
        {
            bool commandResult = false;

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    database.Cards.Add(card);
                    commandResult = true;
                    database.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return new DatabaseQueryResult<bool>(commandResult, ex.Message, ex);
            }

            return new DatabaseQueryResult<bool>(commandResult);
        }

        public DatabaseQueryResult<Card> GetCientCard(string parametr)
        {
            Card card = null;

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    card = database.Cards.Single(x=>x.CardNumber == parametr);
                }
            }
            catch (Exception ex)
            {
                return new DatabaseQueryResult<Card>(card, ex.Message, ex);
            }

            return new DatabaseQueryResult<Card>(card);
        }

        public DatabaseQueryResult<ObservableCollection<Card>> GetClientCards(Account account)
        {
            //ObservableCollection<Card> cards = new ObservableCollection<Card>();

            //try
            //{
            //    using (var )
            //    {

            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
            throw new NotImplementedException();

        }

        public DatabaseQueryResult<bool> SetNewCVC2CardCode(Card card, string CVC2Code = null)
        {
            throw new NotImplementedException();
        }
    }
}
