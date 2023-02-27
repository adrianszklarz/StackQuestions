using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using inWMSAndroid.src.Shared.BaseViewModels;
using MauiApp1.View;
using MauiApp1.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    internal partial class ExamplePageViewModel : ViewModelBase
    {
        public ExamplePageViewModel()
        {
            if (!_messenger.IsRegistered<ButtonOnPage1ClickedMessage>(this))
            {
                _messenger.Register(this, (MessageHandler<object, ButtonOnPage1ClickedMessage>)(async (r, m) =>
                {
                    //SomeActionWhenRecieveMessageFrom Page1
                    Counter++;
                    await _navigation.NavigateBackToPage<ExamplePage>();
                }));
            }
        }
        [RelayCommand]
        public async Task NavigateToPage1()
        {
            await _navigation.NavigateToPage<Page1>();
        }

        [ObservableProperty]
        private int _counter;
    }
}
