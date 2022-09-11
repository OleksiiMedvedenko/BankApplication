using BankApplication.Models.AccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models.AccountOperationModels
{
    public class BLIK
    {
        public int ID { get; private set; }
        public Account Account { get; private set; }
        public string CardNumber { get; private set; }
        public DateTime TimeOfCreateCode { get; private set; }
        public DateTime TimeOutCode { get; private set; }

        public BLIK(Account account, string cardNumber)
        {
            Account = account;
            CardNumber = cardNumber;
            TimeOfCreateCode = DateTime.Now;
            TimeOutCode = DateTime.Now.AddMinutes(1).AddSeconds(30);
        }
    }
}
