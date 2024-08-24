using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_test.Models;

namespace wpf_mvvm_test.Interfaces
{
    public interface IUserService
    {
        void Create(User user);
        void Delete(int id);
        void Update(User user);
        List<User> GetAll();
    }
}
