using DataGridStyle.Modules.ModuleName;
using DataGridStyle.Services;
using DataGridStyle.Services.Interfaces;
using DataGridStyle.ViewModels;
using DataGridStyle.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace DataGridStyle
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<SubjectItemView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<TestView, TestViewModel>();
            containerRegistry.RegisterForNavigation<SubjectItemView, SubjectItemViewModel>();

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
