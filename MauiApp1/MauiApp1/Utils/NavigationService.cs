using inWMSAndroid.src.Shared.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Utils
{
    public class NavigationService : INavigationService
    {
        protected INavigation Navigation
        {
            get
            {
                INavigation navigation = Application.Current?.MainPage?.Navigation;
                if (navigation is not null)
                    return navigation;
                else
                {
                    if (Debugger.IsAttached)
                        Debugger.Break();
                    throw new Exception();
                }
            }
        }

        public Task NavigateBack()
        {
            if (Navigation.NavigationStack.Count > 1)
                return Navigation.PopAsync();

            throw new InvalidOperationException("No pages to navigate back to!");
        }

        public Task NavigateBackToPage<T>() where T : Page
        {
            if (Navigation.NavigationStack.Count > 1)
            {
                if (!Navigation.NavigationStack.Any(x => x is T))
                {
                    throw new InvalidOperationException("Page is not on the stack!");
                }
                foreach (var page in Navigation.NavigationStack.Reverse())
                {
                    if (page is T)
                    {
                        return Task.CompletedTask;
                    }
                    Navigation.PopAsync();
                }
            }

            throw new InvalidOperationException("No pages to navigate back to!");
        }


        public async Task NavigateToPage<T>(object parameter = null) where T : Page
        {

            var toPage = CreatePage(typeof(T));
            if (toPage is not null)
            {
                toPage.NavigatedTo += Page_NavigatedTo;
                var toViewModel = GetPageViewModelBase(toPage);
                if (toViewModel is not null)
                {
                    await toViewModel.OnNavigatingTo(parameter);
                }
                await Navigation.PushAsync(toPage, true);
                toPage.NavigatedFrom += Page_NavigatedFrom;
            }
            else
                throw new InvalidOperationException($"Unable to resolve type {typeof(T).FullName}");
        }

        private async void Page_NavigatedFrom(object sender, NavigatedFromEventArgs e)
        {
            //To determine forward navigation, we look at the 2nd to last item on the NavigationStack
            //If that entry equals the sender, it means we navigated forward from the sender to another page
            bool isForwardNavigation = Navigation.NavigationStack.Count > 1
                && Navigation.NavigationStack[^2] == sender;

            if (sender is Page thisPage)
            {
                if (!isForwardNavigation)
                {
                    thisPage.NavigatedTo -= Page_NavigatedTo;
                    thisPage.NavigatedFrom -= Page_NavigatedFrom;
                }

                await CallNavigatedFrom(thisPage, isForwardNavigation);
            }
        }

        private Task CallNavigatedFrom(Page p, bool isForward)
        {
            var fromViewModel = GetPageViewModelBase(p);

            if (fromViewModel is not null)
                return fromViewModel.OnNavigatedFrom(isForward);
            return Task.CompletedTask;
        }

        private async void Page_NavigatedTo(object sender, NavigatedToEventArgs e)
            => await CallNavigatedTo(sender as Page);

        private Task CallNavigatedTo(Page p)
        {
            var fromViewModel = GetPageViewModelBase(p);

            if (fromViewModel is not null)
                return fromViewModel.OnNavigatedTo();
            return Task.CompletedTask;
        }

        private ViewModelBase? GetPageViewModelBase(Page p)
            => p?.BindingContext as ViewModelBase;

        private Page CreatePage(Type pageType)
        {
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {nameof(pageType)}");
            }
            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}
