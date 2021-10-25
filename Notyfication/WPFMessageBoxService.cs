using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_TEST.Notyfication
{
    interface IMessageBoxService
    {
        bool ShowMessage(string text, string caption, MessageType messageType);
    }
    class WPFMessageBoxService
    {
        public void ShowMessage(string text, string caption, MessageType messageType)
        {
            // TODO: Choose MessageBoxButton and MessageBoxImage based on MessageType received
            MessageBox.Show(text, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
