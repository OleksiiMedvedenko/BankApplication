﻿using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models.AccountOperationModels
{
    public class Deposit : IOperation
    {
        public Account DepositAccount { get; set; }
        private decimal AmountUnderRate { get; set; }
        private DateTime TimePeriod { get; set; } // время на которое клиет кладёт сумму на дипозит 
        public DateTime DepositOperationDate { get; private set; }
        public Guid DepositID { get; private set; }
        public decimal InterestRate { get; set; }
        public string CardNumber { get; private set; }

        public Deposit(Account account, decimal amount, DateTime timePeriod, string cardNumber)
        {
            DepositAccount = account;
            AmountUnderRate = amount;
            TimePeriod = timePeriod;
            CardNumber = cardNumber;
            DepositOperationDate = DateTime.Now;
        }

        public decimal PutAmountInterest()
        {
            int divisionPercentage = 0;

            var time = ReturnTimeSpan(ConvertTimeSpan(), ref divisionPercentage);

            DepositAccount.Client.Cards.SingleOrDefault(x => x.CardNumber == $"{CardNumber}").AmountOfMoney -= AmountUnderRate;

            for (int i = 1; i <= time; i++)
            {
                AmountUnderRate = AmountUnderRate + AmountUnderRate * RateOptions(AmountUnderRate) / divisionPercentage;
            }
            
            return AmountUnderRate;
        }

        private TimeSpan ConvertTimeSpan()
        {
            TimeSpan timeSpan = new TimeSpan(TimePeriod.Day, TimePeriod.Hour, TimePeriod.Minute, TimePeriod.Second);
            return timeSpan;
        }

        private int ReturnTimeSpan(TimeSpan timeSpan, ref int divisionPercentage) // Процент деления для формулы суммы в зависимости от возвращаемого значения (в зависимоти : если возврааем секунды то сумма которою получил при возврате средст с дипозита будет меньше)
        {
            if (timeSpan.Days > 0)
            {
                divisionPercentage = 250;
                return timeSpan.Days;
            }
            else if (timeSpan.Days == 0 && timeSpan.Hours != 0)
            {
                divisionPercentage = 6000; // 250 * 24 так как в сутках 24 часа 
                return timeSpan.Hours;
            }
            else if (timeSpan.Days == 0 && timeSpan.Hours == 0 && timeSpan.Minutes != 0)
            {
                divisionPercentage = 360000; // 6000 * 60 так как в часе 60 минут 
                return timeSpan.Minutes;
            }
            else if (timeSpan.Days == 0 && timeSpan.Hours == 0 && timeSpan.Minutes == 0 && timeSpan.Seconds != 0)
            {
                divisionPercentage = 21600000;
                return timeSpan.Seconds;
            }

            return 0;
        }

        public void ReturnAmountWithInterest()
        {
            DepositAccount.Client.Cards.SingleOrDefault(x => x.CardNumber == $"{CardNumber}").AmountOfMoney += AmountUnderRate;
        }

        private decimal RateOptions(decimal amount)
        {
            if (amount < 8000 && amount > 100)
                InterestRate = 0.07M;

            if (amount >= 8000 && amount < 30000)
                InterestRate = 0.09M;

            if (amount >= 30000 && amount < 100000)
                InterestRate = 0.12M;

            if (amount >= 100000)
                InterestRate = 0.17M;

            return InterestRate;
        }
    }
}
