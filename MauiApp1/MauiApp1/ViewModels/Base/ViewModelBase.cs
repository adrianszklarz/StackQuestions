
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.ViewModels.Base;

namespace inWMSAndroid.src.Shared.BaseViewModels
{
    [ObservableObject]
    internal abstract partial class ViewModelBase : HandlerBase
    {

        [Obsolete("Do wywalenia jak odepniemy od wszystkiego")]
        [RelayCommand]
        protected virtual void OnAppearing()
        {
        }

        [Obsolete("Do wywalenia jak odepniemy od wszystkiego")]
        [RelayCommand]
        protected virtual void OnDisappearing()
        {
        }

        [RelayCommand]
        protected virtual async void NavigateToPreviousPage()
        {
            _messenger.UnregisterAll(this); //TODO Testowo tutaj, podczas powrotu ze strony wyrejestrowanie wszystkich eventów, które zostały zarejestrowane
            await _navigation.NavigateBack();
        }


        public virtual Task OnNavigatingTo(object? parameter)
        {
            //ArgumentNullException.ThrowIfNull(parameter, nameof(parameter));
            //if (!(parameter is Dictionary<string, object>))
            //{
            //    throw new ArgumentNullException(nameof(parameter));
            //}
            return Task.CompletedTask;
        }

        public virtual Task OnNavigatedFrom(bool isForwardNavigation)
            => Task.CompletedTask;

        public virtual Task OnNavigatedTo()
            => Task.CompletedTask;
    }
}
