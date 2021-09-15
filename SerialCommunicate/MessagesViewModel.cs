using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TEST.ViewModel;

namespace WPF_TEST.SerialCommunicate
{
    public class MessagesViewModel:BaseViewModel
    {
        private int _messagesCount;
        private string _messagesText;
        private string _toBeSentText;

        public int MessagesCount
        {
           
            get { return _messagesCount; }
            set { _messagesCount = value;OnPropertyChanged("MessagesCount"); }
        }

        public string MessagesText
        {
            get { return _messagesText; }
            set { _messagesText = value; OnPropertyChanged("MessagesText"); }
        }

        public string ToBeSentText
        {
            get { return _toBeSentText; }
            set { _toBeSentText = value; OnPropertyChanged("ToBeSentText"); }
        }

        public ICommand ClearMessagesCommand { get; }
        public ICommand SendMessageCommand { get; }

        public MessageSender Sender { get; set; }

        public MessagesViewModel()
        {
            MessagesCount = 0;
            MessagesText = "";
            ToBeSentText = "";

            ClearMessagesCommand = new RelayCommand<object>((p) => { return true; },(p) => 
            {
                ClearMessages();
            });
            SendMessageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SendMessage();
            });
        }

        private void SendMessage()
        {
            if (!string.IsNullOrEmpty(ToBeSentText))
            {
                try
                {
                    Sender.SendMessage(ToBeSentText);
                    AddSentMessage(ToBeSentText);
                    // Clear text after sending. this is a personal preference ;)
                    ToBeSentText = "";
                }
                catch (TimeoutException timeout)
                {
                    AddMessage("Timeout Exception. Couldn't send message");
                }
                catch (Exception e)
                {
                    AddMessage("Error: " + e.Message);
                }
            }
        }

        private void ClearMessages()
        {
            MessagesText = "";
            MessagesCount = 0;
        }

        public void AddSentMessage(string message)
        {
            // (Date) | TX> hello there
            AddMessage($"{DateTime.Now} | TX> {message}");
        }

        public void AddReceivedMessage(string message)
        {
            // (Date) | RX> hello there
            AddMessage($"{DateTime.Now} | RX> {message}");
        }

        public void AddMessage(string message)
        {
            WriteLine(message);
            MessagesCount++;
        }

        public void WriteLine(string text)
        {
            MessagesText += text + '\n';
        }
    }
}
