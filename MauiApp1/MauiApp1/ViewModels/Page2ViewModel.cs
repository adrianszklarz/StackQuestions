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
    internal partial class Page2ViewModel : ViewModelBase
    {
        [RelayCommand]
        public async Task Finish()
        {
            _messenger.Send(new ButtonOnPage2ClickedMessage("ButtonOnPage2Clicked"));
        }
    }
}
