using CommunityToolkit.Mvvm.Input;
using inWMSAndroid.src.Shared.BaseViewModels;
using inWMSAndroid.Utilities.DI;
using MauiApp1.View;
using MauiApp1.ViewModels.Standalone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    internal partial class MainPageViewModel : ViewModelBase
    {
        [RelayCommand]
        public async Task Button1Click()
        {
            await _navigation.NavigateToPage<ExamplePage>();

        }

        [RelayCommand]
        public async Task Button2Click()
        {
            IStandaloneViewModel viewModel = DependencyInjectionManager.GetInstance().Resolve<StandaloneViewModel>();
            await viewModel.Process();

        }

        [RelayCommand]
        public async Task Button3Click()
        {
            IStandaloneViewModel viewModel = DependencyInjectionManager.GetInstance().Resolve<Standalone2ViewModel>();
            await viewModel.Process();

        }
    }
}
