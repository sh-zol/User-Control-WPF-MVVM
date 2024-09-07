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
    private IServiceProvider _serviceProvider;
        
        public App()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IConfigReader, ConfigReader>();
            services.AddScoped<ITokenRepo, TokenRepo>();
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddDbContext<AppDBContext>();
            services.AddTransient<UserViewModel>();
            services.AddTransient<MainWindow>();
            var db = new AppDBContext();
            IUserRepo _userRepo = new UserRepo(db);
            ITokenRepo _tokenRepo = new TokenRepo(db);
            IConfigReader _config = new ConfigReader();
            IUserService _userService = new UserService(_userRepo);
            UserViewModel _viewModel = new UserViewModel(_userService, _tokenRepo);
            services.AddSingleton(typeof(UserViewModel), _viewModel);
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            
            base.OnStartup(e);
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            var _viewModel = _serviceProvider.GetRequiredService<UserViewModel>();
            mainWindow.DataContext = _viewModel;
            mainWindow.Show();
            #region old 
            //wpf_mvvm_test.MainWindow window = new MainWindow();
            //UserViewModel model = new UserViewModel();
            //window.DataContext = model;
            //window.Show();
            #endregion
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            
        }
    }
}
