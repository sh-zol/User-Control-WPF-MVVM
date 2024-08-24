using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using wpf_mvvm_test.DB;
using wpf_mvvm_test.EF;
using wpf_mvvm_test.Interfaces;
using wpf_mvvm_test.Token;
using wpf_mvvm_test.TokenService;
using wpf_mvvm_test.ViewModels;

namespace wpf_mvvm_test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigReader, ConfigReader>();
            services.AddSingleton<ITokenGenerator, TokenGenerator>();
            services.AddSingleton<UserService>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddDbContext<AppDBContext>();
            services.AddTransient<UserViewModel>();
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            //wpf_mvvm_test.MainWindow window = new MainWindow();
            //UserViewModel model = new UserViewModel();
            //window.DataContext = model;
            //window.Show();
        }
    }
}
