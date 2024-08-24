using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_test.Interfaces;

namespace wpf_mvvm_test.TokenService
{
    public class ConfigReader : IConfigReader
    {
        public int TokenGeneratorInt()
        {
            string intervalStr = ConfigurationManager.AppSettings["TokensPerSecond"];
            if(int.TryParse(intervalStr, out int interval))
            {
                return interval;
            }
            else
            {
                throw new Exception("problem in app.config");
            }
        }
    }
}
