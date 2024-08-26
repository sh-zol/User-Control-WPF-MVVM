using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_test.Interfaces;
using wpf_mvvm_test.Models;

namespace wpf_mvvm_test.EF
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly ITokenGenerator _tokenGenerator;
        public UserService(IUserRepo repo, ITokenGenerator tokenGenerator)
        {
            _repo = repo;
            _tokenGenerator = tokenGenerator;
        }

        public void Create(User user)
        {
                //user.TokenValue = value;
                _repo.Create(user);
               // throw new Exception("error occured");
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public List<User> GetAll()
        {
            return _repo.GetAll();
        }

        public void Update(User user)
        {
            _repo.Update(user);
        }
    }
}
