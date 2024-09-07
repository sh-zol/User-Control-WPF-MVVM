using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_mvvm_test.Intefaces
{
    public interface ITokenGenerator
    {
        Task StartGenerating();
        void Generating();
        void StopGenerating();
    }
}
