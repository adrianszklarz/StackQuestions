using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels.Messages
{
    internal class ButtonOnPage2ClickedMessage : ValueChangedMessage<string>
    {
        public ButtonOnPage2ClickedMessage(string value) : base(value)
        {

        }
    }
}
