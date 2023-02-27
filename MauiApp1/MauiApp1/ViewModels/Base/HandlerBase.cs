
using CommunityToolkit.Mvvm.Messaging;
using inWMSAndroid.Utilities.DI;
using MauiApp1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels.Base
{
    internal abstract class HandlerBase
    {
        protected IMessenger _messenger;

        protected INavigationService _navigation;
        public HandlerBase()
        {

            _messenger = DependencyInjectionManager.GetInstance().Resolve<IMessenger>();

            _navigation = DependencyInjectionManager.GetInstance().Resolve<INavigationService>();
        }
        protected virtual void ExecuteCommandAndBlockNextCall(ref bool boolAllowExecuteValue, Action action)
        {
            if (boolAllowExecuteValue)
            {
                boolAllowExecuteValue = false;
                action.Invoke();
            }
        }

    }
}
