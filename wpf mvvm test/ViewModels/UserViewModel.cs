using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_mvvm_test.DB;
using wpf_mvvm_test.Interfaces;
using wpf_mvvm_test.Models;

namespace wpf_mvvm_test.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged, IDisposable
    {
        private AppDBContext _database;
        private User _selectingUser;
        private User _editingUser;
        private string _searchQuery;
        private readonly ConcurrentQueue<Tokenn> _tokenQueue = new ConcurrentQueue<Tokenn>();
        private bool _isGenerating = false;
        private Thread _thread;
        private readonly IUserService _service;

        public UserViewModel(IUserService service)
        {
           // _database = new AppDBContext();
            // _database.Database.EnsureCreated();
            _service = service;
            // Users = new ObservableCollection<User>(_service.GetAll());
            LoadUsers();
            EditingUser = new User();
            //StartTokenGeneration();
            UpdateCommand = new RelayCommands(UpdateUser);
            AddCommand = new RelayCommands(AddUser);
            DeleteCommand = new RelayCommands(DeleteUser);
            SearchCommand = new RelayCommands(SearchWord);
            
        }

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public ObservableCollection<User> FilteredUsers { get; set; } = new ObservableCollection<User>();

        public User SelectedUser
        {
            get
            {
                return _selectingUser;
            }
            set
            {
                _selectingUser = value;
                if (_selectingUser != null)
                {
                    EditingUser = new User()
                    {
                        Name = _selectingUser.Name,
                        Email = _selectingUser.Email,
                        Password = _selectingUser.Password,
                        Id = _selectingUser.Id,
                        TokenValue = _selectingUser.TokenValue,
                    };
                }
                OnPropertyChanged(nameof(SelectedUser));
                

            }
        }

        public User EditingUser
        {
            get
            {
                return _editingUser;
            }
            set
            {
                _editingUser = value;
                OnPropertyChanged(nameof(EditingUser));
            }
        }

        public string SearchQuery
        {
            get
            {
                return _searchQuery;
            }
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));

            }
        }

        public ICommand UpdateCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }

        #region Queries
        private void LoadUsers()
        {
            var list = _service.GetAll();
            if (list != null)
            {
                Users.Clear();
                foreach (var user in list)
                {
                    Users.Add(user);
                }
            }
        }

        private void UpdateUser(object user)
        {
            #region old method
            //var update = _database.Users.FirstOrDefault(x=>x.Id == SelectedUser.Id);
            //if (update != null)
            //{
            //   // update.Id == EditingUser.Id;
            //    update.Email = EditingUser.Email;
            //    update.Password = EditingUser.Password;
            //    update.Name = EditingUser.Name;
            //    _database.SaveChanges();
            //    LoadUsers();
            //}
            //else
            //{
            //    throw new Exception("user doesn't exist");
            //}
            #endregion
            _service.Update(SelectedUser);
        }

        private void AddUser(object obj)
        {
            #region Old method
            //var newUser = new User
            //{
            //    Name = /* "empty string" */ EditingUser.Name,
            //    Email =/*"emptystringemail@gmail.com",*/ EditingUser.Email,
            //    Password =/*"12345688",*/ EditingUser.Password
            //};
            //_database.Users.Add(newUser);
            //_database.SaveChanges();
            //LoadUsers();
            #endregion

            #region old method 2
            //if (_tokenQueue.TryDequeue(out Tokenn token))
            //{
            //    var newUser = new User
            //    {
            //        Name = EditingUser.Name,
            //        Email = EditingUser.Email,
            //        Password = EditingUser.Password
            //    };

            //    _database.Users.Add(newUser);
            //    _database.SaveChanges();
            //    LoadUsers();
            //}
            //else
            //{
            //    throw new Exception("no token is available please wait");
            //}
            #endregion
            var user = new User()
            {
                Id = SelectedUser.Id,
                Email = EditingUser.Email,
                Name = EditingUser.Name,
                Password = EditingUser.Password,
            };

            _service.Create(user);
        }


        private void DeleteUser(object user)
        {
            #region old method
            //if(SelectedUser != null)
            //{
            //    var delete = _database.Users.FirstOrDefault(x => x.Id == SelectedUser.Id);
            //    if(delete != null)
            //    {
            //        _database.Users.Remove(delete);
            //        _database.SaveChanges();
            //        LoadUsers();
            //    }
            //    else
            //    {
            //        throw new Exception("User doesn't exist");
            //    }
            //}
            #endregion

            _service.Delete(SelectedUser.Id);
        }

        private void SearchWord(object words)
        {
            if (string.IsNullOrEmpty(SearchQuery))
            {
                FilteredUsers = new ObservableCollection<User>(Users);
            }
            else
            {
                FilteredUsers = new ObservableCollection<User>(
                    Users.Where(x => x.Name.Contains(SearchQuery)));
            }
            OnPropertyChanged(nameof(FilteredUsers));
        }

        #endregion

        #region old token generator method
        //private void StartTokenGeneration()
        //{
        //    if (_isGenerating) return;
        //    _isGenerating = true;
        //    _thread = new Thread(() =>
        //        {
        //             int tokensPerSecond //= 10;
        //             = int.Parse(ConfigurationManager.AppSettings["TokensPerSecond"]);
        //            if (!int.TryParse(ConfigurationManager.AppSettings["TokensPerSecond"], out tokensPerSecond))
        //            {
        //                tokensPerSecond = 1;
        //                throw new Exception("problem in app.config");
        //            }
        //            while (_isGenerating)
        //            {
        //                for(int i =0; i < tokensPerSecond; i++)
        //                {
        //                    _tokenQueue.Enqueue(
        //                        new Tokenn
        //                        {
        //                            Value = Guid.NewGuid().ToString()
        //                        }
        //                        );
        //                }
        //                Thread.Sleep(1000);
        //            }
        //        }
        //        );
        //    _thread.Start();
        //    var th = _thread.IsAlive;
        //    var gn = _isGenerating;
        //}

        //public void StopTokenGeneration()
        //{
        //    _isGenerating = false;
        //    if (_thread != null)
        //    {
        //        _thread.Join();

        //        _thread = null;
        //    }
        //}
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool CanExecuteUpdateOrDelete()
        {
            return SelectedUser != null;
        }

        public void Dispose()
        {
            
        }
    }
}
// inotify on viewmodel
// ef on app
// my sql on app
//binding solution
//build a crud for the app
//search field
//threading : add a thread that creates tokens (nseconds takes for creating a token that can be configured in app.xaml tokenrate 
// .net framework
// mahapps