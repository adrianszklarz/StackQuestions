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
    internal partial class StandaloneViewModel : ViewModelBase, IStandaloneViewModel
    {
        public StandaloneViewModel()
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
                    //Here some actions when process is finish e.q Call some services and restart the process, and restart process by pop up page from stack.
                    await _navigation.NavigateBackToPage<Page1>();
                }));
            }
        }

        public async Task Process()
        {
            await _navigation.NavigateToPage<Page1>();
        }
    }
}
