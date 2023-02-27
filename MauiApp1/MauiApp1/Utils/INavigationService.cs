using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Utils
{
    public interface INavigationService
    {
        Task NavigateBack();
        Task NavigateBackToPage<T>() where T : Page;
        Task NavigateToPage<T>(object parameter = null) where T : Page;
    }
}
