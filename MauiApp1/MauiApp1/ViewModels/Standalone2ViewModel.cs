using CommunityToolkit.Mvvm.Messaging;
using inWMSAndroid.src.Shared.BaseViewModels;
using MauiApp1.View;
using MauiApp1.ViewModels.Messages;
using MauiApp1.ViewModels.Standalone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    internal partial class Standalone2ViewModel : ViewModelBase, IStandaloneViewModel
    {
        public Standalone2ViewModel()
        {
            if (!_messenger.IsRegistered<ButtonOnPage1ClickedMessage>(this))
            {
                _messenger.Register(this, (MessageHandler<object, ButtonOnPage1ClickedMessage>)(async (r, m) =>
                {
                    await _navigation.NavigateToPage<Page2>();
                }));
            }

            if (!_messenger.IsRegistered<ButtonOnPage2ClickedMessage>(this))
            {
                _messenger.Register(this, (MessageHandler<object, ButtonOnPage2ClickedMessage>)(async (r, m) =>
                {
                    //Some action for button 3
                }));
            }
        }

        public async Task Process()
        {
            await _navigation.NavigateToPage<Page1>();
        }
    }
}
