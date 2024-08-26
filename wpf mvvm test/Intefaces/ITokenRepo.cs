using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_test.Models;

namespace wpf_mvvm_test.Intefaces
{
    public interface ITokenRepo
    {
        Token GetToken();
        void DecreaseToken();
    }
}
