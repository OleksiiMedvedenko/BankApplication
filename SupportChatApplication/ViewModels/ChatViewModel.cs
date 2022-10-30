using Prism.Commands;
using Prism.Mvvm;
using SupportChatApplication.Models;
using SupportChatApplication.ViewModels.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SupportChatApplication.ViewModels
{
    public class ChatViewModel : BindableBase, IChatViewModel
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            { 
                _selectedContact = value;
                RaisePropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set 
            { 
                _message = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SendCommand { get; set; }

        public ChatViewModel()
        {
            SendCommand = new DelegateCommand(SendMessage);


            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            Messages.Add(new MessageModel
            {
                Username = "Test USER",
                UsernameColor = "#409aff",
                Message = "Test",
                SendingTime = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });


            Messages.Add(new MessageModel
            {
                Username = "Test USER",
                UsernameColor = "#409aff",
                Message = "Last",
                SendingTime = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = false
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Test USER {i}",
                    Messages = Messages
                });
            }
        }

        private void SendMessage()
        {
            if (!string.IsNullOrEmpty(Message) && SelectedContact != null)
            {
                Messages.Add(new MessageModel
                {
                    Message = Message
                });

                Message = string.Empty;
            }
        }
    }
}
