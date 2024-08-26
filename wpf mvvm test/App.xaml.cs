using Microsoft.EntityFrameworkCore.Diagnostics;
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
        // private readonly UserViewModel userViewModel;
        
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
            services.AddScoped<ITokenRepo, TokenRepo>();
            services.AddSingleton<IUserService,UserService>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddDbContext<AppDBContext>();
            services.AddTransient<UserViewModel>();
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            
            base.OnStartup(e);
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            var db = new AppDBContext();
            IUserRepo _userRepo = new UserRepo(db);
            ITokenRepo _tokenRepo = new TokenRepo(db);
            IConfigReader _config = new ConfigReader();
            ITokenGenerator _tokenGen = new TokenGenerator(_config,_tokenRepo);
            IUserService _userService = new UserService(_userRepo, _tokenGen);
            UserViewModel _viewModel = new UserViewModel(_userService,_tokenRepo);
            mainWindow.DataContext = _viewModel;
            mainWindow.Show();
            #region old 
            //wpf_mvvm_test.MainWindow window = new MainWindow();
            //UserViewModel model = new UserViewModel();
            //window.DataContext = model;
            //window.Show();
            #endregion
        }
    }
}
