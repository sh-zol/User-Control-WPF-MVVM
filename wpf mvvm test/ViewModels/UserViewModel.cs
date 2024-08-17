using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_mvvm_test.DB;
using wpf_mvvm_test.Models;

namespace wpf_mvvm_test.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private AppDBContext _database;
        private User _selectingUser;
        private User _editingUser;
        private string _searchQuery;
        public UserViewModel()
        {
            _database = new AppDBContext();
           // _database.Database.EnsureCreated();
            LoadUsers();

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
                if(_selectingUser != null)
                {
                    EditingUser = new User()
                    {
                        Name = _selectingUser.Name,
                        Email = _selectingUser.Email,
                        Password = _selectingUser.Password,
                        Id = _selectingUser.Id,
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

        private void LoadUsers()
        {
            Users.Clear();
            foreach (var user in _database.Users.ToList())
            {
                Users.Add(user);
            }
        }

        private void UpdateUser(object user)
        {
            var update = _database.Users.FirstOrDefault(x=>x.Id == SelectedUser.Id);
            if (update != null)
            {
               // update.Id == EditingUser.Id;
                update.Email = EditingUser.Email;
                update.Password = EditingUser.Password;
                update.Name = EditingUser.Name;
                _database.SaveChanges();
                LoadUsers();
            }
            else
            {
                throw new Exception("user doesn't exist");
            }
        }

        private void AddUser(object obj)
        {
            var newUser = new User
            {
                Name = EditingUser.Name,
                Email = EditingUser.Email,
                Password = EditingUser.Password
            };
            _database.Users.Add(newUser);
            _database.SaveChanges();
            LoadUsers();
        }


        private void DeleteUser(object user)
        {
            if(SelectedUser != null)
            {
                var delete = _database.Users.FirstOrDefault(x => x.Id == SelectedUser.Id);
                if(delete != null)
                {
                    _database.Users.Remove(delete);
                    _database.SaveChanges();
                    LoadUsers();
                }
                else
                {
                    throw new Exception("User doesn't exist");
                }
            }
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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