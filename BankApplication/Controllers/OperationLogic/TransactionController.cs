using BankApplication.Models.AccountOperationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Controllers.OperationLogic
{
    public class TransactionController
    {
        
        //public static Transaction ExecuteTransactionOperation(Transaction transaction, string fromCardNumber, string toCardNumber)
        //{
        //    try
        //    {
        //        transaction.FromAccount.Client.Cards.SingleOrDefault(x => x.CardNumber == $"{fromCardNumber}").AmountOfMoney -= transaction.OperationAmount;
        //        transaction.ToAccount.Client.Cards.SingleOrDefault(x => x.CardNumber == $"{toCardNumber}").AmountOfMoney += transaction.OperationAmount;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
