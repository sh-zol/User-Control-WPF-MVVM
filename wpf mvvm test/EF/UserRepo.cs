using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_test.DB;
using wpf_mvvm_test.Models;
using wpf_mvvm_test.ViewModels;

namespace wpf_mvvm_test.EF
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDBContext _context;

        public UserRepo(AppDBContext context)
        {
            _context = context;
        }
       // public AppDBContext _context = new AppDBContext();

        public void Create(User user)
        {
            var person = new User()
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                TokenValue = user.TokenValue
            };
            _context.Users.Add(person);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("user doesn't exist");
            }
        }

        public List<User> GetAll()
        {
            var list = _context.Users.AsNoTracking().ToList();
            if(list != null)
            {
                return list;
            }
            else
            {
                return new List<User>();
            }
        }

        public void Update(User user)
        {
            var userToUpdate = _context.Users.FirstOrDefault(x=>x.Id == user.Id);
            if(userToUpdate != null)
            {
                userToUpdate.Name = user.Name;
                userToUpdate.Password = user.Password;
                userToUpdate.Email = user.Email;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("user doesn't exist");
            }
        }
    }
}
