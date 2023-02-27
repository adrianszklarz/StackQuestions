using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using inWMSAndroid.src.Shared.BaseViewModels;
using MauiApp1.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    internal partial class Page1ViewModel : ViewModelBase
    {
        [RelayCommand]
        public async Task ButtonClicked()
        {
            _messenger.Send(new ButtonOnPage1ClickedMessage("ButtonOnPage1Clicked"));
        }
    }
}
