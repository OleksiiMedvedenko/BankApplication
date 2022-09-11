using BankApplication.Models.CardsModel;
using BankApplication.Models.ParseData.DateTime;
using BankApplication.Models.PersonModel;
using BankApplication.ViewModels.Interface;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankApplication.ViewModels
{
    public class AccountStatisticsSettingsViewModel : BindableBase, IAccountStatisticsSettingsViewModel
    {
        public ICommand GetExpensesORReceiptsByDataRangeButtonClickCommand { get; set; }

        public AccountStatisticsSettingsViewModel()
        {
            var client = new Client(1, "test", "test", "test@gmail.com", "123456", "FZ123", new byte[3]);

            DisplayAllClientCards = new ObservableCollection<Card>()
            {
                new Card(321, "5124-5234-6731-7313", 0512, 235, client, CurrencyType.EUR),
                new Card(323, "2351-6342-6342-9074", 5125, 9321, client, CurrencyType.PLN),
            };

            GetExpensesORReceiptsByDataRangeButtonClickCommand = new DelegateCommand(GetExpensesORReceiptsByDataRange);

            SelectDateRange = new List<DateTime>();
        }

        private List<DateTime> SelectDateRange { get; set; }


        private ObservableCollection<Card> _displayAllClientCards;
        public ObservableCollection<Card> DisplayAllClientCards
        {
            get { return _displayAllClientCards; }
            set 
            {
                _displayAllClientCards = value;
                RaisePropertyChanged();
            }
        }

        private Card _selectedCard;
        public Card SelectedCard
        {
            get { return _selectedCard; }
            set 
            {
                _selectedCard = value;
                CardNumberTextBlock = SelectedCard.CardNumber;
                CardCurrency = SelectedCard.CardCurrencyType.ToString();
                AmountOnTheSelectedCardTextBlock = SelectedCard.AmountOfMoney.ToString() + " " + SelectedCard.CardCurrencyType;
                RaisePropertyChanged();
            }
        }

        private string _cardNumberTextBlock;
        public string CardNumberTextBlock
        {
            get { return _cardNumberTextBlock; }
            set 
            { 
                _cardNumberTextBlock = value;
                RaisePropertyChanged();
            }
        }

        private string _amountOnTheSelectedCardTextBlock;

        public string AmountOnTheSelectedCardTextBlock
        {
            get { return _amountOnTheSelectedCardTextBlock; }
            set 
            {
                _amountOnTheSelectedCardTextBlock = value;
                RaisePropertyChanged();
            }
        }

        private DateTime _selectDate = DateTime.Now;
        public DateTime SelectDate
        {
            get { return _selectDate; }
            set 
            {
                _selectDate = value;

                if (SelectDateRange.Count == 2)
                {
                    SelectDateRange.Remove(SelectDateRange[0]);
                }
                SelectDateRange.Add(_selectDate);
                RaisePropertyChanged();
            }
        }

        private DateTime _endDayInCaledar;
        public DateTime EndDayInCaledar
        {
            get { return _endDayInCaledar; }
            set 
            { 
                _endDayInCaledar = DateTime.Now;
                RaisePropertyChanged();
            }
        }


        private string _displayDataRange;
        public string DisplayDataRange
        {
            get { return _displayDataRange; }
            set
            {
                _displayDataRange = value;
                RaisePropertyChanged();
            }
        }

        private string _cardCurrency;
        public string CardCurrency
        {
            get { return _cardCurrency; }
            set 
            {
                _cardCurrency = value;
                RaisePropertyChanged();
            }
        }


        private void ParseAndSetDateForUI()
        {
            if (SelectDateRange.Count == 2)
            {
                if (SelectDateRange[0].Year == SelectDateRange[1].Year)
                {
                    StringBuilder result = new StringBuilder();
                    result.Append(SelectDateRange[0].Day + " ");
                    result.Append((Months)SelectDateRange[0].Month);
                    result.Append(" - ");
                    result.Append(SelectDateRange[1].Day + " ");
                    result.Append((Months)SelectDateRange[1].Month + " ");
                    result.Append(SelectDateRange[1].Year);

                    DisplayDataRange = result.ToString();
                }
                else if (SelectDateRange[0].Year != SelectDateRange[1].Year)
                {
                    StringBuilder result = new StringBuilder();
                    result.Append(SelectDateRange[0].Day + " ");
                    result.Append((Months)SelectDateRange[0].Month);
                    result.Append(" - ");
                    result.Append(SelectDateRange[1].Day + " ");
                    result.Append((Months)SelectDateRange[1].Month + " ");
                    result.Append(SelectDateRange[0].Year);
                    result.Append("-");
                    result.Append(SelectDateRange[1].Year.ToString().Substring(2));

                    DisplayDataRange = result.ToString();
                }

                SelectDateRange.Clear();
            }
        }

        private void GetExpensesORReceiptsByDataRange()
        {
            ParseAndSetDateForUI();
        }

    }
}
