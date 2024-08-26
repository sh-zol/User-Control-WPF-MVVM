using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_test.DB;
using wpf_mvvm_test.Intefaces;
using wpf_mvvm_test.Models;

namespace wpf_mvvm_test.EF
{
    public class TokenRepo : ITokenRepo
    {
        private readonly AppDBContext _context;

        public TokenRepo(AppDBContext context)
        {
            _context = context;
        }

        public void DecreaseToken()
        {
            var token = _context.Tokens.FirstOrDefault();
            if (token != null && token.Value>0)
            {
                token.Value--;
                _context.SaveChanges();
            }
        }

        public Token GetToken()
        {
            return _context.Tokens.FirstOrDefault();
        }
    }
}
