using inWMSAndroid.Utilities.DI;
using MauiApp1.ViewModels;

namespace MauiApp1.View;

public partial class Page1 : ContentPage
{
	public Page1()
	{
		InitializeComponent();
        this.BindingContext = DependencyInjectionManager.GetInstance().Resolve<Page1ViewModel>();
    }
}