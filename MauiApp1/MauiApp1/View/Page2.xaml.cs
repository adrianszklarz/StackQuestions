using inWMSAndroid.Utilities.DI;
using MauiApp1.ViewModels;

namespace MauiApp1.View;

public partial class Page2 : ContentPage
{
	public Page2()
	{
		InitializeComponent();
        this.BindingContext = DependencyInjectionManager.GetInstance().Resolve<Page2ViewModel>();
    }
}