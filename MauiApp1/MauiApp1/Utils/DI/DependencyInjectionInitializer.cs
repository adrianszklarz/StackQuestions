using Autofac;
using CommunityToolkit.Mvvm.Messaging;
using Java.Sql;
using MauiApp1.Utils;
using MauiApp1.ViewModels.Standalone;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace inWMSAndroid.Utilities.DI
{
    internal static class DependencyInjectionInitializer
    {
        public static void Initialize()
        {

            var assembly = Assembly.GetExecutingAssembly();
            DependencyInjectionManager.GetInstance().ContainerBuilder.RegisterAssemblyTypes(assembly).Where(x => x.IsClass && (!x.Name.Contains("TaskNotifier"))) //TaskNotifier jest dodawany przez CommunityToolkit.Mvvm, był problem z rozwiązywaniem go
            .AsImplementedInterfaces();




            DependencyInjectionManager.GetInstance().ContainerBuilder.RegisterType<WeakReferenceMessenger>().As<IMessenger>().SingleInstance();
            DependencyInjectionManager.GetInstance().ContainerBuilder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            RegisterViewModels();
        }


        private static void RegisterViewModels()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var standaloneViewModelType = typeof(IStandaloneViewModel);

            var viewModels = assembly.GetTypes().Where(x => x.Name.Contains("ViewModel") && !x.Name.Contains("Base") && x.IsClass );
            foreach (var type in viewModels)
            {
                if (type.IsAssignableTo(standaloneViewModelType))
                {
                    DependencyInjectionManager.GetInstance().ContainerBuilder.RegisterType(type).SingleInstance();
                }
                else
                {
                    DependencyInjectionManager.GetInstance().ContainerBuilder.RegisterType(type);
                }

            }

        }
    }
}
