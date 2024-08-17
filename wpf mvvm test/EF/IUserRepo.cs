using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_test.Models;

namespace wpf_mvvm_test.EF
{
    public interface IUserRepo
    {
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
