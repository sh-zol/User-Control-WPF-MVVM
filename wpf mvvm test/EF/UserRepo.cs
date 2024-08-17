using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_test.Models;

namespace wpf_mvvm_test.EF
{
    public class UserRepo : IUserRepo
    {
        private readonly Database _context;

        public UserRepo(Database context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            var person = new User()
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
            };
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
