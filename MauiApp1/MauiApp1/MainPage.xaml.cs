using inWMSAndroid.Utilities.DI;
using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        this.BindingContext = DependencyInjectionManager.GetInstance().Resolve<MainPageViewModel>();
    }

}

