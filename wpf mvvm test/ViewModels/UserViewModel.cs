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
using wpf_mvvm_test.Token;

namespace wpf_mvvm_test.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged, IDisposable
    {
        private User _selectingUser;
        private User _editingUser;
        private string _searchQuery;
        private readonly IUserService _service;
        private readonly ITokenRepo _tokenRepo;

        public UserViewModel(IUserService service, ITokenRepo tokenRepo)
        {
            _service = service;
            Users = new ObservableCollection<User>(LoadUsers());
            FilteredUsers = new ObservableCollection<User>();
            EditingUser = new User();
            UpdateCommand = new RelayCommands(UpdateUser);
            AddCommand = new RelayCommands(AddUser);
            DeleteCommand = new RelayCommands(DeleteUser);
            SearchCommand = new RelayCommands(SearchWord);
            _tokenRepo = tokenRepo;
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
                        //TokenValue = _selectingUser.TokenValue,
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
            var user = new User()
            {
                Id = SelectedUser.Id,
                Email = EditingUser.Email,
                Name = EditingUser.Name,
                Password = EditingUser.Password,
            };
            _service.Update(user);
        }

        private void AddUser(object obj)
        {
            var user = new User()
            {
                Email = EditingUser.Email,
                Name = EditingUser.Name,
                Password = EditingUser.Password,
            };
            _service.Create(user);
            _tokenRepo.DecreaseToken();
            
        }


        private void DeleteUser(object user)
        {
            _service.Delete(SelectedUser.Id);
        }

        private void SearchWord(object words)
        {
            var list = _service.SearchUsers(SearchQuery);
            if(list != null)
            {
                foreach(var item in list)
                {
                    FilteredUsers.Add(item);
                }
            }
            else
            {    
                FilteredUsers(_service.GetAll());
            }
        }

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
