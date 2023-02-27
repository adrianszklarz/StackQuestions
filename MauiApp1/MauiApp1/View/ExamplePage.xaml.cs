using inWMSAndroid.Utilities.DI;
using MauiApp1.ViewModels;

namespace MauiApp1.View;

public partial class ExamplePage : ContentPage
{
	public ExamplePage()
	{
		InitializeComponent();
        this.BindingContext = DependencyInjectionManager.GetInstance().Resolve<ExamplePageViewModel>();

    }
}