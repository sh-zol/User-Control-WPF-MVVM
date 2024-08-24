using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_mvvm_test.Interfaces
{
    public interface ITokenGenerator
    {
        void StartGenerating();
        void StopGenerating();
        bool TryGetToken(out string value);
    }
}
